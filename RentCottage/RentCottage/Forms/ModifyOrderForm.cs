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
using RentCottage.Code;

namespace RentCottage
{
    public partial class ModifyOrderForm : Form
    {
        public ModifyOrderForm(Order o)
        {
            InitializeComponent();
            lbOrder_ModifyOrderID.Text = o.OrderID.ToString();
            lbOrder_ModifyCustomerID.Text = o.CustomerID.ToString();
            lbOrder_ModifyCottageID.Text = o.CottageID.ToString();
            lbOrder_ModifyOrderDate.Text = o.Order_date;
            lbOrder_ModifyPaymentDate.Text = o.Payment_date;
            dtpOrder_ModifyStartDate.Text = o.Start_date;
            dtpOrder_ModifyEndDate.Text = o.End_date;
            fill_dgvOrderServices();
        }

        private void fill_dgvOrderServices()
        {
            ConnectionUtils.openConnection();
            MySqlCommand command = new MySqlCommand("SELECT toimintaalue_id FROM mokki WHERE mokki_id = '" + lbOrder_ModifyCottageID.Text + "'", ConnectionUtils.connection);
            int alue_id = Convert.ToInt32(command.ExecuteScalar());
            ConnectionUtils.closeConnection();

            string query = "SELECT p.palvelu_id as 'ID', p.nimi as 'Nimi', p.kuvaus as 'Kuvaus', p.hinta as 'hinta/kpl', " +
                "coalesce(lkm, 0) AS kpl FROM palvelu p LEFT outer JOIN varauksen_palvelut vp ON p.palvelu_id = vp.palvelu_id " + 
                "AND varaus_id = '" + lbOrder_ModifyOrderID.Text + "' " +
                "WHERE toimintaalue_id = '" + alue_id + "'";
            ConnectionUtils.openConnection();
            MySqlDataAdapter sda = new MySqlDataAdapter(query, ConnectionUtils.connection);
            DataTable data = new DataTable();
            sda.Fill(data);
            dgvOrderServices.DataSource = data;
            ConnectionUtils.closeConnection();


        }
        private void btmOrder_OrderModify_Click(object sender, EventArgs e)
        {
            if (!OrderUtils.ChechCottageBookDate(Convert.ToInt32(lbOrder_ModifyCottageID.Text), dtpOrder_ModifyStartDate.Text, dtpOrder_ModifyEndDate.Text))
            {
                return;
            }
            DialogResult res = MessageBox.Show("Haluatko varmasti tallentaa muokatut tiedot?", "Muokkaa varaus", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (res == DialogResult.Yes)
            {
                string query = "START TRANSACTION; " +
                "UPDATE varaus " +
                "SET varattu_alkupvm='" + dtpOrder_ModifyStartDate.Text + " 16:00:00',varattu_loppupvm='" 
                + dtpOrder_ModifyEndDate.Text + " 12:00:00'" +
                "WHERE varaus_id=" + lbOrder_ModifyOrderID.Text + "; " +
                "COMMIT;";
                ConnectionUtils.openConnection();
                MySqlCommand command = new MySqlCommand(query, ConnectionUtils.connection);
                command.ExecuteNonQuery();
                ConnectionUtils.closeConnection();
                Close();
            }
        }

        private void btmOrder_OrderModifyCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dtpOrder_ModifyEndDate_ValueChanged(object sender, EventArgs e)
        {
            if (dtpOrder_ModifyEndDate.Value.Date <= dtpOrder_ModifyStartDate.Value.Date) // Date check
            {
                MessageBox.Show("Majoituksen loppupäivä ei voi olla samaa tai aiemmin kun majoituksen alkupäivä.", "Väärä päivämäärä", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}
