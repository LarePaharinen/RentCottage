using MySql.Data.MySqlClient;
using RentCottage.Code;
using System;
using System.Windows.Forms;

namespace RentCottage.Forms
{
    public partial class AddCottageForm : Form
    {
        public AddCottageForm()
        {
            InitializeComponent();
            RegionUtils.PopulateCBRegion(cbAddCottageRegion);
            cbAddCottageEquipment.Text = "Hyvä";
        }

        private void btnAddCottageAdd_Click(object sender, EventArgs e)
        {
            //Add a cottage to the database, gets data from form components
            try
            {
                PostUtils.CheckPostal(tbAddCottagePostNum.Text, tbAddCottagePostRegion.Text);
                string query = "START TRANSACTION; " +
                    "INSERT INTO mokki(mokki_id,toimintaalue_id,postinro,mokkinimi,katuosoite,kuvaus,henkilomaara,varustelu,hinta) " +
                    "VALUES(default," +
                    RegionUtils.RegionNameToIndex(cbAddCottageRegion.Text) + ",'" +
                    TextBoxUtils.ModifyInput(tbAddCottagePostNum.Text, 5) + "','" +
                    TextBoxUtils.ModifyInput(tbAddCottageName.Text, 45) + "','" +
                    TextBoxUtils.ModifyInput(tbAddCottageStreet.Text, 45) + "','" +
                    TextBoxUtils.ModifyInput(tbAddCottageDescription.Text, 500) + "'," +
                    (int)nudAddCottageCapacity.Value + ",'" +
                    TextBoxUtils.ModifyInput(cbAddCottageEquipment.Text, 100) + "'," +
                    (double)nudAddCottagePrice.Value + "); " +
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
                    //Incase of connction problems
                    ConnectionUtils.CloseConnection();
                    MessageBox.Show("Virhe tietojen syöttämisessä tietokantaan. Tarkista kenttien tiedot. Lisätietoja: " + ex.Message.ToString());
                }
            }
            catch (Exception ex)
            {
                //Incase of exceptions in variable conversion
                ConnectionUtils.CloseConnection();
                MessageBox.Show("Virhe tietojen muuntamisessa. Tarkista kenttien tiedot. Lisätietoja: " + ex.Message.ToString());
            }
            
            
            
        }

        private void btnAddCottageCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
