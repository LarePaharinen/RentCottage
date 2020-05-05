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
using RentCottage.Forms;
using RentCottage.Code;
using Renci.SshNet.Messages;

namespace RentCottage
{
    public partial class RentCottage : Form
    {
        public RentCottage()
        {
            InitializeComponent();
            dtpSearchFROM.Value = DateTime.Now;
            cmbListOrder.Text = "VARAUS ID";
        }

        private void RentCottage_Load(object sender, EventArgs e)
        {
            PopulateDGVRegion();
            PopulateDGVOrder();
            PopulateDGVCustomer();
            PopulateDGVService();
            PopulateDGVCottage();
            billingSearch(); //Populates the dgvBilling
            Search_alue_Combobox_update();
            RegionUtils.PopulateCBRegion(cbCottageRegions);
            RegionUtils.PopulateCBRegion(cbServiceRegion);
            cbSearchAluet.SelectedIndex = 1;
            cbBillingPaid.SelectedIndex = 2;
            tbOrderSearch.Tag = tbOrderSearch.Text = "Kirjoita hakusana...";
            tbOrderSearch.ForeColor = Color.Gray;
            tbOrderSearch.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Italic);
            BillingUtils.rentCottage = this;
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


        //codes related to Varausten hallinta


        private void tbOrderSearch_Enter(object sender, EventArgs e)
        {
            if (tbOrderSearch.Text.Equals("Kirjoita hakusana..."))
            {
                tbOrderSearch.Clear();
                tbOrderSearch.ForeColor = Color.Black;
            }
        }

        private void tbOrderSearch_Leave(object sender, EventArgs e)
        {
            if (tbOrderSearch.Text.Equals("Kirjoita hakusana..."))
            {
                tbOrderSearch.Clear();
                tbOrderSearch.ForeColor = Color.Black;
            }
            else if (tbOrderSearch.TextLength == 0)
            {
                tbOrderSearch.Tag = tbOrderSearch.Text = "Kirjoita hakusana...";
                tbOrderSearch.ForeColor = Color.Gray;
                tbOrderSearch.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Italic);
            }
        }

        private void btmOrderSearch_Click(object sender, EventArgs e)
        {

            if (cmbListOrder.Text == "VARAUS ID")
            {
                MySqlDataAdapter sda = new MySqlDataAdapter("SELECT * FROM Varaus WHERE VARAUS_ID = '" + tbOrderSearch.Text + "'", ConnectionUtils.connection);
                DataTable data = new DataTable();
                sda.Fill(data);
                dgOrder.DataSource = data;
            }
            if (cmbListOrder.Text == "ASIAKAS ID")
            {
                MySqlDataAdapter sda = new MySqlDataAdapter("SELECT * FROM Varaus WHERE ASIAKAS_ID = '" + tbOrderSearch.Text + "'", ConnectionUtils.connection);
                DataTable data = new DataTable();
                sda.Fill(data);
                dgOrder.DataSource = data;
            }
            if (cmbListOrder.Text == "MÖKKI ID")
            {
                MySqlDataAdapter sda = new MySqlDataAdapter("SELECT * FROM Varaus WHERE MOKKI_MOKKI_ID = '" + tbOrderSearch.Text + "'", ConnectionUtils.connection);
                DataTable data = new DataTable();
                sda.Fill(data);
                dgOrder.DataSource = data;
            }
            if (cmbListOrder.Text == "VARATTU PVM")
            {
                MySqlDataAdapter sda = new MySqlDataAdapter("SELECT * FROM Varaus WHERE (VARATTU_PVM LIKE '%" + dtpOrder.Text + "%')", ConnectionUtils.connection);
                DataTable data = new DataTable();
                sda.Fill(data);
                dgOrder.DataSource = data;
            }
            if (cmbListOrder.Text == "VAHVISTUS PVM")
            {
                MySqlDataAdapter sda = new MySqlDataAdapter("SELECT * FROM Varaus WHERE (VAHVISTUS_PVM LIKE '%" + dtpOrder.Text + "%')", ConnectionUtils.connection);
                DataTable data = new DataTable();
                sda.Fill(data);
                dgOrder.DataSource = data;
            }
            if (cmbListOrder.Text == "ALKUPVM")
            {
                MySqlDataAdapter sda = new MySqlDataAdapter("SELECT * FROM Varaus WHERE (VARATTU_ALKUPVM LIKE '%" + dtpOrder.Text + "%')", ConnectionUtils.connection);
                DataTable data = new DataTable();
                sda.Fill(data);
                dgOrder.DataSource = data;
            }
            if (cmbListOrder.Text == "LOPPUPVM")
            {
                MySqlDataAdapter sda = new MySqlDataAdapter("SELECT * FROM Varaus WHERE (VARATTU_LOPPUPVM LIKE '%" + dtpOrder.Text + "%')", ConnectionUtils.connection);
                DataTable data = new DataTable();
                sda.Fill(data);
                dgOrder.DataSource = data;
            }
        }

