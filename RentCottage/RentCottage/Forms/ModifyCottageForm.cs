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
            cbModifyCottageRegion.SelectedItem = RegionUtils.RegionIndexToName(c.RegionID);
            tbModifyCottagePostNum.Text = c.Postal;
            tbModifyCottageName.Text = c.Name;
            tbModifyCottageStreet.Text = c.Address;
            cbModifyCottageCapacity.Text = c.Capacity.ToString();
            tbModifyCottageEquipment.Text = c.Equipment;
            tbModifyCottagePrice.Text = c.Price.ToString();
            tbModifyCottageDescription.Text = c.Description;
        }

        private void btnModifyCottageModify_Click(object sender, EventArgs e)
        {
            //Make sure the data should be modified
            DialogResult result = MessageBox.Show("Haluatko varmasti muuttaa valitun mökin tietoja?", "Muuta mökin tietoja", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (result == DialogResult.Yes)
            {
                //Modifies the data
                string query = "START TRANSACTION; " +
                "UPDATE mokki " +
                "SET toimintaalue_id=" + RegionUtils.RegionNameToIndex(cbModifyCottageRegion.Text) + ",postinro='" + tbModifyCottagePostNum.Text +
                "',mokkinimi='" + tbModifyCottageName.Text + "',katuosoite='" + tbModifyCottageStreet.Text + "'," +
                "kuvaus='" + tbModifyCottageDescription.Text + "',henkilomaara=" + Convert.ToInt32(cbModifyCottageCapacity.Text) +
                " ,varustelu='"+ tbModifyCottageEquipment.Text + "', hinta=" + Convert.ToDouble(tbModifyCottagePrice.Text) + " " +
                "WHERE mokki_id=" + Convert.ToInt32(lblModifyCottageID.Text) + "; " +
                "COMMIT;";
                ConnectionUtils.openConnection();
                MySqlCommand command = new MySqlCommand(query, ConnectionUtils.connection);
                command.ExecuteNonQuery();
                ConnectionUtils.closeConnection();
                this.Close();
            }
        }

        private void btnModifyCottageCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
