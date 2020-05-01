using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Invoicer.Models;
using Invoicer.Services;
using System.IO;

namespace RentCottage
{
    public class BillingUtils
    {
        public static string lastQuery;

        public static void createPdfDocument()
        {
            string laskuID = "1";
            DateTime billingDate = DateTime.Now;
            string dueDate = DateTime.Now.AddDays(14).ToShortDateString();
            string[] senderAddress = { "Village Newbies Oy", "Siilokatu 1", "90700 OULU" };
            string[] receiverAddress = { "Asiakkaan nimi", "Asiakkaan osoite" };
            string file = Path.Combine("C:\\temp\\invoice.pdf");

            new InvoicerApi(SizeOption.A4, OrientationOption.Portrait, "€")
            .Reference(laskuID)
            .BillingDate(billingDate)
            .Company(Address.Make("Lähettäjä", senderAddress, "", ""))
            .Client(Address.Make("Vastaanottaja", receiverAddress, "", ""))
            .TextColor("#CC0000")
            .BackColor("#FFD6CC")
            .Image(@"C:\\temp\\vnLogo.png", 200, 65)
            .Items(new List<ItemRow> {
            ItemRow.Make("Kesärinne 14", "Mökin vuokraus", (decimal)1, 10, (decimal)195.00, (decimal)195.00),
            ItemRow.Make("Porotilavierailu", "Palvelu", (decimal)2, 10, (decimal)10, (decimal)20),
            ItemRow.Make("Kelkka-ajelu", "Palvelu", (decimal)2, 10, (decimal)20, (decimal)40)
            })
            .Totals(new List<TotalRow> {
            TotalRow.Make("Välisumma", (decimal)526.66),
            TotalRow.Make("ALV 10%", (decimal)105.33),
            TotalRow.Make("Kokonaishinta", (decimal)631.99, true),
            })
            .Details(new List<DetailRow> {
            DetailRow.Make("MAKSUTIEDOT",   "SAAJAN TILINUMERO", "FI12345678910",
                                            "BIC", "NDEAFIHH",
                                            "SAAJA", "VILLAGE NEWBIES OY",
                                            "VIITENUMERO", "123456789",
                                            "ERÄPÄIVÄ", dueDate,
                                            "EURO", "10,34")
            })
            .Footer("http://www.villagenewbies.fi")
            .Save(file);

            System.Diagnostics.Process.Start(file);
        }

        public static void refreshDataGridView(DataGridView dgvBilling)
        {
            ConnectionUtils.openConnection();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter(lastQuery, ConnectionUtils.connection);
            adapter.Fill(table);
            dgvBilling.DataSource = table;
            ConnectionUtils.closeConnection();
        }

        //Creates a bill for a reservation
        public static void createInvoice(int varaus_id)
        {
            //Let's dig up all the information needed to create the bill
            double summa = calculatePriceTotalSum(varaus_id);
            double alv = 10;
            string maksettu = "false";
            ConnectionUtils.openConnection();
            string query = "START TRANSACTION; " +
                            "INSERT INTO lasku(varaus_id, summa, alv, maksettu) " +
                            "VALUES(" + varaus_id + ", " + summa + ", " + alv + ", " + maksettu + "); " +
                            "COMMIT;";
            MySqlCommand command = new MySqlCommand(query, ConnectionUtils.connection);
            command.ExecuteNonQuery();
            ConnectionUtils.closeConnection();
        }

        //Calculates the total price for a reservation including additional services
        private static double calculatePriceTotalSum(int varaus_id)
        {
            ConnectionUtils.openConnection();

            //Let's check if there's additional services for the reservation
            string query = "SELECT COUNT(*) " +
                            "FROM varauksen_palvelut " +
                            "WHERE varaus_id = " + varaus_id + ";";
            MySqlCommand cmd = new MySqlCommand(query, ConnectionUtils.connection);
            Int32 dataRows = Convert.ToInt32(cmd.ExecuteScalar());

            double summa = 0;
            if (dataRows == 0) //No data -> No services found -> Calculate only cottage rental
            {
                query = "SELECT (m.hinta * DATEDIFF(v.varattu_loppupvm, v.varattu_alkupvm)) AS summa " +
                        "FROM varaus v " +
                        "JOIN mokki m ON v.mokki_mokki_id = m.mokki_id " +
                        "WHERE v.varaus_id = " + varaus_id + ";";
                DataTable table = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, ConnectionUtils.connection);
                adapter.Fill(table);
                summa = table.Rows[0].Field<double>("summa");
            }

            else //Data found -> Let's calculate the services also
            {
                query = "SELECT((p.hinta * vp.lkm) + (m.hinta * DATEDIFF(v.varattu_loppupvm, v.varattu_alkupvm))) AS summa " +
                        "FROM varaus v " +
                        "JOIN mokki m ON v.mokki_mokki_id = m.mokki_id " +
                        "JOIN varauksen_palvelut vp ON v.varaus_id = vp.varaus_id " +
                        "JOIN palvelu p ON vp.palvelu_id = p.palvelu_id " +
                        "WHERE v.varaus_id = " + varaus_id + ";";
                DataTable table = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, ConnectionUtils.connection);
                adapter.Fill(table);
                summa = table.Rows[0].Field<double>("summa");
            }

            ConnectionUtils.closeConnection();
            return summa;
        }

        public static void setPaymentState(int lasku_id, string paymentState)
        {
            if(paymentState != "")
            {
                ConnectionUtils.openConnection();
                string query1 = "START TRANSACTION; " +
                    "UPDATE lasku " +
                    "SET maksettu = " + paymentState + " " +
                    "WHERE lasku_id = " + lasku_id + "; " +
                    "COMMIT;";
                MySqlCommand command = new MySqlCommand(query1, ConnectionUtils.connection);
                command.ExecuteNonQuery();
                ConnectionUtils.closeConnection();
            }
        }

        public static void deleteSelectedInvoice(int lasku_id)
        {
            try
            {
                ConnectionUtils.openConnection();
                string query1 = "START TRANSACTION; " +
                    "DELETE FROM lasku " +
                    "WHERE lasku_id = " + lasku_id + "; " +
                    "COMMIT;";
                MySqlCommand command = new MySqlCommand(query1, ConnectionUtils.connection);
                command.ExecuteNonQuery();
                ConnectionUtils.closeConnection();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
