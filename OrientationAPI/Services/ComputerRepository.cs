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

        public List<Computer> GetAll()
        {
            using (var db = GetDb())
            {
                db.Open();
                var result = db.Query<Computer>("SELECT * From dbo.Computers").ToList();
                return result;
            }
        }

        public bool Create(Computer computer)
        {
            using (var db = GetDb())
            {
                db.Open();

                var numberCreated = db.Execute(@"INSERT INTO [dbo].[Computers]
                                                    ([Manufacturer],
                                                    [Make],
                                                    [PurchaseDate])
                                                 VALUES
                                                    (@Manufacturer,
                                                     @Make,
                                                     @PurchaseDate)", computer);
                return numberCreated == 1;
                                                
            }
        }

        public bool Update(Computer computer)
        {
            using (var db = GetDb())
            {
                db.Open();

                var updateComputer = db.Execute(@"UPDATE [dbo].[Computers]
                                                SET [Manufacturer] = @Manufacturer,
                                                    [Make] = @Make,
                                                    [PurchaseDate] = @PurchaseDate
                                                WHERE ComputerId = @ComputerId", computer);

                return updateComputer == 1;
            }
        }

        public bool Delete(int ComputerId)
        {
            using (var db = GetDb())
            {
                db.Open();

                var deleteComputer = db.Execute(@"DELETE FROM [dbo].[Employee_Computers]
                                                WHERE ComputerId = @ComputerId", new {ComputerId});

                return deleteComputer == 1;
            }
        }

        public Computer GetComputer(int computerId)
        {
            using (var db = GetDb())
            {
                db.Open();
                var computer = db.QueryFirst<Computer>(@"SELECT * FROM Computers WHERE ComputerId = @computerId", new
                {
                    computerId
                });

                return computer;
            }
        }


    }
}