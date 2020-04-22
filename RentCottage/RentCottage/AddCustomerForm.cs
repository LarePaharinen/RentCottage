using System;
using System.Collections;
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
    public partial class AddCustomerForm : Form
    {
        public AddCustomerForm()
        {
            InitializeComponent();
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



        private void btnAdd_Click(object sender, EventArgs e)
        {
            PostUtils.CheckPostal(tbCustomerPostalAdd.Text, tbCustomerPostOfficeAdd.Text);
            OpenConnection();
            string query3 = "START TRANSACTION; " +
                "INSERT INTO asiakas(asiakas_id,postinro,etunimi,sukunimi,lahiosoite,email,puhelinnro) " +
                "VALUES(default,'" + tbCustomerPostalAdd.Text + "','" + tbCustomerFNameAdd.Text + 
                "','" + tbCustomerLNameAdd.Text + "','" + tbCustomerAddressAdd.Text +
                "','" + tbCustomerEmailAdd.Text + "','" + tbCustomerPhoneAdd.Text + "'); " +
                "COMMIT;";            
            MySqlCommand command3 = new MySqlCommand(query3, connection);
            command3.ExecuteNonQuery();
            CloseConnection();
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
