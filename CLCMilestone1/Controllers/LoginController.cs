using CLCMilestone1.Models;
using CLCMilestone1.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace CLCMilestone1.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ProcessLogin(UserModel user)
        {
            SecurityService securityService = new SecurityService();
            if (securityService.isValid(user))
                return View("LoginSuccess", user);
            else
                return View("LoginFailure", user);
        }
        public IActionResult Register(UserModel user)
        {

            using (SqlConnection connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=WebApp;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                String query = "INSERT INTO dbo.users (USERNAME, PASSWORD) VALUES (@username,@password)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@username", "abc");
                    command.Parameters.AddWithValue("@password", "abc");

                    connection.Open();
                    int result = command.ExecuteNonQuery();

                    // Check Error
                    if (result < 0)
                        Console.WriteLine("Error inserting data into Database!");
                }
            }
            return View("Index");
        }
    }
}
