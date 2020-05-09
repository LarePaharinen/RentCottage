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
        public ModifyOrderForm(Order o) //Fill ModifyOrderForm with selected data from database
        {
            InitializeComponent();
            lbOrder_ModifyOrderID.Text = o.OrderID.ToString();
            lbOrder_ModifyCustomerID.Text = o.CustomerID.ToString();
            tbOrder_ModifyCottageID.Text = o.CottageID.ToString();
            lbOrder_ModifyOrderDate.Text = o.Order_date;
            lbOrder_ModifyPaymentDate.Text = o.Payment_date;
            dtpOrder_ModifyStartDate.Text = o.Start_date;
            dtpOrder_ModifyEndDate.Text = o.End_date;
            fill_dgvOrderServices();           
        }
        int alue_id;
        
        private void fill_dgvOrderServices()
        {
            ConnectionUtils.openConnection();
            MySqlCommand command = new MySqlCommand("SELECT toimintaalue_id FROM mokki WHERE mokki_id = '" + tbOrder_ModifyCottageID.Text + "'", ConnectionUtils.connection);
            alue_id = Convert.ToInt32(command.ExecuteScalar());
            ConnectionUtils.closeConnection();

            string query = "SELECT p.palvelu_id as 'ID', p.nimi as 'Nimi', p.kuvaus as 'Kuvaus', p.hinta as 'hinta/kpl', " +
                "coalesce(lkm, 0) AS kpl FROM palvelu p LEFT outer JOIN varauksen_palvelut vp ON p.palvelu_id = vp.palvelu_id " + 
                "AND varaus_id = '" + lbOrder_ModifyOrderID.Text + "' " +
                "WHERE toimintaalue_id = '" + alue_id + "'";

            MySqlDataAdapter sda = new MySqlDataAdapter(query, ConnectionUtils.connection);
            DataTable data = new DataTable();
            sda.Fill(data);
            dgvOrderServices.DataSource = data;
            dgvOrderServices.Columns[0].Width = 30;
            dgvOrderServices.Columns[1].Width = 137;
            dgvOrderServices.Columns[2].Width = 240;
            dgvOrderServices.Columns[3].Width = 55;
            dgvOrderServices.Columns[4].Width = 35;
            foreach (DataGridViewColumn dgvc in dgvOrderServices.Columns) // Make all rows non editable
            {
                dgvc.ReadOnly = true;
                dgvOrderServices.Columns[4].DefaultCellStyle.BackColor = Color.PaleGreen;
            }
            dgvOrderServices.Columns[4].ReadOnly = false; // Make editable only "kpl" row

        }
        private void tbOrder_ModifyCottageID_Leave(object sender, EventArgs e)
        {
            if (!OrderUtils.checkCottageID(Convert.ToInt32(tbOrder_ModifyCottageID.Text))) //Check is database contains selected cottage
            {
                return;
            }
            else
            {   //Update order's id in database
                string query2 = "START TRANSACTION; " +
                "UPDATE varaus " +
                "SET mokki_mokki_id='" + tbOrder_ModifyCottageID.Text + "' " + "WHERE varaus_id=" + lbOrder_ModifyOrderID.Text + "; " +
                "COMMIT;";
                ConnectionUtils.openConnection();
                MySqlCommand command3 = new MySqlCommand(query2, ConnectionUtils.connection);
                command3.ExecuteNonQuery();
                ConnectionUtils.closeConnection();
            }
        }
        private void btmOrder_OrderModify_Click(object sender, EventArgs e)
        {   
            if (!OrderUtils.checkCottageBookDateTest(Convert.ToInt32(tbOrder_ModifyCottageID.Text), 
                Convert.ToInt32(lbOrder_ModifyOrderID.Text), 
                dtpOrder_ModifyStartDate.Text, dtpOrder_ModifyEndDate.Text)) //Check is cottage free on selected dates
            {
                return;
            }

            DialogResult res = MessageBox.Show("Haluatko varmasti tallentaa muokatut tiedot?", "Muokkaa varaus", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (res == DialogResult.Yes)
            {

                string queryServices = "START TRANSACTION; ";
                foreach (DataGridViewRow row in dgvOrderServices.Rows)  // Services modify
                {
                    ConnectionUtils.openConnection();
                    MySqlCommand checkRow = new MySqlCommand("SELECT * FROM varauksen_palvelut WHERE varaus_id =  '" +
                        lbOrder_ModifyOrderID.Text + "' AND palvelu_id = '" + row.Cells[0].Value.ToString() + "'", ConnectionUtils.connection);
                    MySqlDataReader reader = checkRow.ExecuteReader();
                    if (reader.HasRows && Convert.ToInt32(row.Cells["kpl"].Value) != 0) // If service already in database
                    {
                        reader.Read();
                        if (Convert.ToInt32(reader["lkm"]) != Convert.ToInt32(row.Cells["kpl"].Value))
                        {
                            queryServices += "UPDATE varauksen_palvelut SET lkm='" + row.Cells["kpl"].Value.ToString() + "' " +
                                "WHERE varaus_id =  '" + lbOrder_ModifyOrderID.Text + "' AND palvelu_id = '" + row.Cells[0].Value.ToString() + "'; ";
                        }
                    }
                    else if (!reader.HasRows && Convert.ToInt32(row.Cells["kpl"].Value) != 0) // If new service
                    {
                        queryServices += "INSERT INTO vn.varauksen_palvelut(varaus_id, palvelu_id, lkm) " +
                            "VALUES(" + lbOrder_ModifyOrderID.Text + ", " + row.Cells["ID"].Value.ToString() + ", " + row.Cells["kpl"].Value.ToString() + "); ";
                    }

                    else if (reader.HasRows && Convert.ToInt32(row.Cells["kpl"].Value) == 0) // if service set to 0
                    {
                        queryServices += "DELETE FROM varauksen_palvelut WHERE varaus_id =  '" +
                        lbOrder_ModifyOrderID.Text + "' AND palvelu_id = '" + row.Cells[0].Value.ToString() + "'; ";
                    }
                    ConnectionUtils.closeConnection();
                }
                queryServices += "COMMIT;";
                if (queryServices != "START TRANSACTION; COMMIT;") // check if services not changet
                {
                    try
                    {
                        ConnectionUtils.openConnection();
                        MySqlCommand command1 = new MySqlCommand(queryServices, ConnectionUtils.connection);
                        command1.ExecuteNonQuery(); // Add/EDIT/REMOVE services
                        ConnectionUtils.closeConnection();
                    }
                    catch
                    {
                        MessageBox.Show(queryServices);
                    }
                }
                //Update order's start- and(or) enddate
                string query = "START TRANSACTION; " +
                "UPDATE varaus " +
                "SET varattu_alkupvm='" + dtpOrder_ModifyStartDate.Text + " 16:00:00',varattu_loppupvm='" 
                + dtpOrder_ModifyEndDate.Text + " 12:00:00'" +
                "WHERE varaus_id=" + lbOrder_ModifyOrderID.Text + "; " +
                "COMMIT;";
                ConnectionUtils.openConnection();
                MySqlCommand command2 = new MySqlCommand(query, ConnectionUtils.connection);
                command2.ExecuteNonQuery();
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
