﻿using Dapper;
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

        
    }
}