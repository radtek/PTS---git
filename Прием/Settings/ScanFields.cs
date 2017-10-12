using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using DevExpress.XtraEditors;

namespace Прием
{
    public partial class ScanFields : UserControl
    {
        public static ScanFields scanFields;
        List<Markers> markers = new List<Markers>();
        int i = 0;
        string TokenTags = "";

        public ScanFields()
        {
            InitializeComponent();
            scanFields = this;

            tokenEdit.Properties.TokenRemoving += Properties_TokenRemoving;
        }

        void Properties_TokenRemoving(object sender, TokenEditTokenRemovingEventArgs e)
        {
            if (!e.Token.Value.ToString().StartsWith("{"))
            {
                tokenEdit.Properties.Tokens.Remove(e.Token);
            }
        }

        public void FetchMarkersList()
        {
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
                                tokenEdit.Properties.Tokens.Add(new DevExpress.XtraEditors.TokenEditToken(dr["Caption"].ToString(), dr["Tag"].ToString()));

                                markers.Add(new Markers
                                {
                                    ID = Convert.ToInt32(dr["ID"]),
                                    Tag = dr["Tag"].ToString(),
                                    Caption = dr["Caption"].ToString(),
                                    BeforeSymbol = dr["BeforeSymbol"].ToString(),
                                    AfterSymbol = dr["AfterSymbol"].ToString(),
                                    QRFirstChar = Convert.ToBoolean(dr["QRFirstChar"]),
                                    QRToUpper = Convert.ToBoolean(dr["QRToUpper"]),
                                    QRToDative = Convert.ToBoolean(dr["QRToDative"]),
                                    TextFirstChar = Convert.ToBoolean(dr["TextFirstChar"]),
                                    TextToUpper = Convert.ToBoolean(dr["TextToUpper"]),
                                    TextToDative = Convert.ToBoolean(dr["TextToDative"]),
                                    Example = dr["Example"].ToString(),
                                    ExampleDative = dr["ExampleDative"].ToString()
                                });
                            }
                            conn.Close();

                            foreach (var item in markers)
                            {
                                item.Value = item.Example; item.ValueDative = item.ExampleDative;
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                XtraMessageBox.Show(ex.Message.ToString());
            }
        }

        public class Markers
        {
            public int ID { get; set; }
            public string Tag { get; set; }
            public string Caption { get; set; }
            public string BeforeSymbol { get; set; }
            public string AfterSymbol { get; set; }
            public bool QRFirstChar { get; set; }
            public bool QRToUpper { get; set; }
            public bool QRToDative { get; set; }
            public bool TextFirstChar { get; set; }
            public bool TextToUpper { get; set; }
            public bool TextToDative { get; set; }
            public string Example { get; set; }
            public string ExampleDative { get; set; }

            public string Value { get; set; }
            public string ValueDative { get; set; }

            public string TextValue
            {
                get
                {
                    if (Value != string.Empty && ValueDative != string.Empty)
                    {
                        if (TextToDative == true)
                        {
                            if (TextFirstChar == true)
                            {
                                if (TextToUpper == true)
                                    return BeforeSymbol + ToUpper(ValueDative).Substring(0, 1) + AfterSymbol;
                                else
                                    return BeforeSymbol + ValueDative.Substring(0, 1) + AfterSymbol;
                            }
                            else
                            {
                                if (TextToUpper == true)
                                    return BeforeSymbol + ToUpper(ValueDative) + AfterSymbol;
                                else
                                    return BeforeSymbol + ValueDative + AfterSymbol;
                            }
                        }
                        else
                        {
                            if (TextFirstChar == true)
                            {
                                if (TextToUpper == true)
                                    return BeforeSymbol + ToUpper(Value).Substring(0, 1) + AfterSymbol;
                                else
                                    return BeforeSymbol + Value.Substring(0, 1) + AfterSymbol;
                            }
                            else
                            {
                                if (TextToUpper == true)
                                    return BeforeSymbol + ToUpper(Value) + AfterSymbol;
                                else
                                    return BeforeSymbol + Value + AfterSymbol;
                            }
                        }
                    }
                    else
                    {
                        return string.Empty;
                    }
                }
            }
            public string QRValue
            {
                get
                {
                    if (QRToDative == true)
                    {
                        if (QRFirstChar == true)
                        {
                            if (QRToUpper == true)
                                return ToUpper(ValueDative).Substring(0, 1);
                            else
                                return ValueDative.Substring(0, 1);
                        }
                        else
                        {
                            if (QRToUpper == true)
                                return ToUpper(ValueDative);
                            else
                                return ValueDative;
                        }
                    }
                    else
                    {
                        if (QRFirstChar == true)
                        {
                            if (QRToUpper == true)
                                return ToUpper(Value).Substring(0, 1);
                            else
                                return Value.Substring(0, 1);
                        }
                        else
                        {
                            if (QRToUpper == true)
                                return ToUpper(Value);
                            else
                                return Value;
                        }
                    }
                }
            }
        }

