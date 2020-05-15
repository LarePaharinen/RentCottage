using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentCottage.Code
{
    public class RegionUtils
    {
        public static void PopulateCBRegion(ComboBox comboBox)
        {
            //Fills a combobox-component with all availeable regions
            string query = "SELECT * FROM toimintaalue";
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter(query, ConnectionUtils.connection);
            adapter.Fill(table);
            comboBox.DataSource = table;
            comboBox.DisplayMember = "nimi";
        }

        //Query database on a region name, and return it's index
        public static int RegionNameToIndex(string region)
        {
            int index = 0;
            try
            {
                ConnectionUtils.OpenConnection();
                MySqlDataReader reader = null;
                string query = "SELECT * FROM toimintaalue " +
                    "WHERE nimi = '" + region + "';";
                MySqlCommand command = new MySqlCommand(query, ConnectionUtils.connection);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    index = reader.GetInt32(0);
                }
                reader.Close();
                ConnectionUtils.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return index;
        }


        //Query databe on a region index, return it's name in string
        public static string RegionIndexToName(int index)
        {
            string region = "Haku ei onnistunut";
            try
            {
                ConnectionUtils.OpenConnection();
                MySqlDataReader reader = null;
                string query = "SELECT * FROM toimintaalue " +
                    "WHERE toimintaalue_id = " + index + ";";
                MySqlCommand command = new MySqlCommand(query, ConnectionUtils.connection);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    region = (string)reader["nimi"];
                }
                reader.Close();
                ConnectionUtils.CloseConnection();
                return region;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return region;
            }
        }
    }
}
