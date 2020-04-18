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
        }

        MySqlConnection connection = new MySqlConnection("server=127.0.0.1;user id=testi;password=testi;persistsecurityinfo=True;database=vn");

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
    }
}
