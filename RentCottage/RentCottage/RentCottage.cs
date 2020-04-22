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
using System.Globalization;



namespace RentCottage
{
    public partial class RentCottage : Form
    {
        public RentCottage()
        {
            InitializeComponent();
            tbSearch.Tag = tbSearch.Text = "Kirjoita hakusana...";
            tbSearch.ForeColor = Color.Gray;
            tbSearch.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Italic);
            cmbList.Text = "VARAUS ID";
            //dtp.CustomFormat = "dd.MM.yyyy hh.mm";
        }

        private void RentCottage_Load(object sender, EventArgs e)
        {
            PopulateDGVRegion();
            PopulateDGVOrder();
            PopulateDGVCustomer();
            Search_alue_Combobox_update();
            cbSearchAluet.SelectedIndex = 1;
            cbBillingMaksettu.SelectedIndex = 2;
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

        public void PopulateDGVRegion()
        {
            string query = "SELECT * FROM toimintaalue";
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
            adapter.Fill(table);
            dgvRegion.DataSource = table;
        }

        public void PopulateDGVOrder()
        {
            string query = "SELECT * FROM varaus";
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
            adapter.Fill(table);
            dgOrder.DataSource = table;
        }

        private void tbSearch_Enter(object sender, EventArgs e)
        {
            if (tbSearch.Text.Equals("Kirjoita hakusana..."))
            {
                tbSearch.Clear();
                tbSearch.ForeColor = Color.Black;
            }
        }

        private void tbSearch_Leave(object sender, EventArgs e)
        {
            if (tbSearch.Text.Equals("Kirjoita hakusana..."))
            {
                tbSearch.Clear();
                tbSearch.ForeColor = Color.Black;
            }
            else if (tbSearch.TextLength == 0)
            {
                tbSearch.Tag = tbSearch.Text = "Kirjoita hakusana...";
                tbSearch.ForeColor = Color.Gray;
                tbSearch.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Italic);
            }
        }

        private void btmSearch_Click(object sender, EventArgs e)
        {

            if (cmbList.Text == "VARAUS ID")
            {
                MySqlDataAdapter sda = new MySqlDataAdapter("SELECT * FROM Varaus WHERE VARAUS_ID LIKE '" + tbSearch.Text + "%'", connection);
                DataTable data = new DataTable();
                sda.Fill(data);
                dgOrder.DataSource = data;
            }
            if (cmbList.Text == "ASIAKAS ID")
            {
                MySqlDataAdapter sda = new MySqlDataAdapter("SELECT * FROM Varaus WHERE ASIAKAS_ID LIKE '" + tbSearch.Text + "%'", connection);
                DataTable data = new DataTable();
                sda.Fill(data);
                dgOrder.DataSource = data;
            }
            if (cmbList.Text == "MÖKKI ID")
            {
                MySqlDataAdapter sda = new MySqlDataAdapter("SELECT * FROM Varaus WHERE MOKKI_MOKKI_ID LIKE '" + tbSearch.Text + "%'", connection);
                DataTable data = new DataTable();
                sda.Fill(data);
                dgOrder.DataSource = data;
            }
            if (cmbList.Text == "VARATTU PVM")
            {
                MySqlDataAdapter sda = new MySqlDataAdapter("SELECT * FROM Varaus WHERE (VARATTU_PVM LIKE '" + dtp.Text + "')", connection);
                DataTable data = new DataTable();
                sda.Fill(data);
                dgOrder.DataSource = data;
            }
            if (cmbList.Text == "VAHVISTUS PVM")
            {
                MySqlDataAdapter sda = new MySqlDataAdapter("SELECT * FROM Varaus WHERE VAHVISTUS_PVM LIKE '" + tbSearch.Text + "%'", connection);
                DataTable data = new DataTable();
                sda.Fill(data);
                dgOrder.DataSource = data;
            }
            if (cmbList.Text == "ALKUPVM")
            {
                MySqlDataAdapter sda = new MySqlDataAdapter("SELECT * FROM Varaus WHERE (VARATTU_ALKUPVM LIKE '" + dtp.Text + "')", connection);
                DataTable data = new DataTable();
                sda.Fill(data);
                dgOrder.DataSource = data;
            }
            if (cmbList.Text == "LOPPUPVM")
            {
                MySqlDataAdapter sda = new MySqlDataAdapter("SELECT * FROM Varaus WHERE VARATTU_LOPPUPVM LIKE '" + tbSearch.Text + "%'", connection);
                DataTable data = new DataTable();
                sda.Fill(data);
                dgOrder.DataSource = data;
            }
        }