        private void btmOrderShowAll_Click(object sender, EventArgs e)
        {
            PopulateDGVOrder();
        }

        private void tbOrderSearch_TextChanged(object sender, EventArgs e)
        {
            tbOrderSearch.ForeColor = Color.Black;
            tbOrderSearch.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Regular);
        }

        private void btmOrderChange_Click(object sender, EventArgs e)
        {
            Order order = new Order(Convert.ToInt32(dgOrder.CurrentRow.Cells[0].Value), Convert.ToInt32(dgOrder.CurrentRow.Cells[1].Value),
                Convert.ToInt32(dgOrder.CurrentRow.Cells[2].Value),
                dgOrder.CurrentRow.Cells[3].Value.ToString(), dgOrder.CurrentRow.Cells[4].Value.ToString(),
                dgOrder.CurrentRow.Cells[5].Value.ToString(), dgOrder.CurrentRow.Cells[6].Value.ToString());
            ModifyOrderForm MOF = new ModifyOrderForm(order);
            MOF.ShowDialog();
            PopulateDGVOrder();
        }

        private void cmbListOrder_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tbOrderSearch.Text == null)
                tbOrderSearch.Text = "Kirjoita hakusana...";
            if (cmbListOrder.Text == "VARATTU PVM" || cmbListOrder.Text == "VAHVISTUS PVM" || cmbListOrder.Text == "ALKUPVM" || cmbListOrder.Text == "LOPPUPVM")
            {
                dtpOrder.Visible = true;
            }
            else
                dtpOrder.Visible = false;
        }

        private void btmOrderRemove_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Haluatko varmasti poistaa varauksen?", "Poista varaus", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (res == DialogResult.Yes)
            {
                string query = "START TRANSACTION; " +
                    "DELETE FROM varaus " +
                    "WHERE varaus_id=" + dgOrder.CurrentRow.Cells[0].Value.ToString() + "; " +
                    "COMMIT;";
                ConnectionUtils.openConnection();
                MySqlCommand command = new MySqlCommand(query, ConnectionUtils.connection);
                command.ExecuteNonQuery();
                ConnectionUtils.closeConnection();
                PopulateDGVOrder();
            }
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
                    "SET postinro='xxxxx',etunimi='',sukunimi='',lahiosoite=''," +
                    "email='',puhelinnro='' " +
                    "WHERE asiakas_id=" + dgvCustomer.CurrentRow.Cells[0].Value.ToString() + "; " +
                    "COMMIT;";
                ConnectionUtils.openConnection();
                MySqlCommand command = new MySqlCommand(query, ConnectionUtils.connection);
                command.ExecuteNonQuery();
                ConnectionUtils.closeConnection();
            }
        }

        //private void btnCustomerModify_Click(object sender, EventArgs e)
        //{
        //    Customer customer = new Customer(Convert.ToInt32(dgvCustomer.CurrentRow.Cells[0].Value), dgvCustomer.CurrentRow.Cells[1].Value.ToString(),
        //        dgvCustomer.CurrentRow.Cells[2].Value.ToString(), dgvCustomer.CurrentRow.Cells[3].Value.ToString(),
        //        dgvCustomer.CurrentRow.Cells[4].Value.ToString(), dgvCustomer.CurrentRow.Cells[5].Value.ToString(),
        //        dgvCustomer.CurrentRow.Cells[6].Value.ToString());
        //    ModifyCustomerForm MCF = new ModifyCustomerForm(customer);
        //    MCF.ShowDialog();
        //}
        //^^ EIKÖS TÄMÄN VOI POISTAA? SITTEN VOISI VAIKKA UUDELLEEN NIMETÄ TUON ALEMMAN TAKAISIN _Click()

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

        // Fill regions to combobox
        private void Search_alue_Combobox_update() 
        {
            string selectQuery = "SELECT * FROM toimintaalue"; 
            ConnectionUtils.openConnection();
            MySqlCommand command = new MySqlCommand(selectQuery, ConnectionUtils.connection);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                cbSearchAluet.Items.Add(reader.GetString("nimi"));
            }
            ConnectionUtils.closeConnection();
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
            if (dtpSearchTO.Value.Date <= dtpSearchFROM.Value.Date) // Date check
            {
                MessageBox.Show("Majoituksen alkupäivä ei voi olla sama tai myöhemmin kun viimeinen majoituspäivä.", "Väärä päivämäärä", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (dtpSearchTO.Value.Date < DateTime.Now.Date) 
            {
                MessageBox.Show("Majoituksen alkupäivä ei voi olla aiemmin kun tämän hetkinen päivämäärä.", "Väärä päivämäärä", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DataTable data = new DataTable();

            string query = "SELECT m.mokki_id, t.nimi as toimintaalue, m.postinro, m.mokkinimi, m.katuosoite, m.kuvaus, m.henkilomaara, m.hinta " +
                "FROM mokki m INNER JOIN toimintaalue t " +
                "ON m.toimintaalue_id = t.toimintaalue_id ";

            if (cbSearchAlueKaikki.Checked == false) // Get alue_id
            {
                ConnectionUtils.openConnection();
                MySqlCommand command = new MySqlCommand("SELECT toimintaalue_id FROM toimintaalue WHERE nimi Like '" + cbSearchAluet.Text + "'", ConnectionUtils.connection);
                string alue_id = command.ExecuteScalar().ToString();
                ConnectionUtils.closeConnection();
                query += "WHERE m.toimintaalue_id LIKE '" + alue_id + "' ";
            }
            if (nudSearchHintaraja.Value != 0 && cbSearchAlueKaikki.Checked == true) // Set price limit
                query += "WHERE m.hinta <= '" + nudSearchHintaraja.Value + "' ";

            else if (nudSearchHintaraja.Value != 0 && cbSearchAlueKaikki.Checked == false)
                query += "AND m.hinta <= '" + nudSearchHintaraja.Value + "' ";

            if (nudSearchMaxhlo.Value != 0) // Set customer quantity
            {
                if (nudSearchHintaraja.Value != 0 || cbSearchAlueKaikki.Checked == false)
                    query += "AND ";
                else
                    query += "WHERE ";
                query += "m.henkilomaara >= '" + nudSearchMaxhlo.Value + "' ";
            }
            query += "AND m.mokki_id not IN " + // Check is cottage free on dates
                     "(SELECT mokki_mokki_id FROM varaus v " +
                     "WHERE '" + dtpSearchFROM.Text + " 16:00:00' <= v.varattu_loppupvm and '" + dtpSearchTO.Text + " 12:00:00' >= v.varattu_alkupvm)";
            MySqlDataAdapter sda = new MySqlDataAdapter(query, ConnectionUtils.connection);
            try
            {
                ConnectionUtils.openConnection();
                sda.Fill(data);
                dgSearchTable.DataSource = data;
                ConnectionUtils.closeConnection();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Virhe, yritä uudelleen\n\n" + ex, "Virhe", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btmSearchVarata_Click(object sender, EventArgs e) // New order
        {
            // Check date again, if user change data, and no do search
            if (!OrderUtils.ChechCottageBookDate(Convert.ToInt32(dgSearchTable.CurrentRow.Cells[0].Value), dtpSearchFROM.Text, dtpSearchTO.Text)) 
            {
                btnSearchHae_Click(sender, e);
                return;
            }

            ConnectionUtils.openConnection();
            MySqlCommand command = new MySqlCommand("SELECT toimintaalue_id FROM toimintaalue WHERE nimi Like '" + dgSearchTable.CurrentRow.Cells[1].Value.ToString() + "'", ConnectionUtils.connection);
            int toimintaalueid = Convert.ToInt32(command.ExecuteScalar().ToString());
            // Make object to send on Booking window
            Cottage cottage = new Cottage(Convert.ToInt32(dgSearchTable.CurrentRow.Cells[0].Value), toimintaalueid,
                dgSearchTable.CurrentRow.Cells[2].Value.ToString(), dgSearchTable.CurrentRow.Cells[3].Value.ToString(),
                dgSearchTable.CurrentRow.Cells[4].Value.ToString(), dgSearchTable.CurrentRow.Cells[5].Value.ToString(),
                Convert.ToInt32(dgSearchTable.CurrentRow.Cells[6].Value.ToString()), Convert.ToDouble(dgSearchTable.CurrentRow.Cells[7].Value.ToString()));
            ConnectionUtils.closeConnection();
            NewBook newbook = new NewBook(cottage, dtpSearchFROM.Value.Date, dtpSearchTO.Value.Date);
            Booking booking = new Booking(newbook);
            booking.ShowDialog();
        }
        
        private void dtpSearchFROM_ValueChanged(object sender, EventArgs e) // 'Date to' change close to 'date to'
        {
            dtpSearchTO.Value = dtpSearchFROM.Value.AddDays(+1);
        }

        private void dgSearchTable_SelectionChanged(object sender, EventArgs e) // Set button active when choose cottage
        {
            try
            {
                int mokki_id = Convert.ToInt32(dgSearchTable.SelectedCells[0].Value);
                btnSearchVarata.Enabled = true;
            }
            catch
            {
                btnSearchVarata.Enabled = false;
            }
        }

        //All button events occurring on the "Laskut" tab.
        private void btnBilling_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            //Search for an invoice

            if (btn == btnBillingSearch) 
            {
                billingSearch();
            }

            //Create a new bill for a reservation
            else if (btn == btnBillingCreate) 
            {
                try
                {
                    int varausID = Convert.ToInt32(txtboxBillingVarausID.Text);
                    BillingUtils.createInvoice(varausID);
                    txtboxBillingVarausID.Text = "";
                    BillingUtils.refreshDataGridView(dgvBilling);
                }
                catch (Exception ex)
                {
                    //MessageBox.Show("Antamaasi varausID:tä ei löytynyt.", "Virhe", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    MessageBox.Show(ex.Message);
                }
            }

            //Update the state of payment of a selected invoice
            else if (btn == btnBillingPaid || btn == btnBillingNotPaid)
            {
                bool paymentState;
                if (btn == btnBillingPaid)
                    paymentState = true;
                else
                    paymentState = false;

                int selectedRow = dgvBilling.CurrentCell.RowIndex;
                int lasku_id = Convert.ToInt32(dgvBilling.SelectedCells[0].Value);
                BillingUtils.setPaymentState(lasku_id, paymentState);
                BillingUtils.refreshDataGridView(dgvBilling);
                dgvBilling.ClearSelection();
                dgvBilling.CurrentCell = dgvBilling.Rows[selectedRow].Cells[0];
            }

            //Delete a selected invoice
            else if (btn == btnBillingDelete)
            {
                int lasku_id = Convert.ToInt32(dgvBilling.SelectedCells[0].Value);
                BillingUtils.deleteSelectedInvoice(lasku_id);
                BillingUtils.refreshDataGridView(dgvBilling);
                dgvBilling.ClearSelection();
            }

            //Create a PDF document of a selected bill
            else if (btn == btnBillingPDF)
            {
                try
                {
                    int lasku_id = Convert.ToInt32(dgvBilling.SelectedCells[0].Value);
                    BillingUtils.createPdfDocument(lasku_id);
                }
                catch(Exception ex)
                {
                    MessageBox.Show("PDF:n muodostaminen epäonnistui. Onko aiempi lasku vielä auki?", "Virhe", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //Checks if there's text in the invoiceID textbox on "Laskut" tab.
        private void txtboxBillingVarausID_TextChanged(object sender, EventArgs e)
        {
            if (txtboxBillingVarausID.Text != "")
                btnBillingCreate.Enabled = true;
            else
                btnBillingCreate.Enabled = false;
        }

        //Checks if the information of a selected row in Datagridview is available on "Laskut" tab. Restricts button press if not available
        private void dgvBilling_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                int lasku_id = Convert.ToInt32(dgvBilling.SelectedCells[0].Value);
                btnBillingDelete.Enabled = true;
                btnBillingNotPaid.Enabled = true;
                btnBillingPaid.Enabled = true;
                btnBillingPDF.Enabled = true;
            }
            catch (Exception ex)
            {
                btnBillingDelete.Enabled = false;
                btnBillingNotPaid.Enabled = false;
                btnBillingPaid.Enabled = false;
                btnBillingPDF.Enabled = false;
            }
        }

        //Executes a standard search query at "laskut" tab
        private void billingSearch()
        {
            ConnectionUtils.openConnection();
            string query = "SELECT l.lasku_id AS LaskuID, v.varaus_id, a.asiakas_id AS AsiakasID, CONCAT(a.etunimi, ' '," +
                            " a.sukunimi) AS 'Asiakkaan nimi', a.lahiosoite AS Lähiosoite, a.puhelinnro AS Puhelinnumero, " +
                            "a.email AS 'Sähköposti', " +
                            "l.summa as 'Summa (€)', l.maksettu AS 'maksu suoritettu' " +
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
                query += "AND l.maksettu = TRUE ORDER BY l.lasku_id;";
            else if (cbBillingPaid.SelectedIndex == 1)
                query += "AND l.maksettu = FALSE ORDER BY l.lasku_id;";
            else
                query += "ORDER BY l.lasku_id;";
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter(query, ConnectionUtils.connection);
            adapter.Fill(table);
            dgvBilling.DataSource = table;
            BillingUtils.latestQuery = query;
            ConnectionUtils.closeConnection();
        }




        //Adds region to the database
        private void AddRegion(object sender, EventArgs e)
        {
            ConnectionUtils.openConnection();
            string query3 = "START TRANSACTION; " +
                "INSERT INTO toimintaalue(toimintaalue_id,nimi) " +
                "VALUES(default,'" + tbRegionName.Text + "'); " +
                "COMMIT;";
            MySqlCommand command3 = new MySqlCommand(query3, ConnectionUtils.connection);
            command3.ExecuteNonQuery();
            ConnectionUtils.closeConnection();
            PopulateDGVRegion();
            lblRegionID.Text = "0000";
            tbRegionName.Text = "";
        }

        //Deletes selected region from database
        private void DeleteSelectedRegion(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Haluatko varmasti poistaa valitun toiminta-alueen?", "Poista toimialue", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                string query = "START TRANSACTION; " +
                    "DELETE FROM toimintaalue " +
                    "WHERE toimintaalue_id=" + dgvRegion.CurrentRow.Cells[0].Value.ToString() + "; " +
                    "COMMIT;";
                ConnectionUtils.openConnection();
                MySqlCommand command = new MySqlCommand(query, ConnectionUtils.connection);
                command.ExecuteNonQuery();
                ConnectionUtils.closeConnection();
                PopulateDGVRegion();
                lblRegionID.Text = "0000";
                tbRegionName.Text = "";
            }
        }

        //Updates components on the screen to highlight current row selection
        private void dgvRegionSelectionChanged(object sender, DataGridViewCellEventArgs e)
        {
            lblRegionID.Text = dgvRegion.CurrentRow.Cells[0].Value.ToString();
            tbRegionName.Text = dgvRegion.CurrentRow.Cells[1].Value.ToString();
        }

        //Clears textbox and RegionID-label when entering the tbRegionName-component
        private void tbRegionName_Enter(object sender, EventArgs e)
        {
            lblRegionID.Text = "0000";
            tbRegionName.Text = "";
        }

        public void PopulateDGVService()
        {
            string query = "SELECT * FROM palvelu";
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter(query, ConnectionUtils.connection);
            adapter.Fill(table);
            dgvService.DataSource = table;
        }

        public void PopulateDGVCottage()
        {
            string query = "SELECT * FROM mokki";
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter(query, ConnectionUtils.connection);
            adapter.Fill(table);
            dgvCottage.DataSource = table;
        }

        private void btnServiceAdd_Click(object sender, EventArgs e)
        {
            //Opens a form for adding service to the database
            AddServiceForm ASF = new AddServiceForm();
            ASF.ShowDialog();
            PopulateDGVService();
        }

        private void btnCottageAdd_Click(object sender, EventArgs e)
        {
            //Opens a form for adding a cottage to the database
            AddCottageForm ACF = new AddCottageForm();
            ACF.ShowDialog();
            PopulateDGVCottage();
        }

        private void btnRefereshCottages_Click(object sender, EventArgs e)
        {
            PopulateDGVCottage();
        }

        private void btnModifyCottage_Click(object sender, EventArgs e)
        {
            Cottage cottage = new Cottage(Convert.ToInt32(dgvCottage.CurrentRow.Cells[0].Value), Convert.ToInt32(dgvCottage.CurrentRow.Cells[1].Value), 
                dgvCottage.CurrentRow.Cells[2].Value.ToString(), dgvCottage.CurrentRow.Cells[3].Value.ToString(), dgvCottage.CurrentRow.Cells[4].Value.ToString(),
                dgvCottage.CurrentRow.Cells[5].Value.ToString(), Convert.ToInt32(dgvCottage.CurrentRow.Cells[6].Value),Convert.ToDouble(dgvCottage.CurrentRow.Cells[8].Value),
                dgvCottage.CurrentRow.Cells[7].Value.ToString());
            ModifyCottageForm MCF = new ModifyCottageForm(cottage);
            MCF.ShowDialog();
            PopulateDGVCottage();
        }

        private void btnCottageDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Haluatko varmasti poistaa valitun mökin tiedot?", "Poista mökin tiedot", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                string query = "START TRANSACTION; " +
                    "DELETE FROM mokki " +
                    "WHERE mokki_id=" + dgvCottage.CurrentRow.Cells[0].Value.ToString() + "; " +
                    "COMMIT;";
                ConnectionUtils.openConnection();
                MySqlCommand command = new MySqlCommand(query, ConnectionUtils.connection);
                command.ExecuteNonQuery();
                ConnectionUtils.closeConnection();
                PopulateDGVCottage();
            }
        }

        private void btnCottageSearch_Click(object sender, EventArgs e)
        {
            try
            {
                //Get's data from form components, and does a query to the DB. Updates CottageDataGridView-component so show search results
                string query = "SELECT * FROM mokki " +
                "WHERE toimintaalue_id = " + RegionUtils.RegionNameToIndex(cbCottageRegions.Text) + " " +
                "AND postinro LIKE '%" + tbCottagePostNum.Text + "%' " +
                "AND mokkinimi LIKE '%" + tbCottageName.Text + "%' " +
                "AND katuosoite LIKE '%" + tbCottageStreetAddress.Text + "%' " +
                "AND kuvaus LIKE '%" + tbCottageDescription.Text + "%' " +
                "AND henkilomaara > '" + nudCottageCapacity.Value + "' " +
                "AND varustelu LIKE '%" + tbCottageEqupment.Text + "%' " +
                "AND hinta <(" + (nudCottagePrice.Value + 1) + ");";
                try
                {
                    DataTable table = new DataTable();
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, ConnectionUtils.connection);
                    adapter.Fill(table);
                    dgvCottage.DataSource = table;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Virhe tietojen hakemisessa. Tarkista tiedot ja yritä uudelleen. Lisätietoja: " + ex.Message);
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Virhe haun tekemisessä. Tarkista tiedot ja yritä uudelleen. Lisätietoja: " + ex.Message); 
            }
            
        }

        private void btnServiceModify_Click(object sender, EventArgs e)
        {
            Service service = new Service(Convert.ToInt32(dgvService.CurrentRow.Cells[0].Value),Convert.ToInt32(dgvService.CurrentRow.Cells[1].Value),
                dgvService.CurrentRow.Cells[2].Value.ToString(), Convert.ToInt32(dgvService.CurrentRow.Cells[3].Value), dgvService.CurrentRow.Cells[4].Value.ToString(),
                Convert.ToDouble(dgvService.CurrentRow.Cells[5].Value), Convert.ToDouble(dgvService.CurrentRow.Cells[6].Value));
            ModifyServiceForm MSF = new ModifyServiceForm(service);
            MSF.ShowDialog();
            PopulateDGVService();
        }
    }
}