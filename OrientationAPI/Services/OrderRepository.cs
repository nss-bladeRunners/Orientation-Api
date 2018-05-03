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

        public bool CloseOrder(int orderId)
        {
            using (var db = GetDb())
            {
                db.Open();

                var result = db.Execute(@"UPDATE [dbo].[Orders]
                                           SET [IsClosed] = 1
                                           WHERE OrderId = @orderId", new {orderId});

                return result == 1;
            }
        }

        public int PayForOrder(int orderId)
        {
            using (var db = GetDb())
            {
                db.Open();
                var sql = @"UPDATE [dbo].[Orders]
                            SET PaymentDate = GetDate()
                            WHERE OrderId = @orderId";
                return db.Execute(sql, new { orderId }); 
            }
        }

        public Order SelectOrder(int orderId)
        {
            using (var db = GetDb())
            {
                db.Open();
                var sql = @"SELECT * FROM [dbo].[Orders]
                            WHERE OrderId = @orderId";
                return db.QueryFirst<Order>(sql, new { orderId });
            }
        }

        public List<Order> SelectOutstandingOrders(int timeThresholdInDays)
        {
            using (var db = GetDb())
            {
                db.Open();
                var sql = @"SELECT * FROM [dbo].[Orders]
                            WHERE IsClosed = 1
                            AND DATEDIFF(DAY, CreatedDate, getDate()) > @timeThresholdInDays";
                return db.Query<Order>(sql, new { timeThresholdInDays }).ToList();
            }
        }
















        public int GetIsClosedStatus(int OrderId)
        {
            using (var db = GetDb())
            {
                db.Open();
                var sql = @"Select isClosed FROM [dbo].[Orders]
                            WHERE OrderId = @orderId";
                return db.QueryFirst<int>(sql, new { OrderId });
            }
        }
    }
}