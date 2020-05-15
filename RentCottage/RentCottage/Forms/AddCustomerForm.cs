using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace RentCottage
{
    public partial class AddCustomerForm : Form
    {
        public AddCustomerForm()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e) //add a new customer to the database
        {
            PostUtils.CheckPostal(tbCustomerPostalAdd.Text, tbCustomerPostOfficeAdd.Text);
            ConnectionUtils.OpenConnection();
            string query3 = "START TRANSACTION; " +
                "INSERT INTO asiakas(asiakas_id,postinro,etunimi,sukunimi,lahiosoite,email,puhelinnro) " +
                "VALUES(default,'" + TextBoxUtils.ModifyInput(tbCustomerPostalAdd.Text,tbCustomerPostalAdd.MaxLength) + "','" + TextBoxUtils.ModifyInput(tbCustomerFNameAdd.Text,tbCustomerFNameAdd.MaxLength) + 
                "','" + TextBoxUtils.ModifyInput(tbCustomerLNameAdd.Text,tbCustomerLNameAdd.MaxLength) + "','" + TextBoxUtils.ModifyInput(tbCustomerAddressAdd.Text,tbCustomerAddressAdd.MaxLength) +
                "','" + TextBoxUtils.ModifyInput(tbCustomerEmailAdd.Text,tbCustomerEmailAdd.MaxLength) + "','" + TextBoxUtils.ModifyInput(tbCustomerPhoneAdd.Text,tbCustomerPhoneAdd.MaxLength) + "'); " +
                "COMMIT;";
            MySqlCommand command3 = new MySqlCommand(query3, ConnectionUtils.connection);
            command3.ExecuteNonQuery();
            ConnectionUtils.CloseConnection();
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
