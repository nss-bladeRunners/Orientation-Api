﻿using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace OrientationAPI.Services
{
	public class EmployeeRepository
	{
		public int Create(EmployeeDto employee)
		{
			using (var db = new SqlConnection(ConfigurationManager.ConnectionStrings["BRBangazon"].ConnectionString))
			{
				db.Open();

				return db.Execute(@"INSERT INTO [dbo].[Employees]
													([FirstName]
													,[LastName]
													,[EmployeeStartDate]
													,[DepartmentId])
												 VALUES
													(@FirstName 
													,@LastName 
													,@EmployeeStartDate
													,@DepartmentId)", employee);

			}
		}
		 
		public IEnumerable<Employees> GetAll()
		{
			using (var db = new SqlConnection(ConfigurationManager.ConnectionStrings["BRBangazon"].ConnectionString))
			{
				db.Open();

				return db.Query<Employees>(@"select e.FirstName, e.LastName, d.Name
											 from dbo.Employees e
												join Departments d
												on e.DepartmentId = d.DepartmentId");

			}
		}

		//ask about posting to two tables
		public int Update(Employees employee)
		{
			using (var db = new SqlConnection(ConfigurationManager.ConnectionStrings["BRBangazon"].ConnectionString))
			{
				db.Open();

				return db.Execute(@"UPDATE[dbo].[Employees]
												SET [FirstName] = @FirstName,
												    [LastName] = @LastName,
											        [DepartmentId] = @DepartmentId
												WHERE EmployeeId = @EmployeeId", employee);

			}
		}
	}
}