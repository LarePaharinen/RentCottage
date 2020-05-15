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
            tbCustomerPostOfficeMod.Text = PostUtils.GetPostOffice(c.Postal);
            tbCustomerEmailMod.Text = c.Email;
            tbCustomerPhoneMod.Text = c.Phone;
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
                "SET postinro='" + TextBoxUtils.ModifyInput(tbCustomerPostalMod.Text,tbCustomerPostalMod.MaxLength) + "',etunimi='" + TextBoxUtils.ModifyInput(tbCustomerFNameMod.Text,tbCustomerFNameMod.MaxLength) +
                "',sukunimi='" + TextBoxUtils.ModifyInput(tbCustomerLNameMod.Text,tbCustomerLNameMod.MaxLength) + "',lahiosoite='" + TextBoxUtils.ModifyInput(tbCustomerAddressMod.Text,tbCustomerAddressMod.MaxLength) + "'," +
                "email='" + TextBoxUtils.ModifyInput(tbCustomerEmailMod.Text,tbCustomerEmailMod.MaxLength) + "',puhelinnro='" + TextBoxUtils.ModifyInput(tbCustomerPhoneMod.Text,tbCustomerPhoneMod.MaxLength) + "' " +
                "WHERE asiakas_id=" + lblCustomerIDMod.Text + "; " +
                "COMMIT;";
                ConnectionUtils.OpenConnection();
                MySqlCommand command = new MySqlCommand(query, ConnectionUtils.connection);
                command.ExecuteNonQuery();
                ConnectionUtils.CloseConnection();
                this.Close();
            }
        }

        private void tbCustomerFNameMod_Leave(object sender, EventArgs e)
        {
            //tbCustomerFNameMod.Text = TextBoxUtils.modifyInput(tbCustomerFNameMod.Text, tbCustomerFNameMod.MaxLength);
        }

        private void tbCustomerLNameMod_Leave(object sender, EventArgs e)
        {
            //tbCustomerLNameMod.Text = TextBoxUtils.modifyInput(tbCustomerLNameMod.Text, tbCustomerLNameMod.MaxLength);
        }

        private void tbCustomerAddressMod_Leave(object sender, EventArgs e)
        {
            //tbCustomerAddressMod.Text = TextBoxUtils.modifyInput(tbCustomerAddressMod.Text, tbCustomerAddressMod.MaxLength);
        }

        private void tbCustomerPostalMod_Leave(object sender, EventArgs e)
        {
            //tbCustomerPostalMod.Text = TextBoxUtils.modifyInput(tbCustomerPostalMod.Text, tbCustomerPostalMod.MaxLength);
        }

        private void tbCustomerPostOfficeMod_Leave(object sender, EventArgs e)
        {
            //tbCustomerPostOfficeMod.Text = TextBoxUtils.modifyInput(tbCustomerPostOfficeMod.Text, tbCustomerPostOfficeMod.MaxLength);
        }

        private void tbCustomerEmailMod_Leave(object sender, EventArgs e)
        {
            //tbCustomerEmailMod.Text = TextBoxUtils.modifyInput(tbCustomerEmailMod.Text, tbCustomerEmailMod.MaxLength);
        }

        private void tbCustomerPhoneMod_Leave(object sender, EventArgs e)
        {
            //tbCustomerPhoneMod.Text = TextBoxUtils.modifyInput(tbCustomerPhoneMod.Text, tbCustomerPhoneMod.MaxLength);
        }
    }
}
