using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Content_Management_System.Models
{
    public class Lampen
    {

        public int Id { get; set; }

        public string Model { get; set; }

        public int Watt { get; set; }

        public int Volt { get; set; }

        public int Hertz { get; set; }

        public int Kleur { get; set; }

        public int Aantal { get; set; }


        internal AppDB Db { get; set; }

        public Lampen()
        {
        }

        internal Lampen(AppDB db)
        {
            Db = db;
        }

        public async Task InsertAsync()
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"INSERT INTO `Inventaris` (`Model`, `Watt`) VALUES (@Model, @Watt);";
            BindParams(cmd);
            await cmd.ExecuteNonQueryAsync();
            Id = (int)cmd.LastInsertedId;
        }

        public async Task UpdateAsync()
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"UPDATE `Inventaris` SET `Model` = @Model, `Watt` = @Watt WHERE `Id` = @id;";
            BindParams(cmd);
            BindId(cmd);
            await cmd.ExecuteNonQueryAsync();
        }

        public async Task DeleteAsync()
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"DELETE FROM `Inventaris` WHERE `Id` = @id;";
            BindId(cmd);
            await cmd.ExecuteNonQueryAsync();
        }

        private void BindId(MySqlCommand cmd)
        {
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@id",
                DbType = DbType.Int32,
                Value = Id,
            });
        }

        private void BindParams(MySqlCommand cmd)
        {
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@Model",
                DbType = DbType.String,
                Value = Model,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@Watt",
                DbType = DbType.String,
                Value = Watt,
            });
        }
    }
}
