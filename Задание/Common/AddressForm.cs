using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Задание
{
    public partial class AddressForm : DevExpress.XtraEditors.XtraForm
    {
        string Mode = "";

        public AddressForm(string param)
        {
            InitializeComponent();
            Mode = param;
        }

        private void AddressForm_Load(object sender, EventArgs e)
        {
            LoadCountries();
            GetData();
        }

        private void GetData()
        {
            if (Mode == "accessory")
            {
                if (Address.accessory.Count > 0)
                {
                    cbCountry.Text = Address.accessory[0].Country;
                    tbRegion.Text = Address.accessory[0].Region;
                    tbCity.Text = Address.accessory[0].City;
                    tbStreet.Text = Address.accessory[0].Street;
                    tbHomeNo.Text = Address.accessory[0].Home;
                    tbHomePart.Text = Address.accessory[0].Housing;
                    tbHomePartNo.Text = Address.accessory[0].Part;
                    tbRoomNo.Text = Address.accessory[0].Room;
                }
            }
            else if (Mode == "work")
            {
                if (Address.work.Count > 0)
                {
                    cbCountry.Text = Address.work[0].Country;
                    tbRegion.Text = Address.work[0].Region;
                    tbCity.Text = Address.work[0].City;
                    tbStreet.Text = Address.work[0].Street;
                    tbHomeNo.Text = Address.work[0].Home;
                    tbHomePart.Text = Address.work[0].Housing;
                    tbHomePartNo.Text = Address.work[0].Part;
                    tbRoomNo.Text = Address.work[0].Room;
                }
            }
            else if (Mode == "home")
            {
                if (Address.home.Count > 0)
                {
                    cbCountry.Text = Address.home[0].Country;
                    tbRegion.Text = Address.home[0].Region;
                    tbCity.Text = Address.home[0].City;
                    tbStreet.Text = Address.home[0].Street;
                    tbHomeNo.Text = Address.home[0].Home;
                    tbHomePart.Text = Address.home[0].Housing;
                    tbHomePartNo.Text = Address.home[0].Part;
                    tbRoomNo.Text = Address.home[0].Room;
                }
            }
        }

        private void LoadCountries()
        {
            if (!File.Exists("Data\\Countries.xml"))
            {
                XtraMessageBox.Show("Отсутствует файл базы данных, обратитесь к разработчику!", "Критическая ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    DataSet ds = new DataSet();
                    ds.ReadXml("Data\\Countries.xml");

                    foreach (DataRow item in ds.Tables[1].Rows)
                    {
                        cbCountry.Properties.Items.Add(item[1].ToString());
                    }
                }
                catch (System.Security.SecurityException ex)
                {
                    XtraMessageBox.Show(ex.Message.ToString());
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            if (Mode == "accessory")
            {
                Address.accessory.Clear();

                Address.accessory.Add(new Address.Accessory 
                { 
                    Country = cbCountry.Text, 
                    City = tbCity.Text,
                    Region = tbRegion.Text, 
                    Street = tbStreet.Text, 
                    Home = tbHomeNo.Text, 
                    Housing = tbHomePart.Text, 
                    Part = tbHomePartNo.Text, 
                    Room = tbRoomNo.Text 
                });
            }
            else if (Mode == "work")
            {
                Address.work.Clear();

                Address.work.Add(new Address.Accessory
                {
                    Country = cbCountry.Text,
                    City = tbCity.Text,
                    Region = tbRegion.Text,
                    Street = tbStreet.Text,
                    Home = tbHomeNo.Text,
                    Housing = tbHomePart.Text,
                    Part = tbHomePartNo.Text,
                    Room = tbRoomNo.Text
                });
            }
            else if (Mode == "home")
            {
                Address.home.Clear();

                Address.home.Add(new Address.Accessory
                {
                    Country = cbCountry.Text,
                    City = tbCity.Text,
                    Region = tbRegion.Text,
                    Street = tbStreet.Text,
                    Home = tbHomeNo.Text,
                    Housing = tbHomePart.Text,
                    Part = tbHomePartNo.Text,
                    Room = tbRoomNo.Text
                });
            }

            this.DialogResult = System.Windows.Forms.DialogResult.Yes;
        }
    }
}