        public static string ToUpper(string input)
        {
            if (String.IsNullOrEmpty(input))
            {
                return string.Empty;
            }

            if (input.Length > 1)
            {
                return input.First().ToString().ToUpper() + input.Substring(1);
            }
            else
            {
                return input.First().ToString().ToUpper();
            }
        }

        public void FetchData()
        {
            gridControl.DataSource = null;

            try
            {
                using (var conn = new SqlConnection(MainForm.mainForm.ConnectionPTS))
                {
                    conn.Open();
                    using (var comm = conn.CreateCommand())
                    {
                        comm.CommandText = "SELECT * FROM ScanFields";
                        using (var da = new SqlDataAdapter(comm))
                        {
                            var dt = new DataTable();
                            da.Fill(dt);
                            da.Dispose();
                            gridControl.DataSource = dt;
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                XtraMessageBox.Show(ex.Message.ToString());
            }
        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            tokenEdit.Properties.Tokens.Add(new DevExpress.XtraEditors.TokenEditToken(".", i));
            tokenEdit.SelectItem(i);
            i++;
        }

        private void btnComma_Click(object sender, EventArgs e)
        {
            tokenEdit.Properties.Tokens.Add(new DevExpress.XtraEditors.TokenEditToken(",", i));
            tokenEdit.SelectItem(i);
            i++;
        }

        private void btnSemicolon_Click(object sender, EventArgs e)
        {
            tokenEdit.Properties.Tokens.Add(new DevExpress.XtraEditors.TokenEditToken(";", i));
            tokenEdit.SelectItem(i);
            i++;
        }

        private void btnSpace_Click(object sender, EventArgs e)
        {
            tokenEdit.Properties.Tokens.Add(new DevExpress.XtraEditors.TokenEditToken(" ", i));
            tokenEdit.SelectItem(i);
            i++;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (tbInput.Text != string.Empty)
            {
                tokenEdit.Properties.Tokens.Add(new DevExpress.XtraEditors.TokenEditToken(tbInput.Text, i));
                tokenEdit.SelectItem(i);
                i++;

                tbInput.Text = string.Empty;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (tbCaption.Text.Trim() != string.Empty)
            {
                TokenTags = "";
                string s = "";
                foreach (var item in tokenEdit.SelectedItems)
                {
                    if (tokenEdit.Properties.Tokens.First(x => x.Description == item.ToString()).Value.ToString().StartsWith("{"))
                    {
                        s += tokenEdit.Properties.Tokens.First(x => x.Description == item.ToString()).Value.ToString();
                        TokenTags += tokenEdit.Properties.Tokens.First(x => x.Description == item.ToString()).Value.ToString().Replace("{", "").Replace("}", "") + "|";
                    }
                    else
                    {
                        s += "{" + item + "}";
                    }
                }

                try
                {
                    using (var conn = new SqlConnection(MainForm.mainForm.ConnectionPTS))
                    {
                        conn.Open();
                        using (var comm = conn.CreateCommand())
                        {
                            comm.CommandText = "INSERT INTO ScanFields (Caption, Value, Tags) VALUES (@Caption, @Value, @Tags)";
                            comm.Parameters.AddWithValue("@Caption", tbCaption.Text);
                            comm.Parameters.AddWithValue("@Value", s);
                            comm.Parameters.AddWithValue("@Tags", TokenTags);
                            comm.ExecuteNonQuery();
                            conn.Close();
                        }
                    }
                }
                catch (SqlException ex)
                {
                    XtraMessageBox.Show(ex.Message.ToString());
                }

                tokenEdit.EditValue = null;
                FetchData();
            }
        }

        private void tokenEdit_SelectedItemsChanged(object sender, ListChangedEventArgs e)
        {
            TokenTags = string.Empty;
            labelPreview.Text = string.Empty;
            string s = "";

            foreach (var item in tokenEdit.SelectedItems)
            {
                if (tokenEdit.Properties.Tokens.First(x => x.Description == item.ToString()).Value.ToString().StartsWith("{"))
                {
                    s += tokenEdit.Properties.Tokens.First(x => x.Description == item.ToString()).Value.ToString();
                    TokenTags += tokenEdit.Properties.Tokens.First(x => x.Description == item.ToString()).Value.ToString().Replace("{", "").Replace("}", "") + "|";
                }
                else
                {
                    s += "{" + item + "}";
                }
            }

            string[] split = s.Replace("{", "").Split(new string[] { "}" }, StringSplitOptions.None);
            foreach (var i in split)
            {
                if (i != "")
                {
                    if (CheckString(i) == "error")
                        labelPreview.Text += "Ошибка";
                    else if (CheckString(i) == "DigCount")
                        labelPreview.Text += markers[Convert.ToInt32(i)].QRValue;
                    else
                        labelPreview.Text += i;
                }
            }
        }

        private string CheckString(string Value)
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

        public class Total
        {
            public string Caption { get; set; }
            public int Value { get; set; }
        }

        private void tokenEdit_SizeChanged(object sender, EventArgs e)
        {

        }
    }
}
