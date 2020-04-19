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
            lblCustomerID.Text = c.CustomerID.ToString();
            tbCustomerFName.Text = c.Forename;
            tbCustomerLName.Text = c.Surname;
            tbCustomerAddress.Text = c.Address;
            tbCustomerPostal.Text = c.Postal;
            tbCustomerEmail.Text = c.Email;
            tbCustomerPhone.Text = c.Phone;
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
                string query = "START TRANSACTION; " +
                "UPDATE asiakas " +
                "SET postinro='" + tbCustomerPostal.Text + "',etunimi='" + tbCustomerFName.Text +
                "',sukunimi='" + tbCustomerLName.Text + "',lahiosoite='" + tbCustomerAddress.Text + "'," +
                "email='" + tbCustomerEmail.Text + "',puhelinnro='" + tbCustomerPhone.Text + "' " +
                "WHERE asiakas_id=" + lblCustomerID.Text + "; " +
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
