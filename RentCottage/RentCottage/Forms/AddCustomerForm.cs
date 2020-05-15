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

        private void tbCustomerFNameAdd_Leave(object sender, EventArgs e)
        {
            //tbCustomerFNameAdd.Text = TextBoxUtils.modifyInput(tbCustomerFNameAdd.Text, tbCustomerFNameAdd.MaxLength);
        }

        private void tbCustomerLNameAdd_Leave(object sender, EventArgs e)
        {
            //tbCustomerLNameAdd.Text = TextBoxUtils.modifyInput(tbCustomerLNameAdd.Text, tbCustomerLNameAdd.MaxLength);
        }

        private void tbCustomerAddressAdd_Leave(object sender, EventArgs e)
        {
            //tbCustomerAddressAdd.Text = TextBoxUtils.modifyInput(tbCustomerAddressAdd.Text, tbCustomerAddressAdd.MaxLength);
        }

        private void tbCustomerPostalAdd_Leave(object sender, EventArgs e)
        {
            //tbCustomerPostalAdd.Text = TextBoxUtils.modifyInput(tbCustomerPostalAdd.Text, tbCustomerPostalAdd.MaxLength);
        }

        private void tbCustomerPostOfficeAdd_Leave(object sender, EventArgs e)
        {
            //tbCustomerPostOfficeAdd.Text = TextBoxUtils.modifyInput(tbCustomerPostOfficeAdd.Text, tbCustomerPostOfficeAdd.MaxLength);
        }

        private void tbCustomerEmailAdd_Leave(object sender, EventArgs e)
        {
            //tbCustomerEmailAdd.Text = TextBoxUtils.modifyInput(tbCustomerEmailAdd.Text, tbCustomerEmailAdd.MaxLength);
        }

        private void tbCustomerPhoneAdd_Leave(object sender, EventArgs e)
        {
            //tbCustomerPhoneAdd.Text = TextBoxUtils.modifyInput(tbCustomerPhoneAdd.Text, tbCustomerPhoneAdd.MaxLength);
        }
    }
}
