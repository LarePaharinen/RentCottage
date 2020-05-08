using MySql.Data.MySqlClient;
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
    public partial class AddRegionForm : Form
    {
        public AddRegionForm()
        {
            InitializeComponent();
        }

        private void btnRegionAddAdd_Click(object sender, EventArgs e)
        {
            try
            {
                //Add a region to the database, gets data from form components
                string query = "START TRANSACTION; " +
                "INSERT INTO toimintaalue(toimintaalue_id,nimi) " +
                "VALUES(default,'" +
                TextBoxUtils.modifyInput(tbRegionAddRegionName.Text,40) +"');"+
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
                    //Incase of database-connection problems
                    ConnectionUtils.closeConnection();
                    MessageBox.Show("Virhe tietojen syöttämisessä tietokantaan. Tarkista kenttien tiedot. Lisätietoja: " + ex.Message.ToString());
                }
            }
            catch (Exception ex)
            {
                //Incase of variable conversion problems
                ConnectionUtils.closeConnection();
                MessageBox.Show("Virhe tietojen muuntamisessa. Tarkista kenttien tiedot. Lisätietoja: " + ex.Message.ToString());
            }
        }

        private void btnRegionAddCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
