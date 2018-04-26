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
	public class CustomerRepository
	{
		public int Create(CustomerDto customer)
		{
			using (var db = new SqlConnection(ConfigurationManager.ConnectionStrings["BRBangazon"].ConnectionString))
			{
				db.Open();

				return db.Execute(@"INSERT INTO [dbo].[Customers]
													([FirstName]
													,[LastName]
													,[Phone])
												 VALUES
													(@FirstName 
													,@LastName 
													,@Phone)", customer);

			}
		}

		public IEnumerable<Customer> GetAllActive()
		{
			using (var db = new SqlConnection(ConfigurationManager.ConnectionStrings["BRBangazon"].ConnectionString))
			{
				db.Open();
				var sql = "Select * From dbo.Customers WHERE isActive = 1";
				return db.Query<Customer>(sql);
			}
		}

		public int Update(Customer customer)
		{
			using (var db = new SqlConnection(ConfigurationManager.ConnectionStrings["BRBangazon"].ConnectionString))
			{
				db.Open();

				return db.Execute(@"UPDATE[dbo].[Customers]
												SET [FirstName] = @FirstName,
												    [LastName] = @LastName,
											        [Phone] = @Phone
												WHERE CustomerId = @CustomerId", customer);

			}
		}

		public int Deactivate(int customerId)
		{
			using (var db = new SqlConnection(ConfigurationManager.ConnectionStrings["BRBangazon"].ConnectionString))
			{
				db.Open();
				var sql = @"UPDATE [dbo].[Customers]
							SET isActive = 0
                            WHERE CustomerId = @CustomerId";

				return db.Execute(sql, new { customerId });
			}
		}
	}
}