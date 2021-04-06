using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Content_Management_System.Models;

namespace BlogPostApi
{
    public class BlogPostQuery
    {
        public AppDB Db { get; }

        public BlogPostQuery(AppDB db)
        {
            Db = db;
        }

        public async Task<Lampen> FindOneAsync(int id)
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"SELECT `Id`, `Model`, `Watt` FROM `Inventaris` WHERE `Id` = @id";
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@id",
                DbType = DbType.Int32,
                Value = id,
            });
            var result = await ReadAllAsync(await cmd.ExecuteReaderAsync());
            return result.Count > 0 ? result[0] : null;
        }

        public async Task<List<Lampen>> InventarisAsync()
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"SELECT `Id`, `Model`, `Watt` FROM `Inventaris` ORDER BY `Id` DESC LIMIT 10;";
            return await ReadAllAsync(await cmd.ExecuteReaderAsync());
        }

        public async Task DeleteAllAsync()
        {
            using var txn = await Db.Connection.BeginTransactionAsync();
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"DELETE FROM `Inventaris`";
            await cmd.ExecuteNonQueryAsync();
            await txn.CommitAsync();
        }

        private async Task<List<Lampen>> ReadAllAsync(DbDataReader reader)
        {
            var posts = new List<Lampen>();
            using (reader)
            {
                while (await reader.ReadAsync())
                {
                    var post = new Lampen(Db)
                    {
                        Id = reader.GetInt32(0),
                        Model = reader.GetString(1),
                        Watt = reader.GetInt32(2),
                    };
                    posts.Add(post);
                }
            }
            return posts;
        }
    }
}