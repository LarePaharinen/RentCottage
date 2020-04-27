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
            cbBillingPaid.SelectedIndex = 2;
        }

        //MySqlConnection connection = new MySqlConnection("server=127.0.0.1;user id=testi;password=testi;persistsecurityinfo=True;database=vn");

        //public void OpenConnection()
        //{
        //    if (connection.State == ConnectionState.Closed)
        //    {
        //        connection.Open();
        //    }
        //}

        //public void CloseConnection()
        //{
        //    if (connection.State == ConnectionState.Open)
        //    {
        //        connection.Close();
        //    }
        //}

        public void PopulateDGVRegion()
        {
            string query = "SELECT * FROM toimintaalue";
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter(query, ConnectionUtils.connection);
            adapter.Fill(table);
            dgvRegion.DataSource = table;
        }

        public void PopulateDGVOrder()
        {
            string query = "SELECT * FROM varaus";
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter(query, ConnectionUtils.connection);
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
                MySqlDataAdapter sda = new MySqlDataAdapter("SELECT * FROM Varaus WHERE VARAUS_ID LIKE '" + tbSearch.Text + "%'", ConnectionUtils.connection);
                DataTable data = new DataTable();
                sda.Fill(data);
                dgOrder.DataSource = data;
            }
            if (cmbList.Text == "ASIAKAS ID")
            {
                MySqlDataAdapter sda = new MySqlDataAdapter("SELECT * FROM Varaus WHERE ASIAKAS_ID LIKE '" + tbSearch.Text + "%'", ConnectionUtils.connection);
                DataTable data = new DataTable();
                sda.Fill(data);
                dgOrder.DataSource = data;
            }
            if (cmbList.Text == "MÖKKI ID")
            {
                MySqlDataAdapter sda = new MySqlDataAdapter("SELECT * FROM Varaus WHERE MOKKI_MOKKI_ID LIKE '" + tbSearch.Text + "%'", ConnectionUtils.connection);
                DataTable data = new DataTable();
                sda.Fill(data);
                dgOrder.DataSource = data;
            }
            if (cmbList.Text == "VARATTU PVM")
            {
                MySqlDataAdapter sda = new MySqlDataAdapter("SELECT * FROM Varaus WHERE (VARATTU_PVM LIKE '" + dtp.Text + "')", ConnectionUtils.connection);
                DataTable data = new DataTable();
                sda.Fill(data);
                dgOrder.DataSource = data;
            }
            if (cmbList.Text == "VAHVISTUS PVM")
            {
                MySqlDataAdapter sda = new MySqlDataAdapter("SELECT * FROM Varaus WHERE VAHVISTUS_PVM LIKE '" + tbSearch.Text + "%'", ConnectionUtils.connection);
                DataTable data = new DataTable();
                sda.Fill(data);
                dgOrder.DataSource = data;
            }
            if (cmbList.Text == "ALKUPVM")
            {
                MySqlDataAdapter sda = new MySqlDataAdapter("SELECT * FROM Varaus WHERE (VARATTU_ALKUPVM LIKE '" + dtp.Text + "')", ConnectionUtils.connection);
                DataTable data = new DataTable();
                sda.Fill(data);
                dgOrder.DataSource = data;
            }
            if (cmbList.Text == "LOPPUPVM")
            {
                MySqlDataAdapter sda = new MySqlDataAdapter("SELECT * FROM Varaus WHERE VARATTU_LOPPUPVM LIKE '" + tbSearch.Text + "%'", ConnectionUtils.connection);
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
            MySqlDataAdapter adapter = new MySqlDataAdapter(query, ConnectionUtils.connection);
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
            MySqlDataAdapter adapter = new MySqlDataAdapter(query, ConnectionUtils.connection);
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
                ConnectionUtils.OpenConnection();
                MySqlCommand command = new MySqlCommand(query, ConnectionUtils.connection);
                command.ExecuteNonQuery();
                ConnectionUtils.CloseConnection();
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
            ConnectionUtils.OpenConnection();
            MySqlCommand command = new MySqlCommand(selectQuery, ConnectionUtils.connection);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                cbSearchAluet.Items.Add(reader.GetString("nimi"));
            }
            ConnectionUtils.CloseConnection();
        }

        private void cbSearchAlueKaikki_CheckedChanged(object sender, EventArgs e)
        {
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
            ConnectionUtils.OpenConnection();
            DataTable data = new DataTable();

            string query = "SELECT m.mokki_id, t.nimi as toimintaalue, m.postinro, m.mokkinimi, m.katuosoite, m.kuvaus, m.henkilomaara, m.hinta " +
                "FROM mokki m INNER JOIN toimintaalue t " +
                "ON m.toimintaalue_id = t.toimintaalue_id ";
            string alue_id = null;

            if (cbSearchAlueKaikki.Checked == false)
            {
                MySqlCommand command = new MySqlCommand("SELECT toimintaalue_id FROM toimintaalue WHERE nimi Like '" + cbSearchAluet.Text + "'", ConnectionUtils.connection);
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
            query += "AND m.mokki_id not IN " +
                     "(SELECT mokki_mokki_id FROM varaus v " +
                     "WHERE '" + dtpSearchFROM.Text + "%' <= v.varattu_loppupvm and '" + dtpSearchTO.Text + "%' >= v.varattu_alkupvm)";
            MySqlDataAdapter sda = new MySqlDataAdapter(query, ConnectionUtils.connection);
            sda.Fill(data);
            dgSearchTable.DataSource = data;
            ConnectionUtils.CloseConnection();
        }

        private void btnBilling_Click(object sender, EventArgs e)
        {
            //All button events occurring on the "Lasku" tab.

            Button btn = (Button)sender;

            if (btn == btnBillingSearch) //Search button
            {
                string query = "SELECT l.lasku_id AS LaskuID, l.summa as 'Summa (€)', a.asiakas_id AS AsiakasID, CONCAT(a.etunimi, ' ', a.sukunimi) AS Nimi, " +
                "a.lahiosoite AS Lähiosoite, a.puhelinnro AS Puhelinnumero, a.email AS Sähköposti, l.maksettu AS 'maksu suoritettu' " +
                "FROM lasku l " +
                "JOIN varaus v ON l.varaus_id = v.varaus_id " +
                "JOIN asiakas a ON v.asiakas_id = a.asiakas_id " +
                "WHERE l.lasku_id LIKE '%" + txtboxBillingInvoiceID.Text + "%' " +
                "AND v.varaus_id LIKE '%" + txtboxBillingOrderID.Text + "%' " +
                "AND a.asiakas_id LIKE '%" + txtboxBillingCustomerID.Text + "%' " +
                "AND a.etunimi LIKE '%" + txtboxBillingSurname.Text + "%' " +
                "AND a.sukunimi LIKE '%" + txtboxBillingLastname.Text + "%' " +
                "AND a.email LIKE '%" + txtboxBillingEmail.Text + "%' " +
                "AND a.puhelinnro LIKE '%" + txtboxBillingPhone.Text + "%' ";

                if (cbBillingPaid.SelectedIndex == 0)
                    query += "AND l.maksettu = TRUE;";
                else if (cbBillingPaid.SelectedIndex == 1)
                    query += "AND l.maksettu = FALSE;";
                else if (cbBillingPaid.SelectedIndex == 2)
                    query += ";";

                DataTable table = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, ConnectionUtils.connection);
                adapter.Fill(table);
                dgvBilling.DataSource = table;
            }

            else if (btn == btnBillingPDF) //Create PDF
            {
            }

            else if (btn == btnBillingDelete) //Delete
            {
            }

        }

        private void AddRegion(object sender, EventArgs e)
        {
            ConnectionUtils.OpenConnection();
            string query3 = "START TRANSACTION; " +
                "INSERT INTO toimintaalue(toimintaalue_id,nimi) " +
                "VALUES(default,'" + tbRegionName.Text + "'); " +
                "COMMIT;";
            MySqlCommand command3 = new MySqlCommand(query3, ConnectionUtils.connection);
            command3.ExecuteNonQuery();
            ConnectionUtils.CloseConnection();
            PopulateDGVRegion();
        }

        private void DeleteSelectedRegion(object sender, EventArgs e)
        {
            
        }
    }
}
