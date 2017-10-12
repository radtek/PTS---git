using CoreScanner;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.DXErrorProvider;

namespace Прием
{
    public partial class ScanControl : DevExpress.XtraEditors.XtraUserControl
    {
        #region "Declaration"
        public static ScanControl scanControl;
        List<TaskControls> controls = new List<TaskControls>();
        string ConnectionSQLString = "Data Source=localhost;Initial Catalog=ASSA;User ID=sa;Password=sa;MultipleActiveResultSets=True;";
        string SmsEventName = "СИТКССМС";
        string SkEventName = "СИТКС(СК)";
        #endregion
        #region "Scan"
        List<ScanFields> scanFields = new List<ScanFields>();
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
        #region "Developer tools"
        //int i = 0;
        //File.WriteAllText(Application.StartupPath + "\\" + i.ToString() + ".txt", scanData, Encoding.UTF8);
        //i++;
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
                    XtraMessageBox.Show("Справку необходимо сканировать после задания!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void btnOpenQR_Click(object sender, EventArgs e)
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

        public ScanControl()
        {
            InitializeComponent();
            scanControl = this;

            splitContainer2.Collapsed = true;
            splitContainer1.Collapsed = true;

            DXErrorProvider.GetErrorIcon += DXErrorProvider_GetErrorIcon;
        }

        #region "Validate Fields"
        void DXErrorProvider_GetErrorIcon(GetErrorIconEventArgs e)
        {
            if (e.ErrorType == ErrorType.User1)
                e.ErrorIcon = Properties.Resources.icon_error;
        }

        private void UpdateForValidate()
        {
            controls.Clear();
            controls.Add(new TaskControls { control = tbBlankNo, Flag = false });
            controls.Add(new TaskControls { control = tbTaskNo, Flag = false });
            controls.Add(new TaskControls { control = tbCommissionNo, Flag = false });
            controls.Add(new TaskControls { control = cbTaskYear, Flag = false });
            controls.Add(new TaskControls { control = cbExecutor, Flag = false });
            controls.Add(new TaskControls { control = cbWorkGroup, Flag = false });
            controls.Add(new TaskControls { control = cbTaskCode, Flag = false });
        }

        public bool ValidateTaskFields(List<TaskControls> controls)
        {
            foreach (var item in controls)
            {
                if (item.control.Enabled == true)
                {
                    if (item.control.Text == string.Empty || item.control.Text.Length == 0)
                    {
                        item.Flag = false;
                        dxErrorProvider.SetError(item.control, "Необходимо заполнить это поле", ErrorType.User1);
                    }
                    else
                    {
                        item.Flag = true;
                        dxErrorProvider.SetError(item.control, "");
                    }
                }
                else
                {
                    item.Flag = true;
                    dxErrorProvider.SetError(item.control, "");
                }
            }

            if (controls.Where(x => x.Flag == false).Count() == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public class TaskControls
        {
            public BaseEdit control { get; set; }
            public bool Flag { get; set; }
        }
        #endregion
        #region "Navigation"
        private void btnSave_Click(object sender, EventArgs e)
        {
            File.WriteAllText(SavePath + tbBlankNo.Text + ".xml", InsertXml(tbBlankNo.Text, tbTaskNo.Text, list[31], ProlongationCodePtp), Encoding.UTF8);
            if (chbSms.Checked)// && tbProlongationSMSno.Text != string.Empty)
                File.WriteAllText(SavePath + GetNewTaskNo(tbBlankNo.Text, 1) + ".xml", InsertXml(GetNewTaskNo(tbBlankNo.Text, 1), (Convert.ToInt32(tbTaskNo.Text) + 1).ToString(), "СИТКССМС", ProlongationCodeSms), Encoding.UTF8);
            if (chbSk.Checked)// && tbProlongationSKno.Text != string.Empty)
                File.WriteAllText(SavePath + GetNewTaskNo(tbBlankNo.Text, 2) + ".xml", InsertXml(GetNewTaskNo(tbBlankNo.Text, 2), (Convert.ToInt32(tbTaskNo.Text) + 2).ToString(), "СИТКС(СК)", ProlongationCodeSms), Encoding.UTF8);
            Reset();
        }

        private string GetNewTaskNo(string TaskNo, int Dig)
        {
            string[] s = TaskNo.Split(new string[] { "-" }, StringSplitOptions.None);
            string Letter = s[0];
            int Number = Convert.ToInt32(s[1]);
            var s1 = string.Concat(Enumerable.Repeat("0", 5 - Number.ToString().Length));

            return string.Format("{0}-{1}{2}", Letter, s1, Number + Dig);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Reset();
        }
        #endregion
        #region "Scan"
        public void BeginScan()
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
                                scanFields.Add(new ScanFields { Caption = dr["Caption"].ToString(), Value = dr["Value"].ToString(), Tags = dr["Tags"].ToString() });
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
                using (var conn = new SqlConnection(MainForm.mainForm.ConnectionPTS))
                {
                    conn.Open();
                    using (var comm = conn.CreateCommand())
                    {
                        comm.CommandText = "SELECT * FROM Markers";
                        using (var dr = comm.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                markers.Add(new Markers { Tag = dr["Tag"].ToString(), BeforeSymbol = dr["BeforeSymbol"].ToString(), AfterSymbol = dr["AfterSymbol"].ToString() });
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
                    XtraMessageBox.Show("Справку необходимо сканировать после задания!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            ScanControl.scanControl.tbBlankNo.Text = tmp[1].Split(new string[] { " " }, StringSplitOptions.None)[0];

            ScanControl.scanControl.labelStat.Text = string.Format("QR код {0} из {1}", index, count);

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

                if (XtraMessageBox.Show("Данные получены.\r\nСканировать коды справки?", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    scan = new List<int>();
                    fl = true;
                    scan_task = true;
                }
                else
                {
                    splitContainer1.Collapsed = false;

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

            ScanControl.scanControl.labelStat.Text = string.Format("QR код {0} из {1}", index, count);

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

                XtraMessageBox.Show("Все данные получены!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);

                splitContainer2.Collapsed = false;
                splitContainer1.Collapsed = false;

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

        public string InsertXml(string BlankNo, string TaskNo, string EventType, string ProlonagtionCode)
        {
            ExportDocument doc = new ExportDocument();
            doc.Document = new Document();
            doc.Document.TemplateId = "АПК «Задание»";
            doc.Document.TemplateVersionId = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
            doc.Document.TemplateVersionTime = DateTime.Now.Year.ToString();
            doc.Document.Values = new Values();
            doc.Document.Values.Value = new List<Value>();

            Value v = new Value();

            v = new Value();
            v.FieldName = "Задание: Бланк №"; v.FieldValue = BlankNo;
            doc.Document.Values.Value.Add(v);

            v = new Value();
            v.FieldName = "Задание: Задание №"; v.FieldValue = TaskNo;
            doc.Document.Values.Value.Add(v);

            v = new Value();
            v.FieldName = "Задание: Поручение №"; v.FieldValue = tbCommissionNo.Text;
            doc.Document.Values.Value.Add(v);

            v = new Value();
            v.FieldName = "Задание: Год задания"; v.FieldValue = cbTaskYear.Text;
            doc.Document.Values.Value.Add(v);

            v = new Value();
            v.FieldName = "Задание: Исполнитель"; v.FieldValue = cbExecutor.Text;
            doc.Document.Values.Value.Add(v);

            v = new Value();
            v.FieldName = "Задание: Группа контроля"; v.FieldValue = cbWorkGroup.Text;
            doc.Document.Values.Value.Add(v);

            v = new Value();
            v.FieldName = "Задание: Код мероприятия"; v.FieldValue = cbTaskCode.Text;
            doc.Document.Values.Value.Add(v);

            v = new Value();
            v.FieldName = "Мероприятие: Тип ОТМ"; v.FieldValue = EventType;
            doc.Document.Values.Value.Add(v);

            //foreach (var item in markers)
            //{
            //    string s = item.Tags;
            //    string[] split = s.Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries);
            //    int decision = 0;
            //    foreach (var tag in split)
            //    {
            //        if (list[Convert.ToInt32(tag.Replace("{", "").Replace("}", ""))] != string.Empty)
            //            decision++;
            //    }
            //    if (decision > 0)
            //    {
            //        string j = "";
            //        string[] splitValue = item.Value.Replace("{", "").Split(new string[] { "}" }, StringSplitOptions.RemoveEmptyEntries);
            //        foreach (var p in splitValue)
            //        {
            //            if (p != "")
            //            {
            //                if (EjectData(p) == "error")
            //                    j += "Ошибка";
            //                else if (EjectData(p) == "DigCount")
            //                    j += list[Convert.ToInt32(p)];
            //                else
            //                    j += p;
            //            }
            //        }

            //        v = new Value();
            //        v.FieldName = item.Caption; v.FieldValue = j;
            //        doc.Document.Values.Value.Add(v);
            //    }
            //    else
            //    {
            //        v = new Value();
            //        v.FieldName = item.Caption; v.FieldValue = "";
            //        doc.Document.Values.Value.Add(v);
            //    }
            //}

            foreach (var item in scanFields)
            {
                string s = item.Tags;
                string[] split = s.Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries);
                string complete = string.Empty;

                foreach (var tag in split)
                {
                    if (list[Convert.ToInt32(tag.Replace("{", "").Replace("}", ""))] != string.Empty)
                    {
                        complete += markers.Find(x => x.Tag == tag).BeforeSymbol + list[Convert.ToInt32(tag.Replace("{", "").Replace("}", ""))] + markers.Find(x => x.Tag == tag).AfterSymbol;
                    }
                }

                if (complete != string.Empty)
                {
                    v = new Value();
                    v.FieldName = item.Caption; v.FieldValue = complete;
                    doc.Document.Values.Value.Add(v);
                }
                else
                {
                    v = new Value();
                    v.FieldName = item.Caption; v.FieldValue = "";
                    doc.Document.Values.Value.Add(v);
                }
            }

            if (chbProlongation.Checked)
            {
                v = new Value();
                v.FieldName = "Продление для задания"; v.FieldValue = ProlonagtionCode;
                doc.Document.Values.Value.Add(v);
            }
            else
            {
                v = new Value();
                v.FieldName = "Продление для задания"; v.FieldValue = "";
                doc.Document.Values.Value.Add(v);
            }

            if (list2.Count > 0)
            {
                v = new Value();
                v.FieldName = "Задание: Справка об объекте (справка-меморандум)";
                v.FieldValue = R + " " + T + " " + Y + " " + U + " " + I + " " + O + " " + P + " " + A + " " + S;
                doc.Document.Values.Value.Add(v);
            }
            else
            {
                v = new Value();
                v.FieldName = "Задание: Справка об объекте (справка-меморандум)";
                v.FieldValue = "";
                doc.Document.Values.Value.Add(v);
            }

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportDocument));
            StringWriter stringWriter = new StringWriter();
            xmlSerializer.Serialize(stringWriter, doc);

            return stringWriter.ToString();
        }


        private string EjectData(string Value)
        {
            if (Value != "|")
            {
                int DigCount = 0;
                int ChrCount = 0;
                int PntCount = 0;
                int SprCount = 0;
                int SpcCount = 0;

                int j = Value.Length;
                foreach (char ch in Value)
                {
                    if (char.IsDigit(ch))
                        DigCount++;
                    else if (char.IsLetter(ch))
                        ChrCount++;
                    else if (char.IsPunctuation(ch))
                        PntCount++;
                    else if (char.IsSeparator(ch))
                        SprCount++;
                    else if (char.IsWhiteSpace(ch))
                        SpcCount++;
                }

                var total = new List<Total>();
                total.Add(new Total { Caption = "DigCount", Value = DigCount });
                total.Add(new Total { Caption = "ChrCount", Value = ChrCount });
                total.Add(new Total { Caption = "PntCount", Value = PntCount });
                total.Add(new Total { Caption = "SprCount", Value = SprCount });
                total.Add(new Total { Caption = "SpcCount", Value = SpcCount });

                var max = total.Max(x => x.Value);
                var maxCaption = total.Find(y => y.Value == max).Caption;

                if (max + 4 >= j)
                    return maxCaption;
                else
                    return "error";
            }
            else
            {
                return "ChrCount";
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

        public void Reset()
        {
            ScanControl.scanControl.labelStat.Text = "QR код 0 из 0";
            scan = new List<int>();
            ScanControl.scanControl.btnSave.Enabled = false;
            fl = true;
            scan_task = false;
            list = new List<string>();
            list2 = new List<string>();

            tbBlankNo.Text = string.Empty;
            tbTaskNo.Text = string.Empty;
            tbCommissionNo.Text = string.Empty;
            cbTaskYear.Text = string.Empty;
            cbExecutor.Text = string.Empty;
            cbWorkGroup.Text = string.Empty;
            cbTaskCode.Text = string.Empty;
            cbProlongationYear.Text = string.Empty;
            tbProlongationNo.Text = string.Empty;
            tbProlongationSMSno.Text = string.Empty;
            tbProlongationSKno.Text = string.Empty;
            tbProlongationPhone.Text = string.Empty;
            tbProlongationInitiator.Text = string.Empty;
            dtProlongationDt.Text = string.Empty;

            splitContainer2.Collapsed = true;
            splitContainer1.Collapsed = true;
            gridControlTask.DataSource = null;
            tbReference.Text = string.Empty;
        }
        
        private void chbProlongation_CheckedChanged(object sender, EventArgs e)
        {
            UpdateForValidate();
            if (ValidateTaskFields(controls))
            {
                if (chbProlongation.Checked)
                    SwitchProlongation(true);
                else
                    SwitchProlongation(false);
            }
            else
            {
                chbProlongation.CheckState = CheckState.Unchecked;
                XtraMessageBox.Show("Заполните все необходимые поля!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SwitchProlongation(bool Enable)
        {
            if (Enable)
            {
                tbProlongationNo.Enabled = true;
                cbProlongationYear.Enabled = true;
                dtProlongationDt.Enabled = true;
                tbProlongationSMSno.Enabled = true;
                tbProlongationSKno.Enabled = true;
                tbProlongationPhone.Enabled = true;
                tbProlongationStopDt.Enabled = true;
                tbProlongationInitiator.Enabled = true;
                labelProlongationNo.Enabled = true;
                labelProlongationYear.Enabled = true;
                labelProlongationDt.Enabled = true;
                labelProlongationPhone.Enabled = true;
                labelProlongationStopDt.Enabled = true;
                labelProlongationInitiator.Enabled = true;
                if (chbSms.Checked)
                {
                    labelProlongationSMS.Enabled = true;
                    tbProlongationSMSno.Enabled = true;
                }
                else
                {
                    labelProlongationSMS.Enabled = false;
                    tbProlongationSMSno.Enabled = false;
                }

                if (chbSk.Checked)
                {
                    labelProlongationSK.Enabled = true;
                    tbProlongationSKno.Enabled = true;
                }
                else
                {
                    labelProlongationSK.Enabled = false;
                    tbProlongationSKno.Enabled = false;
                }
            }
            else
            {
                tbProlongationNo.Enabled = false;
                cbProlongationYear.Enabled = false;
                dtProlongationDt.Enabled = false;
                tbProlongationSMSno.Enabled = false;
                tbProlongationSKno.Enabled = false;
                tbProlongationPhone.Enabled = false;
                tbProlongationStopDt.Enabled = false;
                tbProlongationInitiator.Enabled = false;
                labelProlongationNo.Enabled = false;
                labelProlongationYear.Enabled = false;
                labelProlongationDt.Enabled = false;
                labelProlongationSMS.Enabled = false;
                labelProlongationSK.Enabled = false;
                labelProlongationPhone.Enabled = false;
                labelProlongationStopDt.Enabled = false;
                labelProlongationInitiator.Enabled = false;

                tbProlongationNo.Text = string.Empty;
                cbProlongationYear.Text = string.Empty;
                dtProlongationDt.Text = string.Empty;
                tbProlongationSMSno.Text = string.Empty;
                tbProlongationSKno.Text = string.Empty;
                tbProlongationPhone.Text = string.Empty;
                tbProlongationStopDt.Text = string.Empty;
                tbProlongationInitiator.Text = string.Empty;
                ProlongationCodePtp = string.Empty;
                ProlongationCodeSms = string.Empty;
                ProlongationCodeSk = string.Empty;
            }
        }

        private void tbProlongationNo_EditValueChanged(object sender, EventArgs e)
        {
            if (tbProlongationNo.Text != string.Empty)
            {
                if (cbProlongationYear.Text != string.Empty)
                {
                    Summary();
                    FetchProlongationData();
                }
                else
                {
                    XtraMessageBox.Show("Выберите год шифра продления!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cbProlongationYear.ShowPopup();
                }
            }
            else
            {
                tbProlongationSMSno.Text = string.Empty;
                tbProlongationSKno.Text = string.Empty;
                tbProlongationPhone.Text = string.Empty;
                tbProlongationInitiator.Text = string.Empty;
                tbProlongationStopDt.Text = string.Empty;
            }
        }

        private void Summary()
        {
            ProlongationCodePtp = string.Format("{0}-{1}-{2}-{3}", list[31], cbTaskCode.Text, tbProlongationNo.Text, cbProlongationYear.Text.Substring(2, 2));

            if (chbSms.Checked)
            {
                tbProlongationSMSno.Text = (Convert.ToInt32(tbProlongationNo.Text) + 1).ToString();
                ProlongationCodeSms = string.Format("{0}-{1}-{2}-{3}", SmsEventName, cbTaskCode.Text, tbProlongationSMSno.Text, cbProlongationYear.Text.Substring(2, 2));
            }
            if (chbSk.Checked)
            {
                tbProlongationSKno.Text = (Convert.ToInt32(tbProlongationNo.Text) + 2).ToString();
                ProlongationCodeSk = string.Format("{0}-{1}-{2}-{3}", SkEventName, cbTaskCode.Text, tbProlongationSKno.Text, cbProlongationYear.Text.Substring(2, 2));
            }
        }

        private void FetchProlongationData()
        {
            try
            {
                using (var conn = new SqlConnection(MainForm.mainForm.ConnectionASSA))
                {
                    conn.Open();
                    using (var comm = conn.CreateCommand())
                    {
                        comm.CommandText = "SELECT TOP 1 JobNo, JobYear, JobCode, JobType, DivName, ObjDescription, JobStopPlanDT FROM ASSA.dbo.JobBlank, ASSA.dbo.Job WHERE JobNo = @JobNoLoad AND JobYear = @JobYearLoad AND JobCode = @JobCodeLoad AND Job.JobID = JobBlank.JobID";
                        comm.Parameters.AddWithValue("@JobNoLoad", tbProlongationNo.Text);
                        comm.Parameters.AddWithValue("@JobYearLoad", cbProlongationYear.Text);
                        comm.Parameters.AddWithValue("@JobCodeLoad", cbTaskCode.Text);
                        using (var dr = comm.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    tbProlongationPhone.Text = dr["ObjDescription"].ToString();
                                    tbProlongationInitiator.Text = dr["DivName"].ToString();
                                    tbProlongationStopDt.Text = dr["JobStopPlanDT"].ToString();
                                }
                            }
                            else
                            {
                                tbProlongationPhone.Text = string.Empty;
                                tbProlongationInitiator.Text = string.Empty;
                                tbProlongationStopDt.Text = string.Empty;
                            }
                        }
                    }
                }
            }
            catch
            {
                var dialog = XtraMessageBox.Show("Выберите год шифра продления!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (dialog == DialogResult.OK)
                {
                    cbProlongationYear.ShowPopup();
                }
            }
        }

        private void chbSms_CheckedChanged(object sender, EventArgs e)
        {
            if (chbProlongation.Checked)
            {
                if (chbSms.Checked)
                {
                    labelProlongationSMS.Enabled = true;
                    tbProlongationSMSno.Enabled = true;
                }
                else
                {
                    labelProlongationSMS.Enabled = false;
                    tbProlongationSMSno.Enabled = false;
                }
            }
        }

        private void chbSk_CheckedChanged(object sender, EventArgs e)
        {
            if (chbProlongation.Checked)
            {
                if (chbSk.Checked)
                {
                    labelProlongationSK.Enabled = true;
                    tbProlongationSKno.Enabled = true;
                }
                else
                {
                    labelProlongationSK.Enabled = false;
                    tbProlongationSKno.Enabled = false;
                }
            }
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

        class ScanFields
        {
            public string Caption { get; set; }
            public string Value { get; set; }
            public string Tags { get; set; }
        }

        class Markers
        {
            public string Tag { get; set; }
            public string BeforeSymbol { get; set; }
            public string AfterSymbol { get; set; }
        }

        class Records
        {
            public string FieldName { get; set; }
            public string FieldValue { get; set; }
        }

        public class Total
        {
            public string Caption { get; set; }
            public int Value { get; set; }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            cCoreScannerClass.ExecCommand(opcode, ref inXML, out outXML, out status);
        }
        #endregion

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            ImportData importForm = new ImportData();
            importForm.ShowDialog();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            SetupFields setup = new SetupFields();
            setup.ShowDialog();
        }
    }
}
