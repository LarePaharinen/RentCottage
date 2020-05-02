using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace RentCottage
{
    public partial class Booking : Form
    {
        int customerid;
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
            MySqlCommand command = new MySqlCommand("SELECT nimi FROM toimintaalue WHERE toimintaalue_id Like '" + 
                b.Cottage.RegionID.ToString() + "'", ConnectionUtils.connection);
            string region = command.ExecuteScalar().ToString();
            ConnectionUtils.closeConnection();

            lblBookCottageId.Text = b.Cottage.CottageID.ToString();
            lblBookCottageName.Text = b.Cottage.Name.ToString();
            lblBookCottageAddress.Text = b.Cottage.Address.ToString() + ", " + b.Cottage.Postal.ToString();
            lblBookAlue.Text = region;
            lblBookMaxPersons.Text = b.Cottage.Capacity.ToString() + " hlö";
            lblBookCottagePrice.Text = b.Cottage.Price.ToString() + " €/yö";
            lblBookBookingDateFrom.Text = b.Alkupv.ToString("yyyy-MM-dd");
            lblBookBookingDateTo.Text = b.Loppupv.ToString("yyyy-MM-dd");
            cottagepriodprice = b.Cottage.Price * ((b.Loppupv - b.Alkupv).TotalDays + 1);
            lblBookDays.Text = "(" + ((b.Loppupv - b.Alkupv).TotalDays + 1).ToString() + " pv)";
            lblBookSeasonPrice.Text = cottagepriodprice.ToString() + " €";
            lblBookPriceFull.Text = cottagepriodprice.ToString() + " €";

            MySqlDataAdapter sda = new MySqlDataAdapter("SELECT palvelu_id as 'ID', nimi as 'Nimi', kuvaus as 'Kuvaus', " +
                "hinta as 'hinta/kpl', 0 as 'kpl' FROM palvelu WHERE toimintaalue_id LIKE '" + b.Cottage.RegionID + "'", ConnectionUtils.connection);
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
                MySqlCommand ckech_is_user_exists = new MySqlCommand("SELECT * FROM asiakas WHERE email like '" + 
                    tbBookCustomerEmail.Text + "'", ConnectionUtils.connection);
                MySqlDataReader reader = ckech_is_user_exists.ExecuteReader();
                dt.Load(reader);
                if (dt.Rows.Count > 0 && dt.Rows.Count < 2)
                {
                    fill_customer_values();
                    lblBookCustomerExists.Text = "Sähköpostilla löydetty 1 asiakas";
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
                    lblBookCustomerExists.Text = "Asiakasta ei löydy, syötä uuden asiakkaan tiedot.";
                }
                ConnectionUtils.closeConnection();
            }
            else if(tbBookCustomerPhone.Text != "") //Search customer on phonenumber
            {
                ConnectionUtils.openConnection();
                MySqlCommand ckech_is_user_exists = new MySqlCommand("SELECT * FROM asiakas WHERE puhelinnro like '" + 
                    tbBookCustomerPhone.Text + "'", ConnectionUtils.connection);
                MySqlDataReader reader = ckech_is_user_exists.ExecuteReader();
                dt.Load(reader);
                lblBookCustomerExists.Visible = true;
                if (dt.Rows.Count == 1)
                {
                    fill_customer_values();
                    lblBookCustomerExists.Text = "Puhelinnumerolla löydetty 1 asiakas";
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
                    lblBookCustomerExists.Text = "Asiakasta ei löydy, syötä uuden asiakkaan tiedot.";
                }
                ConnectionUtils.closeConnection();
            }
            else
            {
                lblBookCustomerExists.Text = "Hae asiakasta sähköpostilla tai puhelinnumerolla";
                erase_customer_values();
            }
        }

        private void btnBookAddResirvation_Click(object sender, EventArgs e)
        {
            if(tbBookCustomerEmail.Text == "" || tbBookCustomerPhone.Text == "" ||  tbBookCustomerName.Text == "" || 
                tbBookCustomerLastname.Text == "" || tbBookCustomerPostnumber.Text == "" || tbBookCustomerPostOffice.Text == "" ||
                tbBookCustomerAddress.Text == "")
            {
                MessageBox.Show("Kaikki asiakas tiedot pitäisi olla täyetty.", "Tiedot puuttuu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string queryCustomer, services = "\n\nLisäpalvelut:\n";
            if (customerid != 0)
            {
                PostUtils.checkPostal(tbBookCustomerPostnumber.Text, tbBookCustomerPostOffice.Text);
                queryCustomer = "START TRANSACTION; " +
                    "UPDATE asiakas SET etunimi='" + tbBookCustomerName.Text + "', sukunimi='" + tbBookCustomerLastname.Text + "', " +
                    "lahiosoite='" + tbBookCustomerAddress.Text + "', postinro='" + tbBookCustomerPostnumber.Text + "', " +
                    "email='" + tbBookCustomerEmail.Text + "', puhelinnro='" + tbBookCustomerPhone.Text + "' " +
                    "WHERE asiakas_id='" + customerid + "'; " +
                    "COMMIT;";
            }
            else 
            {
                PostUtils.checkPostal(tbBookCustomerPostnumber.Text, tbBookCustomerPostOffice.Text);
                queryCustomer = "START TRANSACTION; " +
                "INSERT INTO asiakas(asiakas_id,postinro,etunimi,sukunimi,lahiosoite,email,puhelinnro) " +
                "VALUES(default,'" + tbBookCustomerPostnumber.Text + "','" + tbBookCustomerName.Text +
                "','" + tbBookCustomerLastname.Text + "','" + tbBookCustomerAddress.Text +
                "','" + tbBookCustomerEmail.Text + "','" + tbBookCustomerPhone.Text + "'); " +
                "COMMIT;";
            }
            foreach (DataGridViewRow row in dgvBookServices.Rows)
            {
                if (Convert.ToInt32(row.Cells["kpl"].Value) != 0)
                {
                    services += row.Cells["nimi"].Value.ToString() + " - " + row.Cells["kpl"].Value.ToString() + "kpl\n";
                }
            }
            if (services == "\n\nLisäpalvelut:\n")
                services += "";

            DialogResult res = MessageBox.Show("\t\tYhteenveto \n\nMökki tiedot:" +
                "\nAlue: \t\t" + lblBookAlue.Text + 
                "\nMökki ID: \t" + lblBookCottageId.Text + 
                "\nMajoitusaika: \t" + lblBookBookingDateFrom.Text + " - " + lblBookBookingDateTo.Text + " " + lblBookDays.Text + 
                "\nOsoite: \t\t" + lblBookCottageAddress.Text + 
                "\n\nAsiakas tiedot: " + "\nNimi: \t\t" + tbBookCustomerName.Text + " " + tbBookCustomerLastname.Text + 
                "\nOsoite: \t\t" + tbBookCustomerAddress.Text + ", " + tbBookCustomerPostnumber.Text + ", " + tbBookCustomerPostOffice.Text +
                "\nSähköposti: \t" + tbBookCustomerEmail.Text +
                "\nPuhelinnumero: \t" + tbBookCustomerPhone.Text + 
                services + 
                "\n\nSumma yhteensä: " + lblBookPriceFull.Text, "Yhteenveto", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (res == DialogResult.OK)
            {
                try
                {
                    ConnectionUtils.openConnection();
                    MySqlCommand command1 = new MySqlCommand(queryCustomer, ConnectionUtils.connection);
                    command1.ExecuteNonQuery();
                    string queryBook = makeQueryBook();

                    ConnectionUtils.openConnection();
                    MySqlCommand command2 = new MySqlCommand(queryBook, ConnectionUtils.connection);
                    command2.ExecuteNonQuery();
                    ConnectionUtils.closeConnection();

                    string queryServices = makeQueryServices();
                    ConnectionUtils.openConnection();
                    MySqlCommand command3 = new MySqlCommand(queryServices, ConnectionUtils.connection);
                    command3.ExecuteNonQuery();
                    ConnectionUtils.closeConnection();
                    this.Close();
                    MessageBox.Show("Varaus lisätty.", "Prosessi onnistui", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Tapahtunut virhe, yritä uudelleen: \n" + ex, "Virhe", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (res == DialogResult.Cancel) { }
        }

        private string makeQueryBook()
        {
            if (customerid == 0)
            {
                ConnectionUtils.openConnection();
                MySqlCommand command = new MySqlCommand("SELECT asiakas_id FROM asiakas WHERE etunimi LIKE '" +
                    tbBookCustomerName.Text + "' AND sukunimi LIKE '" + tbBookCustomerLastname.Text + "' AND lahiosoite LIKE '" +
                    tbBookCustomerAddress.Text + "' AND postinro LIKE '" + tbBookCustomerPostnumber.Text + "' AND email LIKE '" +
                    tbBookCustomerEmail.Text + "' AND puhelinnro LIKE '" + tbBookCustomerPhone.Text + "'", ConnectionUtils.connection);
                customerid = Convert.ToInt32(command.ExecuteScalar());
                ConnectionUtils.closeConnection();
            }
            string queryBook = "START TRANSACTION; " +
                "INSERT INTO varaus(asiakas_id, mokki_mokki_id, varattu_pvm, vahvistus_pvm, varattu_alkupvm, varattu_loppupvm) " +
                "VALUES('" + customerid + "', '" + lblBookCottageId.Text + "', '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") +
                "', NULL, '" + lblBookBookingDateFrom.Text + " 16:00:00', '" + lblBookBookingDateTo.Text + " 12:00:00'); " +
                "COMMIT;";

            return queryBook;
        }

        private string makeQueryServices()
        {
            string query = "START TRANSACTION; ";
            ConnectionUtils.openConnection();
            MySqlCommand command = new MySqlCommand("SELECT varaus_id FROM varaus WHERE asiakas_id LIKE '" +
                customerid + "' AND mokki_mokki_id LIKE '" + lblBookCottageId.Text + "' AND varattu_alkupvm LIKE '" +
                lblBookBookingDateFrom.Text + "%' AND varattu_loppupvm LIKE '" + lblBookBookingDateTo.Text + "%' ", ConnectionUtils.connection);
            string varausid = command.ExecuteScalar().ToString();
            ConnectionUtils.closeConnection();
            foreach (DataGridViewRow row in dgvBookServices.Rows)
            {
                if (Convert.ToInt32(row.Cells["kpl"].Value) != 0)
                {
                    query += "INSERT INTO vn.varauksen_palvelut (varaus_id, palvelu_id, lkm) " +
                    "VALUES(" + varausid + ", " + row.Cells["ID"].Value.ToString() + ", " + row.Cells["kpl"].Value.ToString() + "); ";
                }
            }
            query += "COMMIT;";
            return query;
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
            if (tbBookCustomerEmail.Text == "")
                tbBookCustomerEmail.Text = dt.Rows[currentcustomer].Field<string>("email").ToString();
            else if (tbBookCustomerPhone.Text == "")
                tbBookCustomerPhone.Text = dt.Rows[currentcustomer].Field<string>("puhelinnro");

            tbBookCustomerName.Text = dt.Rows[currentcustomer].Field<string>("etunimi").ToString();
            tbBookCustomerLastname.Text = dt.Rows[currentcustomer].Field<string>("sukunimi").ToString();
            tbBookCustomerAddress.Text = dt.Rows[currentcustomer].Field<string>("lahiosoite").ToString();
            tbBookCustomerPostnumber.Text = dt.Rows[currentcustomer].Field<string>("postinro").ToString();
            tbBookCustomerPostOffice.Text = PostUtils.getPostOffice(dt.Rows[currentcustomer].Field<string>("postinro").ToString());
            customerid = dt.Rows[currentcustomer].Field<int>("asiakas_id");
            lblBookCustomerID.Visible = true;
            lblBookCustomerID.Text = "Asiakas ID: " + customerid.ToString();
        }
        private void erase_customer_values()
        {
            tbBookCustomerName.Text = "";
            tbBookCustomerLastname.Text = "";
            tbBookCustomerAddress.Text = "";
            tbBookCustomerPostnumber.Text = "";
            tbBookCustomerPostOffice.Text = "";
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
    }
}
