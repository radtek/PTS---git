using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using DevExpress.XtraEditors;

namespace Задание
{
    public partial class MarkersControl : DevExpress.XtraEditors.XtraUserControl
    {
        public static MarkersControl markersControl;

        public MarkersControl()
        {
            InitializeComponent();
            markersControl = this;
        }

        public void LoadMarkers()
        {
            try
            {
                using (var conn = new SQLiteConnection(MainForm.mainForm.connectionTemplateData))
                {
                    conn.Open();
                    using (var comm = conn.CreateCommand())
                    {
                        comm.CommandText = "SELECT * FROM Markers";
                        using (var da = new SQLiteDataAdapter(comm))
                        {
                            var dt = new DataTable();
                            da.Fill(dt);
                            da.Dispose();
                            gridControl1.DataSource = dt;
                        }
                    }
                    conn.Close();
                }
            }
            catch (SQLiteException ex)
            {
                XtraMessageBox.Show(ex.Message.ToString());
            }
        }

        private void gridView1_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "QRFirstChar")
            {
                EditRow("QRFirstChar", (bool)e.Value);
            }
            else if (e.Column.FieldName == "QRToUpper")
            {
                EditRow("QRToUpper", (bool)e.Value);
            }
            else if (e.Column.FieldName == "TextFirstChar")
            {
                EditRow("TextFirstChar", (bool)e.Value);
            }
            else if (e.Column.FieldName == "TextToUpper")
            {
                EditRow("TextToUpper", (bool)e.Value);
            }
            else if (e.Column.FieldName == "QRToDative")
            {
                EditRow("QRToDative", (bool)e.Value);
            }
            else if (e.Column.FieldName == "TextToDative")
            {
                EditRow("TextToDative", (bool)e.Value);
            }

            if (e.Column.FieldName == "BeforeSymbol")
            {
                EditSymbolRow("BeforeSymbol", e.Value.ToString());
            }
            else if (e.Column.FieldName == "AfterSymbol")
            {
                EditSymbolRow("AfterSymbol", e.Value.ToString());
            }
        }

        private void EditRow(string _column, bool _value)
        {
            try
            {
                using (var conn = new SQLiteConnection(MainForm.mainForm.connectionTemplateData))
                {
                    conn.Open();
                    using (var comm = conn.CreateCommand())
                    {
                        comm.CommandText = "UPDATE Markers SET " + _column + " = @Flag WHERE ID = @ID";
                        comm.Parameters.AddWithValue("@Flag", _value);
                        comm.Parameters.AddWithValue("@ID", gridView1.GetFocusedRowCellValue("ID"));
                        comm.ExecuteNonQuery();
                    }
                    conn.Close();
                }
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void EditSymbolRow(string _column, string _value)
        {
            try
            {
                using (var conn = new SQLiteConnection(MainForm.mainForm.connectionTemplateData))
                {
                    conn.Open();
                    using (var comm = conn.CreateCommand())
                    {
                        comm.CommandText = "UPDATE Markers SET " + _column + " = @Value WHERE ID = @ID";
                        if (_value == string.Empty)
                            comm.Parameters.AddWithValue("@Value", DBNull.Value);
                        else
                            comm.Parameters.AddWithValue("@Value", _value);
                        comm.Parameters.AddWithValue("@ID", gridView1.GetFocusedRowCellValue("ID"));
                        comm.ExecuteNonQuery();
                    }
                    conn.Close();
                }
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
