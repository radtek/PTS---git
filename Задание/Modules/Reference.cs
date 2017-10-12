using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.DXErrorProvider;
using System.Data.SQLite;
using fastJSON;
using ZXing.QrCode;
using ZXing;
using ZXing.Common;
//using Novacode;
using Spire.Doc;
using Spire.Doc.Fields;
using Spire.Doc.Documents;
//
using System.IO;
using System.Drawing.Imaging;
using System.Text.RegularExpressions;

namespace Задание
{
    public partial class Reference : DevExpress.XtraEditors.XtraUserControl
    {
        #region "Declaration"
        public static Reference reference;
        public bool IsRefOpen = false; // Справка была загружена из БД? Если true, то сохраняем изменения в открытой
        public int RefID;
        public string RefCaption = "";
        public bool Flag = false;
        public List<ReferenceControls> controls = new List<ReferenceControls>();
        List<GroupBoxes> groupBoxes = new List<GroupBoxes>();
        List<Approving> approving = new List<Approving>();

        List<Bitmap> img = new List<Bitmap>();

        bool gc1Expended = false;
        bool gc2Expended = false;
        bool gc3Expended = false;
        bool gc4Expended = false;
        bool gc5Expended = false;
        bool gc6Expended = false;
        bool gc7Expended = false;
        bool gc8Expended = false;
        bool gc9Expended = false;
        #endregion

        public Reference()
        {
            JSON.Parameters.UseUTCDateTime = false;
            JSON.Parameters.UseExtensions = false;
            JSON.Parameters.UseEscapedUnicode = false;
            JSON.Parameters.EnableAnonymousTypes = true;
            JSON.Parameters.IgnoreCaseOnDeserialize = true;
            JSON.Parameters.IgnoreUnderscopeOnDeserialize = true;

            InitializeComponent();
            reference = this;

            tb1.Properties.MaxLength = 900; pbTb1.Properties.Maximum = 900; // *3
            tb2.Properties.MaxLength = 1200; pbTb2.Properties.Maximum = 1200; // *2
            tb3.Properties.MaxLength = 1200; pbTb3.Properties.Maximum = 1200; // *3
            tb4.Properties.MaxLength = 1200; pbTb4.Properties.Maximum = 1200; // *2
            tb5.Properties.MaxLength = 1200; pbTb5.Properties.Maximum = 1200; // *2 
            tb6.Properties.MaxLength = 1200; pbTb6.Properties.Maximum = 1200; // *2 
            tb7.Properties.MaxLength = 800; pbTb7.Properties.Maximum = 800; // *4
            tb8.Properties.MaxLength = 1200; pbTb8.Properties.Maximum = 1200; // *1
            tb9.Properties.MaxLength = 800; pbTb9.Properties.Maximum = 800; // *4

            DXErrorProvider.GetErrorIcon += DXErrorProvider_GetErrorIcon;
        }

        private void DXErrorProvider_GetErrorIcon(GetErrorIconEventArgs e)
        {
            if (e.ErrorType == ErrorType.User1)
                e.ErrorIcon = Properties.Resources.icon_error;
        }

        private void btnDocument_Click(object sender, EventArgs e)
        {
            if (navigation.SelectedPageIndex == 0)
            {
                navigation.SelectedPageIndex = 1;
                btnDocument.Text = "Справка об объекте";
                btnDocument.Image = Properties.Resources.BackToRef;
            }
            else
            {
                navigation.SelectedPageIndex = 0;
                btnDocument.Text = "Заполнить реквизиты";
                btnDocument.Image = Properties.Resources.AddDocument;
            }
        }

        #region "Open All Groups"
        private void chbOpenAll_CheckedChanged(object sender, EventArgs e)
        {
            groupBoxes.Clear();
            groupBoxes.Add(new GroupBoxes { control = gc1 });
            groupBoxes.Add(new GroupBoxes { control = gc2 });
            groupBoxes.Add(new GroupBoxes { control = gc3 });
            groupBoxes.Add(new GroupBoxes { control = gc4 });
            groupBoxes.Add(new GroupBoxes { control = gc5 });
            groupBoxes.Add(new GroupBoxes { control = gc6 });
            groupBoxes.Add(new GroupBoxes { control = gc7 });
            groupBoxes.Add(new GroupBoxes { control = gc8 });
            if (Flag)
                groupBoxes.Add(new GroupBoxes { control = gc9 });

            if (chbOpenAll.Checked)
            {
                foreach (var group in groupBoxes)
                {
                    if (group.control.CustomHeaderButtons[0].Properties.Caption == "Развернуть")
                    {
                        group.control.CustomHeaderButtons[0].Properties.Caption = "Свернуть";
                        group.control.CustomHeaderButtons[0].Properties.Image = Properties.Resources.DrillUp;
                    }

                    if (group.control.Name == "gc1")
                        gc1Expended = true;
                    else if (group.control.Name == "gc2")
                        gc2Expended = true;
                    else if (group.control.Name == "gc3")
                        gc3Expended = true;
                    else if (group.control.Name == "gc4")
                        gc4Expended = true;
                    else if (group.control.Name == "gc5")
                        gc5Expended = true;
                    else if (group.control.Name == "gc6")
                        gc6Expended = true;
                    else if (group.control.Name == "gc7")
                        gc7Expended = true;
                    else if (group.control.Name == "gc8")
                        gc8Expended = true;
                    else if (group.control.Name == "gc9")
                        gc9Expended = true;

                    group.control.Height = 380;
                }
            }
            else
            {
                foreach (var group in groupBoxes)
                {
                    if (group.control.CustomHeaderButtons[0].Properties.Caption == "Свернуть")
                    {
                        group.control.CustomHeaderButtons[0].Properties.Caption = "Развернуть";
                        group.control.CustomHeaderButtons[0].Properties.Image = Properties.Resources.DrillDown;
                    }

                    if (group.control.Name == "gc1")
                        gc1Expended = false;
                    else if (group.control.Name == "gc2")
                        gc2Expended = false;
                    else if (group.control.Name == "gc3")
                        gc3Expended = false;
                    else if (group.control.Name == "gc4")
                        gc4Expended = false;
                    else if (group.control.Name == "gc5")
                        gc5Expended = false;
                    else if (group.control.Name == "gc6")
                        gc6Expended = false;
                    else if (group.control.Name == "gc7")
                        gc7Expended = false;
                    else if (group.control.Name == "gc8")
                        gc8Expended = false;
                    else if (group.control.Name == "gc9")
                        gc9Expended = false;

                    group.control.Height = 23;
                }
            }
        }

        class GroupBoxes
        {
            public GroupControl control { get; set; }
        }
        #endregion
        #region "Open One Group In Section"
        private void chbOneInSection_CheckedChanged(object sender, EventArgs e)
        {
            groupBoxes.Clear();
            groupBoxes.Add(new GroupBoxes { control = gc1 });
            groupBoxes.Add(new GroupBoxes { control = gc2 });
            groupBoxes.Add(new GroupBoxes { control = gc3 });
            groupBoxes.Add(new GroupBoxes { control = gc4 });
            groupBoxes.Add(new GroupBoxes { control = gc5 });
            groupBoxes.Add(new GroupBoxes { control = gc6 });
            groupBoxes.Add(new GroupBoxes { control = gc7 });
            groupBoxes.Add(new GroupBoxes { control = gc8 });
            if (Flag)
                groupBoxes.Add(new GroupBoxes { control = gc9 });

            if (chbOneInSection.Checked)
            {
                chbOpenAll.CheckState = CheckState.Unchecked;
            }
        }
        #endregion
        #region "GroupBox Managment"
        private void gc1_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            if (chbOneInSection.Checked)
            {
                foreach (var group in groupBoxes)
                {
                    if (group.control.Name != "gc1")
                    {
                        if (group.control.CustomHeaderButtons[0].Properties.Caption == "Свернуть")
                        {
                            group.control.CustomHeaderButtons[0].Properties.Caption = "Развернуть";
                            group.control.CustomHeaderButtons[0].Properties.Image = Properties.Resources.DrillDown;
                        }

                        if (group.control.Name == "gc2")
                            gc2Expended = false;
                        else if (group.control.Name == "gc3")
                            gc3Expended = false;
                        else if (group.control.Name == "gc4")
                            gc4Expended = false;
                        else if (group.control.Name == "gc5")
                            gc5Expended = false;
                        else if (group.control.Name == "gc6")
                            gc6Expended = false;
                        else if (group.control.Name == "gc7")
                            gc7Expended = false;
                        else if (group.control.Name == "gc8")
                            gc8Expended = false;
                        else if (group.control.Name == "gc9")
                            gc9Expended = false;

                        group.control.Height = 23;
                    }
                    else
                    {
                        tb1.Focus();
                    }
                }
            }

            if (gc1Expended == true)
            {
                gc1Expended = false;
                gc1.Height = 23;
                e.Button.Properties.Caption = "Развернуть";
                e.Button.Properties.Image = Properties.Resources.DrillDown;
            }
            else
            {
                gc1Expended = true;
                gc1.Height = 380;
                e.Button.Properties.Caption = "Свернуть";
                e.Button.Properties.Image = Properties.Resources.DrillUp;
            }
        }

