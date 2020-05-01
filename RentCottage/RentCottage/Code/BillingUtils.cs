using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentCottage
{
    public class BillingUtils
    {

        //Creates a bill for a reservation
        public static void CreateBill(int varaus_id)
        {
            //Let's dig up all the information needed to create the bill
            double summa = calculatePriceTotalSum(varaus_id);
            double alv = 10;
            string maksettu = "false";
            ConnectionUtils.openConnection();
            string query =  "START TRANSACTION; " +
                            "INSERT INTO lasku(varaus_id, summa, alv, maksettu) " +
                            "VALUES(" + varaus_id + ", " + summa + ", " + alv + ", " + maksettu + "); " +
                            "COMMIT;";
            MySqlCommand command = new MySqlCommand(query, ConnectionUtils.connection);
            command.ExecuteNonQuery();
            ConnectionUtils.closeConnection();
        }

        //Calculates the total price for a reservation including additional services
        private static double calculatePriceTotalSum (int varaus_id)
        {
            ConnectionUtils.openConnection();

            //Let's check if there's additional services for the reservation
            string query =  "SELECT COUNT(*) " +
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
    }
}
