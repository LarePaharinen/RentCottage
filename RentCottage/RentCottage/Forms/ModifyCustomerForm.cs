﻿using System;
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
            tbCustomerFNameMod.Text = TextBoxUtils.modifyInput(c.Forename,tbCustomerFNameMod.MaxLength);
            tbCustomerLNameMod.Text = TextBoxUtils.modifyInput(c.Surname,tbCustomerLNameMod.MaxLength);
            tbCustomerAddressMod.Text = TextBoxUtils.modifyInput(c.Address,tbCustomerAddressMod.MaxLength);
            tbCustomerPostalMod.Text = TextBoxUtils.modifyInput(c.Postal,tbCustomerPostalMod.MaxLength);
            tbCustomerPostOfficeMod.Text = TextBoxUtils.modifyInput(PostUtils.getPostOffice(c.Postal),tbCustomerPostOfficeMod.MaxLength);
            tbCustomerEmailMod.Text = TextBoxUtils.modifyInput(c.Email,tbCustomerEmailMod.MaxLength);
            tbCustomerPhoneMod.Text = TextBoxUtils.modifyInput(c.Phone,tbCustomerPhoneMod.MaxLength);
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
                PostUtils.checkPostal(tbCustomerPostalMod.Text, tbCustomerPostOfficeMod.Text);
                string query = "START TRANSACTION; " +
                "UPDATE asiakas " +
                "SET postinro='" + tbCustomerPostalMod.Text + "',etunimi='" + tbCustomerFNameMod.Text +
                "',sukunimi='" + tbCustomerLNameMod.Text + "',lahiosoite='" + tbCustomerAddressMod.Text + "'," +
                "email='" + tbCustomerEmailMod.Text + "',puhelinnro='" + tbCustomerPhoneMod.Text + "' " +
                "WHERE asiakas_id=" + lblCustomerIDMod.Text + "; " +
                "COMMIT;";
                ConnectionUtils.openConnection();
                MySqlCommand command = new MySqlCommand(query, ConnectionUtils.connection);
                command.ExecuteNonQuery();
                ConnectionUtils.closeConnection();
                this.Close();
            }
        }

        private void tbCustomerFNameMod_Leave(object sender, EventArgs e)
        {
            tbCustomerFNameMod.Text = TextBoxUtils.modifyInput(tbCustomerFNameMod.Text, tbCustomerFNameMod.MaxLength);
        }

        private void tbCustomerLNameMod_Leave(object sender, EventArgs e)
        {
            tbCustomerLNameMod.Text = TextBoxUtils.modifyInput(tbCustomerLNameMod.Text, tbCustomerLNameMod.MaxLength);
        }

        private void tbCustomerAddressMod_Leave(object sender, EventArgs e)
        {
            tbCustomerAddressMod.Text = TextBoxUtils.modifyInput(tbCustomerAddressMod.Text, tbCustomerAddressMod.MaxLength);
        }

        private void tbCustomerPostalMod_Leave(object sender, EventArgs e)
        {
            tbCustomerPostalMod.Text = TextBoxUtils.modifyInput(tbCustomerPostalMod.Text, tbCustomerPostalMod.MaxLength);
        }

        private void tbCustomerPostOfficeMod_Leave(object sender, EventArgs e)
        {
            tbCustomerPostOfficeMod.Text = TextBoxUtils.modifyInput(tbCustomerPostOfficeMod.Text, tbCustomerPostOfficeMod.MaxLength);
        }

        private void tbCustomerEmailMod_Leave(object sender, EventArgs e)
        {
            tbCustomerEmailMod.Text = TextBoxUtils.modifyInput(tbCustomerEmailMod.Text, tbCustomerEmailMod.MaxLength);
        }

        private void tbCustomerPhoneMod_Leave(object sender, EventArgs e)
        {
            tbCustomerPhoneMod.Text = TextBoxUtils.modifyInput(tbCustomerPhoneMod.Text, tbCustomerPhoneMod.MaxLength);
        }
    }
}