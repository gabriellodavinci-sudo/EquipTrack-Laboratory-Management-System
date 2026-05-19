using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

namespace EQUIPTRACK
{
   public class DATABASE
    {
        private static string connStr =
           "server=localhost;user=root;password=3cn1vince;database=equiptrackdb;";

        // 🔌 Get connection
        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(connStr);
        }

        // 🧪 Test connection method
        public static bool TestConnection()
        {
            try
            {
                using (MySqlConnection conn = GetConnection())
                {
                    conn.Open();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
