using AplineF1_Miki_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace AplineF1_Miki_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AplineF1MikiController : ControllerBase
    {
        private IConfiguration _configuration;

        public AplineF1MikiController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        [Route("GetCircuits")]
        public JsonResult GetCircuits()
        {
            string query = "select * from dbo.circuits";
            DataTable table = new DataTable();
            string sqlDatasource = _configuration.GetConnectionString("alpineF1DbConnection");

            SqlDataReader myReader;
            using(SqlConnection myConn = new SqlConnection(sqlDatasource))
            {
                myConn.Open();
                using(SqlCommand myCommand = new SqlCommand(query,myConn)) 
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myConn.Close();
                }
            }

            return new JsonResult(table);
        }

        [HttpGet]
        [Route("GetAllTyres")]
        public JsonResult GetAllTyres()
        {
            string query = "select * from dbo.tyres";
            DataTable table = new DataTable();
            string sqlDatasource = _configuration.GetConnectionString("alpineF1DbConnection");

            SqlDataReader myReader;
            using (SqlConnection myConn = new SqlConnection(sqlDatasource))
            {
                myConn.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myConn))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myConn.Close();
                }
            }

            return new JsonResult(table);
        }

        [HttpPost]
        [Route("GetTyre")]
        public JsonResult GetTyre([FromForm] string id)
        {
            string query = "select * from dbo.tyres where id = @id";
            DataTable table = new DataTable();
            string sqlDatasource = _configuration.GetConnectionString("alpineF1DbConnection");

            SqlDataReader myReader;
            using (SqlConnection myConn = new SqlConnection(sqlDatasource))
            {
                myConn.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myConn))
                {
                    myCommand.Parameters.AddWithValue("@id", id);

                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myConn.Close();
                }
            }

            return new JsonResult(table);
        }

        [HttpPost]
        [Route("UpdateTyreDetails")]
        public JsonResult UpdateTyreCoefficient(
            [FromForm] string id,
            [FromForm] string name,
            [FromForm] string family,
            [FromForm] string type,
            [FromForm] string placement,
            [FromForm] string degradationCoefficient
            )
        {
            string query = "update dbo.tyres set " +
                "name = @name, " +
                "family = @family, " +
                "type = @type, " +
                "placement = @placement, " +
                "degradationCoefficient = @degradationCoefficient " +
                "where id = @id";

            DataTable table = new DataTable();
            string sqlDatasource = _configuration.GetConnectionString("alpineF1DbConnection");

            SqlDataReader myReader;
            using (SqlConnection myConn = new SqlConnection(sqlDatasource))
            {
                myConn.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myConn))
                {
                    myCommand.Parameters.AddWithValue("@name", name);
                    myCommand.Parameters.AddWithValue("@family", family);
                    myCommand.Parameters.AddWithValue("@type", type);
                    myCommand.Parameters.AddWithValue("@placement", placement);
                    myCommand.Parameters.AddWithValue("@degradationCoefficient", degradationCoefficient);
                    myCommand.Parameters.AddWithValue("@id", id);

                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myConn.Close();
                }
            }

            return new JsonResult(table);
        }

    }
}
