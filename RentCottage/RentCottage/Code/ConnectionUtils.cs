using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MySql.Data;
using System.Data;

namespace RentCottage
{
    public class ConnectionUtils
    {
        public static MySqlConnection connection = new MySqlConnection("server=127.0.0.1;user id=testi;password=testi;persistsecurityinfo=True;database=vn");

        public static void OpenConnection()
        {
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
        }

        public static void CloseConnection()
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }

    }
}
