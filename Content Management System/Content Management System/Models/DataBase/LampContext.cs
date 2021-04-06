using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Content_Management_System.Models;

namespace BlogPostApi.Controllers
{
    [Route("api/[controller]")]
    public class BlogController : ControllerBase
    {
        public BlogController(AppDB db)
        {
            Db = db;
        }

        // GET api/blog
        [HttpGet]
        public async Task<IActionResult> GetLatest()
        {
            await Db.Connection.OpenAsync();
            var query = new BlogPostQuery(Db);
            var result = await query.InventarisAsync();
            return new OkObjectResult(result);
        }

        // GET api/blog/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOne(int id)
        {
            await Db.Connection.OpenAsync();
            var query = new BlogPostQuery(Db);
            var result = await query.FindOneAsync(id);
            if (result is null)
                return new NotFoundResult();
            return new OkObjectResult(result);
        }

        // POST api/blog
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Lampen body)
        {
            await Db.Connection.OpenAsync();
            body.Db = Db;
            await body.InsertAsync();
            return new OkObjectResult(body);
        }

        // PUT api/blog/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOne(int id, [FromBody] Lampen body)
        {
            await Db.Connection.OpenAsync();
            var query = new BlogPostQuery(Db);
            var result = await query.FindOneAsync(id);
            if (result is null)
                return new NotFoundResult();
            result.Model = body.Model;
            result.Watt = body.Watt;
            await result.UpdateAsync();
            return new OkObjectResult(result);
        }

        // DELETE api/blog/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOne(int id)
        {
            await Db.Connection.OpenAsync();
            var query = new BlogPostQuery(Db);
            var result = await query.FindOneAsync(id);
            if (result is null)
                return new NotFoundResult();
            await result.DeleteAsync();
            return new OkResult();
        }

        // DELETE api/blog
        [HttpDelete]
        public async Task<IActionResult> DeleteAll()
        {
            await Db.Connection.OpenAsync();
            var query = new BlogPostQuery(Db);
            await query.DeleteAllAsync();
            return new OkResult();
        }

        public AppDB Db { get; }
    }
}
//public string ConnectionString { get; set; }

//public LampContext(string connectionString)
//{
//    this.ConnectionString = connectionString;
//}

//private MySqlConnection GetConnection()
//{
//    return new MySqlConnection(ConnectionString);
//}
//public List<Lampen> GetAllLampen()
//{
//    List<Lampen> list = new List<Lampen>();

//    using (MySqlConnection conn = GetConnection())
//    {
//        conn.Open();
//        MySqlCommand cmd = new MySqlCommand("select * from inventaris where id < 15", conn);

//        using (var reader = cmd.ExecuteReader())
//        {
//            while (reader.Read())
//            {
//                list.Add(new Lampen()
//                {
//                    Id = Convert.ToInt32(reader["Id"]),
//                    Model = reader["Model"].ToString(),
//                    Watt = Convert.ToInt32(reader["Watt"]),
//                    Volt = Convert.ToInt32(reader["Volt"]),
//                    Hertz = Convert.ToInt32(reader["Hertz"]),
//                    Kleur = Convert.ToInt32(reader["Kleur"]),
//                    Aantal = Convert.ToInt32(reader["Aantal"])

//                });
//            }
//        }
//    }
//    return list;
//}

