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
        public static string latestQuery;
        public static RentCottage rentCottage;

        //Changes the tab to "laskut" and selects the row which has the parameter (varaus_id) reservation
        public static void goToCreatedInvoice(int varaus_id)
        {
            rentCottage.tcMain.SelectedIndex = 5;
            BillingUtils.refreshDataGridView(rentCottage.dgvBilling);

            //Search for the row which has the created bill
            int rowIndex = -1;
            foreach (DataGridViewRow row in rentCottage.dgvBilling.Rows)
            {
                if (row.Cells[1].Value.ToString().Equals(varaus_id.ToString()))
                {
                    rowIndex = row.Index;
                    break;
                }
            }
            //Select the row
            rentCottage.dgvBilling.CurrentCell = rentCottage.dgvBilling.Rows[rowIndex].Cells[0];
        }

        //Creates invoice.pdf file with reservation details, saves it and opens it
        public static void createPdfDocument(int lasku_id)
        {
            ConnectionUtils.openConnection();
            string fileSaveLocation = Path.GetDirectoryName(Application.ExecutablePath) + "\\invoice.pdf"; //Next to .exe file

            ////varaus_id for simplifying queries
            //string query = "SELECT varaus_id " +
            //        "FROM lasku " +
            //        "WHERE lasku_id = " + lasku_id + ";";
            //MySqlCommand cmd = new MySqlCommand(query, ConnectionUtils.connection);
            //int varaus_id = Convert.ToInt32(cmd.ExecuteScalar());

            //Customer name
            string query = "SELECT CONCAT(a.etunimi, ' ', a.sukunimi) AS nimi " +
                "FROM lasku l " +
                "JOIN varaus v ON l.varaus_id = v.varaus_id " +
                "JOIN asiakas a ON v.asiakas_id = a.asiakas_id " +
                "WHERE l.lasku_id = " + lasku_id + ";";
            MySqlCommand cmd = new MySqlCommand(query, ConnectionUtils.connection);
            string customerName = cmd.ExecuteScalar().ToString();

            //Customer address
            query = "SELECT a.lahiosoite " +
                    "FROM lasku l " +
                    "JOIN varaus v ON l.varaus_id = v.varaus_id " +
                    "JOIN asiakas a ON v.asiakas_id = a.asiakas_id " +
                    "WHERE l.lasku_id = " + lasku_id + ";";
            cmd = new MySqlCommand(query, ConnectionUtils.connection);
            string customerAddress = cmd.ExecuteScalar().ToString();

            //Customer zip code
            query = "SELECT CONCAT(a.postinro, ' ', p.toimipaikka) AS posti " +
                    "FROM lasku l " +
                    "JOIN varaus v ON l.varaus_id = v.varaus_id " +
                    "JOIN asiakas a ON v.asiakas_id = a.asiakas_id " +
                    "JOIN posti p ON a.postinro = p.postinro " +
                    "WHERE l.lasku_id = " + lasku_id + ";";
            cmd = new MySqlCommand(query, ConnectionUtils.connection);
            string customerPostal = cmd.ExecuteScalar().ToString().ToUpper();

            //varaus_id for calculating the price later
            query = "SELECT varaus_id " +
                    "FROM lasku " +
                    "WHERE lasku_id = " + lasku_id + ";";
            cmd = new MySqlCommand(query, ConnectionUtils.connection);
            int varaus_id = Convert.ToInt32(cmd.ExecuteScalar());

            DateTime billingDate = DateTime.Now;
            string dueDate = DateTime.Now.AddDays(14).ToShortDateString();
            string[] senderAddress = { "Village Newbies Oy", "Siilokatu 1", "90700 OULU" };
            string[] receiverAddress = { customerName, customerAddress, customerPostal };
            List<ItemRow> itemsList = generateItemsList(lasku_id);
            double totalPrice = calculateTotalPrice(varaus_id);
            string totalPriceString = String.Format("{0:0.00}", totalPrice);
            double totalAlvAmount = 0;
            foreach (ItemRow item in itemsList)
            {
                totalAlvAmount += (Convert.ToDouble(item.Total) * (Convert.ToDouble(item.VAT)/100));
            }
            double subTotal = totalPrice - totalAlvAmount;

            //Creating the PDF document
            new InvoicerApi(SizeOption.A4, OrientationOption.Portrait, "€")
            .Reference(lasku_id.ToString())
            .BillingDate(billingDate)
            .Company(Address.Make("Lähettäjä", senderAddress, "", ""))
            .Client(Address.Make("Vastaanottaja", receiverAddress, "", ""))
            .TextColor("#2E5902")
            .BackColor("#e7fecf")
            .Image(@"..\..\images\vnLogo.png", 175, 60)
            .Items(itemsList)
            .Totals(new List<TotalRow> {
            TotalRow.Make("Välisumma", (decimal)subTotal),
            TotalRow.Make("ALV", (decimal)totalAlvAmount),
            TotalRow.Make("Kokonaishinta", (decimal)totalPrice, true),
            })
            .Details(new List<DetailRow> {
            DetailRow.Make("MAKSUTIEDOT",   "SAAJAN TILINUMERO", "FI12345678910",
                                            "BIC", "NDEAFIHH",
                                            "SAAJA", "VILLAGE NEWBIES OY",
                                            "VIITENUMERO", "123456789",
                                            "ERÄPÄIVÄ", dueDate,
                                            "EURO", totalPriceString)
            })
            .Footer("http://www.villagenewbies.fi")
            .Save(fileSaveLocation);

            //Open the document using default application
            System.Diagnostics.Process.Start(fileSaveLocation);
            ConnectionUtils.closeConnection();
        }

        //Returns a list containing names and prices of all reservation cottages and additional services
        private static List<ItemRow> generateItemsList(int lasku_id)
        {
            //Cottage name
            string query = "SELECT m.mokkinimi " +
                            "FROM lasku l " +
                            "JOIN varaus v ON l.varaus_id = v.varaus_id " +
                            "JOIN mokki m ON v.mokki_mokki_id = m.mokki_id " +
                            "WHERE l.lasku_id = " + lasku_id + ";";
            MySqlCommand cmd = new MySqlCommand(query, ConnectionUtils.connection);
            string cottageName = cmd.ExecuteScalar().ToString();

            //Cottage price per night
            query = "SELECT m.hinta AS hinta " +
                    "FROM lasku l " +
                    "JOIN varaus v ON l.varaus_id = v.varaus_id " +
                    "JOIN mokki m ON v.mokki_mokki_id = m.mokki_id " +
                    "WHERE l.lasku_id = " + lasku_id + ";";
            cmd = new MySqlCommand(query, ConnectionUtils.connection);
            double cottagePriceForNight = Convert.ToDouble(cmd.ExecuteScalar());

            //Nights stayed
            query = "SELECT DATEDIFF(v.varattu_loppupvm, v.varattu_alkupvm) AS nights " +
                    "FROM lasku l " +
                    "JOIN varaus v ON l.varaus_id = v.varaus_id " +
                    "WHERE l.lasku_id = " + lasku_id + ";";
            cmd = new MySqlCommand(query, ConnectionUtils.connection);
            double nightsStayed = Convert.ToDouble(cmd.ExecuteScalar());

            double cottageTotalPrice = (cottagePriceForNight * nightsStayed);
            double cottageALV = 10.00;

            List<ItemRow> itemList = new List<ItemRow>();
            ItemRow cottage = ItemRow.Make(cottageName, "Mökin vuokraus", (decimal)nightsStayed, (decimal)cottageALV, (decimal)cottagePriceForNight, (decimal)cottageTotalPrice);
            itemList.Add(cottage);

            //Additional services:

            //varaus_id for simplifying queries
            query = "SELECT varaus_id " +
                    "FROM lasku " +
                    "WHERE lasku_id = " + lasku_id + ";";
            cmd = new MySqlCommand(query, ConnectionUtils.connection);
            int varaus_id = Convert.ToInt32(cmd.ExecuteScalar());

            //Number of services
            query = "SELECT COUNT(*) " +
                            "FROM varauksen_palvelut " +
                            "WHERE varaus_id = " + varaus_id + ";";
            cmd = new MySqlCommand(query, ConnectionUtils.connection);
            int numberOfServices = Convert.ToInt32(cmd.ExecuteScalar());

            //Add all services to the itemList
            for (int i = 0; i < numberOfServices; i++)
            {
                //Name of the service
                query = "SELECT p.nimi AS nimi " +
                    "FROM palvelu p " +
                    "JOIN varauksen_palvelut vp ON vp.palvelu_id = p.palvelu_id " +
                    "WHERE varaus_id = " + varaus_id + ";";
                DataTable table = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, ConnectionUtils.connection);
                adapter.Fill(table);
                string serviceName = table.Rows[i].Field<string>("nimi");

                //Unit price of service
                query = "SELECT p.hinta AS price " +
                        "FROM palvelu p " +
                        "JOIN varauksen_palvelut vp ON vp.palvelu_id = p.palvelu_id " +
                        "WHERE varaus_id = " + varaus_id + ";";
                table = new DataTable();
                adapter = new MySqlDataAdapter(query, ConnectionUtils.connection);
                adapter.Fill(table);
                double serviceUnitPrice = table.Rows[i].Field<double>("price");

                //number of orders of service
                query = "SELECT vp.lkm as unitAmount " +
                        "FROM palvelu p " +
                        "JOIN varauksen_palvelut vp ON vp.palvelu_id = p.palvelu_id " +
                        "WHERE varaus_id = " + varaus_id + ";";
                table = new DataTable();
                adapter = new MySqlDataAdapter(query, ConnectionUtils.connection);
                adapter.Fill(table);
                int serviceUnitAmount = table.Rows[i].Field<int>("unitAmount");

                //ALV for service
                query = "SELECT p.alv AS serviceALV " +
                        "FROM palvelu p " +
                        "JOIN varauksen_palvelut vp ON vp.palvelu_id = p.palvelu_id " +
                        "WHERE varaus_id = " + varaus_id + ";";
                table = new DataTable();
                adapter = new MySqlDataAdapter(query, ConnectionUtils.connection);
                adapter.Fill(table);
                double serviceALV = table.Rows[i].Field<double>("serviceALV");

                double serviceTotalPrice = (serviceUnitPrice * serviceUnitAmount);

                ItemRow service = ItemRow.Make(serviceName, "Palvelu", (decimal)serviceUnitAmount, (decimal)serviceALV, (decimal)serviceUnitPrice, (decimal)serviceTotalPrice);
                itemList.Add(service);
            }

            return itemList;
        }

        //Uses the latest search query to update the datagridview
        public static void refreshDataGridView(DataGridView dgvBilling)
        {
            ConnectionUtils.openConnection();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter(latestQuery, ConnectionUtils.connection);
            adapter.Fill(table);
            dgvBilling.DataSource = table;
            ConnectionUtils.closeConnection();
        }

        //Creates a bill for a reservation and checks if there are existing bills for this reservation
        public static void createInvoice(int varaus_id)
        {
            ConnectionUtils.openConnection();
            //Let's check if there's an existing invoice for this varaus_id value
            string query = "SELECT COUNT(*) " +
                "FROM lasku " +
                "WHERE varaus_id = " + varaus_id + ";";
            MySqlCommand command = new MySqlCommand(query, ConnectionUtils.connection);
            int existingInvoices = Convert.ToInt32(command.ExecuteScalar());

            DialogResult result = DialogResult.No;
            if (existingInvoices != 0)
                result = MessageBox.Show("Tälle varaukselle on jo yksi tai useampi lasku. Poistetaanko vanha lasku/laskut?", "Hetkinen!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            //Delete existing invoices with the same reservation number
            if (result == DialogResult.Yes)
            {
                for (int i = 0; i < existingInvoices; i++)
                {
                    query = "SELECT lasku_id " +
                                    "FROM lasku " +
                                    "WHERE varaus_id = " + varaus_id + ";";
                    command = new MySqlCommand(query, ConnectionUtils.connection);
                    int lasku_id = Convert.ToInt32(command.ExecuteScalar());

                    query = "START TRANSACTION; " +
                        "DELETE FROM lasku " +
                        "WHERE lasku_id = " + lasku_id + "; " +
                        "COMMIT;";
                    command = new MySqlCommand(query, ConnectionUtils.connection);
                    command.ExecuteNonQuery();
                }
            }

            //Create new invoice
            double summa = calculateTotalPrice(varaus_id);
            double alv = 10;
            string maksettu = "false";
            query = "START TRANSACTION; " +
                            "INSERT INTO lasku(varaus_id, summa, alv, maksettu) " +
                            "VALUES(" + varaus_id + ", " + summa + ", " + alv + ", " + maksettu + "); " +
                            "COMMIT;";
            command = new MySqlCommand(query, ConnectionUtils.connection);
            command.ExecuteNonQuery();
            ConnectionUtils.closeConnection();
        }

        //Calculates the total price for a reservation including additional services
        private static double calculateTotalPrice(int varaus_id)
        {
            //Let's check if there's additional services for the reservation
            string query = "SELECT COUNT(*) " +
                            "FROM varauksen_palvelut " +
                            "WHERE varaus_id = " + varaus_id + ";";
            MySqlCommand cmd = new MySqlCommand(query, ConnectionUtils.connection);
            int dataRows = Convert.ToInt32(cmd.ExecuteScalar());

            double summa = 0;

            if (dataRows == 0) //No data -> No services found -> Calculate only cottage rental
            {
                query = "SELECT (m.hinta * DATEDIFF(v.varattu_loppupvm, v.varattu_alkupvm)) AS summa " +
                        "FROM varaus v " +
                        "JOIN mokki m ON v.mokki_mokki_id = m.mokki_id " +
                        "WHERE v.varaus_id = " + varaus_id + ";";
                cmd = new MySqlCommand(query, ConnectionUtils.connection);
                summa = Convert.ToInt32(cmd.ExecuteScalar());
            }

            else //Data found -> Let's calculate the services also
            {
                query = "SELECT ((SUM(p.hinta * vp.lkm)) + (m.hinta * DATEDIFF(v.varattu_loppupvm, v.varattu_alkupvm))) AS summa " +
                        "FROM varaus v " +
                        "JOIN mokki m ON v.mokki_mokki_id = m.mokki_id " +
                        "JOIN varauksen_palvelut vp ON v.varaus_id = vp.varaus_id " +
                        "JOIN palvelu p ON vp.palvelu_id = p.palvelu_id " +
                        "WHERE v.varaus_id = " + varaus_id + ";";
                cmd = new MySqlCommand(query, ConnectionUtils.connection);
                summa = Convert.ToInt32(cmd.ExecuteScalar());
            }
            return summa;
        }

        //Updates the 'vahvistus_pvm' field of varaus
        public static void setPaymentState(int lasku_id, string paymentDate)
        {
            ConnectionUtils.openConnection();
            //get varaus_id
            string query =  "SELECT varaus_id " +
                            "FROM lasku " +
                            "WHERE lasku_id = " + lasku_id + ";";
            MySqlCommand command = new MySqlCommand(query, ConnectionUtils.connection);
            int varaus_id = Convert.ToInt32(command.ExecuteScalar());

            //Set the date of payment
            query = "START TRANSACTION; " +
                    "UPDATE varaus " +
                    "SET vahvistus_pvm = " + paymentDate + " " +
                    "WHERE varaus_id = " + varaus_id + "; " +
                    "COMMIT;";
            command = new MySqlCommand(query, ConnectionUtils.connection);
            command.ExecuteNonQuery();
            ConnectionUtils.closeConnection();
        }

        //Deletes a bill
        public static void deleteSelectedInvoice(int lasku_id)
        {
            ConnectionUtils.openConnection();
            string query = "START TRANSACTION; " +
                "DELETE FROM lasku " +
                "WHERE lasku_id = " + lasku_id + "; " +
                "COMMIT;";
            MySqlCommand command = new MySqlCommand(query, ConnectionUtils.connection);
            command.ExecuteNonQuery();
            ConnectionUtils.closeConnection();
        }
    }
}
