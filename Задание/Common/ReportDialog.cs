using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Задание
{
    public partial class ReportDialog : DevExpress.XtraEditors.XtraForm
    {
        public ReportDialog()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (chbPeriod.Checked)
            {
                if (dtStart.Text != string.Empty && dtFinish.Text != string.Empty)
                {
                    if (DateTime.Parse(dtFinish.Text) < DateTime.Parse(dtStart.Text))
                    {
                        XtraMessageBox.Show("Дата окончания не может быть меньше даты начала!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        this.DialogResult = System.Windows.Forms.DialogResult.OK;
                        Report.report.FetchReportData(dtStart.Text, dtFinish.Text);
                    }
                }
                else
                {
                    XtraMessageBox.Show("Заполните дату начала и окончания отчета!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                if (chbWeek.Checked)
                {
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    DateTime date = DateTime.Now.AddDays(-7);
                    DateTime dateNow = DateTime.Now;
                    Report.report.FetchReportData(date.ToString("dd.MM.yyyy HH:mm:ss"), dateNow.ToString("dd.MM.yyyy HH:mm:ss")); 
                }
                else if (chbMonth.Checked)
                {
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    DateTime date = DateTime.Now.AddDays(-30);
                    DateTime dateNow = DateTime.Now;
                    Report.report.FetchReportData(date.ToString("dd.MM.yyyy HH:mm:ss"), dateNow.ToString("dd.MM.yyyy HH:mm:ss")); 
                }
                else if (chbQuarter.Checked)
                {
                    DateTime date = DateTime.Now.AddDays(-120);
                    DateTime dateNow = DateTime.Now;
                    Report.report.FetchReportData(date.ToString("dd.MM.yyyy HH:mm:ss"), dateNow.ToString("dd.MM.yyyy HH:mm:ss")); 
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.No;
            Report.report.LoadMinDate();
        }

        private void chbWeek_CheckedChanged(object sender, EventArgs e)
        {
            if (chbWeek.Checked)
            {
                chbMonth.CheckState = CheckState.Unchecked;
                chbQuarter.CheckState = CheckState.Unchecked;
                chbPeriod.CheckState = CheckState.Unchecked;
            }
        }

        private void chbMonth_CheckedChanged(object sender, EventArgs e)
        {
            if (chbMonth.Checked)
            {
                chbWeek.CheckState = CheckState.Unchecked;
                chbQuarter.CheckState = CheckState.Unchecked;
                chbPeriod.CheckState = CheckState.Unchecked;
            }
        }

        private void chbQuarter_CheckedChanged(object sender, EventArgs e)
        {
            if (chbQuarter.Checked)
            {
                chbWeek.CheckState = CheckState.Unchecked;
                chbMonth.CheckState = CheckState.Unchecked;
                chbPeriod.CheckState = CheckState.Unchecked;
            }
        }

        private void chbPeriod_CheckedChanged(object sender, EventArgs e)
        {
            if (chbPeriod.Checked)
            {
                chbWeek.CheckState = CheckState.Unchecked;
                chbMonth.CheckState = CheckState.Unchecked;
                chbQuarter.CheckState = CheckState.Unchecked;

                dtStart.Enabled = true;
                dtFinish.Enabled = true;
            }
            else
            {
                dtStart.Enabled = false; dtStart.Text = string.Empty;
                dtFinish.Enabled = false; dtFinish.Text = string.Empty;
            }
        }
    }
}
