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

namespace RentCottage
{
    public partial class Booking : Form
    {
        public Booking()
        {
            InitializeComponent();
        }

        public Booking(NewBook b)
        {
            InitializeComponent();

            ConnectionUtils.openConnection();
            MySqlCommand command = new MySqlCommand("SELECT nimi FROM toimintaalue WHERE toimintaalue_id Like '" + b.Cottage.RegionID.ToString() + "'", ConnectionUtils.connection);
            string toimintaalue = command.ExecuteScalar().ToString();
            ConnectionUtils.closeConnection();

            lblBookVillageId.Text = b.Cottage.CottageID.ToString();
            lblBookVillageName.Text = b.Cottage.Name.ToString();
            lblBookVillageAddress.Text = b.Cottage.Address.ToString() + ", " + b.Cottage.Postal.ToString();
            lblBookAlue.Text = toimintaalue;
            lblBookMaxPersons.Text = b.Cottage.Capacity.ToString() + " hlö";
            lblBookVillagePrice.Text = b.Cottage.Price.ToString() + " €/yö";
            lblBookBookingDateFrom.Text = b.Alkupv.ToString("dd.MM.yyyy");
            lblBookBookingDateTo.Text = b.Loppupv.ToString("dd.MM.yyyy");
            double cottagepriodprice = b.Cottage.Price * ((b.Loppupv - b.Alkupv).TotalDays + 1);
            lblBookSeasonPrice.Text = cottagepriodprice.ToString() + " €";

            MySqlDataAdapter sda = new MySqlDataAdapter("SELECT palvelu_id as 'ID', nimi as 'Nimi', kuvaus as 'Kuvaus', hinta as 'hinta/kpl', 0 as 'kpl' FROM palvelu WHERE toimintaalue_id LIKE '" + b.Cottage.RegionID + "'", ConnectionUtils.connection);
            DataTable data = new DataTable();
            sda.Fill(data);
            dgvBookServices.DataSource = data;
            dgvBookServices.Columns[0].Width = 26;
            dgvBookServices.Columns[1].Width = 200;
            dgvBookServices.Columns[2].Width = 320;
            dgvBookServices.Columns[3].Width = 57;
            dgvBookServices.Columns[4].Width = 30;
            foreach (DataGridViewColumn dgvc in dgvBookServices.Columns)
            {
                dgvc.ReadOnly = true;
            }
            dgvBookServices.Columns[4].ReadOnly = false;
        }
    }
}
