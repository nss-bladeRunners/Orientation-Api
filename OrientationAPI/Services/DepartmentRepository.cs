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
    public class DepartmentRepository
    {
        private static SqlConnection GetDb()
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings["BRBangazon"].ConnectionString);
        }

        public List<DepartmentDto> ListDepartment()
        {
            using (var db = GetDb())
            {
                db.Open();
                var getAllDepartments = db.Query<DepartmentDto>(@"select * from dbo.Departments");
                return getAllDepartments.ToList();
            }
        }

        public IEnumerable<EmployeeDto> GetEmployeesByDepartmentId(int departmentID)
        {
            using (var db = GetDb())
            {
                db.Open();

                var getDepartmentEmployees = db.Query<EmployeeDto>(@"SELECT * from Employees 
                       JOIN Departments on Departments.DepartmentID = Employees.DepartmentID
                       WHERE Departments.DepartmentId = @departmentId", new { departmentID });
                return getDepartmentEmployees;
            }
        }

        public DepartmentDto GetDepartmentById(int departmentId)
        {
            using (var db = GetDb())
            {
                db.Open();
                var sql = "Select * From dbo.Departments WHERE departmentId = @departmentId";
                return db.QueryFirst<DepartmentDto>(sql, new { departmentId });
            }
        }

        public int AddNewDepartment(DepartmentDto department)
        {
            using (var db = GetDb())
            {
                db.Open();

                var newDepartmentQuery = @"INSERT INTO dbo.Departments
                                            (name)
                                            VALUES 
                                            (@name)";
                return db.Execute(newDepartmentQuery, department);
            }
        }
    }
}