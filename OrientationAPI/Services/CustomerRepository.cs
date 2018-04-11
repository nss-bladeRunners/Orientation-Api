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
	public class CustomerRepository
	{
		public bool Create(CustomerDto customer)
		{
			using (var db = new SqlConnection(ConfigurationManager.ConnectionStrings["BRBangazon"].ConnectionString))
			{
				db.Open();

				var numberCreated = db.Execute(@"INSERT INTO [dbo].[Customers]
													([FirstName]
													,[LastName]
													,[Phone])
												 VALUES
													(@FirstName 
													,@LastName 
													,@Phone)", customer);
				return numberCreated == 1;
			}
		}

		public bool Update(CustomerDto customer)
		{
			using (var db = new SqlConnection(ConfigurationManager.ConnectionStrings["BRBangazon"].ConnectionString))
			{
				db.Open();

				var updateCustomer = db.Execute(@"UPDATE[dbo].[Customers]
												SET[FirstName] =  @FirstName,
												   [LastName] =  @LastName,
											       [Phone] = @Phone
												WHERE customerId = @customerId", new { customer });
				return updateCustomer == 1;
			}
		}
	}
}