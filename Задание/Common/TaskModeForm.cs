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
    public partial class TaskModeForm : DevExpress.XtraEditors.XtraForm
    {
        public static TaskModeForm taskModeForm;

        public TaskModeForm()
        {
            InitializeComponent();
            taskModeForm = this;
        }

        private void TaskModeForm_Load(object sender, EventArgs e)
        {
            this.Focus();
            lbMode.SelectedIndex = 0;
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            if (lbMode.SelectedIndex == 0)
            {
                CourtNotificationVisibleOff();
                Task.task.btnObjectNoPerson.Visible = false;
                Task.task.tbEventCount.Text = "30";
                Task.task.dtEventStartDT.Enabled = false;
                Task.task.taskMode = 1;
            }
            else if (lbMode.SelectedIndex == 1)
            {
                CourtNotificationVisibleOff();
                Task.task.btnObjectNoPerson.Visible = true;
                Task.task.tbEventCount.Text = "20";
                Task.task.dtEventStartDT.Enabled = false;
                Task.task.taskMode = 1;
            }
            else if (lbMode.SelectedIndex == 2)
            {
                CourtNotificationVisibleOn();
                Task.task.btnObjectNoPerson.Visible = true;
                Task.task.tbEventCount.Text = "2";
                Task.task.dtEventStartDT.Enabled = true;
                Task.task.taskMode = 1;
            }
            else if (lbMode.SelectedIndex == 3)
            {
                CourtNotificationVisibleOff();
                Task.task.btnObjectNoPerson.Visible = true;
                Task.task.dtEventStartDT.Enabled = false;
                Task.task.taskMode = 1;
            }
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (Task.task.taskMode == 0)
            {
                CourtNotificationVisibleOff();
                Task.task.btnObjectNoPerson.Visible = false;
                Task.task.tbEventCount.Text = "30";
                Task.task.dtEventStartDT.Enabled = false;
                Task.task.taskMode = 1;
            }
            else
            {
                this.Close();
            }
        }

        private void CourtNotificationVisibleOn()
        {
            Task.task.labelBaseNotificationCourt.Visible = true;
            Task.task.labelBaseNotificationJudge.Visible = true;
            Task.task.labelBaseNotificationNo.Visible = true;
            Task.task.labelBaseNotificationStartDT.Visible = true;
            Task.task.cbBaseNotificationCourt.Visible = true;
            Task.task.cbBaseNotificationJudge.Visible = true;
            Task.task.tbBaseNotificationNo.Visible = true;
            Task.task.dtBaseNotificationStartDT.Visible = true;

            Task.task.cbBaseNotificationCourt.Enabled = true;
            Task.task.cbBaseNotificationJudge.Enabled = true;
            Task.task.tbBaseNotificationNo.Enabled = true;
            Task.task.dtBaseNotificationStartDT.Enabled = true;
        }

        private void CourtNotificationVisibleOff()
        {
            Task.task.labelBaseNotificationCourt.Visible = false;
            Task.task.labelBaseNotificationJudge.Visible = false;
            Task.task.labelBaseNotificationNo.Visible = false;
            Task.task.labelBaseNotificationStartDT.Visible = false;
            Task.task.cbBaseNotificationCourt.Visible = false;
            Task.task.cbBaseNotificationJudge.Visible = false;
            Task.task.tbBaseNotificationNo.Visible = false;
            Task.task.dtBaseNotificationStartDT.Visible = false;

            Task.task.cbBaseNotificationJudge.EditValue = null;
            Task.task.cbBaseNotificationCourt.EditValue = null;
            Task.task.tbBaseNotificationNo.Text = string.Empty;
            Task.task.dtBaseNotificationStartDT.Text = string.Empty;

            Task.task.cbBaseNotificationCourt.Enabled = false;
            Task.task.cbBaseNotificationJudge.Enabled = false;
            Task.task.tbBaseNotificationNo.Enabled = false;
            Task.task.dtBaseNotificationStartDT.Enabled = false;
        }

        private void lbMode_DoubleClick(object sender, EventArgs e)
        {
            if (lbMode.SelectedIndex == 0)
            {
                CourtNotificationVisibleOff();
                Task.task.btnObjectNoPerson.Visible = false;
                Task.task.tbEventCount.Text = "30";
                Task.task.dtEventStartDT.Enabled = false;
            }
            else if (lbMode.SelectedIndex == 1)
            {
                CourtNotificationVisibleOff();
                Task.task.btnObjectNoPerson.Visible = true;
                Task.task.tbEventCount.Text = "20";
                Task.task.dtEventStartDT.Enabled = false;
            }
            else if (lbMode.SelectedIndex == 2)
            {
                CourtNotificationVisibleOn();
                Task.task.btnObjectNoPerson.Visible = true;
                Task.task.tbEventCount.Text = "2";
                Task.task.dtEventStartDT.Enabled = true;
            }
            else if (lbMode.SelectedIndex == 3)
            {
                CourtNotificationVisibleOff();
                Task.task.btnObjectNoPerson.Visible = true;
                Task.task.dtEventStartDT.Enabled = false;
            }
            this.Close();
        }
    }
}
