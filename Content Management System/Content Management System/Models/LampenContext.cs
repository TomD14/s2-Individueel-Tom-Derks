using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Content_Management_System.Models
{
    public class LampenContext
    {
        public string ConnectionString { get; set; }

        public LampenContext(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }
        public List<Lampen> GetAllLampen()
        {
            List<Lampen> list = new List<Lampen>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select * from lampen where id < 10", conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Lampen()
                        {
                            id = Convert.ToInt32(reader["id"]),
                            Model = reader["Model"].ToString(),
                            Watt = reader["Watt"].ToString(),
                            Volt = reader["Volt"].ToString()
                        });
                    }
                }
            }
            return list;
        }

    }
}
