using CoreScanner;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace Прием
{
    public partial class ScanNominalTask : DevExpress.XtraEditors.XtraForm
    {
        #region "Declaration"
        public int JobID = 0;
        public int JobBlankID = 0;

        List<Markers> markers = new List<Markers>();

        CCoreScannerClass cCoreScannerClass;
        int opcode = 1001; // Method for Subscribe events
        string outXML; // XML Output
        string inXML;
        int status; // Extended API return code

        List<int> scan = new List<int>();
        List<string> list = new List<string>();
        List<string> list2 = new List<string>();
        bool fl = true;
        bool scan_task = false;

        string T37 = "";
        string T38 = "";
        string T42 = "";
        string T75 = "";
        string T76 = "";
        string T84 = "";
        string R = "";
        string T = "";
        string Y = "";
        string U = "";
        string I = "";
        string O = "";
        string P = "";
        string A = "";
        string S = "";

        string ProlongationCodePtp = "";
        string ProlongationCodeSms = "";
        string ProlongationCodeSk = "";

        public string SavePath = @"C:\xml\";
        #endregion
        #region "Developer"
        private void BarcodeEvent(string scanData)
        {
            string tmpScanData = scanData;

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(tmpScanData);

            string strData = String.Empty;
            string[] numbers = xmlDoc.DocumentElement.GetElementsByTagName("datalabel").Item(0).InnerText.Split(' ');

            foreach (string number in numbers)
            {
                if (String.IsNullOrEmpty(number))
                {
                    break;
                }

                strData += ((char)Convert.ToInt32(number, 16)).ToString();
            }

            string scan_name = GetScanName(Base64Decode(strData));
            if (scan_name == "Reference")
            {
                if (scan_task == false)
                {
                    MessageBox.Show("Справку необходимо сканировать после задания!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    GetReferenceText(Base64Decode(strData));
                }
            }
            else if (scan_name == "Task")
            {
                GetTaskText(Base64Decode(strData));
            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = true;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                foreach (var file in dialog.FileNames)
                {
                    BarcodeEvent(File.ReadAllText(file, Encoding.UTF8));
                }
            }
        }
        #endregion

        public ScanNominalTask(string TaskNo, string Object)
        {
            InitializeComponent();
            labelTask.Text = string.Format("Изменение условного задания № {0} - {1}", TaskNo, Object);
        }

        private void ScanNominalTask_Load(object sender, EventArgs e)
        {
            FetchSavePath();

            try
            {
                using (var conn = new SqlConnection(MainForm.mainForm.ConnectionPTS))
                {
                    conn.Open();
                    using (var comm = conn.CreateCommand())
                    {
                        comm.CommandText = "SELECT * FROM ScanFields";
                        using (var dr = comm.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                markers.Add(new Markers { Caption = dr["Caption"].ToString(), Value = dr["Value"].ToString(), Tags = dr["Tags"].ToString() });
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                XtraMessageBox.Show(ex.Message.ToString());
            }

            try
            {
                cCoreScannerClass = new CCoreScannerClass();
            }
            catch (Exception)
            {
                Thread.Sleep(1000);
                cCoreScannerClass = new CCoreScannerClass();
            }

            short[] scannerTypes = new short[1];//Scanner Types you are interested in
            scannerTypes[0] = 1; // 1 for all scanner types
            short numberOfScannerTypes = 1; // Size of the scannerTypes array

            cCoreScannerClass.Open(0, scannerTypes, numberOfScannerTypes, out status);
            cCoreScannerClass.BarcodeEvent += new CoreScanner._ICoreScannerEvents_BarcodeEventEventHandler(OnBarcodeEvent);

            inXML = "<inArgs>" +
            "<cmdArgs>" +
            "<arg-int>1</arg-int>" + // Number of events you want to subscribe
            "<arg-int>1</arg-int>" + // Comma separated event IDs
            "</cmdArgs>" +
            "</inArgs>";

            timer.Start();
        }

        void OnBarcodeEvent(short eventType, ref string scanData)
        {
            string tmpScanData = scanData;

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(tmpScanData);

            string strData = String.Empty;
            string[] numbers = xmlDoc.DocumentElement.GetElementsByTagName("datalabel").Item(0).InnerText.Split(' ');

            foreach (string number in numbers)
            {
                if (String.IsNullOrEmpty(number))
                {
                    break;
                }

                strData += ((char)Convert.ToInt32(number, 16)).ToString();
            }

            string scan_name = GetScanName(Base64Decode(strData));
            if (scan_name == "Reference")
            {
                if (scan_task == false)
                {
                    MessageBox.Show("Справку необходимо сканировать после задания!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    GetReferenceText(Base64Decode(strData));
                }
            }
            else if (scan_name == "Task")
            {
                GetTaskText(Base64Decode(strData));
            }
        }

        private void GetTaskText(string barcode)
        {
            List<string> tmp = new List<string>();
            foreach (var s in barcode.Split(new string[] { Environment.NewLine }, StringSplitOptions.None))
            {
                tmp.Add(s);
            }

            string[] str = tmp[0].Split(new string[] { " " }, StringSplitOptions.None);
            int index = Convert.ToInt32(str[0]);
            int count = Convert.ToInt32(str[1]);
            tbBlankNo.Text = tmp[1].Split(new string[] { " " }, StringSplitOptions.None)[0];

            labelStat.Text = string.Format("QR код {0} из {1}", index, count);

            if (fl)
            {
                for (int i = 0; i < count; i++)
                {
                    list.Add("");
                }
                fl = false;
            }

            scan.Add(index);
            tmp.RemoveRange(0, 2);

            list[index - 1] = string.Join("\r\n", tmp.ToArray());

            if (index == count)
            {
                string res = "";
                foreach (string s in list)
                {
                    if (s != null)
                    {
                        res += s;
                    }
                }

                T37 = res.Split(new string[] { "#T37#" }, StringSplitOptions.None)[1];
                T38 = res.Split(new string[] { "#T38#" }, StringSplitOptions.None)[1];
                T42 = res.Split(new string[] { "#T42#" }, StringSplitOptions.None)[1];
                T75 = res.Split(new string[] { "#T75#" }, StringSplitOptions.None)[1];
                T76 = res.Split(new string[] { "#T76#" }, StringSplitOptions.None)[1];
                T84 = res.Split(new string[] { "#T84#" }, StringSplitOptions.None)[1];
                res = res.Replace("#T37#" + T37 + "#T37#", "")
                         .Replace("#T38#" + T38 + "#T38#", "")
                         .Replace("#T42#" + T42 + "#T42#", "")
                         .Replace("#T75#" + T75 + "#T75#", "")
                         .Replace("#T76#" + T76 + "#T76#", "")
                         .Replace("#T84#" + T84 + "#T84#", "");

                list = new List<string>(res.Split(new string[] { "\r\n" }, StringSplitOptions.None));

                if (MessageBox.Show("Данные получены.\r\nСканировать коды справки?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    scan = new List<int>();
                    fl = true;
                    scan_task = true;
                }
                else
                {
                    List<Records> records = new List<Records>();
                    try
                    {
                        using (var conn = new SqlConnection(MainForm.mainForm.ConnectionPTS))
                        {
                            conn.Open();
                            using (var comm = conn.CreateCommand())
                            {
                                comm.CommandText = "SELECT Tag, Caption FROM Markers";
                                using (var dr = comm.ExecuteReader())
                                {
                                    while (dr.Read())
                                    {
                                        records.Add(new Records
                                        {
                                            FieldName = dr["Caption"].ToString(),
                                            FieldValue = list[Convert.ToInt32(dr["Tag"].ToString().Replace("{", "").Replace("}", ""))]
                                        });
                                    }
                                }
                            }
                        }
                    }
                    catch (SqlException ex)
                    {
                        XtraMessageBox.Show(ex.Message.ToString());
                    }
                    gridControlTask.DataSource = records;

                    btnSave.Enabled = true;
                }
            }
        }

        private void GetReferenceText(string barcode)
        {
            List<string> tmp = new List<string>();
            foreach (var s in barcode.Split(new string[] { Environment.NewLine }, StringSplitOptions.None))
            {
                tmp.Add(s);
            }

            string[] str = tmp[0].Split(new string[] { " " }, StringSplitOptions.None);
            int index = Convert.ToInt32(str[0]);
            int count = Convert.ToInt32(str[1]);

            labelStat.Text = string.Format("QR код {0} из {1}", index, count);

            if (fl)
            {
                for (int i = 0; i < count; i++)
                {
                    list2.Add("");
                }
                fl = false;
            }

            scan.Add(index);
            tmp.RemoveRange(0, 2);

            list2[index - 1] = string.Join("\r\n", tmp.ToArray());

            if (index == count)
            {
                string res = "";
                foreach (string s in list2)
                {
                    if (s != null)
                    {
                        res += s;
                    }
                }

                R = res.Split(new string[] { "#R#" }, StringSplitOptions.None)[1];
                T = res.Split(new string[] { "#T#" }, StringSplitOptions.None)[1];
                Y = res.Split(new string[] { "#Y#" }, StringSplitOptions.None)[1];
                U = res.Split(new string[] { "#U#" }, StringSplitOptions.None)[1];
                I = res.Split(new string[] { "#I#" }, StringSplitOptions.None)[1];
                O = res.Split(new string[] { "#O#" }, StringSplitOptions.None)[1];
                P = res.Split(new string[] { "#P#" }, StringSplitOptions.None)[1];
                A = res.Split(new string[] { "#A#" }, StringSplitOptions.None)[1];
                S = res.Split(new string[] { "#S#" }, StringSplitOptions.None)[1];
                res = res.Replace("#R#" + R + "#R#", "").Replace("#T#" + T + "#T#", "").Replace("#Y#" + Y + "#Y#", "").Replace("#U#" + U + "#U#", "").Replace("#I#" + I + "#I#", "").Replace("#O#" + O + "#O#", "").Replace("#P#" + P + "#P#", "").Replace("#A#" + A + "#A#", "").Replace("#S#" + S + "#S#", "");
                list2 = new List<string>(res.Split(new string[] { "\r\n" }, StringSplitOptions.None));

                MessageBox.Show("Все данные получены!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);

                List<Records> records = new List<Records>();
                try
                {
                    using (var conn = new SqlConnection(MainForm.mainForm.ConnectionPTS))
                    {
                        conn.Open();
                        using (var comm = conn.CreateCommand())
                        {
                            comm.CommandText = "SELECT Tag, Caption FROM Markers";
                            using (var dr = comm.ExecuteReader())
                            {
                                while (dr.Read())
                                {
                                    records.Add(new Records
                                    {
                                        FieldName = dr["Caption"].ToString(),
                                        FieldValue = list[Convert.ToInt32(dr["Tag"].ToString().Replace("{", "").Replace("}", ""))]
                                    });
                                }
                            }
                        }
                    }
                }
                catch (SqlException ex)
                {
                    XtraMessageBox.Show(ex.Message.ToString());
                }
                gridControlTask.DataSource = records;
                tbReference.Text = R + " " + T + " " + Y + " " + U + " " + I + " " + O + " " + P + " " + A + " " + S;

                btnSave.Enabled = true;
            }
        }

        private string GetScanName(string text)
        {
            return text.Split(new string[] { Environment.NewLine }, StringSplitOptions.None)[1].Split(new string[] { " " }, StringSplitOptions.None)[1];
        }

        public string Base64Decode(string base64EncodedData)
        {
            return System.Text.Encoding.UTF8.GetString(System.Convert.FromBase64String(base64EncodedData));
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            cCoreScannerClass.ExecCommand(opcode, ref inXML, out outXML, out status);
        }

        private void FetchSavePath()
        {
            if (!Directory.Exists(@"C:\xml"))
                Directory.CreateDirectory(@"C:\xml");
        }

        [XmlRoot(ElementName = "Value")]
        public class Value
        {
            [XmlElement(ElementName = "FieldName")]
            public string FieldName { get; set; }
            [XmlElement(ElementName = "FieldValue")]
            public string FieldValue { get; set; }
        }

        [XmlRoot(ElementName = "Values")]
        public class Values
        {
            [XmlElement(ElementName = "Value")]
            public List<Value> Value { get; set; }
        }

        [XmlRoot(ElementName = "Document")]
        public class Document
        {
            [XmlElement(ElementName = "TemplateId")]
            public string TemplateId { get; set; }
            [XmlElement(ElementName = "TemplateVersionId")]
            public string TemplateVersionId { get; set; }
            [XmlElement(ElementName = "TemplateVersionTime")]
            public string TemplateVersionTime { get; set; }
            [XmlElement(ElementName = "Values")]
            public Values Values { get; set; }
        }

        [XmlRoot(ElementName = "ExportDocument")]
        public class ExportDocument
        {
            [XmlElement(ElementName = "Document")]
            public Document Document { get; set; }
            [XmlElement(ElementName = "DocumenType")]
            public string DocumenType { get; set; }
            [XmlElement(ElementName = "TemplateName")]
            public string TemplateName { get; set; }
        }

        class Markers
        {
            public string Caption { get; set; }
            public string Value { get; set; }
            public string Tags { get; set; }
        }

        class Records
        {
            public string FieldName { get; set; }
            public string FieldValue { get; set; }
        }
    }
}
