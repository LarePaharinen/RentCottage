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
            RegionUtils.PopulateCBRegion(cbAddCottageRegion);
        }

        //Add cottage to the database
        private void btnAddCottageAdd_Click(object sender, EventArgs e)
        {   
            PostUtils.checkPostal(tbAddCottagePostNum.Text, tbAddCottagePostRegion.Text);
            string query = "START TRANSACTION; " +
                "INSERT INTO mokki(mokki_id,toimintaalue_id,postinro,mokkinimi,katuosoite,kuvaus,henkilomaara,varustelu,hinta) " +
                "VALUES(default," + 
                RegionUtils.RegionNameToIndex(cbAddCottageRegion.Text) + "," + 
                int.Parse(tbAddCottagePostNum.Text) +",'" + 
                tbAddCottageName.Text + "','" + 
                tbAddCottageStreet.Text + "','" + 
                tbAddCottageDescription.Text + "'," + 
                cbAddCottageCapacity.Text + ",'" + 
                tbAddCottageEquipment.Text + "'," + 
                int.Parse(tbAddCottagePrice.Text) + "); " +
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
                MessageBox.Show(ex.Message);
            }
            
            
        }

        private void btnAddCottageCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
