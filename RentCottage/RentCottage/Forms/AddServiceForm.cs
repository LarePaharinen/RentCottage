using MySql.Data.MySqlClient;
using RentCottage.Code;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentCottage.Forms
{
    public partial class AddServiceForm : Form
    {
        public AddServiceForm()
        {
            InitializeComponent();
            RegionUtils.PopulateCBRegion(cbAddServiceRegion);
        }

        private void btnAddServiceCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddServiceAdd_Click(object sender, EventArgs e)
        {
            
            string query = "START TRANSACTION; " +
                "INSERT INTO palvelu(palvelu_id,toimintaalue_id,nimi,tyyppi,kuvaus,hinta,alv) " +
                "VALUES(default," +
                RegionUtils.RegionNameToIndex(cbAddServiceRegion.Text) + ",'" +
                tbAddServiceName.Text + "'," +
                Convert.ToInt32(tbAddServiceType.Text) + ",'" +
                tbAddServiceDescription.Text + "'," +
                Convert.ToDouble(tbAddServicePrice.Text) + "," +
                Convert.ToDouble(tbAddServiceVAT.Text) + "); " +
                "COMMIT;";
            try
            {
                //Adds service to the DB
                ConnectionUtils.openConnection();
                MySqlCommand command = new MySqlCommand(query, ConnectionUtils.connection);
                command.ExecuteNonQuery();
                ConnectionUtils.closeConnection();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
