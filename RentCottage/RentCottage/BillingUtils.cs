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
            //let's dig up all the information needed to create the bill
            double summa = calculatePriceTotalSum();
            double alv = 10;
            string maksettu = "false";
            ConnectionUtils.OpenConnection();
            string query =  "START TRANSACTION; " +
                            "INSERT INTO lasku(varaus_id, summa, alv, maksettu) " +
                            "VALUES(" + varaus_id + ", " + summa + ", " + alv + ", " + maksettu + "); " +
                            "COMMIT;";
            MySqlCommand command = new MySqlCommand(query, ConnectionUtils.connection);
            command.ExecuteNonQuery();
            ConnectionUtils.CloseConnection();
        }

        //Calculates the total price for a reservation
        private static double calculatePriceTotalSum()
        {
            ConnectionUtils.OpenConnection();
            string query =  "SELECT((p.hinta * vp.lkm) + (m.hinta * DATEDIFF(v.varattu_loppupvm, v.varattu_alkupvm))) as summa " +
                            "FROM varaus v " +
                            "JOIN mokki m ON v.mokki_mokki_id = m.mokki_id " +
                            "JOIN varauksen_palvelut vp ON v.varaus_id = vp.varaus_id " +
                            "JOIN palvelu p ON vp.palvelu_id = p.palvelu_id " +
                            "WHERE v.varaus_id = 1;";
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter(query, ConnectionUtils.connection);
            adapter.Fill(table);
            double summa = table.Rows[0].Field<double>("summa");
            ConnectionUtils.CloseConnection();
            return summa;
        }
    }
}
