using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Content_Management_System.Models;
using MySql.Data.MySqlClient;

namespace Content_Management_System.Models
{

    public class InventarisDBAccesLayer
    {

        public static bool AddLamp(string storeData )
        {

            MySqlConnection con = new MySqlConnection("Server = localhost; Database=cms;Uid=root;");
            MySqlCommand StoreRegisterData = new MySqlCommand(storeData, con);

            try
            {
                con.Open();
                MySqlDataReader executeString = StoreRegisterData.ExecuteReader();
                con.Close();
                return true;
            }

            catch (Exception e)
            {
                Console.WriteLine("error:" + e.Message);
            }
            return false;

        }

    }

}
