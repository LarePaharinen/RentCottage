using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentCottage.Forms
{
    public partial class ModifyCottageForm : Form
    {
        public ModifyCottageForm()
        {
            InitializeComponent();
            string query = "SELECT * FROM toimintaalue";
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter(query, ConnectionUtils.connection);
            adapter.Fill(table);
            cbModifyCottageRegion.DataSource = table;
            cbModifyCottageRegion.DisplayMember = "nimi";
        }

        public ModifyCottageForm(Cottage c)
        {
            InitializeComponent();

            string query = "SELECT * FROM toimintaalue";
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter(query, ConnectionUtils.connection);
            adapter.Fill(table);
            cbModifyCottageRegion.DataSource = table;
            cbModifyCottageRegion.DisplayMember = "nimi";

            lblModifyCottageID.Text = c.CottageID.ToString();
            cbModifyCottageRegion.SelectedItem = PostUtils.RegionIndexToName(c.RegionID);
            tbModifyCottagePostNum.Text = c.Postal;
            tbModifyCottageName.Text = c.Name;
            tbModifyCottageStreet.Text = c.Address;
            cbModifyCottageCapacity.Text = c.Capacity.ToString();
            tbModifyCottageEquipment.Text = c.Equipment;
            tbModifyCottagePrice.Text = c.Price.ToString();
            tbModifyCottageDescription.Text = c.Description;
        }
    }
}
