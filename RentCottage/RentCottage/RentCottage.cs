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
    public partial class RentCottage : Form
    {
        public RentCottage()
        {
            InitializeComponent();
            tbSearch.Tag = tbSearch.Text = "kirjoita hakusana...";
            tbSearch.ForeColor = Color.Gray;
        }

        private void RentCottage_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'vnDataSet.varaus' table. You can move, or remove it, as needed.
            this.varausTableAdapter.Fill(this.vnDataSet.varaus);
            PopulateDGVRegion();
            cmbList.ForeColor = Color.Gray;
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

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label29_Click(object sender, EventArgs e)
        {

        }

        private void tbSearch_Enter(object sender, EventArgs e)
        {
            if (tbSearch.Text.Equals("kirjoita hakusana..."))
            {
                tbSearch.Clear();
                tbSearch.ForeColor = Color.Black;
            }
        }

        private void tbSearch_Leave(object sender, EventArgs e)
        {
            if (tbSearch.Text.Equals("kirjoita hakusana..."))
            {
                tbSearch.Clear();
                tbSearch.ForeColor = Color.Black;
            }
            else if (tbSearch.TextLength == 0)
            {
                tbSearch.Tag = tbSearch.Text = "kirjoita hakusana...";
                tbSearch.ForeColor = Color.Gray;
            }
        }
    }
}