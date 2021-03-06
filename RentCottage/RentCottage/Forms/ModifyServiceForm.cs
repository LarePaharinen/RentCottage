﻿using MySql.Data.MySqlClient;
using RentCottage.Code;
using System;
using System.Windows.Forms;

namespace RentCottage.Forms
{
    public partial class ModifyServiceForm : Form
    {
        public ModifyServiceForm()
        {
            InitializeComponent();
            RegionUtils.PopulateCBRegion(cbModifyServiceRegion);
        }

        public ModifyServiceForm(Service s)
        {
            //Used to import services data to from
            InitializeComponent();
            RegionUtils.PopulateCBRegion(cbModifyServiceRegion);
            lblModifyServiceID.Text = s.ServiceID.ToString();
            cbModifyServiceRegion.Text = RegionUtils.RegionIndexToName(s.RegionID);
            tbModifyServiceName.Text = s.Name;
            tbModifyServiceType.Text = s.Type.ToString();
            nudModifyServicePrice.Value = (int)s.Price;
            nudModifyServiceVAT.Value = (int)s.Vat;
            tbModifyServiceDescription.Text = s.Description;

        }

        private void btnModifyServiceCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnModifyServiceModify_Click(object sender, EventArgs e)
        {
            //Make sure the data should be modified
            DialogResult result = MessageBox.Show("Haluatko varmasti muuttaa valitun palvelun tietoja?", "Muuta palvelun tietoja",
                MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (result == DialogResult.Yes)
            {
                try
                {
                    //Updates services information in the database. Gets data from form components, service is uniquely identified by serviceID, which can't be modified
                    string query = "START TRANSACTION; " +
                    "UPDATE palvelu " +
                    "SET toimintaalue_id=" + RegionUtils.RegionNameToIndex(cbModifyServiceRegion.Text) +
                    ",nimi='" + TextBoxUtils.ModifyInput(tbModifyServiceName.Text, 40) +
                    "',tyyppi=" + Convert.ToInt32(tbModifyServiceType.Text) +
                    ",kuvaus='" + TextBoxUtils.ModifyInput(tbModifyServiceDescription.Text, 40) + "'," +
                    "hinta=" + Convert.ToDouble(nudModifyServicePrice.Value) +
                    ",alv=" + Convert.ToDouble(nudModifyServiceVAT.Value) + " " +
                    "WHERE palvelu_id=" + Convert.ToInt32(lblModifyServiceID.Text) + "; " +
                    "COMMIT;";
                    try
                    {
                        ConnectionUtils.OpenConnection();
                        MySqlCommand command = new MySqlCommand(query, ConnectionUtils.connection);
                        command.ExecuteNonQuery();
                        ConnectionUtils.CloseConnection();
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        //Incase of database-connection problems
                        ConnectionUtils.CloseConnection();
                        MessageBox.Show("Virhe tietojen syöttämisessä tietokantaan. Tarkista kenttien tiedot, ja yritä uudelleen myöhemmin. Lisätietoja virheestä: "
                            + ex.Message.ToString());
                    }
                }
                catch (Exception ex)
                {
                    //Incase of variable conversion problems
                    ConnectionUtils.CloseConnection();
                    MessageBox.Show("Virhe tietojen muuntamisessa. Onhan kaikkien kenttien syötteet oikein? Lisätietoja virheestä: " + ex.Message.ToString());
                }
                
                
            }
        }
    }
}
