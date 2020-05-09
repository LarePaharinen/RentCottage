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
    public partial class AddCottageForm : Form
    {
        public AddCottageForm()
        {
            InitializeComponent();
            RegionUtils.populateCBRegion(cbAddCottageRegion);
        }

        private void btnAddCottageAdd_Click(object sender, EventArgs e)
        {
            //Add a cottage to the database, gets data from form components
            try
            {
                PostUtils.checkPostal(tbAddCottagePostNum.Text, tbAddCottagePostRegion.Text);
                string query = "START TRANSACTION; " +
                    "INSERT INTO mokki(mokki_id,toimintaalue_id,postinro,mokkinimi,katuosoite,kuvaus,henkilomaara,varustelu,hinta) " +
                    "VALUES(default," +
                    RegionUtils.regionNameToIndex(cbAddCottageRegion.Text) + ",'" +
                    TextBoxUtils.modifyInput(tbAddCottagePostNum.Text, 5) + "','" +
                    TextBoxUtils.modifyInput(tbAddCottageName.Text, 45) + "','" +
                    TextBoxUtils.modifyInput(tbAddCottageStreet.Text, 45) + "','" +
                    TextBoxUtils.modifyInput(tbAddCottageDescription.Text, 500) + "'," +
                    (int)nudAddCottageCapacity.Value + ",'" +
                    TextBoxUtils.modifyInput(tbAddCottageEquipment.Text, 100) + "'," +
                    (double)nudAddCottagePrice.Value + "); " +
                    "COMMIT;";
                try
                {
                    ConnectionUtils.openConnection();
                    MySqlCommand command = new MySqlCommand(query, ConnectionUtils.connection);
                    command.ExecuteNonQuery();
                    ConnectionUtils.closeConnection();
                    this.Close();
                }
                catch (Exception ex)
                {
                    //Incase of connction problems
                    ConnectionUtils.closeConnection();
                    MessageBox.Show("Virhe tietojen syöttämisessä tietokantaan. Tarkista kenttien tiedot. Lisätietoja: " + ex.Message.ToString());
                }
            }
            catch (Exception ex)
            {
                //Incase of exceptions in variable conversion
                ConnectionUtils.closeConnection();
                MessageBox.Show("Virhe tietojen muuntamisessa. Tarkista kenttien tiedot. Lisätietoja: " + ex.Message.ToString());
            }
            
            
            
        }

        private void btnAddCottageCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
