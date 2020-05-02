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
        int customerid;
        bool customerfinded;
        double serviceprice;
        double cottagepriodprice;
        DataTable dt = new DataTable();
        int currentcustomer;

        public Booking()
        {
            InitializeComponent();
        }

        public Booking(NewBook b)
        {
            InitializeComponent();

            ConnectionUtils.openConnection();
            MySqlCommand command = new MySqlCommand("SELECT nimi FROM toimintaalue WHERE toimintaalue_id Like '" + b.Cottage.RegionID.ToString() + "'", ConnectionUtils.connection);
            string region = command.ExecuteScalar().ToString();
            ConnectionUtils.closeConnection();

            lblBookVillageId.Text = b.Cottage.CottageID.ToString();
            lblBookVillageName.Text = b.Cottage.Name.ToString();
            lblBookVillageAddress.Text = b.Cottage.Address.ToString() + ", " + b.Cottage.Postal.ToString();
            lblBookAlue.Text = region;
            lblBookMaxPersons.Text = b.Cottage.Capacity.ToString() + " hlö";
            lblBookVillagePrice.Text = b.Cottage.Price.ToString() + " €/yö";
            lblBookBookingDateFrom.Text = b.Alkupv.ToString("dd.MM.yyyy");
            lblBookBookingDateTo.Text = b.Loppupv.ToString("dd.MM.yyyy");
            cottagepriodprice = b.Cottage.Price * ((b.Loppupv - b.Alkupv).TotalDays + 1);
            lblBookSeasonPrice.Text = cottagepriodprice.ToString() + " €";
            lblBookPriceFull.Text = cottagepriodprice.ToString() + " €";

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
                dgvBookServices.Columns[4].DefaultCellStyle.BackColor = Color.PaleGreen;
            }
            dgvBookServices.Columns[4].ReadOnly = false;
        }

        private void btnBookSearch_Click(object sender, EventArgs e)
        {
            dt.Clear();
            currentcustomer = 0;
            if (tbBookCustomerEmail.Text != "") // Search customer on email
            {
                ConnectionUtils.openConnection();
                MySqlCommand ckech_is_user_exists = new MySqlCommand("SELECT * FROM asiakas WHERE email like '" + tbBookCustomerEmail.Text + "'", ConnectionUtils.connection);
                MySqlDataReader reader = ckech_is_user_exists.ExecuteReader();
                dt.Load(reader);
                if (dt.Rows.Count > 0 && dt.Rows.Count < 2)
                {
                    fill_customer_values();
                    lblBookCustomerExists.Text = "Sähköpostilla löydetty asiakas";
                    btnBookNext.Visible = false;
                    btnBookPrev.Visible = false;
                    lblCustomerOnSame.Visible = false;
                }
                else if(dt.Rows.Count > 1)
                {
                    lblBookCustomerExists.Text = "Sähköpostiosoitella löytyy " + dt.Rows.Count.ToString() + " asiakasta";
                    fill_customer_values();
                    lblCustomerOnSame.Text = "1/" + dt.Rows.Count.ToString();
                    btnBookNext.Visible = true;
                    btnBookPrev.Visible = true;
                    lblCustomerOnSame.Visible = true;
                }
                else
                {
                    erase_customer_values();
                    lblBookCustomerExists.Visible = true;
                    lblBookCustomerExists.Text = "Asiakasta ei löydy, syötä uuden asiakkaan tiedot.";
                }
                ConnectionUtils.closeConnection();
            }
            else if(tbBookCustomerPhone.Text != "") //Search customer on phonenumber
            {
                ConnectionUtils.openConnection();
                MySqlCommand ckech_is_user_exists = new MySqlCommand("SELECT * FROM asiakas WHERE puhelinnro like '" + tbBookCustomerPhone.Text + "'", ConnectionUtils.connection);
                MySqlDataReader reader = ckech_is_user_exists.ExecuteReader();
                dt.Load(reader);
                lblBookCustomerExists.Visible = true;
                if (dt.Rows.Count == 1)
                {
                    fill_customer_values();
                    lblBookCustomerExists.Text = "Puhelinnumerolla löydetty asiakas";
                    btnBookNext.Visible = false;
                    btnBookPrev.Visible = false;
                    lblCustomerOnSame.Visible = false;
                }
                else if (dt.Rows.Count > 1)
                {
                    lblBookCustomerExists.Text = "Puhelinnumerolla löytyy " + dt.Rows.Count.ToString() + " asiakasta";
                    fill_customer_values();
                    lblCustomerOnSame.Text = "1/" + dt.Rows.Count.ToString();
                    btnBookNext.Visible = true;
                    btnBookPrev.Visible = true;
                    lblCustomerOnSame.Visible = true;
                }
                else
                {
                    erase_customer_values();
                    lblBookCustomerExists.Visible = true;
                    lblBookCustomerExists.Text = "Asiakasta ei löydy, syötä uuden asiakkaan tiedot.";
                }
                ConnectionUtils.closeConnection();
            }
            else
            {
                erase_customer_values();
                customerfinded = false;
                lblBookCustomerExists.Visible = false;
            }
        }

        private void btnBookNext_Click(object sender, EventArgs e)
        {
            if(currentcustomer < (dt.Rows.Count - 1))
            {
                currentcustomer++;
                lblCustomerOnSame.Text = (currentcustomer + 1).ToString() + "/" + dt.Rows.Count.ToString();
                tbBookCustomerEmail.Text = "";
                fill_customer_values();
            }
        }

        private void btnBookPrev_Click(object sender, EventArgs e)
        {
            if (currentcustomer <= (dt.Rows.Count - 1) && currentcustomer > 0)
            {
                currentcustomer--;
                lblCustomerOnSame.Text = (currentcustomer + 1).ToString() + "/" + dt.Rows.Count.ToString();
                tbBookCustomerEmail.Text = "";
                fill_customer_values();
            }
        }


        private void fill_customer_values()
        {
            customerfinded = true;
            if (tbBookCustomerEmail.Text == "")
                tbBookCustomerEmail.Text = dt.Rows[currentcustomer].Field<string>("email").ToString();
            else if (tbBookCustomerPhone.Text == "")
                tbBookCustomerPhone.Text = dt.Rows[currentcustomer].Field<string>("puhelinnro");

            tbBookCustomerName.Text = dt.Rows[currentcustomer].Field<string>("etunimi").ToString();
            tbBookCustomerLastname.Text = dt.Rows[currentcustomer].Field<string>("sukunimi").ToString();
            tbBookCustomerAddress.Text = dt.Rows[currentcustomer].Field<string>("lahiosoite").ToString();
            tbBookCustomerPostnumber.Text = dt.Rows[currentcustomer].Field<string>("postinro").ToString();
            customerid = dt.Rows[currentcustomer].Field<int>("asiakas_id");
            lblBookCustomerID.Visible = true;
            lblBookCustomerID.Text = "Asiakas ID: " + customerid.ToString();
        }
        private void erase_customer_values()
        {
            customerfinded = false;
            tbBookCustomerName.Text = "";
            tbBookCustomerLastname.Text = "";
            tbBookCustomerAddress.Text = "";
            tbBookCustomerPostnumber.Text = "";
            customerid = 0;
            lblBookCustomerID.Visible = false;
            btnBookNext.Visible = false;
            btnBookPrev.Visible = false;
            lblCustomerOnSame.Visible = false;
        }

        private void tbBookCustomerEmail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnBookSearch_Click(sender, e);
            }
        }

        private void dgvBookServices_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            serviceprice = 0;
            foreach (DataGridViewRow row in dgvBookServices.Rows)
            {
                if (Convert.ToInt32(row.Cells["kpl"].Value) != 0)
                {
                    serviceprice += Convert.ToInt32(row.Cells["kpl"].Value) * Convert.ToInt32(row.Cells["hinta/kpl"].Value);
                    lblBookServicePrice.Text = serviceprice.ToString() + " €";
                }
            }
        }
        private void lblBookServicePrice_TextChanged(object sender, EventArgs e)
        {
            lblBookPriceFull.Text = (cottagepriodprice + serviceprice).ToString() + " €";
        }

        private void btnBookAddResirvation_Click(object sender, EventArgs e)
        {

        }
    }
}
