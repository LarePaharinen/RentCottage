using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentCottage.Code
{
    public class OrderUtils
    {
        public static bool ChechCottageBookDate(int mokki_id, string dateFrom, string DateTo)
        {
            ConnectionUtils.openConnection(); // Check is cottage free at the indicated time
            MySqlCommand msc = new MySqlCommand("SELECT mokki_id FROM mokki " +
                "WHERE mokki_id = " + mokki_id + " " +
                "AND mokki_id IN " +
                "(SELECT mokki_mokki_id FROM varaus v WHERE '" +
                dateFrom + " 16:00:00' < v.varattu_loppupvm AND '" + DateTo + " 12:00:00' > v.varattu_alkupvm);", ConnectionUtils.connection);
            MySqlDataReader reader = msc.ExecuteReader();

            if (reader.HasRows)
            {
                ConnectionUtils.closeConnection();
                return false;
            }
            else
            {
                ConnectionUtils.closeConnection();
                return true;
            }
        }
    }
}
