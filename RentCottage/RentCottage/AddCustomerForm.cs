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
            string query = "START TRANSACTION; " +
                "INSERT INTO asiakas(asiakas_id,postinro,etunimi,sukunimi,lahiosoite,email,puhelinnro) " +
                "VALUES(default,'" + tbCustomerPostal.Text + "','" + tbCustomerFName.Text + 
                "','" + tbCustomerLName.Text + "','" + tbCustomerAddress.Text +
                "','" + tbCustomerEmail.Text + "','" + tbCustomerPhone.Text + "'); " +
                "COMMIT;";
            OpenConnection();
            MySqlCommand command = new MySqlCommand(query, connection);
            command.ExecuteNonQuery();
            CloseConnection();
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