        private void btmShowAll_Click(object sender, EventArgs e)
        {
            PopulateDGVOrder();
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            tbSearch.ForeColor = Color.Black;
            tbSearch.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Regular);
        }

        private void cmbList_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbSearch.Text = "";
            if (cmbList.Text == "VARATTU PVM" || cmbList.Text == "ALKUPVM")
            {
                dtp.Visible = true;
            }
            else
                dtp.Visible = false;
        }


        //codes related to Asiakashallinta
        public void PopulateDGVCustomer() //get all data from asiakas-table to datagridview
        {
            string query = "SELECT * FROM asiakas";
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
            adapter.Fill(table);
            dgvCustomer.DataSource = table;
        }

        private void btnCustomerSearch_Click(object sender, EventArgs e) //
        {
            string query = "SELECT * FROM asiakas " +
                "WHERE postinro LIKE '%" + tbCustomerPostal.Text + "%' " +
                "AND etunimi LIKE '%" + tbCustomerFName.Text + "%' " +
                "AND sukunimi LIKE '%" + tbCustomerLName.Text + "%' " +
                "AND lahiosoite LIKE '%" + tbCustomerAddress.Text + "%' " +
                "AND email LIKE '%" + tbCustomerEmail.Text + "%' " +
                "AND puhelinnro LIKE '%" + tbCustomerPhone.Text + "%';";
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
            adapter.Fill(table);
            dgvCustomer.DataSource = table;
        }

        private void btnCustomerAdd_Click(object sender, EventArgs e)
        {
            AddCustomerForm ACF = new AddCustomerForm();
            ACF.ShowDialog();
        }

        private void btnCustomerDeleteInfo_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Haluatko varmasti poistaa valitun asiakkaan tiedot?", "Poista asiakkaan tiedot", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (res == DialogResult.Yes)
            {
                string query = "START TRANSACTION; " +
                    "UPDATE asiakas " +
                    "SET postinro='90100',etunimi='',sukunimi='',lahiosoite=''," +
                    "email='',puhelinnro='' " +
                    "WHERE asiakas_id=" + dgvCustomer.CurrentRow.Cells[0].Value.ToString() + "; " +
                    "COMMIT;";
                OpenConnection();
                MySqlCommand command = new MySqlCommand(query, connection);
                command.ExecuteNonQuery();
                CloseConnection();
            }
        }

        private void btnCustomerModify_Click(object sender, EventArgs e)
        {
            Customer customer = new Customer(Convert.ToInt32(dgvCustomer.CurrentRow.Cells[0].Value), dgvCustomer.CurrentRow.Cells[1].Value.ToString(),
                dgvCustomer.CurrentRow.Cells[2].Value.ToString(), dgvCustomer.CurrentRow.Cells[3].Value.ToString(),
                dgvCustomer.CurrentRow.Cells[4].Value.ToString(), dgvCustomer.CurrentRow.Cells[5].Value.ToString(),
                dgvCustomer.CurrentRow.Cells[6].Value.ToString());
            ModifyCustomerForm MCF = new ModifyCustomerForm(customer);
            MCF.ShowDialog();
        }

        private void btnCustomerModify_Click_1(object sender, EventArgs e)
        {
            Customer customer = new Customer(Convert.ToInt32(dgvCustomer.CurrentRow.Cells[0].Value), dgvCustomer.CurrentRow.Cells[1].Value.ToString(),
                dgvCustomer.CurrentRow.Cells[2].Value.ToString(), dgvCustomer.CurrentRow.Cells[3].Value.ToString(),
                dgvCustomer.CurrentRow.Cells[4].Value.ToString(), dgvCustomer.CurrentRow.Cells[5].Value.ToString(),
                dgvCustomer.CurrentRow.Cells[6].Value.ToString());
            ModifyCustomerForm MCF = new ModifyCustomerForm(customer);
            MCF.ShowDialog();
        }
        //Search
        private void Search_alue_Combobox_update()
        {
            string selectQuery = "SELECT * FROM toimintaalue";
            OpenConnection();
            MySqlCommand command = new MySqlCommand(selectQuery, connection);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                cbSearchAluet.Items.Add(reader.GetString("nimi"));
            }
            CloseConnection();
        }

        private void cbSearchAlueKaikki_CheckedChanged(object sender, EventArgs e)
        {
            //CheckBox checkBox = (CheckBox)sender;
            if (cbSearchAlueKaikki.Checked == true)
            {
                cbSearchAluet.Enabled = false;
                cbSearchAluet.SelectedItem = null;
            }
            else
            {
                cbSearchAluet.SelectedIndex = 1;
                cbSearchAluet.Enabled = true;
            }
        }

        private void btnSearchHae_Click(object sender, EventArgs e)
        {
            OpenConnection();
            DataTable data = new DataTable();

            string query = "SELECT m.mokki_id, t.nimi as toimintaalue, m.postinro, m.mokkinimi, m.katuosoite, m.kuvaus, m.henkilomaara, m.hinta " +
                "FROM mokki m INNER JOIN toimintaalue t " +
                "ON m.toimintaalue_id = t.toimintaalue_id ";
            string alue_id = null;
            double hinta;

            if (tbSearchMokkiid.Text != "")
            {
                query += "WHERE m.mokki_id LIKE " + tbSearchMokkiid.Text;
                MySqlDataAdapter sda = new MySqlDataAdapter(query, connection);
                sda.Fill(data);
                dgSearchTable.DataSource = data;
            }
            else
            {
                if (cbSearchAlueKaikki.Checked == false)
                {
                    MySqlCommand command = new MySqlCommand("SELECT toimintaalue_id FROM toimintaalue WHERE nimi Like '" + cbSearchAluet.Text + "'", connection);
                    alue_id = command.ExecuteScalar().ToString();
                    query += "WHERE m.toimintaalue_id LIKE '" + alue_id + "' ";
                }
                if (nudSearchHintaraja.Value != 0 && cbSearchAlueKaikki.Checked == true)
                {
                    query += "WHERE m.hinta <= '" + nudSearchHintaraja.Value + "' ";
                }
                else if (nudSearchHintaraja.Value != 0 && cbSearchAlueKaikki.Checked == false)
                {
                    query += "AND m.hinta <= '" + nudSearchHintaraja.Value + "' ";
                }

                if (nudSearchMaxhlo.Value != 0)
                {
                    if (nudSearchHintaraja.Value != 0 || cbSearchAlueKaikki.Checked == false)
                        query += "AND ";
                    else
                        query += "WHERE ";
                    query += "m.henkilomaara >= '" + nudSearchMaxhlo.Value + "' ";
                }
                lbltest.Text = query;
                MySqlDataAdapter sda = new MySqlDataAdapter(query, connection);
                sda.Fill(data);
                dgSearchTable.DataSource = data;
            }
            CloseConnection();
        }

        private void btnBilling_Click(object sender, EventArgs e)
        {
            //All button events occurring on the "Lasku" tab.

            Button btn = (Button)sender;
            string query = "SELECT l.lasku_id AS LaskuID, l.summa as 'Summa (€)', a.asiakas_id AS AsiakasID, CONCAT(a.etunimi, ' ', a.sukunimi) AS Nimi, " +
               "a.lahiosoite AS Lähiosoite, a.puhelinnro AS Puhelinnumero, a.email AS Sähköposti, l.maksettu AS 'maksu suoritettu' " +
               "FROM lasku l " +
               "JOIN varaus v ON l.varaus_id = v.varaus_id " +
               "JOIN asiakas a ON v.asiakas_id = a.asiakas_id ";

            if (btn == btnBillingHaku) //Search button
            {
                string laskuID = txtboxBillingLaskuID.Text;
                string varausID = txtboxBillingVarausID.Text;
                string asiakasID = txtboxBillingAsiakasID.Text;
                string etunimi = txtboxBillingEtunimi.Text;
                string sukunimi = txtboxBillingSukunimi.Text;
                string email = txtboxBillingSahkoposti.Text;
                string puhelinnro = txtboxBillingPuhelinnro.Text;
                string maksettu = "";
                if (cbBillingMaksettu.SelectedIndex == 0)
                    maksettu = "TRUE";
                else if (cbBillingMaksettu.SelectedIndex == 1)
                    maksettu = "FALSE";
                else if (cbBillingMaksettu.SelectedIndex == 2)
                    maksettu = "";

                if (laskuID != "" || varausID != "" || asiakasID != "" || etunimi != "" || sukunimi != "" || email != "" || puhelinnro != "" || maksettu != "")
                    query += " WHERE ";

                if (laskuID != "")
                {
                    query += "l.lasku_id = " + laskuID;
                    query += " AND ";
                }

                if (varausID != "")
                {
                    query += "l.varaus_id = " + varausID;
                    query += " AND ";
                }

                if (asiakasID != "")
                {
                    query += "a.asiakas_id = " + asiakasID;
                    query += " AND ";
                }

                if (etunimi != "")
                {
                    query += "a.etunimi = " + "'" + etunimi + "'";
                    query += " AND ";
                }

                if (sukunimi != "")
                {
                    query += "a.sukunimi = " + "'" + sukunimi + "'";
                    query += " AND ";
                }

                if (email != "")
                {
                    query += "a.email = " + "'" + email + "'";
                    query += " AND ";
                }

                if (puhelinnro != "")
                {
                    query += "a.puhelinnro = " + "'" + puhelinnro + "'";
                    query += " AND ";
                }

                if (maksettu != "")
                {
                    query += "l.maksettu = " + maksettu;
                    query += " AND ";
                }

                //Removing the last "AND" from the query and placing the ";" int the end.
                string find = "AND";
                int index = query.LastIndexOf(find);
                string replace = "";

                if (index != -1)
                {
                    string result = query.Remove(index, find.Length).Insert(index, replace);
                    query = result;
                }

                query += ";";

                DataTable table = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                adapter.Fill(table);
                dgvBilling.DataSource = table;
            }

            else if (btn == btnBillingPDF) //Create PDF
            {
            }

            else if (btn == btnBillingPoista) //Delete
            {
            }

        }
    }
}
