﻿using MySql.Data.MySqlClient;
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
        public static bool CheckCottageBookDate(int mokki_id, string dateFrom, string DateTo)
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
                MessageBox.Show("Valitsemasi mökki on varattu annetuna ajalla", "Mökki varattu annetuna ajalla", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                ConnectionUtils.closeConnection();
                return true;
            }
        }

        public static bool CheckCottageID(int mokki_id)
        {
            ConnectionUtils.openConnection();
            MySqlCommand msc = new MySqlCommand("SELECT mokki_id FROM mokki WHERE MOKKI_ID = '" + mokki_id + "'", ConnectionUtils.connection);
            MySqlDataReader reader = msc.ExecuteReader();
            if (!reader.HasRows)
            {
                ConnectionUtils.closeConnection();
                MessageBox.Show("Antamaasi mökkiID:tä ei löytynyt.", "Virhe", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                ConnectionUtils.closeConnection();
                return true;
            }
        }

        public static bool CheckCottageBookDateTest(int mokki_id, int varaus_id, string dateFrom, string DateTo)
        {
            ConnectionUtils.openConnection(); // Check is cottage free at the indicated time
            MySqlCommand msc = new MySqlCommand("SELECT mokki_id FROM mokki " +
                "WHERE mokki_id = " + mokki_id + " " +
                "AND mokki_id IN " +
                "(SELECT mokki_mokki_id FROM varaus v WHERE '" + dateFrom + " 16:00:00' < v.varattu_loppupvm AND '" + DateTo + " 12:00:00' > v.varattu_alkupvm AND '" + varaus_id + "' != VARAUS_ID);", ConnectionUtils.connection);
            MySqlDataReader reader = msc.ExecuteReader();

            if (reader.HasRows)
            {
                ConnectionUtils.closeConnection();
                MessageBox.Show("Valitsemasi mökki on varattu annetuna ajalla", "Mökki varattu annetuna ajalla", MessageBoxButtons.OK, MessageBoxIcon.Error);
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