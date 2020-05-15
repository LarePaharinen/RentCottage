using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MySql.Data;
using System.Windows.Forms;

namespace RentCottage
{
    public class PostUtils
    {

        public static string GetPostOffice(string postalCode)
        {
            string postOffice = "";
            ConnectionUtils.OpenConnection();
            MySqlDataReader reader = null;
            string query0 = "SELECT * FROM posti " +
                "WHERE postinro LIKE '" + postalCode + "';";
            MySqlCommand command0 = new MySqlCommand(query0, ConnectionUtils.connection);
            reader = command0.ExecuteReader();
            while (reader.Read())
            {
                postOffice = (string)reader["toimipaikka"];
            }
            reader.Close();
            ConnectionUtils.CloseConnection();
            return postOffice;
        }

        public static void CheckPostal(string postalCode, string postOffice)
        {
            //first we'll check whether the postal code already exists in the database
            ConnectionUtils.OpenConnection();
            MySqlDataReader reader = null;
            string query0 = "SELECT * FROM posti " +
                "WHERE postinro LIKE '" + postalCode + "';";
            MySqlCommand command0 = new MySqlCommand(query0, ConnectionUtils.connection);
            reader = command0.ExecuteReader();
            ArrayList postalList = new ArrayList();
            ArrayList officeList = new ArrayList();
            while (reader.Read())
            {
                postalList.Add((string)reader["postinro"]);
                officeList.Add((string)reader["toimipaikka"]);
            }
            reader.Close();
            ConnectionUtils.CloseConnection();
            if (postalList.Count > 0) //the postal code already exists
            {
                if (!officeList[0].Equals(postOffice)) //the post office in textbox is different from that of database -> solve conflict
                {
                    DialogResult res = MessageBox.Show("Postinumeroon " + postalList[0] +
                        " liittyvä postitoimipaikka on " + officeList[0] +
                        ". Haluatko varmasti muuttaa postinumeroon liittyvää postitoimipaikkaa?",
                        "Muuta postinumeron postitoimipaikkaa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (res == DialogResult.Yes)
                    {
                        ConnectionUtils.OpenConnection();
                        string query1 = "START TRANSACTION; " +
                            "UPDATE posti " +
                            "SET postinro='" + postalList[0] + "', toimipaikka='"
                            + postOffice + "' WHERE postinro ='" + postalList[0] + "'; " +
                            "COMMIT;";
                        MySqlCommand command1 = new MySqlCommand(query1, ConnectionUtils.connection);
                        command1.ExecuteNonQuery();
                        ConnectionUtils.CloseConnection();
                    }
                    else //res == DialogResult.No
                    {
                        //tbCustomerPostOffice.Text = (string)officeList[0];
                    }
                }
            }
            else //the postal code does not exist, so we create it
            {
                ConnectionUtils.OpenConnection();
                string query2 = "START TRANSACTION; " +
                    "INSERT INTO posti(postinro,toimipaikka) " +
                    "VALUES('" + postalCode + "','" + postOffice + "');" +
                    "COMMIT;";
                MySqlCommand command2 = new MySqlCommand(query2, ConnectionUtils.connection);
                command2.ExecuteNonQuery();
                ConnectionUtils.CloseConnection();
            }
        }

    }
}
