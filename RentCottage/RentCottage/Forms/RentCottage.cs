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
            PopulateDGVBilling();
            RegionUtils.PopulateCBRegion(cbSearchAluet);
            RegionUtils.PopulateCBRegion(cbCottageRegions);
            RegionUtils.PopulateCBRegion(cbServiceRegion);
            cbSearchAluet.SelectedIndex = 0;
            cbSearchVarustelu.SelectedIndex = 0;
            cbBillingPaid.SelectedIndex = 2;
            tbOrderSearch.Tag = tbOrderSearch.Text = "Kirjoita hakusana...";
            tbOrderSearch.ForeColor = Color.Gray;
            tbOrderSearch.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Italic);
            BillingUtils.rentCottage = this;
        }

        public void PopulateDGVRegion()
        {
            //Fills the DGVRegion-component with data from the DB
            string query = "SELECT * FROM toimintaalue";
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter(query, ConnectionUtils.connection);
            adapter.Fill(table);
            dgvRegion.DataSource = table;
            dgvRegion.Columns[0].HeaderText = "Toiminta-Alue ID";
            dgvRegion.Columns[1].HeaderText = "Toiminta-alueen nimi";
            dgvRegion.Sort(dgvRegion.Columns[0], ListSortDirection.Ascending);
        }

        public void PopulateDGVOrder()
        {
            string query = "SELECT * FROM varaus";
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter(query, ConnectionUtils.connection);
            adapter.Fill(table);
            dgOrder.DataSource = table;
            dgOrder.Columns[0].HeaderText = "Varaus ID";
            dgOrder.Columns[1].HeaderText = "Asiakas ID";
            dgOrder.Columns[2].HeaderText = "Mökki ID";
            dgOrder.Columns[3].HeaderText = "Varaus tehty (pvm)";
            dgOrder.Columns[4].HeaderText = "Maksettu (pvm)";
            dgOrder.Columns[5].HeaderText = "Varaus alkaa (pvm)";
            dgOrder.Columns[6].HeaderText = "Varaus loppuu (pvm)";
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

        private void btnOrderSearch_Click(object sender, EventArgs e) //Make a search by input
        {
            if (cmbListOrder.Text == "Varaus ID")
            {
                MySqlDataAdapter sda = new MySqlDataAdapter("SELECT * FROM Varaus WHERE VARAUS_ID = '" + tbOrderSearch.Text + "'", ConnectionUtils.connection);
                DataTable data = new DataTable();
                sda.Fill(data);
                dgOrder.DataSource = data;
            }
            if (cmbListOrder.Text == "Asiakas ID")
            {
                MySqlDataAdapter sda = new MySqlDataAdapter("SELECT * FROM Varaus WHERE ASIAKAS_ID = '" + tbOrderSearch.Text + "'", ConnectionUtils.connection);
                DataTable data = new DataTable();
                sda.Fill(data);
                dgOrder.DataSource = data;
            }
            if (cmbListOrder.Text == "Mökki ID")
            {
                MySqlDataAdapter sda = new MySqlDataAdapter("SELECT * FROM Varaus WHERE MOKKI_MOKKI_ID = '" + tbOrderSearch.Text + "'", ConnectionUtils.connection);
                DataTable data = new DataTable();
                sda.Fill(data);
                dgOrder.DataSource = data;
            }
            if (cmbListOrder.Text == "Varattu (pvm)")
            {
                MySqlDataAdapter sda = new MySqlDataAdapter("SELECT * FROM Varaus WHERE (VARATTU_PVM LIKE '%" + dtpOrder.Text + "%')", ConnectionUtils.connection);
                DataTable data = new DataTable();
                sda.Fill(data);
                dgOrder.DataSource = data;
            }
            if (cmbListOrder.Text == "Maksettu (pvm)")
            {
                MySqlDataAdapter sda = new MySqlDataAdapter("SELECT * FROM Varaus WHERE (VAHVISTUS_PVM LIKE '%" + dtpOrder.Text + "%')", ConnectionUtils.connection);
                DataTable data = new DataTable();
                sda.Fill(data);
                dgOrder.DataSource = data;
            }
            if (cmbListOrder.Text == "Alkaa (pvm)")
            {
                MySqlDataAdapter sda = new MySqlDataAdapter("SELECT * FROM Varaus WHERE (VARATTU_ALKUPVM LIKE '%" + dtpOrder.Text + "%')", ConnectionUtils.connection);
                DataTable data = new DataTable();
                sda.Fill(data);
                dgOrder.DataSource = data;
            }
            if (cmbListOrder.Text == "Loppuu (pvm)")
            {
                MySqlDataAdapter sda = new MySqlDataAdapter("SELECT * FROM Varaus WHERE (VARATTU_LOPPUPVM LIKE '%" + dtpOrder.Text + "%')", ConnectionUtils.connection);
                DataTable data = new DataTable();
                sda.Fill(data);
                dgOrder.DataSource = data;
            }
        }

        private void btnOrderShowAll_Click(object sender, EventArgs e)
        {
            PopulateDGVOrder();
        }

        private void dgOrder_SelectionChanged(object sender, EventArgs e) //If no row was selected can't make a changes
        {
            try
            {
                int varaus_id = Convert.ToInt32(dgOrder.SelectedCells[0].Value);
                btnOrderChange.Enabled = true;
                btnOrderRemove.Enabled = true;
                btnOrderCreateInvoice.Enabled = true;

            }
            catch
            {
                btnOrderChange.Enabled = false;
                btnOrderRemove.Enabled = false;
                btnOrderCreateInvoice.Enabled = false;
            }
        }

        private void tbOrderSearch_TextChanged(object sender, EventArgs e)
        {
            tbOrderSearch.ForeColor = Color.Black;
            tbOrderSearch.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Regular);
        }

        private void btnOrderChange_Click(object sender, EventArgs e) //Order form appear with selected data
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
            if (cmbListOrder.Text == "Varattu (pvm)" || cmbListOrder.Text == "Maksettu (pvm)" || cmbListOrder.Text == "Alkaa (pvm)" || cmbListOrder.Text == "Loppuu (pvm)")
            {
                dtpOrder.Visible = true;
            }
            else
                dtpOrder.Visible = false;
        }

        private void btnOrderRemove_Click(object sender, EventArgs e) //Delete order from database
        {
            DialogResult res = MessageBox.Show("Haluatko varmasti poistaa varauksen?", "Poista varaus", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (res == DialogResult.Yes)
            {
                string query = "START TRANSACTION; " +
                    "DELETE FROM varaus " +
                    "WHERE varaus_id=" + dgOrder.CurrentRow.Cells[0].Value.ToString() + "; " +
                    "COMMIT;";
                ConnectionUtils.OpenConnection();
                MySqlCommand command = new MySqlCommand(query, ConnectionUtils.connection);
                command.ExecuteNonQuery();
                ConnectionUtils.CloseConnection();
                PopulateDGVOrder();
            }
        }


        //codes related to Asiakashallinta


        public void PopulateDGVCustomer() //get data from asiakas-table to datagridview
        {
            string query = "SELECT * FROM asiakas;";
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter(query, ConnectionUtils.connection);
            adapter.Fill(table);
            dgvCustomer.DataSource = table;
            dgvCustomer.Columns[0].HeaderText = "Asiakas ID";
            dgvCustomer.Columns[1].HeaderText = "Postinumero";
            dgvCustomer.Columns[2].HeaderText = "Etunimi";
            dgvCustomer.Columns[3].HeaderText = "Sukunimi";
            dgvCustomer.Columns[4].HeaderText = "Lähiosoite";
            dgvCustomer.Columns[5].HeaderText = "Sähköposti";
            dgvCustomer.Columns[6].HeaderText = "Puhelinnumero";
        }

        private void btnCustomerSearch_Click(object sender, EventArgs e) //get data from asiakas-table to datagridview according to the search criteria
        {
            string query = "SELECT * FROM asiakas " +
                "WHERE postinro LIKE '%" + TextBoxUtils.ModifyInput(tbCustomerPostal.Text, tbCustomerPostal.MaxLength) + "%' " +
                "AND etunimi LIKE '%" + TextBoxUtils.ModifyInput(tbCustomerFName.Text, tbCustomerFName.MaxLength) + "%' " +
                "AND sukunimi LIKE '%" + TextBoxUtils.ModifyInput(tbCustomerLName.Text, tbCustomerLName.MaxLength) + "%' " +
                "AND lahiosoite LIKE '%" + TextBoxUtils.ModifyInput(tbCustomerAddress.Text, tbCustomerAddress.MaxLength) + "%' " +
                "AND email LIKE '%" + TextBoxUtils.ModifyInput(tbCustomerEmail.Text, tbCustomerEmail.MaxLength) + "%' " +
                "AND puhelinnro LIKE '%" + TextBoxUtils.ModifyInput(tbCustomerPhone.Text, tbCustomerPhone.MaxLength) + "%';";
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter(query, ConnectionUtils.connection);
            adapter.Fill(table);
            dgvCustomer.DataSource = table;
            dgvCustomer.Columns[0].HeaderText = "Asiakas ID";
            dgvCustomer.Columns[1].HeaderText = "Postinumero";
            dgvCustomer.Columns[2].HeaderText = "Etunimi";
            dgvCustomer.Columns[3].HeaderText = "Sukunimi";
            dgvCustomer.Columns[4].HeaderText = "Lähiosoite";
            dgvCustomer.Columns[5].HeaderText = "Sähköposti";
            dgvCustomer.Columns[6].HeaderText = "Puhelinnumero";
        }

        private void btnCustomerShowAll_Click(object sender, EventArgs e) //show all customers on datagridview
        {
            PopulateDGVCustomer();
        }

        private void btnCustomerAdd_Click(object sender, EventArgs e) //add a new customer
        {
            AddCustomerForm ACF = new AddCustomerForm();
            ACF.ShowDialog();
            PopulateDGVCustomer();
        }

        private void btnCustomerDeleteInfo_Click(object sender, EventArgs e) //delete customer's identifying data from database
        {   //First, we need to check whether the customer has unpaid bills
            ConnectionUtils.OpenConnection();
            string query0 = "SELECT l.maksettu " +
                "FROM lasku l JOIN varaus v " +
                "ON l.varaus_id = v.varaus_id " +
                "JOIN asiakas a " +
                "ON v.asiakas_id = a.asiakas_id " +
                "WHERE a.asiakas_id =" + dgvCustomer.CurrentRow.Cells[0].Value.ToString() + ";";
            MySqlCommand command0 = new MySqlCommand(query0, ConnectionUtils.connection);
            MySqlDataReader reader = null;
            reader = command0.ExecuteReader();
            ArrayList billList = new ArrayList();
            while (reader.Read())
            {
                billList.Add((bool)reader["maksettu"]);
            }
            reader.Close();
            ConnectionUtils.CloseConnection();
            bool unpaidBills = false;
            foreach (bool b in billList)
            {
                if (b.Equals(false))
                {
                    unpaidBills = true; //unpaid bill found
                }
            }
            if (unpaidBills)
            {
                MessageBox.Show("Asiakkaalla on maksamattomia laskuja. Tietoja ei voida poistaa.", "Maksamattomia laskuja", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else //the customer does not have unpaid bills, so we can proceed to remove his/her data
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
                    ConnectionUtils.OpenConnection();
                    MySqlCommand command = new MySqlCommand(query, ConnectionUtils.connection);
                    command.ExecuteNonQuery();
                    ConnectionUtils.CloseConnection();
                    PopulateDGVCustomer();
                }
            }
        }

        private void btnCustomerModify_Click(object sender, EventArgs e) //modify the customer's data
        {
            Customer customer = new Customer(Convert.ToInt32(dgvCustomer.CurrentRow.Cells[0].Value), dgvCustomer.CurrentRow.Cells[1].Value.ToString(),
                dgvCustomer.CurrentRow.Cells[2].Value.ToString(), dgvCustomer.CurrentRow.Cells[3].Value.ToString(),
                dgvCustomer.CurrentRow.Cells[4].Value.ToString(), dgvCustomer.CurrentRow.Cells[5].Value.ToString(),
                dgvCustomer.CurrentRow.Cells[6].Value.ToString());
            ModifyCustomerForm MCF = new ModifyCustomerForm(customer);
            MCF.ShowDialog();
            PopulateDGVCustomer();
        }

        private void dgvCustomer_SelectionChanged(object sender, EventArgs e)
        {
            //Disable buttons if there are no rows in dgvCustomer
            try
            {
                int customer_id = Convert.ToInt32(dgvCustomer.SelectedCells[0].Value);
                btnCustomerModify.Enabled = true;
                btnCustomerDeleteInfo.Enabled = true;
            }
            catch (Exception ex)
            {
                btnCustomerModify.Enabled = false;
                btnCustomerDeleteInfo.Enabled = false;
            }
        }


        //Search

        // Fill regions to combobox

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
            DataTable data = new DataTable();

            string query = "SELECT m.mokki_id, t.nimi as Toimintaalue, m.postinro as Postinumero, m.mokkinimi as 'Nimi', m.katuosoite, " +
                "m.kuvaus as 'Kuvaus', m.henkilomaara, m.varustelu as 'Varustelu', m.hinta " +
                "FROM mokki m INNER JOIN toimintaalue t " +
                "ON m.toimintaalue_id = t.toimintaalue_id ";

            if (cbSearchAlueKaikki.Checked == false) // Get alue_id
            {
                ConnectionUtils.OpenConnection();
                MySqlCommand command = new MySqlCommand("SELECT toimintaalue_id FROM toimintaalue WHERE nimi Like '" + cbSearchAluet.Text + "'", ConnectionUtils.connection);
                string alue_id = command.ExecuteScalar().ToString();
                ConnectionUtils.CloseConnection();
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
            if (cbSearchVarustelu.Text != "Kaikki")
            {
                if (nudSearchHintaraja.Value == 0 && cbSearchAlueKaikki.Checked == true && nudSearchMaxhlo.Value == 0)
                {
                    query += "WHERE varustelu = '" + cbSearchVarustelu.Text + "' ";
                }
                else
                {
                    query += "AND varustelu = '" + cbSearchVarustelu.Text + "' ";
                }
            }
            query += "AND m.mokki_id not IN " + // Check is cottage free on dates
                     "(SELECT mokki_mokki_id FROM varaus v " +
                     "WHERE '" + dtpSearchFROM.Text + " 16:00:00' <= v.varattu_loppupvm and '" + dtpSearchTO.Text + " 12:00:00' >= v.varattu_alkupvm)";
            MySqlDataAdapter sda = new MySqlDataAdapter(query, ConnectionUtils.connection);
            try
            {
                ConnectionUtils.OpenConnection();
                dgSearchTable.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgSearchTable.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter;
                sda.Fill(data);
                dgSearchTable.DataSource = data;
                dgSearchTable.Columns[0].HeaderText = "Mökki ID";
                dgSearchTable.Columns[4].HeaderText = "Lähiosoite";
                dgSearchTable.Columns[6].HeaderText = "Henkilömäärä(max)";
                dgSearchTable.Columns[8].HeaderText = "Hinta (€)";
                ConnectionUtils.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Virhe, yritä uudelleen\n\n" + ex, "Virhe", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btmSearchVarata_Click(object sender, EventArgs e) // New order
        {
            // Check date again, if user change data, and no do search
            if (!OrderUtils.CheckCottageBookDate(Convert.ToInt32(dgSearchTable.CurrentRow.Cells[0].Value), dtpSearchFROM.Text, dtpSearchTO.Text))
            {
                btnSearchHae_Click(sender, e);
                return;
            }

            ConnectionUtils.OpenConnection();
            MySqlCommand command = new MySqlCommand("SELECT toimintaalue_id FROM toimintaalue WHERE nimi Like '" +
                dgSearchTable.CurrentRow.Cells[1].Value.ToString() + "'", ConnectionUtils.connection);
            int toimintaalueid = Convert.ToInt32(command.ExecuteScalar().ToString());
            // Make object to send on Booking window
            Cottage cottage = new Cottage(Convert.ToInt32(dgSearchTable.CurrentRow.Cells[0].Value), toimintaalueid,
                dgSearchTable.CurrentRow.Cells[2].Value.ToString(), dgSearchTable.CurrentRow.Cells[3].Value.ToString(),
                dgSearchTable.CurrentRow.Cells[4].Value.ToString(), dgSearchTable.CurrentRow.Cells[5].Value.ToString(),
                Convert.ToInt32(dgSearchTable.CurrentRow.Cells[6].Value.ToString()), dgSearchTable.CurrentRow.Cells[7].Value.ToString(),
                Convert.ToDouble(dgSearchTable.CurrentRow.Cells[8].Value.ToString()));
            ConnectionUtils.CloseConnection();
            NewBook newbook = new NewBook(cottage, dtpSearchFROM.Value.Date, dtpSearchTO.Value.Date);
            Booking booking = new Booking(newbook);
            booking.ShowDialog();
        }

        private void dtpSearchFROM_ValueChanged(object sender, EventArgs e) // 'Date to' change close to 'date to'
        {
            if (dtpSearchFROM.Value.Date < DateTime.Now.Date)
            {
                MessageBox.Show("Majoituksen alkupäivä ei voi olla aiemmin kun tämän hetkinen päivämäärä.", "Väärä päivämäärä", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtpSearchFROM.Value = DateTime.Now.Date;
            }
            dtpSearchTO.Value = dtpSearchFROM.Value.AddDays(+1);
        }

        private void dtpSearchTO_ValueChanged(object sender, EventArgs e)
        {
            if (dtpSearchTO.Value <= dtpSearchFROM.Value)
            {
                MessageBox.Show("Majoituksen loppupäivä ei voi olla sama tai aiemmin kun majoituksen alkupäivä.", "Väärä päivämäärä", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtpSearchTO.Value = dtpSearchFROM.Value.AddDays(+1);
            }
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

        ///<summary>All button events occurring on the "Laskut" tab.</summary>
        private void btnBilling_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            //Search for an invoice
            if (btn == btnBillingSearch)
            {
                PopulateDGVBilling();
            }

            //Update the state of payment of a selected invoice
            else if (btn == btnBillingPaid || btn == btnBillingNotPaid)
            {
                try
                {
                    string paymentDate;
                    if (btn == btnBillingPaid)
                    {
                        DateTime myDateTime = DateTime.Now;
                        paymentDate = myDateTime.ToString("yyyy-MM-dd HH:mm:ss");
                        paymentDate = "'" + paymentDate + "'";
                    }
                    else
                        paymentDate = "NULL";

                    int selectedRow = dgvBilling.CurrentCell.RowIndex;
                    int lasku_id = Convert.ToInt32(dgvBilling.SelectedCells[0].Value);
                    BillingUtils.SetPaymentState(lasku_id, paymentDate);
                    BillingUtils.RefreshDataGridView(dgvBilling);
                    dgvBilling.ClearSelection();
                    dgvBilling.CurrentCell = dgvBilling.Rows[selectedRow].Cells[0];
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Odottamaton virhe. Laskun maksutilanteen päivitys epäonnistui.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            //Delete a selected invoice
            else if (btn == btnBillingDelete)
            {
                DialogResult result = MessageBox.Show("Halutko varmasti poistaa valitun laskun?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    int lasku_id = Convert.ToInt32(dgvBilling.SelectedCells[0].Value);
                    BillingUtils.DeleteSelectedInvoice(lasku_id);
                    BillingUtils.RefreshDataGridView(dgvBilling);
                    dgvBilling.ClearSelection();
                }
            }

            //Create a PDF document of a selected bill
            else if (btn == btnBillingPDF)
            {
                try
                {
                    int lasku_id = Convert.ToInt32(dgvBilling.SelectedCells[0].Value);
                    BillingUtils.CreatePdfDocument(lasku_id);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("PDF:n muodostaminen epäonnistui. Onko aiempi lasku vielä auki?", "Virhe", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            //Show all invoices
            else if (btn == btnBillingShowAll)
            {
                txtboxBillingCustomerID.Text = "";
                txtboxBillingEmail.Text = "";
                txtboxBillingInvoiceID.Text = "";
                txtboxBillingLastname.Text = "";
                txtboxBillingOrderID.Text = "";
                txtboxBillingPhone.Text = "";
                txtboxBillingSurname.Text = "";
                cbBillingPaid.SelectedIndex = 2;
                PopulateDGVBilling();
            }
        }

        ///<summary>Checks if the information of a selected row in Datagridview is available on "Laskut" tab. Restricts button press if not available</summary>
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

        ///<summary>Executes a standard search query at "laskut" tab</summary>
        private void PopulateDGVBilling()
        {
            ConnectionUtils.OpenConnection();
            string query = "SELECT l.lasku_id, v.varaus_id, a.asiakas_id, CONCAT(a.etunimi, ' ', a.sukunimi) " +
                ", a.lahiosoite, a.puhelinnro, a.email, l.summa, v.vahvistus_pvm " +
                "FROM lasku l " +
                "JOIN varaus v ON l.varaus_id = v.varaus_id " +
                "JOIN asiakas a ON v.asiakas_id = a.asiakas_id " +
                "WHERE l.lasku_id LIKE '%" + TextBoxUtils.ModifyInput(txtboxBillingInvoiceID.Text, 11) + "%' " +
                "AND v.varaus_id LIKE '%" + TextBoxUtils.ModifyInput(txtboxBillingOrderID.Text, 11) + "%' " +
                "AND a.asiakas_id LIKE '%" + TextBoxUtils.ModifyInput(txtboxBillingCustomerID.Text, 11) + "%' " +
                "AND a.etunimi LIKE '%" + TextBoxUtils.ModifyInput(txtboxBillingSurname.Text, 20) + "%' " +
                "AND a.sukunimi LIKE '%" + TextBoxUtils.ModifyInput(txtboxBillingLastname.Text, 40) + "%' " +
                "AND a.email LIKE '%" + TextBoxUtils.ModifyInput(txtboxBillingEmail.Text, 50) + "%' " +
                "AND a.puhelinnro LIKE '%" + TextBoxUtils.ModifyInput(txtboxBillingPhone.Text, 15) + "%' ";
            if (cbBillingPaid.SelectedIndex == 0)
                query += "AND v.vahvistus_pvm IS NOT NULL ORDER BY l.lasku_id;";
            else if (cbBillingPaid.SelectedIndex == 1)
                query += "AND v.vahvistus_pvm IS NULL ORDER BY l.lasku_id;";
            else
                query += "ORDER BY l.lasku_id;";
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter(query, ConnectionUtils.connection);
            adapter.Fill(table);
            dgvBilling.DataSource = table;
            dgvBilling.Columns[0].HeaderText = "Lasku ID";
            dgvBilling.Columns[1].HeaderText = "Varaus ID";
            dgvBilling.Columns[2].HeaderText = "Asiakas ID";
            dgvBilling.Columns[3].HeaderText = "Asiakkaan nimi";
            dgvBilling.Columns[4].HeaderText = "Lähiosoite";
            dgvBilling.Columns[5].HeaderText = "Puhelinnumero";
            dgvBilling.Columns[6].HeaderText = "Sähköposti";
            dgvBilling.Columns[7].HeaderText = "Summa (€)";
            dgvBilling.Columns[8].HeaderText = "Maksettu (pvm)";
            BillingUtils.latestQuery = query;
            ConnectionUtils.CloseConnection();
        }

        ///<summary>Create a new bill for a reservation</summary>
        private void btnOrderCreateInvoice_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Luodaanko valitulle varaukselle lasku?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    int varaus_id = Convert.ToInt32(dgOrder.SelectedCells[0].Value);
                    BillingUtils.CreateInvoice(varaus_id);
                    BillingUtils.RefreshDataGridView(dgvBilling);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Odottamaton virhe. Laskun luonti ei onnistunut.", "Virhe", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvRegion_SelectionChanged(object sender, EventArgs e)
        {
            //Disable buttons if there are no rows in dgvRegion
            try
            {
                int region_id = Convert.ToInt32(dgvRegion.SelectedCells[0].Value);
                btnRegionModify.Enabled = true;
                btnRegionDelete.Enabled = true;
            }
            catch (Exception ex)
            {
                btnRegionModify.Enabled = false;
                btnRegionDelete.Enabled = false;
            }
        }

        private void AddRegion(object sender, EventArgs e)
        {
            //Open form for adding a region to the database
            AddRegionForm ARF = new AddRegionForm();
            ARF.ShowDialog();
            PopulateDGVRegion();
        }


        private void DeleteSelectedRegion(object sender, EventArgs e)
        {
            //Deletes selected region from database

            DialogResult result = MessageBox.Show("Haluatko varmasti poistaa valitun toiminta-alueen?", "Poista toimialue", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                try
                {
                    string query = "START TRANSACTION; " +
                    "DELETE FROM toimintaalue " +
                    "WHERE toimintaalue_id=" + dgvRegion.CurrentRow.Cells[0].Value.ToString() + "; " +
                    "COMMIT;";
                    ConnectionUtils.OpenConnection();
                    MySqlCommand command = new MySqlCommand(query, ConnectionUtils.connection);
                    command.ExecuteNonQuery();
                    ConnectionUtils.CloseConnection();
                    PopulateDGVRegion();
                    tbRegionName.Text = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Alueen poisto epäonnistui. Varmista, ettei alueeseen ole liitetty palveluita tai mökkejä, ja yritä uudelleen.", "Poisto epäonnistui"
                        , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
        }

        private void btnRegionReferesh_Click(object sender, EventArgs e)
        {
            //Referesh DGVRegion-component
            PopulateDGVRegion();
        }

        private void btnRegionModify_Click(object sender, EventArgs e)
        {
            try
            {
                Code.Region region = new Code.Region(Convert.ToInt32(dgvRegion.CurrentRow.Cells[0].Value), dgvRegion.CurrentRow.Cells[1].Value.ToString());
                ModifyRegionForm MRF = new ModifyRegionForm(region);
                MRF.ShowDialog();
                PopulateDGVRegion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Tietojen muunnossa tapahtui virhe. Yritä myöhemmin uudelleen.", "Virhe"
                        , MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void btnRegionSearch_Click(object sender, EventArgs e)
        {
            try
            {
                //Get's data from tbRegionName, and does a query to the DB. Updates dgvRegion-component to show search results
                string query = "SELECT * FROM toimintaalue " +
                "WHERE nimi LIKE '%" + TextBoxUtils.ModifyInput(tbRegionName.Text, 40) + "%';";
                try
                {
                    DataTable table = new DataTable();
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, ConnectionUtils.connection);
                    adapter.Fill(table);
                    dgvRegion.DataSource = table;
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


        public void PopulateDGVService()
        {
            //Fills the DGVService-component with data from DB
            string query = "SELECT * FROM palvelu";
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter(query, ConnectionUtils.connection);
            adapter.Fill(table);
            dgvService.DataSource = table;
            dgvService.Columns[0].HeaderText = "Palvelu ID";
            dgvService.Columns[1].HeaderText = "Toiminta-alue ID";
            dgvService.Columns[2].HeaderText = "Nimi";
            dgvService.Columns[3].HeaderText = "Tyyppi";
            dgvService.Columns[4].HeaderText = "Kuvaus";
            dgvService.Columns[5].HeaderText = "Hinta (€)";
            dgvService.Columns[6].HeaderText = "Alv (%)";

        }

        private void dgvService_SelectionChanged(object sender, EventArgs e)
        {
            //Disable buttons if there are no rows in dgvService
            try
            {
                int service_id = Convert.ToInt32(dgvService.SelectedCells[0].Value);
                btnServiceModify.Enabled = true;
                btnServiceDelete.Enabled = true;
            }
            catch (Exception ex)
            {
                btnServiceModify.Enabled = false;
                btnServiceDelete.Enabled = false;
            }
        }

        public void PopulateDGVCottage()
        {
            //Fills the DGVCottage-component with data from DB
            string query = "SELECT * FROM mokki";
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter(query, ConnectionUtils.connection);
            adapter.Fill(table);
            dgvCottage.DataSource = table;
            dgvCottage.Columns[0].HeaderText = "Mökki ID";
            dgvCottage.Columns[1].HeaderText = "Toiminta-alue ID";
            dgvCottage.Columns[2].HeaderText = "Postinumero";
            dgvCottage.Columns[3].HeaderText = "Mökkinimi";
            dgvCottage.Columns[4].HeaderText = "Katuosoite";
            dgvCottage.Columns[5].HeaderText = "Kuvaus";
            dgvCottage.Columns[6].HeaderText = "Henkilömäärä (max)";
            dgvCottage.Columns[7].HeaderText = "Varustelu";
            dgvCottage.Columns[8].HeaderText = "Hinta";
        }

        private void dgvCottage_SelectionChanged(object sender, EventArgs e)
        {
            //Disable buttons if there are no rows in dgvCottage
            try
            {
                int cottage_id = Convert.ToInt32(dgvCottage.SelectedCells[0].Value);
                btnModifyCottage.Enabled = true;
                btnCottageDelete.Enabled = true;
            }
            catch (Exception ex)
            {
                btnModifyCottage.Enabled = false;
                btnCottageDelete.Enabled = false;
            }
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
            try
            {
                Cottage cottage = new Cottage(Convert.ToInt32(dgvCottage.CurrentRow.Cells[0].Value), Convert.ToInt32(dgvCottage.CurrentRow.Cells[1].Value),
                dgvCottage.CurrentRow.Cells[2].Value.ToString(), dgvCottage.CurrentRow.Cells[3].Value.ToString(), dgvCottage.CurrentRow.Cells[4].Value.ToString(),
                dgvCottage.CurrentRow.Cells[5].Value.ToString(), Convert.ToInt32(dgvCottage.CurrentRow.Cells[6].Value), Convert.ToDouble(dgvCottage.CurrentRow.Cells[8].Value),
                dgvCottage.CurrentRow.Cells[7].Value.ToString());
                ModifyCottageForm MCF = new ModifyCottageForm(cottage);
                MCF.ShowDialog();
                PopulateDGVCottage();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Mökin valinta epäonnistui. Yritä kohta uudelleen. Lisätietoja: " + ex.Message);
            }

        }

        private void btnCottageDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Haluatko varmasti poistaa valitun mökin tiedot?", "Poista mökin tiedot", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    string query = "START TRANSACTION; " +
                        "DELETE FROM mokki " +
                        "WHERE mokki_id=" + dgvCottage.CurrentRow.Cells[0].Value.ToString() + "; " +
                        "COMMIT;";
                    ConnectionUtils.OpenConnection();
                    MySqlCommand command = new MySqlCommand(query, ConnectionUtils.connection);
                    command.ExecuteNonQuery();
                    ConnectionUtils.CloseConnection();
                    PopulateDGVCottage();
                }
            }
            catch (Exception ex)
            {
                ConnectionUtils.CloseConnection();
                MessageBox.Show("Tietojen poisto ei onnistunut. Yritä uudelleen myöhemmin. Lisätietoja: " + ex.Message);
            }

        }

        private void btnCottageSearch_Click(object sender, EventArgs e)
        {
            try
            {
                //Get's data from form components, and does a query to the DB. Updates CottageDataGridView-component to show search results
                string query = "SELECT * FROM mokki " +
                "WHERE toimintaalue_id = " + RegionUtils.RegionNameToIndex(cbCottageRegions.Text) + " " +
                "AND postinro LIKE '%" + TextBoxUtils.ModifyInput(tbCottagePostNum.Text, 5) + "%' " +
                "AND mokkinimi LIKE '%" + TextBoxUtils.ModifyInput(tbCottageName.Text, 45) + "%' " +
                "AND katuosoite LIKE '%" + TextBoxUtils.ModifyInput(tbCottageStreetAddress.Text, 45) + "%' " +
                "AND kuvaus LIKE '%" + TextBoxUtils.ModifyInput(tbCottageDescription.Text, 500) + "%' " +
                "AND henkilomaara > '" + (nudCottageCapacity.Value - 1) + "' " +
                "AND varustelu LIKE '%" + cbCottageEqupment.Text + "%' " +
                "AND hinta <(" + Convert.ToDouble(nudCottagePrice.Value + 1) + ");";
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
            try
            {
                Service service = new Service(Convert.ToInt32(dgvService.CurrentRow.Cells[0].Value), Convert.ToInt32(dgvService.CurrentRow.Cells[1].Value),
                                dgvService.CurrentRow.Cells[2].Value.ToString(), Convert.ToInt32(dgvService.CurrentRow.Cells[3].Value), dgvService.CurrentRow.Cells[4].Value.ToString(),
                                Convert.ToDouble(dgvService.CurrentRow.Cells[5].Value), Convert.ToDouble(dgvService.CurrentRow.Cells[6].Value));
                ModifyServiceForm MSF = new ModifyServiceForm(service);
                MSF.ShowDialog();
                PopulateDGVService();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Palvelun valinta epäonnistui. Yritä kohta uudelleen. Lisätietoja: " + ex.Message);
            }

        }

        private void btnServiceShowAll_Click(object sender, EventArgs e)
        {
            PopulateDGVService();
        }

        private void btnServiceDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Haluatko varmasti poistaa valitun palvelun tiedot?", "Poista palvelun tiedot", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                try
                {
                    string query = "START TRANSACTION; " +
                                        "DELETE FROM palvelu " +
                                        "WHERE palvelu_id=" + dgvService.CurrentRow.Cells[0].Value.ToString() + "; " +
                                        "COMMIT;";
                    ConnectionUtils.OpenConnection();
                    MySqlCommand command = new MySqlCommand(query, ConnectionUtils.connection);
                    command.ExecuteNonQuery();
                    ConnectionUtils.CloseConnection();
                    PopulateDGVService();
                }
                catch (Exception ex)
                {
                    ConnectionUtils.CloseConnection();
                    MessageBox.Show("Tietojen poisto ei onnistunut. Yritä uudelleen myöhemmin. Lisätietoja: " + ex.Message);
                }

            }
        }

        private void btnServiceSearch_Click(object sender, EventArgs e)
        {
            try
            {
                //Get's data from form components, and does a query to the DB. Updates ServiceDataGridView-component to show search results
                string query = "SELECT * FROM palvelu " +
                "WHERE toimintaalue_id = " + RegionUtils.RegionNameToIndex(cbServiceRegion.Text) + " " +
                "AND nimi LIKE '%" + TextBoxUtils.ModifyInput(tbServiceName.Text, 40) + "%' " +
                "AND tyyppi LIKE '%" + tbServiceType.Text + "%' " +
                "AND kuvaus LIKE '%" + TextBoxUtils.ModifyInput(tbServiceDescription.Text, 500) + "%' " +
                "AND hinta <(" + (nudServicePrice.Value + 1) + ");";
                try
                {
                    DataTable table = new DataTable();
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, ConnectionUtils.connection);
                    adapter.Fill(table);
                    dgvService.DataSource = table;
                    dgvService.Columns[0].HeaderText = "Palvelu ID";
                    dgvService.Columns[1].HeaderText = "Toiminta-alue ID";
                    dgvService.Columns[2].HeaderText = "Nimi";
                    dgvService.Columns[3].HeaderText = "Tyyppi";
                    dgvService.Columns[4].HeaderText = "Kuvaus";
                    dgvService.Columns[5].HeaderText = "Hinta (€)";
                    dgvService.Columns[6].HeaderText = "Alv (%)";
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


        

        private void tcMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Update each tabs components when switching to the tab
            if (tcMain.SelectedTab.Name == "tSearch")
            {
                RegionUtils.PopulateCBRegion(cbSearchAluet);
            }
            else if (tcMain.SelectedTab.Name == "tRentControl")
            {
                PopulateDGVOrder();
            }
            else if (tcMain.SelectedTab.Name == "tAreaControl")
            {
                PopulateDGVRegion();
            }
            else if (tcMain.SelectedTab.Name == "tCustomerControl")
            {
                PopulateDGVCustomer();
            }
            else if (tcMain.SelectedTab.Name == "tServiceControl")
            {
                PopulateDGVCottage();
                PopulateDGVService();
                RegionUtils.PopulateCBRegion(cbCottageRegions);
                RegionUtils.PopulateCBRegion(cbServiceRegion);
            }
            else if (tcMain.SelectedTab.Name == "tBilling")
            {
                PopulateDGVBilling();
            }

        }
    }
}