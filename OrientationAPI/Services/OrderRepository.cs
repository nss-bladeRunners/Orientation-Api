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
    public class OrderRepository
    {
        private static SqlConnection GetDb()
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings["BRBangazon"].ConnectionString);
        }

        public bool Create(int customerId)
        {
            using (var db = GetDb())
            {
                db.Open();
                var orderCreated = db.Execute(@"INSERT INTO Orders (CustomerId)
              VALUES (@customerId)", new
                {
                    customerId
                });

                return orderCreated == 1;
            } 
        }
    }
}