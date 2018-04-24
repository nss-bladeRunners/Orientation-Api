using Dapper;
using OrientationAPI.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace OrientationAPI.Services
{

    public class ComputerRepository
    {
        private static SqlConnection GetDb()
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings["BRBangazon"].ConnectionString);
        }

        public IEnumerable<Computer> GetAll()
        {
            using (var db = GetDb())
            {
                db.Open();
                var result = "SELECT * From dbo.Computers";
                return db.Query<Computer>(result).ToList();
            }
        }
    }
}