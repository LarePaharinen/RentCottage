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

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label29_Click(object sender, EventArgs e)
        {

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

        private void cmbList_DropDown(object sender, EventArgs e)
        {
        }

        private void cmbList_DropDownClosed(object sender, EventArgs e)
        {
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
    }
}
