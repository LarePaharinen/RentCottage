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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            PostUtils.checkPostal(tbCustomerPostalAdd.Text, tbCustomerPostOfficeAdd.Text);
            ConnectionUtils.openConnection();
            string query3 = "START TRANSACTION; " +
                "INSERT INTO asiakas(asiakas_id,postinro,etunimi,sukunimi,lahiosoite,email,puhelinnro) " +
                "VALUES(default,'" + tbCustomerPostalAdd.Text + "','" + tbCustomerFNameAdd.Text + 
                "','" + tbCustomerLNameAdd.Text + "','" + tbCustomerAddressAdd.Text +
                "','" + tbCustomerEmailAdd.Text + "','" + tbCustomerPhoneAdd.Text + "'); " +
                "COMMIT;";            
            MySqlCommand command3 = new MySqlCommand(query3, ConnectionUtils.connection);
            command3.ExecuteNonQuery();
            ConnectionUtils.closeConnection();
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