        private void gc2_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            if (chbOneInSection.Checked)
            {
                foreach (var group in groupBoxes)
                {
                    if (group.control.Name != "gc2")
                    {
                        if (group.control.CustomHeaderButtons[0].Properties.Caption == "Свернуть")
                        {
                            group.control.CustomHeaderButtons[0].Properties.Caption = "Развернуть";
                            group.control.CustomHeaderButtons[0].Properties.Image = Properties.Resources.DrillDown;
                        }

                        if (group.control.Name == "gc1")
                            gc2Expended = false;
                        else if (group.control.Name == "gc3")
                            gc3Expended = false;
                        else if (group.control.Name == "gc4")
                            gc4Expended = false;
                        else if (group.control.Name == "gc5")
                            gc5Expended = false;
                        else if (group.control.Name == "gc6")
                            gc6Expended = false;
                        else if (group.control.Name == "gc7")
                            gc7Expended = false;
                        else if (group.control.Name == "gc8")
                            gc8Expended = false;
                        else if (group.control.Name == "gc9")
                            gc9Expended = false;

                        group.control.Height = 23;
                    }
                    else
                    {
                        tb2.Focus();
                    }
                }
            }

            if (gc2Expended == true)
            {
                gc2Expended = false;
                gc2.Height = 23;
                e.Button.Properties.Caption = "Развернуть";
                e.Button.Properties.Image = Properties.Resources.DrillDown;
            }
            else
            {
                gc2Expended = true;
                gc2.Height = 380;
                e.Button.Properties.Caption = "Свернуть";
                e.Button.Properties.Image = Properties.Resources.DrillUp;
            }
        }

        private void gc3_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            if (chbOneInSection.Checked)
            {
                foreach (var group in groupBoxes)
                {
                    if (group.control.Name != "gc3")
                    {
                        if (group.control.CustomHeaderButtons[0].Properties.Caption == "Свернуть")
                        {
                            group.control.CustomHeaderButtons[0].Properties.Caption = "Развернуть";
                            group.control.CustomHeaderButtons[0].Properties.Image = Properties.Resources.DrillDown;
                        }

                        if (group.control.Name == "gc1")
                            gc2Expended = false;
                        else if (group.control.Name == "gc2")
                            gc3Expended = false;
                        else if (group.control.Name == "gc4")
                            gc4Expended = false;
                        else if (group.control.Name == "gc5")
                            gc5Expended = false;
                        else if (group.control.Name == "gc6")
                            gc6Expended = false;
                        else if (group.control.Name == "gc7")
                            gc7Expended = false;
                        else if (group.control.Name == "gc8")
                            gc8Expended = false;
                        else if (group.control.Name == "gc9")
                            gc9Expended = false;

                        group.control.Height = 23;
                    }
                    else
                    {
                        tb3.Focus();
                    }
                }
            }

            if (gc3Expended == true)
            {
                gc3Expended = false;
                gc3.Height = 23;
                e.Button.Properties.Caption = "Развернуть";
                e.Button.Properties.Image = Properties.Resources.DrillDown;
            }
            else
            {
                gc3Expended = true;
                gc3.Height = 380;
                e.Button.Properties.Caption = "Свернуть";
                e.Button.Properties.Image = Properties.Resources.DrillUp;
            }
        }

        private void gc4_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            if (chbOneInSection.Checked)
            {
                foreach (var group in groupBoxes)
                {
                    if (group.control.Name != "gc4")
                    {
                        if (group.control.CustomHeaderButtons[0].Properties.Caption == "Свернуть")
                        {
                            group.control.CustomHeaderButtons[0].Properties.Caption = "Развернуть";
                            group.control.CustomHeaderButtons[0].Properties.Image = Properties.Resources.DrillDown;
                        }

                        if (group.control.Name == "gc1")
                            gc2Expended = false;
                        else if (group.control.Name == "gc2")
                            gc3Expended = false;
                        else if (group.control.Name == "gc3")
                            gc4Expended = false;
                        else if (group.control.Name == "gc5")
                            gc5Expended = false;
                        else if (group.control.Name == "gc6")
                            gc6Expended = false;
                        else if (group.control.Name == "gc7")
                            gc7Expended = false;
                        else if (group.control.Name == "gc8")
                            gc8Expended = false;
                        else if (group.control.Name == "gc9")
                            gc9Expended = false;

                        group.control.Height = 23;
                    }
                    else
                    {
                        tb4.Focus();
                    }
                }
            }

            if (gc4Expended == true)
            {
                gc4Expended = false;
                gc4.Height = 23;
                e.Button.Properties.Caption = "Развернуть";
                e.Button.Properties.Image = Properties.Resources.DrillDown;
            }
            else
            {
                gc4Expended = true;
                gc4.Height = 380;
                e.Button.Properties.Caption = "Свернуть";
                e.Button.Properties.Image = Properties.Resources.DrillUp;
            }
        }

        private void gc5_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            if (chbOneInSection.Checked)
            {
                foreach (var group in groupBoxes)
                {
                    if (group.control.Name != "gc5")
                    {
                        if (group.control.CustomHeaderButtons[0].Properties.Caption == "Свернуть")
                        {
                            group.control.CustomHeaderButtons[0].Properties.Caption = "Развернуть";
                            group.control.CustomHeaderButtons[0].Properties.Image = Properties.Resources.DrillDown;
                        }

                        if (group.control.Name == "gc1")
                            gc2Expended = false;
                        else if (group.control.Name == "gc2")
                            gc3Expended = false;
                        else if (group.control.Name == "gc3")
                            gc4Expended = false;
                        else if (group.control.Name == "gc4")
                            gc5Expended = false;
                        else if (group.control.Name == "gc6")
                            gc6Expended = false;
                        else if (group.control.Name == "gc7")
                            gc7Expended = false;
                        else if (group.control.Name == "gc8")
                            gc8Expended = false;
                        else if (group.control.Name == "gc9")
                            gc9Expended = false;

                        group.control.Height = 23;
                    }
                    else
                    {
                        tb5.Focus();
                    }
                }
            }

            if (gc5Expended == true)
            {
                gc5Expended = false;
                gc5.Height = 23;
                e.Button.Properties.Caption = "Развернуть";
                e.Button.Properties.Image = Properties.Resources.DrillDown;
            }
            else
            {
                gc5Expended = true;
                gc5.Height = 380;
                e.Button.Properties.Caption = "Свернуть";
                e.Button.Properties.Image = Properties.Resources.DrillUp;
            }
        }

        private void gc6_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            if (chbOneInSection.Checked)
            {
                foreach (var group in groupBoxes)
                {
                    if (group.control.Name != "gc6")
                    {
                        if (group.control.CustomHeaderButtons[0].Properties.Caption == "Свернуть")
                        {
                            group.control.CustomHeaderButtons[0].Properties.Caption = "Развернуть";
                            group.control.CustomHeaderButtons[0].Properties.Image = Properties.Resources.DrillDown;
                        }

                        if (group.control.Name == "gc1")
                            gc2Expended = false;
                        else if (group.control.Name == "gc2")
                            gc3Expended = false;
                        else if (group.control.Name == "gc3")
                            gc4Expended = false;
                        else if (group.control.Name == "gc4")
                            gc5Expended = false;
                        else if (group.control.Name == "gc5")
                            gc6Expended = false;
                        else if (group.control.Name == "gc7")
                            gc7Expended = false;
                        else if (group.control.Name == "gc8")
                            gc8Expended = false;
                        else if (group.control.Name == "gc9")
                            gc9Expended = false;

                        group.control.Height = 23;
                    }
                    else
                    {
                        tb6.Focus();
                    }
                }
            }

            if (gc6Expended == true)
            {
                gc6Expended = false;
                gc6.Height = 23;
                e.Button.Properties.Caption = "Развернуть";
                e.Button.Properties.Image = Properties.Resources.DrillDown;
            }
            else
            {
                gc6Expended = true;
                gc6.Height = 380;
                e.Button.Properties.Caption = "Свернуть";
                e.Button.Properties.Image = Properties.Resources.DrillUp;
            }
        }

        private void gc7_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            if (chbOneInSection.Checked)
            {
                foreach (var group in groupBoxes)
                {
                    if (group.control.Name != "gc7")
                    {
                        if (group.control.CustomHeaderButtons[0].Properties.Caption == "Свернуть")
                        {
                            group.control.CustomHeaderButtons[0].Properties.Caption = "Развернуть";
                            group.control.CustomHeaderButtons[0].Properties.Image = Properties.Resources.DrillDown;
                        }

                        if (group.control.Name == "gc1")
                            gc2Expended = false;
                        else if (group.control.Name == "gc2")
                            gc3Expended = false;
                        else if (group.control.Name == "gc3")
                            gc4Expended = false;
                        else if (group.control.Name == "gc4")
                            gc5Expended = false;
                        else if (group.control.Name == "gc5")
                            gc6Expended = false;
                        else if (group.control.Name == "gc6")
                            gc7Expended = false;
                        else if (group.control.Name == "gc8")
                            gc8Expended = false;
                        else if (group.control.Name == "gc9")
                            gc9Expended = false;

                        group.control.Height = 23;
                    }
                    else
                    {
                        tb7.Focus();
                    }
                }
            }

            if (gc7Expended == true)
            {
                gc7Expended = false;
                gc7.Height = 23;
                e.Button.Properties.Caption = "Развернуть";
                e.Button.Properties.Image = Properties.Resources.DrillDown;
            }
            else
            {
                gc7Expended = true;
                gc7.Height = 380;
                e.Button.Properties.Caption = "Свернуть";
                e.Button.Properties.Image = Properties.Resources.DrillUp;
            }
        }

        private void gc8_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            if (chbOneInSection.Checked)
            {
                foreach (var group in groupBoxes)
                {
                    if (group.control.Name != "gc8")
                    {
                        if (group.control.CustomHeaderButtons[0].Properties.Caption == "Свернуть")
                        {
                            group.control.CustomHeaderButtons[0].Properties.Caption = "Развернуть";
                            group.control.CustomHeaderButtons[0].Properties.Image = Properties.Resources.DrillDown;
                        }

                        if (group.control.Name == "gc1")
                            gc2Expended = false;
                        else if (group.control.Name == "gc2")
                            gc3Expended = false;
                        else if (group.control.Name == "gc3")
                            gc4Expended = false;
                        else if (group.control.Name == "gc4")
                            gc5Expended = false;
                        else if (group.control.Name == "gc5")
                            gc6Expended = false;
                        else if (group.control.Name == "gc6")
                            gc7Expended = false;
                        else if (group.control.Name == "gc7")
                            gc8Expended = false;
                        else if (group.control.Name == "gc9")
                            gc8Expended = false;

                        group.control.Height = 23;
                    }
                    else
                    {
                        tb8.Focus();
                    }
                }
            }

            if (gc8Expended == true)
            {
                gc8Expended = false;
                gc8.Height = 23;
                e.Button.Properties.Caption = "Развернуть";
                e.Button.Properties.Image = Properties.Resources.DrillDown;
            }
            else
            {
                gc8Expended = true;
                gc8.Height = 380;
                e.Button.Properties.Caption = "Свернуть";
                e.Button.Properties.Image = Properties.Resources.DrillUp;
            }
        }

        private void gc9_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            if (chbOneInSection.Checked)
            {
                foreach (var group in groupBoxes)
                {
                    if (group.control.Name != "gc9")
                    {
                        if (group.control.CustomHeaderButtons[0].Properties.Caption == "Свернуть")
                        {
                            group.control.CustomHeaderButtons[0].Properties.Caption = "Развернуть";
                            group.control.CustomHeaderButtons[0].Properties.Image = Properties.Resources.DrillDown;
                        }

                        if (group.control.Name == "gc1")
                            gc2Expended = false;
                        else if (group.control.Name == "gc2")
                            gc3Expended = false;
                        else if (group.control.Name == "gc3")
                            gc4Expended = false;
                        else if (group.control.Name == "gc4")
                            gc5Expended = false;
                        else if (group.control.Name == "gc5")
                            gc6Expended = false;
                        else if (group.control.Name == "gc6")
                            gc7Expended = false;
                        else if (group.control.Name == "gc7")
                            gc8Expended = false;
                        else if (group.control.Name == "gc8")
                            gc8Expended = false;

                        group.control.Height = 23;
                    }
                    else
                    {
                        tb9.Focus();
                    }
                }
            }

            if (gc9Expended == true)
            {
                gc9Expended = false;
                gc9.Height = 23;
                e.Button.Properties.Caption = "Развернуть";
                e.Button.Properties.Image = Properties.Resources.DrillDown;
            }
            else
            {
                gc9Expended = true;
                gc9.Height = 380;
                e.Button.Properties.Caption = "Свернуть";
                e.Button.Properties.Image = Properties.Resources.DrillUp;
            }
        }

        private void gc1_SizeChanged(object sender, EventArgs e)
        {
            gc2.Location = new Point(22, gc1.Bottom + 6);
            gc3.Location = new Point(22, gc2.Bottom + 6);
            gc4.Location = new Point(22, gc3.Bottom + 6);
            gc5.Location = new Point(22, gc4.Bottom + 6);
            gc6.Location = new Point(22, gc5.Bottom + 6);
            gc7.Location = new Point(22, gc6.Bottom + 6);
            gc8.Location = new Point(22, gc7.Bottom + 6);
            gc9.Location = new Point(22, gc8.Bottom + 6);
        }

        private void gc2_SizeChanged(object sender, EventArgs e)
        {
            gc3.Location = new Point(22, gc2.Bottom + 6);
            gc4.Location = new Point(22, gc3.Bottom + 6);
            gc5.Location = new Point(22, gc4.Bottom + 6);
            gc6.Location = new Point(22, gc5.Bottom + 6);
            gc7.Location = new Point(22, gc6.Bottom + 6);
            gc8.Location = new Point(22, gc7.Bottom + 6);
            gc9.Location = new Point(22, gc8.Bottom + 6);
        }

        private void gc3_SizeChanged(object sender, EventArgs e)
        {
            gc4.Location = new Point(22, gc3.Bottom + 6);
            gc5.Location = new Point(22, gc4.Bottom + 6);
            gc6.Location = new Point(22, gc5.Bottom + 6);
            gc7.Location = new Point(22, gc6.Bottom + 6);
            gc8.Location = new Point(22, gc7.Bottom + 6);
            gc9.Location = new Point(22, gc8.Bottom + 6);
        }

        private void gc4_SizeChanged(object sender, EventArgs e)
        {
            gc5.Location = new Point(22, gc4.Bottom + 6);
            gc6.Location = new Point(22, gc5.Bottom + 6);
            gc7.Location = new Point(22, gc6.Bottom + 6);
            gc8.Location = new Point(22, gc7.Bottom + 6);
            gc9.Location = new Point(22, gc8.Bottom + 6);
        }

        private void gc5_SizeChanged(object sender, EventArgs e)
        {
            gc6.Location = new Point(22, gc5.Bottom + 6);
            gc7.Location = new Point(22, gc6.Bottom + 6);
            gc8.Location = new Point(22, gc7.Bottom + 6);
            gc9.Location = new Point(22, gc8.Bottom + 6);
        }

        private void gc6_SizeChanged(object sender, EventArgs e)
        {
            gc7.Location = new Point(22, gc6.Bottom + 6);
            gc8.Location = new Point(22, gc7.Bottom + 6);
            gc9.Location = new Point(22, gc8.Bottom + 6);
        }

        private void gc7_SizeChanged(object sender, EventArgs e)
        {
            gc8.Location = new Point(22, gc7.Bottom + 6);
            gc9.Location = new Point(22, gc8.Bottom + 6);
        }

        private void gc8_SizeChanged(object sender, EventArgs e)
        {
            gc9.Location = new Point(22, gc8.Bottom + 6);
        }
        #endregion
        #region "Mouse Double Click Events"
        private void gc1_DoubleClick(object sender, EventArgs e)
        {
            if (chbOneInSection.Checked)
            {
                foreach (var group in groupBoxes)
                {
                    if (group.control.Name != "gc1")
                    {
                        if (group.control.CustomHeaderButtons[0].Properties.Caption == "Свернуть")
                        {
                            group.control.CustomHeaderButtons[0].Properties.Caption = "Развернуть";
                            group.control.CustomHeaderButtons[0].Properties.Image = Properties.Resources.DrillDown;
                        }

                        if (group.control.Name == "gc2")
                            gc2Expended = false;
                        else if (group.control.Name == "gc3")
                            gc3Expended = false;
                        else if (group.control.Name == "gc4")
                            gc4Expended = false;
                        else if (group.control.Name == "gc5")
                            gc5Expended = false;
                        else if (group.control.Name == "gc6")
                            gc6Expended = false;
                        else if (group.control.Name == "gc7")
                            gc7Expended = false;
                        else if (group.control.Name == "gc8")
                            gc8Expended = false;
                        else if (group.control.Name == "gc9")
                            gc9Expended = false;

                        group.control.Height = 23;
                    }
                }
            }

            if (gc1Expended == true)
            {
                gc1Expended = false;
                gc1.Height = 23;
                gc1.CustomHeaderButtons[0].Properties.Caption = "Развернуть";
                gc1.CustomHeaderButtons[0].Properties.Image = Properties.Resources.DrillDown;
            }
            else
            {
                gc1Expended = true;
                gc1.Height = 380;
                gc1.CustomHeaderButtons[0].Properties.Caption = "Свернуть";
                gc1.CustomHeaderButtons[0].Properties.Image = Properties.Resources.DrillUp;
            }
        }

        private void gc2_DoubleClick(object sender, EventArgs e)
        {
            if (chbOneInSection.Checked)
            {
                foreach (var group in groupBoxes)
                {
                    if (group.control.Name != "gc2")
                    {
                        if (group.control.CustomHeaderButtons[0].Properties.Caption == "Свернуть")
                        {
                            group.control.CustomHeaderButtons[0].Properties.Caption = "Развернуть";
                            group.control.CustomHeaderButtons[0].Properties.Image = Properties.Resources.DrillDown;
                        }

                        if (group.control.Name == "gc1")
                            gc2Expended = false;
                        else if (group.control.Name == "gc3")
                            gc3Expended = false;
                        else if (group.control.Name == "gc4")
                            gc4Expended = false;
                        else if (group.control.Name == "gc5")
                            gc5Expended = false;
                        else if (group.control.Name == "gc6")
                            gc6Expended = false;
                        else if (group.control.Name == "gc7")
                            gc7Expended = false;
                        else if (group.control.Name == "gc8")
                            gc8Expended = false;
                        else if (group.control.Name == "gc9")
                            gc9Expended = false;

                        group.control.Height = 23;
                    }
                }
            }

            if (gc2Expended == true)
            {
                gc2Expended = false;
                gc2.Height = 23;
                gc2.CustomHeaderButtons[0].Properties.Caption = "Развернуть";
                gc2.CustomHeaderButtons[0].Properties.Image = Properties.Resources.DrillDown;
            }
            else
            {
                gc2Expended = true;
                gc2.Height = 380;
                gc2.CustomHeaderButtons[0].Properties.Caption = "Свернуть";
                gc2.CustomHeaderButtons[0].Properties.Image = Properties.Resources.DrillUp;
            }
        }

        private void gc3_DoubleClick(object sender, EventArgs e)
        {
            if (chbOneInSection.Checked)
            {
                foreach (var group in groupBoxes)
                {
                    if (group.control.Name != "gc3")
                    {
                        if (group.control.CustomHeaderButtons[0].Properties.Caption == "Свернуть")
                        {
                            group.control.CustomHeaderButtons[0].Properties.Caption = "Развернуть";
                            group.control.CustomHeaderButtons[0].Properties.Image = Properties.Resources.DrillDown;
                        }

                        if (group.control.Name == "gc1")
                            gc2Expended = false;
                        else if (group.control.Name == "gc2")
                            gc3Expended = false;
                        else if (group.control.Name == "gc4")
                            gc4Expended = false;
                        else if (group.control.Name == "gc5")
                            gc5Expended = false;
                        else if (group.control.Name == "gc6")
                            gc6Expended = false;
                        else if (group.control.Name == "gc7")
                            gc7Expended = false;
                        else if (group.control.Name == "gc8")
                            gc8Expended = false;
                        else if (group.control.Name == "gc9")
                            gc9Expended = false;

                        group.control.Height = 23;
                    }
                }
            }

            if (gc3Expended == true)
            {
                gc3Expended = false;
                gc3.Height = 23;
                gc3.CustomHeaderButtons[0].Properties.Caption = "Развернуть";
                gc3.CustomHeaderButtons[0].Properties.Image = Properties.Resources.DrillDown;
            }
            else
            {
                gc3Expended = true;
                gc3.Height = 380;
                gc3.CustomHeaderButtons[0].Properties.Caption = "Свернуть";
                gc3.CustomHeaderButtons[0].Properties.Image = Properties.Resources.DrillUp;
            }
        }

        private void gc4_DoubleClick(object sender, EventArgs e)
        {
            if (chbOneInSection.Checked)
            {
                foreach (var group in groupBoxes)
                {
                    if (group.control.Name != "gc4")
                    {
                        if (group.control.CustomHeaderButtons[0].Properties.Caption == "Свернуть")
                        {
                            group.control.CustomHeaderButtons[0].Properties.Caption = "Развернуть";
                            group.control.CustomHeaderButtons[0].Properties.Image = Properties.Resources.DrillDown;
                        }

                        if (group.control.Name == "gc1")
                            gc2Expended = false;
                        else if (group.control.Name == "gc2")
                            gc3Expended = false;
                        else if (group.control.Name == "gc3")
                            gc4Expended = false;
                        else if (group.control.Name == "gc5")
                            gc5Expended = false;
                        else if (group.control.Name == "gc6")
                            gc6Expended = false;
                        else if (group.control.Name == "gc7")
                            gc7Expended = false;
                        else if (group.control.Name == "gc8")
                            gc8Expended = false;
                        else if (group.control.Name == "gc9")
                            gc9Expended = false;

                        group.control.Height = 23;
                    }
                }
            }

            if (gc4Expended == true)
            {
                gc4Expended = false;
                gc4.Height = 23;
                gc4.CustomHeaderButtons[0].Properties.Caption = "Развернуть";
                gc4.CustomHeaderButtons[0].Properties.Image = Properties.Resources.DrillDown;
            }
            else
            {
                gc4Expended = true;
                gc4.Height = 380;
                gc4.CustomHeaderButtons[0].Properties.Caption = "Свернуть";
                gc4.CustomHeaderButtons[0].Properties.Image = Properties.Resources.DrillUp;
            }
        }

        private void gc5_DoubleClick(object sender, EventArgs e)
        {
            if (chbOneInSection.Checked)
            {
                foreach (var group in groupBoxes)
                {
                    if (group.control.Name != "gc5")
                    {
                        if (group.control.CustomHeaderButtons[0].Properties.Caption == "Свернуть")
                        {
                            group.control.CustomHeaderButtons[0].Properties.Caption = "Развернуть";
                            group.control.CustomHeaderButtons[0].Properties.Image = Properties.Resources.DrillDown;
                        }

                        if (group.control.Name == "gc1")
                            gc2Expended = false;
                        else if (group.control.Name == "gc2")
                            gc3Expended = false;
                        else if (group.control.Name == "gc3")
                            gc4Expended = false;
                        else if (group.control.Name == "gc4")
                            gc5Expended = false;
                        else if (group.control.Name == "gc6")
                            gc6Expended = false;
                        else if (group.control.Name == "gc7")
                            gc7Expended = false;
                        else if (group.control.Name == "gc8")
                            gc8Expended = false;
                        else if (group.control.Name == "gc9")
                            gc9Expended = false;

                        group.control.Height = 23;
                    }
                }
            }

            if (gc5Expended == true)
            {
                gc5Expended = false;
                gc5.Height = 23;
                gc5.CustomHeaderButtons[0].Properties.Caption = "Развернуть";
                gc5.CustomHeaderButtons[0].Properties.Image = Properties.Resources.DrillDown;
            }
            else
            {
                gc5Expended = true;
                gc5.Height = 380;
                gc5.CustomHeaderButtons[0].Properties.Caption = "Свернуть";
                gc5.CustomHeaderButtons[0].Properties.Image = Properties.Resources.DrillUp;
            }
        }

        private void gc6_DoubleClick(object sender, EventArgs e)
        {
            if (chbOneInSection.Checked)
            {
                foreach (var group in groupBoxes)
                {
                    if (group.control.Name != "gc6")
                    {
                        if (group.control.CustomHeaderButtons[0].Properties.Caption == "Свернуть")
                        {
                            group.control.CustomHeaderButtons[0].Properties.Caption = "Развернуть";
                            group.control.CustomHeaderButtons[0].Properties.Image = Properties.Resources.DrillDown;
                        }

                        if (group.control.Name == "gc1")
                            gc2Expended = false;
                        else if (group.control.Name == "gc2")
                            gc3Expended = false;
                        else if (group.control.Name == "gc3")
                            gc4Expended = false;
                        else if (group.control.Name == "gc4")
                            gc5Expended = false;
                        else if (group.control.Name == "gc5")
                            gc6Expended = false;
                        else if (group.control.Name == "gc7")
                            gc7Expended = false;
                        else if (group.control.Name == "gc8")
                            gc8Expended = false;
                        else if (group.control.Name == "gc9")
                            gc9Expended = false;

                        group.control.Height = 23;
                    }
                }
            }

            if (gc6Expended == true)
            {
                gc6Expended = false;
                gc6.Height = 23;
                gc6.CustomHeaderButtons[0].Properties.Caption = "Развернуть";
                gc6.CustomHeaderButtons[0].Properties.Image = Properties.Resources.DrillDown;
            }
            else
            {
                gc6Expended = true;
                gc6.Height = 380;
                gc6.CustomHeaderButtons[0].Properties.Caption = "Свернуть";
                gc6.CustomHeaderButtons[0].Properties.Image = Properties.Resources.DrillUp;
            }
        }

        private void gc7_DoubleClick(object sender, EventArgs e)
        {
            if (chbOneInSection.Checked)
            {
                foreach (var group in groupBoxes)
                {
                    if (group.control.Name != "gc7")
                    {
                        if (group.control.CustomHeaderButtons[0].Properties.Caption == "Свернуть")
                        {
                            group.control.CustomHeaderButtons[0].Properties.Caption = "Развернуть";
                            group.control.CustomHeaderButtons[0].Properties.Image = Properties.Resources.DrillDown;
                        }

                        if (group.control.Name == "gc1")
                            gc2Expended = false;
                        else if (group.control.Name == "gc2")
                            gc3Expended = false;
                        else if (group.control.Name == "gc3")
                            gc4Expended = false;
                        else if (group.control.Name == "gc4")
                            gc5Expended = false;
                        else if (group.control.Name == "gc5")
                            gc6Expended = false;
                        else if (group.control.Name == "gc6")
                            gc7Expended = false;
                        else if (group.control.Name == "gc8")
                            gc8Expended = false;
                        else if (group.control.Name == "gc9")
                            gc9Expended = false;

                        group.control.Height = 23;
                    }
                }
            }

            if (gc7Expended == true)
            {
                gc7Expended = false;
                gc7.Height = 23;
                gc7.CustomHeaderButtons[0].Properties.Caption = "Развернуть";
                gc7.CustomHeaderButtons[0].Properties.Image = Properties.Resources.DrillDown;
            }
            else
            {
                gc7Expended = true;
                gc7.Height = 380;
                gc7.CustomHeaderButtons[0].Properties.Caption = "Свернуть";
                gc7.CustomHeaderButtons[0].Properties.Image = Properties.Resources.DrillUp;
            }
        }

        private void gc8_DoubleClick(object sender, EventArgs e)
        {
            if (chbOneInSection.Checked)
            {
                foreach (var group in groupBoxes)
                {
                    if (group.control.Name != "gc8")
                    {
                        if (group.control.CustomHeaderButtons[0].Properties.Caption == "Свернуть")
                        {
                            group.control.CustomHeaderButtons[0].Properties.Caption = "Развернуть";
                            group.control.CustomHeaderButtons[0].Properties.Image = Properties.Resources.DrillDown;
                        }

                        if (group.control.Name == "gc1")
                            gc2Expended = false;
                        else if (group.control.Name == "gc2")
                            gc3Expended = false;
                        else if (group.control.Name == "gc3")
                            gc4Expended = false;
                        else if (group.control.Name == "gc4")
                            gc5Expended = false;
                        else if (group.control.Name == "gc5")
                            gc6Expended = false;
                        else if (group.control.Name == "gc6")
                            gc7Expended = false;
                        else if (group.control.Name == "gc7")
                            gc8Expended = false;
                        else if (group.control.Name == "gc9")
                            gc8Expended = false;

                        group.control.Height = 23;
                    }
                }
            }

            if (gc8Expended == true)
            {
                gc8Expended = false;
                gc8.Height = 23;
                gc8.CustomHeaderButtons[0].Properties.Caption = "Развернуть";
                gc8.CustomHeaderButtons[0].Properties.Image = Properties.Resources.DrillDown;
            }
            else
            {
                gc8Expended = true;
                gc8.Height = 380;
                gc8.CustomHeaderButtons[0].Properties.Caption = "Свернуть";
                gc8.CustomHeaderButtons[0].Properties.Image = Properties.Resources.DrillUp;
            }
        }

        private void gc9_DoubleClick(object sender, EventArgs e)
        {
            if (chbOneInSection.Checked)
            {
                foreach (var group in groupBoxes)
                {
                    if (group.control.Name != "gc9")
                    {
                        if (group.control.CustomHeaderButtons[0].Properties.Caption == "Свернуть")
                        {
                            group.control.CustomHeaderButtons[0].Properties.Caption = "Развернуть";
                            group.control.CustomHeaderButtons[0].Properties.Image = Properties.Resources.DrillDown;
                        }

                        if (group.control.Name == "gc1")
                            gc2Expended = false;
                        else if (group.control.Name == "gc2")
                            gc3Expended = false;
                        else if (group.control.Name == "gc3")
                            gc4Expended = false;
                        else if (group.control.Name == "gc4")
                            gc5Expended = false;
                        else if (group.control.Name == "gc5")
                            gc6Expended = false;
                        else if (group.control.Name == "gc6")
                            gc7Expended = false;
                        else if (group.control.Name == "gc7")
                            gc8Expended = false;
                        else if (group.control.Name == "gc8")
                            gc8Expended = false;

                        group.control.Height = 23;
                    }
                }
            }

            if (gc9Expended == true)
            {
                gc9Expended = false;
                gc9.Height = 23;
                gc9.CustomHeaderButtons[0].Properties.Caption = "Развернуть";
                gc9.CustomHeaderButtons[0].Properties.Image = Properties.Resources.DrillDown;
            }
            else
            {
                gc9Expended = true;
                gc9.Height = 380;
                gc9.CustomHeaderButtons[0].Properties.Caption = "Свернуть";
                gc9.CustomHeaderButtons[0].Properties.Image = Properties.Resources.DrillUp;
            }
        }
        #endregion
        #region "Validate Reference Fields"
        public void UpdateForValidate()
        {
            controls.Clear();
            controls.Add(new ReferenceControls { control = tbObject, Flag = false });
            controls.Add(new ReferenceControls { control = tb1, groupControl = gc1, Flag = false });
            controls.Add(new ReferenceControls { control = tb2, groupControl = gc2, Flag = false });
            controls.Add(new ReferenceControls { control = tb3, groupControl = gc3, Flag = false });
            controls.Add(new ReferenceControls { control = tb4, groupControl = gc4, Flag = false });
            controls.Add(new ReferenceControls { control = tb5, groupControl = gc5, Flag = false });
            controls.Add(new ReferenceControls { control = tb6, groupControl = gc6, Flag = false });
            controls.Add(new ReferenceControls { control = tb7, groupControl = gc7, Flag = false });
            controls.Add(new ReferenceControls { control = tb8, groupControl = gc8, Flag = false });
            controls.Add(new ReferenceControls { control = tb9, groupControl = gc9, Flag = false });

            controls.Add(new ReferenceControls { control = tbDocumentSerialNo, Flag = false });
            controls.Add(new ReferenceControls { control = tbDocumentWorkStation, Flag = false });
            controls.Add(new ReferenceControls { control = tbDocumentAuthor, Flag = false });
            controls.Add(new ReferenceControls { control = tbDocumentAuthorPhone, Flag = false });
            controls.Add(new ReferenceControls { control = tbDocumentPrivacyRank, Flag = false });
            controls.Add(new ReferenceControls { control = tbDocumentOrderNo, Flag = false });
            controls.Add(new ReferenceControls { control = dtDocumentDoneDT, Flag = false });
            controls.Add(new ReferenceControls { control = tbDivision1, Flag = false });
            controls.Add(new ReferenceControls { control = tbDivision2, Flag = false });
            controls.Add(new ReferenceControls { control = tbDivision3, Flag = false });
            controls.Add(new ReferenceControls { control = tbDivision4, Flag = false });
            controls.Add(new ReferenceControls { control = tbDivision5, Flag = false });
        }

        public bool ValidateReferenceFields(List<ReferenceControls> controls)
        {
            foreach (var item in controls)
            {
                if (item.control.Enabled == true)
                {
                    if (item.control.Text == string.Empty || item.control.Text.Length == 0)
                    {
                        item.Flag = false;
                        if (item.groupControl != null)
                        {
                            dxErrorProvider.SetError(item.control, "Необходимо заполнить это поле", ErrorType.User1);
                            item.groupControl.AppearanceCaption.ForeColor = Color.Red;
                        }
                        else
                        {
                            dxErrorProvider.SetError(item.control, "Необходимо заполнить это поле", ErrorType.User1);
                        }
                    }
                    else
                    {
                        item.Flag = true;
                        if (item.groupControl != null)
                        {
                            dxErrorProvider.SetError(item.control, "");
                            item.groupControl.AppearanceCaption.ForeColor = default(Color);
                        }
                        else
                        {
                            dxErrorProvider.SetError(item.control, "");
                        }
                    }
                }
                else
                {
                    item.Flag = true;
                    if (item.groupControl != null)
                    {
                        dxErrorProvider.SetError(item.control, "");
                        item.groupControl.AppearanceCaption.ForeColor = default(Color);
                    }
                    else
                    {
                        dxErrorProvider.SetError(item.control, "");
                    }
                }
            }

            if (controls.Where(x => x.Flag == false).Count() == 0)
                return true;
            else
                return false;
        }

        public class ReferenceControls
        {
            public GroupControl groupControl { get; set; }
            public BaseEdit control { get; set; }
            public bool Flag { get; set; }
        }
        #endregion
        #region "Reference Navigation"
        private void btnOpenRef_Click(object sender, EventArgs e)
        {
            var openRefDialog = new ReferenceMenu();
            if (openRefDialog.ShowDialog() == DialogResult.OK)
            {
                RefID = openRefDialog.GetID;
                RefCaption = openRefDialog.GetCaption;
                IsRefOpen = true;

                try
                {
                    using (var conn = new SQLiteConnection(MainForm.mainForm.connectionReferenceData))
                    {
                        conn.Open();
                        using (var comm = conn.CreateCommand())
                        {
                            comm.CommandText = "SELECT Body FROM Reference WHERE ID = @ID";
                            comm.Parameters.AddWithValue("@ID", RefID);
                            using (var dr = comm.ExecuteReader())
                            {
                                while (dr.Read())
                                {
                                    List<ReferenceData> refData = JSON.Instance.ToObject<List<ReferenceData>>(dr["Body"].ToString());
                                    tbObject.Text = refData[0].tbObject;
                                    tb1.Text = refData[0].tb1Value;
                                    tb2.Text = refData[0].tb2Value;
                                    tb3.Text = refData[0].tb3Value;
                                    tb4.Text = refData[0].tb4Value;
                                    tb5.Text = refData[0].tb5Value;
                                    tb6.Text = refData[0].tb6Value;
                                    tb7.Text = refData[0].tb7Value;
                                    tb8.Text = refData[0].tb8Value;
                                    if (tb9.Enabled)
                                        tb9.Text = refData[0].tb9Value;

                                    XtraMessageBox.Show("Справка «" + RefCaption + "» была успешно загружена!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
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
        }

        private void btnSaveRef_Click(object sender, EventArgs e)
        {
            CloseReference(false);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (Reference.reference.tbObject.Text != string.Empty)
            {
                var dialog = XtraMessageBox.Show("Сохранить справку об объекте?", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialog == DialogResult.Yes)
                {
                    CloseReference(true);
                    NavigationPanel.navigationPanel.navigation.SelectedPageIndex = 0;
                    CloseAllGroups();
                }
                else
                {
                    ControlPanel.controlPanel.navigation.SelectedPageIndex = 0;
                    NavigationPanel.navigationPanel.navigation.SelectedPageIndex = 0;
                    NavigationBar.navigationBar.NavigationMain.Groups["TaskGroup"].Expanded = true;
                    MainForm.mainForm.navigationBar.Enabled = true;
                    ClearReference();
                    CloseAllGroups();
                }
            }
            else
            {
                ControlPanel.controlPanel.navigation.SelectedPageIndex = 0;
                NavigationPanel.navigationPanel.navigation.SelectedPageIndex = 0;
                NavigationBar.navigationBar.NavigationMain.Groups["TaskGroup"].Expanded = true;
                MainForm.mainForm.navigationBar.Enabled = true;
                ClearReference();
                CloseAllGroups();
            }
        }

        public void CloseReference(bool AutoSave)
        {
            string NewCaption = "";

            if (IsRefOpen)
            {
                var refDialog = new ReferenceSaveDialog(RefCaption);
                if (refDialog.ShowDialog() == DialogResult.OK)
                {
                    NewCaption = refDialog.Caption;

                    List<ReferenceData> refData = new List<ReferenceData>();
                    refData.Add(new ReferenceData
                    {
                        tbObject = tbObject.Text,
                        tb1Value = tb1.Text,
                        tb2Value = tb2.Text,
                        tb3Value = tb3.Text,
                        tb4Value = tb4.Text,
                        tb5Value = tb5.Text,
                        tb6Value = tb6.Text,
                        tb7Value = tb7.Text,
                        tb8Value = tb8.Text,
                        tb9Value = tb9.Text
                    });

                    string json = JSON.Instance.ToJSON(refData);

                    try
                    {
                        using (var conn = new SQLiteConnection(MainForm.mainForm.connectionReferenceData))
                        {
                            conn.Open();
                            using (var comm = conn.CreateCommand())
                            {
                                comm.CommandText = "UPDATE Reference SET Caption = @Caption, LastEditDT = @LastEditDT, Body = @Body WHERE UserID = @UserID AND ID = @ID";
                                comm.Parameters.AddWithValue("@Caption", refDialog.Caption);
                                comm.Parameters.AddWithValue("@UserID", MainForm.mainForm.UserID);
                                comm.Parameters.AddWithValue("@ID", RefID);
                                comm.Parameters.AddWithValue("@LastEditDT", DateTime.Now);
                                comm.Parameters.AddWithValue("@Body", json);
                                comm.ExecuteNonQuery();
                            }
                            conn.Close();
                        }
                    }
                    catch (SQLiteException ex)
                    {
                        XtraMessageBox.Show(ex.Message.ToString());
                    }
                }
                else
                {
                    ControlPanel.controlPanel.navigation.SelectedPageIndex = 0;
                    NavigationPanel.navigationPanel.navigation.SelectedPageIndex = 0;
                    NavigationBar.navigationBar.NavigationMain.Groups["TaskGroup"].Expanded = true;
                    MainForm.mainForm.navigationBar.Enabled = true;
                    ClearReference();
                }
            }
            else
            {
                var refDialog = new ReferenceSaveDialog(RefCaption);
                if (refDialog.ShowDialog() == DialogResult.OK)
                {
                    List<ReferenceData> refData = new List<ReferenceData>();
                    refData.Add(new ReferenceData
                    {
                        tbObject = tbObject.Text,
                        tb1Value = tb1.Text,
                        tb2Value = tb2.Text,
                        tb3Value = tb3.Text,
                        tb4Value = tb4.Text,
                        tb5Value = tb5.Text,
                        tb6Value = tb6.Text,
                        tb7Value = tb7.Text,
                        tb8Value = tb8.Text,
                        tb9Value = tb9.Text
                    });

                    string json = JSON.Instance.ToJSON(refData);

                    try
                    {
                        using (var conn = new SQLiteConnection(MainForm.mainForm.connectionReferenceData))
                        {
                            conn.Open();
                            using (var comm = conn.CreateCommand())
                            {
                                comm.CommandText = "INSERT INTO Reference (Caption, UserID, CreateDT, Body) VALUES (@Caption, @UserID, @CreateDT, @Body)";
                                comm.Parameters.AddWithValue("@Caption", refDialog.Caption);
                                comm.Parameters.AddWithValue("@UserID", MainForm.mainForm.UserID);
                                comm.Parameters.AddWithValue("@CreateDT", DateTime.Now);
                                comm.Parameters.AddWithValue("@Body", json);
                                comm.ExecuteNonQuery();
                            }
                            conn.Close();
                        }
                    }
                    catch (SQLiteException ex)
                    {
                        XtraMessageBox.Show(ex.Message.ToString());
                    }
                }
                else
                {
                    ControlPanel.controlPanel.navigation.SelectedPageIndex = 0;
                    NavigationPanel.navigationPanel.navigation.SelectedPageIndex = 0;
                    NavigationBar.navigationBar.NavigationMain.Groups["TaskGroup"].Expanded = true;
                    MainForm.mainForm.navigationBar.Enabled = true;
                    ClearReference();
                }
            }

            if (AutoSave)
            {
                ClearReference();
            }
            else
            {
                XtraMessageBox.Show("Справка «" + NewCaption + "» была успешно сохранена!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void ClearReference()
        {
            tbObject.Text = string.Empty;
            tb1.Text = string.Empty;
            tb2.Text = string.Empty;
            tb3.Text = string.Empty;
            tb4.Text = string.Empty;
            tb5.Text = string.Empty;
            tb6.Text = string.Empty;
            tb7.Text = string.Empty;
            tb8.Text = string.Empty;
            tb9.Text = string.Empty;

            tbDocumentSerialNo.Text = string.Empty;
            dtDocumentDoneDT.Text = string.Empty;

            Flag = false;
            gc9.Enabled = false;
            tb9.Enabled = false;
            IsRefOpen = false;
            RefCaption = string.Empty;
            RefID = 0;
        }
        #endregion
        #region "Progress bar controls"
        private void tb1_EditValueChanged(object sender, EventArgs e)
        {
            int i = tb1.Text.Length;
            pbTb1.EditValue = i;
        }

        private void tb2_EditValueChanged(object sender, EventArgs e)
        {
            int i = tb2.Text.Length;
            pbTb2.EditValue = i;
        }

        private void tb3_EditValueChanged(object sender, EventArgs e)
        {
            int i = tb3.Text.Length;
            pbTb3.EditValue = i;
        }

        private void tb4_EditValueChanged(object sender, EventArgs e)
        {
            int i = tb4.Text.Length;
            pbTb4.EditValue = i;
        }

        private void tb5_EditValueChanged(object sender, EventArgs e)
        {
            int i = tb5.Text.Length;
            pbTb5.EditValue = i;
        }

        private void tb6_EditValueChanged(object sender, EventArgs e)
        {
            int i = tb6.Text.Length;
            pbTb6.EditValue = i;
        }

        private void tb7_EditValueChanged(object sender, EventArgs e)
        {
            int i = tb7.Text.Length;
            pbTb7.EditValue = i;
        }

        private void tb8_EditValueChanged(object sender, EventArgs e)
        {
            int i = tb8.Text.Length;
            pbTb8.EditValue = i;
        }

        private void tb9_EditValueChanged(object sender, EventArgs e)
        {
            int i = tb9.Text.Length;
            pbTb9.EditValue = i;
        }
        #endregion
        #region "Load User Settings"
        public void LoadUserSettings()
        {
            tbDocumentAuthor.Text = UserSettings.SettingsList[0].UserName.Substring(0, 1) + "." + UserSettings.SettingsList[0].UserSecondName.Substring(0, 1) + ". " + UserSettings.SettingsList[0].UserSurname;
            tbDocumentWorkStation.Text = UserSettings.SettingsList[0].UserComputer;
            tbDocumentAuthorPhone.Text = UserSettings.SettingsList[0].UserPhone;
        }
        #endregion
        #region "Division Controls"
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (tbDivision2.Visible == false)
            {
                tbDivision2.Visible = true; tbDivision2.Enabled = true;
                btnRemove2.Visible = true; btnRemove2.Enabled = true;
            }
            else if (tbDivision2.Visible == true && tbDivision3.Visible == false)
            {
                tbDivision3.Visible = true; tbDivision3.Enabled = true;
                btnRemove3.Visible = true; btnRemove3.Enabled = true;

                btnRemove2.Visible = false; btnRemove2.Enabled = false;
            }
            else if (tbDivision3.Visible == true && tbDivision4.Visible == false)
            {
                tbDivision4.Visible = true; tbDivision4.Enabled = true;
                btnRemove4.Visible = true; btnRemove4.Enabled = true;

                btnRemove3.Visible = false; btnRemove3.Enabled = false;
            }
            else if (tbDivision4.Visible == true && tbDivision5.Visible == false)
            {
                tbDivision5.Visible = true; tbDivision5.Enabled = true;
                btnRemove5.Visible = true; btnRemove5.Enabled = true;

                btnRemove4.Visible = false; btnRemove4.Enabled = false;
            }
        }

        private void btnRemove2_Click(object sender, EventArgs e)
        {
            tbDivision2.Visible = false; tbDivision2.Enabled = false; tbDivision2.Text = string.Empty;
            btnRemove2.Visible = false; btnRemove2.Enabled = false;
        }

        private void btnRemove3_Click(object sender, EventArgs e)
        {
            tbDivision3.Visible = false; tbDivision3.Enabled = false; tbDivision3.Text = string.Empty;
            btnRemove3.Visible = false; btnRemove3.Enabled = false;

            btnRemove2.Visible = true; btnRemove2.Enabled = true;
        }

        private void btnRemove4_Click(object sender, EventArgs e)
        {
            tbDivision4.Visible = false; tbDivision4.Enabled = false; tbDivision4.Text = string.Empty;
            btnRemove4.Visible = false; btnRemove4.Enabled = false;

            btnRemove3.Visible = true; btnRemove3.Enabled = true;
        }

        private void btnRemove5_Click(object sender, EventArgs e)
        {
            tbDivision5.Visible = false; tbDivision5.Enabled = false; tbDivision5.Text = string.Empty;
            btnRemove5.Visible = false; btnRemove5.Enabled = false;

            btnRemove4.Visible = true; btnRemove4.Enabled = true;
        }
        #endregion
        #region "Load Apporve List"
        public void LoadApproveList()
        {
            approving.Clear();
            lbApproved.Items.Clear();

            try
            {
                using (var conn = new SQLiteConnection(MainForm.mainForm.connectionReferenceData))
                {
                    conn.Open();
                    using (var comm = conn.CreateCommand())
                    {
                        comm.CommandText = "SELECT * FROM Approving";
                        using (var dr = comm.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                approving.Add(new Approving
                                {
                                    ID = Convert.ToInt32(dr["ID"].ToString()),
                                    Surname = dr["Surname"].ToString(),
                                    Name = dr["Name"].ToString(),
                                    SecondName = dr["SecondName"].ToString(),
                                    Position = dr["Position"].ToString(),
                                    Title = dr["Title"].ToString(),
                                    Division = dr["Division"].ToString(),
                                    Service = dr["Service"].ToString(),
                                    Line = dr["Line"].ToString()
                                });
                            }

                            foreach (var item in approving)
                            {
                                lbApproved.Items.Add(item.Value);
                            }
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

        public static string ToUpper(string input)
        {
            if (String.IsNullOrEmpty(input))
            {
                //throw new ArgumentException("");
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

        public class Approving
        {
            public int ID { get; set; }
            public string Surname { get; set; }
            public string Name { get; set; }
            public string SecondName { get; set; }
            public string Position { get; set; }
            public string Title { get; set; }
            public string Division { get; set; }
            public string Service { get; set; }
            public string Line { get; set; }

            public string Value
            {
                get
                {
                    if (Line != string.Empty)
                    {
                        return string.Format("{0} {1} {2} {3} {4} {5}.{6}. {7}", ToUpper(Position), Line, Service, Division, Title, Name.Substring(0, 1), SecondName.Substring(0, 1), Surname);
                    }
                    else
                    {
                        return string.Format("{0} {1} {2} {3} {4}.{5}. {6}", ToUpper(Position), Service, Division, Title, Name.Substring(0, 1), SecondName.Substring(0, 1), Surname);
                    }
                }
            }
        }
        #endregion
        #region "Open First Block"
        public void OpenFirstGroup()
        {
            groupBoxes.Clear();
            groupBoxes.Add(new GroupBoxes { control = gc1 });
            foreach (var group in groupBoxes)
            {
                if (group.control.CustomHeaderButtons[0].Properties.Caption == "Развернуть")
                {
                    group.control.CustomHeaderButtons[0].Properties.Caption = "Свернуть";
                    group.control.CustomHeaderButtons[0].Properties.Image = Properties.Resources.DrillUp;
                }

                if (group.control.Name == "gc1")
                    gc1Expended = true;

                group.control.Height = 380;
            }
            tb1.Focus();
        }

        private void CloseAllGroups()
        {
            groupBoxes.Clear();
            groupBoxes.Add(new GroupBoxes { control = gc1 });
            groupBoxes.Add(new GroupBoxes { control = gc2 });
            groupBoxes.Add(new GroupBoxes { control = gc3 });
            groupBoxes.Add(new GroupBoxes { control = gc4 });
            groupBoxes.Add(new GroupBoxes { control = gc5 });
            groupBoxes.Add(new GroupBoxes { control = gc6 });
            groupBoxes.Add(new GroupBoxes { control = gc7 });
            groupBoxes.Add(new GroupBoxes { control = gc8 });
            if (Flag)
                groupBoxes.Add(new GroupBoxes { control = gc9 });

            foreach (var group in groupBoxes)
            {
                if (group.control.CustomHeaderButtons[0].Properties.Caption == "Свернуть")
                {
                    group.control.CustomHeaderButtons[0].Properties.Caption = "Развернуть";
                    group.control.CustomHeaderButtons[0].Properties.Image = Properties.Resources.DrillDown;
                }

                if (group.control.Name == "gc1")
                    gc1Expended = false;
                else if (group.control.Name == "gc2")
                    gc2Expended = false;
                else if (group.control.Name == "gc3")
                    gc3Expended = false;
                else if (group.control.Name == "gc4")
                    gc4Expended = false;
                else if (group.control.Name == "gc5")
                    gc5Expended = false;
                else if (group.control.Name == "gc6")
                    gc6Expended = false;
                else if (group.control.Name == "gc7")
                    gc7Expended = false;
                else if (group.control.Name == "gc8")
                    gc8Expended = false;
                else if (group.control.Name == "gc9")
                    gc9Expended = false;

                group.control.Height = 23;
            }
            chbOneInSection.Checked = false;
            chbOpenAll.Checked = false;
        }
        #endregion
        #region "User & Head Division Helper"
        class DivisionHelper
        {
            public string UserOffice { get; set; }
            public string UserDepartment { get; set; }
            public string UserLine { get; set; }
            public string UserService { get; set; }
            public string UserDivision { get; set; }

            public string Office
            {
                get
                {
                    if (UserOffice != string.Empty)
                        return UserOffice + " ";
                    else
                        return string.Empty;
                }
            }
            public string Department
            {
                get
                {
                    if (UserDepartment != string.Empty)
                        return UserDepartment + " ";
                    else
                        return string.Empty;
                }
            }
            public string Line
            {
                get
                {
                    if (UserLine != string.Empty)
                        return UserLine + " ";
                    else
                        return string.Empty;
                }
            }
            public string Service
            {
                get
                {
                    if (UserService != string.Empty)
                        return UserService + " ";
                    else
                        return string.Empty;
                }
            }
            public string Division
            {
                get
                {
                    if (UserDivision != string.Empty)
                        return UserDivision;
                    else
                        return string.Empty;
                }
            }
        }
        #endregion

        public class ReferenceData
        {
            public string tbObject { get; set; }
            public string tb1Value { get; set; }
            public string tb2Value { get; set; }
            public string tb3Value { get; set; }
            public string tb4Value { get; set; }
            public string tb5Value { get; set; }
            public string tb6Value { get; set; }
            public string tb7Value { get; set; }
            public string tb8Value { get; set; }
            public string tb9Value { get; set; }
        }

        #region "Begin DocX & QR"
        public void InsertDocX(int Current, int Total)
        {
            List<DivisionHelper> division = new List<DivisionHelper>();
            division.Add(new DivisionHelper
            {
                UserOffice = UserSettings.SettingsList[0].UserOffice,
                UserDepartment = UserSettings.SettingsList[0].UserDepartment,
                UserLine = UserSettings.SettingsList[0].UserLine,
                UserService = UserSettings.SettingsList[0].UserService,
                UserDivision = UserSettings.SettingsList[0].UserDivision
            });

            string Template = "";
            if (Flag)
                Template = Application.StartupPath + "\\Data\\Templates\\tpreference.docx";
            else
                Template = Application.StartupPath + "\\Data\\Templates\\treference.docx";

            using (var document = new Spire.Doc.Document(Template, FileFormat.Docx))
            {
                document.Replace("{0}", tbObject.Text.Trim(), false, false);
                document.Replace("{1}", tb1.Text.Trim(), false, false);
                document.Replace("{2}", tb2.Text.Trim(), false, false);
                document.Replace("{3}", tb3.Text.Trim(), false, false);
                document.Replace("{4}", tb4.Text.Trim(), false, false);
                document.Replace("{5}", tb5.Text.Trim(), false, false);
                document.Replace("{6}", tb6.Text.Trim(), false, false);
                document.Replace("{7}", tb7.Text.Trim(), false, false);
                document.Replace("{8}", tb8.Text.Trim(), false, false);
                document.Replace("{9}", tb9.Text.Trim(), false, false);
                document.Replace("{10}", tbDocumentPrivacyRank.Text.Trim(), false, false);
                document.Replace("{11}", tbDocumentOrderNo.Text.Trim(), false, false);
                document.Replace("{13}", tbDocumentSerialNo.Text.Trim(), false, false);
                if (Total == 1)
                    document.Replace("{12}", "единств.", false, false);
                else
                    document.Replace("{12}", Current.ToString(), false, false);

                document.Replace("{UserPosition}", ToUpper(UserSettings.SettingsList[0].UserPosition), false, false);
                document.Replace("{UserDivision}", string.Format("{0} {1}", division[0].UserService, division[0].UserDivision), false, false);
                document.Replace("{UserTitle}", UserSettings.SettingsList[0].UserTitle, false, false);
                document.Replace("{UserFullName}", string.Format("{0}.{1}. {2}", UserSettings.SettingsList[0].UserName.Substring(0, 1), UserSettings.SettingsList[0].UserSecondName.Substring(0, 1), UserSettings.SettingsList[0].UserSurname), false, false);

                int i = 1;
                foreach (var item in approving)
                {
                    document.Replace("{HeadTitle" + i + "}", item.Title, false, false);
                    document.Replace("{HeadDivision" + i + "}", string.Format("{0} {1}", item.Service, item.Division), false, false);
                    document.Replace("{HeadPosition" + i + "}", ToUpper(item.Position), false, false);
                    document.Replace("{HeadFullName" + i + "}", string.Format("{0}.{1}. {2}", item.Name.Substring(0, 1), item.SecondName.Substring(0, 1), item.Surname), false, false);
                    i++;
                }

                Table t = (Table)document.Sections[0].Tables[1];
                int count = t.Rows.Count;
                for (int j = i; j < count; j++)
                {
                    t.Rows.Remove(t.Rows[t.Rows.Count - 1]);
                }

                document.SaveToFile(Application.StartupPath + "\\Temp\\tmp.docx");
            }

            //using (var document = DocX.Load(Template))
            //{
            //    document.ReplaceText("{0}", tbObject.Text.Trim());
            //    document.ReplaceText("{1}", tb1.Text.Trim());
            //    document.ReplaceText("{2}", tb2.Text.Trim());
            //    document.ReplaceText("{3}", tb3.Text.Trim());
            //    document.ReplaceText("{4}", tb4.Text.Trim());
            //    document.ReplaceText("{5}", tb5.Text.Trim());
            //    document.ReplaceText("{6}", tb6.Text.Trim());
            //    document.ReplaceText("{7}", tb7.Text.Trim());
            //    document.ReplaceText("{8}", tb8.Text.Trim());
            //    document.ReplaceText("{9}", tb9.Text.Trim());
            //    document.ReplaceText("{10}", tbDocumentPrivacyRank.Text.Trim());
            //    document.ReplaceText("{11}", tbDocumentOrderNo.Text.Trim());
            //    document.ReplaceText("{13}", tbDocumentSerialNo.Text.Trim());
            //    if (Total == 1)
            //        document.ReplaceText("{12}", "единств.");
            //    else
            //        document.ReplaceText("{12}", Current.ToString());

            //    document.ReplaceText("{UserPosition}", ToUpper(UserSettings.SettingsList[0].UserPosition));
            //    document.ReplaceText("{UserDivision}", string.Format("{0} {1}", division[0].UserService, division[0].UserDivision));
            //    document.ReplaceText("{UserTitle}", UserSettings.SettingsList[0].UserTitle);
            //    document.ReplaceText("{UserFullName}", string.Format("{0}.{1}. {2}", UserSettings.SettingsList[0].UserName.Substring(0, 1), UserSettings.SettingsList[0].UserSecondName.Substring(0, 1), UserSettings.SettingsList[0].UserSurname));

            //    int i = 1;
            //    foreach (var item in approving)
            //    {
            //        document.ReplaceText("{HeadTitle" + i + "}", item.Title);
            //        document.ReplaceText("{HeadDivision" + i + "}", string.Format("{0} {1}", item.Service, item.Division));
            //        document.ReplaceText("{HeadPosition" + i + "}", ToUpper(item.Position));
            //        document.ReplaceText("{HeadFullName" + i + "}", string.Format("{0}.{1}. {2}", item.Name.Substring(0, 1), item.SecondName.Substring(0, 1), item.Surname));
            //        i++;
            //    }

            //    int count = document.Tables[1].RowCount;
            //    for (int j = i; j < count; j++)
            //    {
            //        document.Tables[1].RemoveRow(document.Tables[1].RowCount - 1);
            //    }

            //    document.SaveAs(Application.StartupPath + "\\Temp\\tmp.docx");
            //}
        }

        public void CreateReferenceDocument()
        {
            using (var document = new Spire.Doc.Document(Application.StartupPath + "\\Data\\Templates\\lastpage.docx", FileFormat.Docx))
            {
                Spire.Doc.Fields.TextBox textbox = document.TextBoxes[0];
                List<DivisionHelper> userDivision = new List<DivisionHelper>();
                userDivision.Add(new DivisionHelper
                {
                    UserOffice = UserSettings.SettingsList[0].UserOffice,
                    UserDepartment = UserSettings.SettingsList[0].UserDepartment,
                    UserLine = UserSettings.SettingsList[0].UserLine,
                    UserService = UserSettings.SettingsList[0].UserService,
                    UserDivision = UserSettings.SettingsList[0].UserDivision
                });

                document.Replace("{0}", tbDocumentSerialNo.Text, false, false);
                if (TotalDivisions == 1)
                    document.Replace("{1}", "единств.", false, false);
                else
                    document.Replace("{1}", TotalDivisions.ToString(), false, false);

                document.Replace("{2}", tbDocumentWorkStation.Text, false, false);
                document.Replace("{3}", tbDocumentAuthor.Text, false, false);
                document.Replace("{4}", string.Format("{0}{1}{2}{3}{4}", userDivision[0].Office, userDivision[0].Department, userDivision[0].Line, userDivision[0].Service, userDivision[0].Division), false, false);
                document.Replace("{5}", tbDocumentAuthorPhone.Text, false, false);
                document.Replace("{6}", dtDocumentDoneDT.Text, false, false);
                if (tbDivision1.Visible == true && tbDivision1.Text != string.Empty)
                {
                    document.Replace("{101}", "1 - в " + tbDivision1.Text.Trim(), false, false);
                }
                else
                {
                    document.Replace("{101}", string.Empty.Trim(), false, false);
                }
                if (tbDivision2.Visible == true && tbDivision2.Text != string.Empty)
                {
                    document.Replace("{102}", "2 - в " + tbDivision2.Text.Trim(), false, false);
                }
                else
                {
                    document.Replace("{102}", string.Empty.Trim(), false, false);
                    textbox.Body.Paragraphs.RemoveAt(TotalDivisions + 1);
                }
                if (tbDivision3.Visible == true && tbDivision3.Text != string.Empty)
                {
                    document.Replace("{103}", "3 - в " + tbDivision3.Text.Trim(), false, false);
                }
                else
                {
                    document.Replace("{103}", string.Empty.Trim(), false, false);
                    textbox.Body.Paragraphs.RemoveAt(TotalDivisions + 1);
                }
                if (tbDivision4.Visible == true && tbDivision4.Text != string.Empty)
                {
                    document.Replace("{104}", "4 - в " + tbDivision4.Text.Trim(), false, false);
                }
                else
                {
                    document.Replace("{104}", string.Empty.Trim(), false, false);
                    textbox.Body.Paragraphs.RemoveAt(TotalDivisions + 1);
                }
                if (tbDivision5.Visible == true && tbDivision4.Text != string.Empty)
                {
                    document.Replace("{105}", "5 - в " + tbDivision5.Text.Trim(), false, false);
                }
                else
                {
                    document.Replace("{105}", string.Empty.Trim(), false, false);
                    textbox.Body.Paragraphs.RemoveAt(TotalDivisions + 1);
                }

                CreateQrText();

                int k = 0; int l = 0;
                foreach (System.Drawing.Bitmap Img in img)
                {
                    using (var ms = new MemoryStream())
                    {
                        Img.Save(ms, ImageFormat.Png);
                        ms.Position = 0;
                        Table t = (Table)document.Sections[0].Tables[0];
                        DocPicture picture = t.Rows[k].Cells[l].Paragraphs[0].AppendPicture(ms.ToArray());
                        picture.Width = 120;
                        picture.Height = 120;

                        if (l == 2)
                        {
                            k++;
                            l = -1;
                        }
                        l++;
                    }
                }

                document.SaveToFile(Application.StartupPath + "\\Temp\\tmp2.docx", FileFormat.Docx);
            }
        }

        public int TotalDivisions
        {
            get
            {
                var pageCount = new List<PageCount>();
                pageCount.Add(new PageCount { control = tbDivision1 });
                pageCount.Add(new PageCount { control = tbDivision2 });
                pageCount.Add(new PageCount { control = tbDivision3 });
                pageCount.Add(new PageCount { control = tbDivision4 });
                pageCount.Add(new PageCount { control = tbDivision5 });
                return pageCount.Count(x => x.control.Text != string.Empty);
            }
        }

        class PageCount
        {
            public BaseEdit control { get; set; }
        }

        private void CreateQrText()
        {
            string text = "";

            text += "#R#" + tb1.Text.Trim() + Environment.NewLine + "#R#"; // Установочные данные фигуранта
            text += "#T#" + tb2.Text.Trim() + Environment.NewLine + "#T#"; // Роль объекта в оперативной разработке, состав совершенного преступления, квалификация
            text += "#Y#" + tb3.Text.Trim() + Environment.NewLine + "#Y#"; // Объект преступного посягательства
            text += "#U#" + tb4.Text.Trim() + Environment.NewLine + "#U#"; // Способ совершения преступления
            text += "#I#" + tb5.Text.Trim() + Environment.NewLine + "#I#"; // Связи объекта
            text += "#O#" + tb6.Text.Trim() + Environment.NewLine + "#O#"; // Принадлежность абонентского номера
            text += "#P#" + tb7.Text.Trim() + Environment.NewLine + "#P#"; // Принадлежность объекта к спец. субъектам
            text += "#A#" + tb8.Text.Trim() + Environment.NewLine + "#A#"; // Результативная часть
            text += "#S#" + tb9.Text.Trim() + Environment.NewLine + "#S#"; // Целесообразность продления

            List<string> list = Split(text, 1100).ToList<string>();
            for (int i = 0; i < list.Count; i++)
            {
                list[i] = Base64Encode((i + 1) + " " + list.Count + Environment.NewLine + " Reference" + Environment.NewLine + list[i]);
            }

            img = new List<Bitmap>();
            QRCodeWriter qrEncode = new QRCodeWriter(); //создание QR кода
            BarcodeWriter qrWrite = new BarcodeWriter(); //класс для кодирования QR в растровом файле
            foreach (string s in list)
            {
                BitMatrix qrMatrix = qrEncode.encode(s, BarcodeFormat.QR_CODE, 2000, 2000);
                Bitmap b = qrWrite.Write(qrMatrix);
                img.Add(b);
            }
        }

        public static IEnumerable<string> Split(string s, int length)
        {
            int i;
            for (i = 0; i + length < s.Length; i += length)
                yield return s.Substring(i, length);
            if (i != s.Length)
                yield return s.Substring(i, s.Length - i);
        }

        public static string Base64Encode(string plainText)
        {
            return System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(plainText));
        }
        #endregion

        private void btnAddApprove_Click(object sender, EventArgs e)
        {
            if (lbApproved.Items.Count < 4)
            {
                var addNew = new ReferenceApprove();
                addNew.ShowDialog();
            }
            else
            {
                XtraMessageBox.Show("Нельзя добавить больше 4 согласующих!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRemoveApprove_Click(object sender, EventArgs e)
        {
            if (lbApproved.SelectedIndex != -1)
            {
                var dialog = XtraMessageBox.Show("Вы действительно хотите удалить выбранного согласующего?", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialog == DialogResult.Yes)
                {
                    int SelectedIndex = lbApproved.SelectedIndex;
                    int ID = approving[SelectedIndex].ID;

                    try
                    {
                        using (var conn = new SQLiteConnection(MainForm.mainForm.connectionReferenceData))
                        {
                            conn.Open();
                            using (var comm = conn.CreateCommand())
                            {
                                comm.CommandText = "DELETE FROM Approving WHERE ID = @ID";
                                comm.Parameters.AddWithValue("@ID", ID);
                                comm.ExecuteNonQuery();
                            }
                            conn.Close();
                        }
                    }
                    catch (SQLiteException ex)
                    {
                        XtraMessageBox.Show(ex.Message.ToString());
                    }

                    LoadApproveList();
                }
            }
        }
    }
}
