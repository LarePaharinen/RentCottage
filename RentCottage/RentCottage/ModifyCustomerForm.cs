using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using MySql.Data;

namespace RentCottage
{
    public partial class ModifyCustomerForm : Form
    {
        public ModifyCustomerForm()
        {
            InitializeComponent();
        }

        public ModifyCustomerForm(Customer c)
        {
            InitializeComponent();
            lblCustomerIDMod.Text = c.CustomerID.ToString();
            tbCustomerFNameMod.Text = c.Forename;
            tbCustomerLNameMod.Text = c.Surname;
            tbCustomerAddressMod.Text = c.Address;
            tbCustomerPostalMod.Text = c.Postal;
            tbCustomerEmailMod.Text = c.Email;
            tbCustomerPhoneMod.Text = c.Phone;
        }

        MySqlConnection connection = new MySqlConnection("server=127.0.0.1;user id=testi;password=testi;persistsecurityinfo=True;database=vn");

        public void OpenConnection()
        {
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
        }

        public void CloseConnection()
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Haluatko varmasti muuttaa valitun asiakkaan tietoja?", "Muuta asiakkaan tietoja", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (res == DialogResult.Yes)
            {
                PostUtils.CheckPostal(tbCustomerPostalMod.Text, tbCustomerPostOfficeMod.Text);
                string query = "START TRANSACTION; " +
                "UPDATE asiakas " +
                "SET postinro='" + tbCustomerPostalMod.Text + "',etunimi='" + tbCustomerFNameMod.Text +
                "',sukunimi='" + tbCustomerLNameMod.Text + "',lahiosoite='" + tbCustomerAddressMod.Text + "'," +
                "email='" + tbCustomerEmailMod.Text + "',puhelinnro='" + tbCustomerPhoneMod.Text + "' " +
                "WHERE asiakas_id=" + lblCustomerIDMod.Text + "; " +
                "COMMIT;";
                OpenConnection();
                MySqlCommand command = new MySqlCommand(query, connection);
                command.ExecuteNonQuery();
                CloseConnection();
                this.Close();
            }
        }
    }
}
