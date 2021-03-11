using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Content_Management_System.Models;
using Microsoft.Azure.Documents;

namespace Content_Management_System.Models
{
    public class LampenAccesLayer
    {
        public string ConnectionString { get; set; }

        public LampenAccesLayer(string connectionString)
        {
            this.ConnectionString = connectionString;
        }
        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }
        public string AddEmployeeRecord(Lampen Lampen)
        {
            using (MySqlConnection conn = GetConnection())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand("sp_Lamp_Add", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", Lampen.id);
                    cmd.Parameters.AddWithValue("@Model", Lampen.Model);
                    cmd.Parameters.AddWithValue("@Watt", Lampen.Watt);
                    cmd.Parameters.AddWithValue("@Volt", Lampen.Volt);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    return ("Data save Successfully");
                }
                catch (Exception ex)
                {
                    conn.Close();
                    
                    return (ex.Message.ToString());
                }
            }
        }
    }
}
