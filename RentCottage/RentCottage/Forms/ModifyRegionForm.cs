using MySql.Data.MySqlClient;
using RentCottage.Code;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentCottage.Forms
{
    public partial class ModifyRegionForm : Form
    {
        public ModifyRegionForm()
        {
            InitializeComponent();
        }

        public ModifyRegionForm(Code.Region region)
        {
            InitializeComponent();
            lblRegionModifyRegionID.Text = region.RegionID.ToString();
            tbRegionModifyRegionName.Text = region.Name;
        }

        private void btnRegionModifyModify_Click(object sender, EventArgs e)
        {
            //Make sure the data should be modified
            DialogResult result = MessageBox.Show("Haluatko varmasti muuttaa valitun toiminta-alueen nimeä?", "Muuta toiminta-alueen nimeä",
                MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (result == DialogResult.Yes)
            {
                try
                {
                    //Updates regions information in the database. Gets data from form components, region is uniquely identified by regionID, which can't be modified
                    string query = "START TRANSACTION; " +
                    "UPDATE toimintaalue " +
                    "SET nimi='" + TextBoxUtils.ModifyInput(tbRegionModifyRegionName.Text, 40) + "' " +
                    "WHERE toimintaalue_id=" + Convert.ToInt32(TextBoxUtils.ModifyInput(lblRegionModifyRegionID.Text, 11)) + "; " +
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
                        MessageBox.Show("Virhe tietojen syöttämisessä tietokantaan. Yritä uudelleen myöhemmin. Lisätietoja virheestä: "
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
        private void btnRegionModifyCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

