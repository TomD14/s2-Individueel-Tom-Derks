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

        //public string AddLamp(Lampen Lampen)
        //{
        //    try
        //    {
        //        MySqlCommand cmd = new MySqlCommand("INSERT INTO inventaris(`Model`,`Watt`,`Volt`,`Hertz`,`Aantal`,`Kleur`)VALUES('@Model','@Watt','@Volt','@Hertz','@Kleur','@Aantal')", con);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.AddWithValue("@Model", Lampen.Model);
        //        cmd.Parameters.AddWithValue("@Watt", Lampen.Watt);
        //        cmd.Parameters.AddWithValue("@Volt", Lampen.Volt);
        //        cmd.Parameters.AddWithValue("@Hertz", Lampen.Hertz);
        //        cmd.Parameters.AddWithValue("@Kleur", Lampen.Kleur);
        //        cmd.Parameters.AddWithValue("@Aantal", Lampen.Aantal);
        //        con.Open();
        //        cmd.ExecuteNonQuery();
        //        con.Close();
        //        return ("Data save Successfully");
        //    }
        //    catch (Exception ex)
        //    {
        //        if (con.State == ConnectionState.Open)
        //        {
        //            con.Close();
        //        }
        //        return (ex.Message.ToString());
        //    }
        //}

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
