using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Content_Management_System.Models
{
    public class LampContext
    {
        public string ConnectionString { get; set; }

        public LampContext(string connectionString)
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
                MySqlCommand cmd = new MySqlCommand("select * from inventaris where id < 15", conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Lampen()
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Model = reader["Model"].ToString(),
                            Watt = Convert.ToInt32(reader["Watt"]),
                            Volt = Convert.ToInt32(reader["Volt"]),
                            Hertz = Convert.ToInt32(reader["Hertz"]),
                            Kleur = Convert.ToInt32(reader["Kleur"]),
                            Aantal = Convert.ToInt32(reader["Aantal"])

                        });
                    }
                }
            }
            return list;
        }
    }
}
