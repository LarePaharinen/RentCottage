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
            try
            {
                //Add a service to the database, gets data from form components
                string query = "START TRANSACTION; " +
                "INSERT INTO palvelu(palvelu_id,toimintaalue_id,nimi,tyyppi,kuvaus,hinta,alv) " +
                "VALUES(default," +
                RegionUtils.RegionNameToIndex(cbAddServiceRegion.Text) + ",'" +
                TextBoxUtils.ModifyInput(tbAddServiceName.Text, 40) + "'," +
                Convert.ToInt32(tbAddServiceType.Text) + ",'" +
                TextBoxUtils.ModifyInput(tbAddServiceDescription.Text, 500) + "'," +
                (double)nudAddServicePrice.Value + "," +
                (double)nudAddServiceVAT.Value + "); " +
                "COMMIT;";

                try
                {
                    ConnectionUtils.OpenConnection();
                    MySqlCommand command = new MySqlCommand(query, ConnectionUtils.connection);
                    command.ExecuteNonQuery();
                    ConnectionUtils.CloseConnection();
                    this.Close();
                }
                catch (Exception ex)
                {
                    //Incase of database-connection problems
                    ConnectionUtils.CloseConnection();
                    MessageBox.Show("Virhe tietojen syöttämisessä tietokantaan. Tarkista kenttien tiedot. Lisätietoja: " + ex.Message.ToString());
                }
            }
            catch (Exception ex)
            {
                //Incase of variable conversion problems
                ConnectionUtils.CloseConnection();
                MessageBox.Show("Virhe tietojen muuntamisessa. Tarkista kenttien tiedot. Lisätietoja: " + ex.Message.ToString());
            }
            
        }
    }
}
