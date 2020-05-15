using MySql.Data.MySqlClient;
using RentCottage.Code;
using System;
using System.Windows.Forms;

namespace RentCottage.Forms
{
    public partial class ModifyCottageForm : Form
    {
        public ModifyCottageForm()
        {
            InitializeComponent();

            RegionUtils.PopulateCBRegion(cbModifyCottageRegion);
        }

        public ModifyCottageForm(Cottage c)
        {
            //Used to import cottage data to form
            InitializeComponent();

            RegionUtils.PopulateCBRegion(cbModifyCottageRegion);            

            lblModifyCottageID.Text = c.CottageID.ToString();
            cbModifyCottageRegion.Text = RegionUtils.RegionIndexToName(c.RegionID);
            tbModifyCottagePostNum.Text = c.Postal;
            tbModifyCottageName.Text = c.Name;
            tbModifyCottageStreet.Text = c.Address;
            nudModifyCottageCapacity.Value = c.Capacity;
            cbModifyCottageEquipment.Text = c.Equipment;
            nudModifyCottagePrice.Value = (int)c.Price;
            tbModifyCottageDescription.Text = c.Description;
        }

        private void btnModifyCottageModify_Click(object sender, EventArgs e)
        {
            //Make sure the data should be modified
            DialogResult result = MessageBox.Show("Haluatko varmasti muuttaa valitun mökin tietoja?", "Muuta mökin tietoja", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (result == DialogResult.Yes)
            {
                try
                {
                    //Updates cottages information in the database. Gets data from form components, cottage is uniquely identified by cottageID, which can't be modified
                    string query = "START TRANSACTION; " +
                    "UPDATE mokki " +
                    "SET toimintaalue_id=" + RegionUtils.RegionNameToIndex(cbModifyCottageRegion.Text) +
                    ",postinro='" + TextBoxUtils.ModifyInput(tbModifyCottagePostNum.Text, 5) +
                    "',mokkinimi='" + TextBoxUtils.ModifyInput(tbModifyCottageName.Text, 45) +
                    "',katuosoite='" + TextBoxUtils.ModifyInput(tbModifyCottageStreet.Text, 45) + "'," +
                    "kuvaus='" + TextBoxUtils.ModifyInput(tbModifyCottageDescription.Text, 500) +
                    "',henkilomaara=" + nudModifyCottageCapacity.Value +
                    " ,varustelu='" + TextBoxUtils.ModifyInput(cbModifyCottageEquipment.Text, 100) +
                    "', hinta=" + Convert.ToDouble(nudModifyCottagePrice.Value) + " " +
                    "WHERE mokki_id=" + Convert.ToInt32(lblModifyCottageID.Text) + "; " +
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
                        MessageBox.Show("Virhe tietojen syöttämisessä tietokantaan. Tarkista kenttien tiedot, ja yritä uudelleen myöhemmin. Lisätietoja virheestä: "
                            + ex.Message.ToString());
                    }
                    
                }
                catch (Exception ex)
                {
                    //Incase of variable conversion problems
                    ConnectionUtils.CloseConnection();
                    MessageBox.Show("Virhe tietojen muuntamisessa. Onhan kaikkien kenttien syötteet oikein? Lisätietoja virheestä: " + ex.Message.ToString());
                }
                
            }
        }

        private void btnModifyCottageCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
