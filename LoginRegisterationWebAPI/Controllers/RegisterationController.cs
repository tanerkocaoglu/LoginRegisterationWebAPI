using LoginRegisterationWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace LoginRegisterationWebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]

	public class RegisterationController : ControllerBase
	{
		private readonly IConfiguration _configuration;

		public RegisterationController(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		static readonly string connectionString = "Data Source=localhost;Initial Catalog=AuthWithWebAPI;Integrated Security=True";
		public IConfiguration Configuration => _configuration;

		[HttpPost]
		[Route("registeration")]
		public string Registeration(Registeration registeration)
		{
			using var con = new SqlConnection(connectionString);
			string sqlQuery = "insert into Registeration(Username,Password,Email) values ('" + registeration.Username + "','" + registeration.Password + "','" + registeration.Email + "') ";
			SqlCommand sqlCommand = new(sqlQuery, con);
			con.Open();
			int i = sqlCommand.ExecuteNonQuery();

			if (i > 0)
			{
				return "Data inserted";
			}
			else
			{
				return "Error";
			}
		}

		[HttpPost]
		[Route("login")]
		public string Login(Login login)
		{
			using var con = new SqlConnection(connectionString);
			SqlDataAdapter da = new("select Username,Password from Registeration where Username='" + login.Username + "' AND Password='" + login.Password + "' AND IsActive= 1 ", con);
			DataTable dt = new();
			da.Fill(dt);
			if (dt.Rows.Count > 0)

			{
				return "Successfully Logged In";
			}
			else
			{
				return "Username or password is wrong";
			}
		}


	}
}
