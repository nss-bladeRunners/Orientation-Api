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
		 
		public List<Employee> GetAll()
		{
			using (var db = new SqlConnection(ConfigurationManager.ConnectionStrings["BRBangazon"].ConnectionString))
			{
				db.Open();

				return db.Query<Employee>(@"select e.FirstName, e.LastName, d.Name DepartmentName, e.EmployeeId
											 from dbo.Employees e
												join Departments d
												on e.DepartmentId = d.DepartmentId").ToList();

			}
		}

		public int UpdateEmployee(Employee employee)
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

		public int UpdateComputer(Employee employee)
		{
			using (var db = new SqlConnection(ConfigurationManager.ConnectionStrings["BRBangazon"].ConnectionString))
			{
				db.Open();

				return db.Execute(@"UPDATE[dbo].[Employee_Computers]
												SET [ComputerId] = @ComputerId
												WHERE EmployeeId = @EmployeeId", employee);

			}
		}

		public int UpdateTrainingProgram(Employee employee)
		{
			using (var db = new SqlConnection(ConfigurationManager.ConnectionStrings["BRBangazon"].ConnectionString))
			{
				db.Open();

				return db.Execute(@"UPDATE[dbo].[Employee_Training]
												SET [TrainingProgramId] = @TrainingProgramId
												WHERE EmployeeId = @EmployeeId", employee);

			}
		}

		public Employee GetEmployee(int employeeId)
		{ 

			using (var db = new SqlConnection(ConfigurationManager.ConnectionStrings["BRBangazon"].ConnectionString))
			{
				db.Open();

				
				return db.QueryFirst<Employee>( @"select e.FirstName, e.LastName, d.Name DepartmentName, y.Make ComputerMake, t.Name TrainingProgramName, e.employeeId, d.DepartmentId, c.ComputerId, x.TrainingProgramId
							from Employees e
								join Departments d
								on d.DepartmentId = e.DepartmentId
								left join Employee_Training x
								on e.EmployeeId = x.EmployeeId
								left join TrainingPrograms t
								on x.TrainingProgramId = t.ProgramId
								left join Employee_Computers c
								on e.EmployeeId = c.EmployeeId
								left join Computers y
								on y.ComputerId = c.ComputerId
						    WHERE e.EmployeeId = @employeeId", new { employeeId });


			}
		}

		public List<TrainingProgram>GetTraining(int employeeId)
		{
			using (var db = new SqlConnection(ConfigurationManager.ConnectionStrings["BRBangazon"].ConnectionString))
			{
				db.Open();


				return db.Query<TrainingProgram>(@"select *
											from employees e
											join Employee_Training t
											on e.EmployeeId = t.EmployeeId
											join TrainingPrograms p
											on t.TrainingProgramId = p.ProgramId
											where e.EmployeeId = @employeeId", new { employeeId }).ToList();

			}
		}

        public List<TrainingProgram> GetAvailableTrainings(int employeeId)
        {
            using (var db = new SqlConnection(ConfigurationManager.ConnectionStrings["BRBangazon"].ConnectionString))
            {
                db.Open();

                var sql = @"WITH EmployeeTrainingCTE (ProgramId)  
                            AS  
                            (  
                                SELECT distinct tp.ProgramId
                                FROM TrainingPrograms tp  
                                JOIN Employee_Training et on tp.ProgramId = et.TrainingProgramId
	                            WHERE et.EmployeeId = @employeeId 
                            ) 

                            SELECT * 
                            FROM TrainingPrograms 
                            WHERE ProgramId NOT IN (SELECT ProgramId FROM EmployeeTrainingCTE) 
                            AND StartDate > getDate();";

                return db.Query<TrainingProgram>(sql, new { employeeId } ).ToList(); 
            }
        }

        public int CreateEmployeeTraining(int employeeId, int trainingProgramId)
        {
            using (var db = new SqlConnection(ConfigurationManager.ConnectionStrings["BRBangazon"].ConnectionString))
            {
                db.Open();
                var sql = @"INSERT INTO [dbo].[Employee_Training]
                                   ([TrainingProgramId]
                                   ,[EmployeeId])
                             VALUES
                                   (@trainingProgramId
                                   ,@employeeId)";
                return db.Execute(sql, new { employeeId, trainingProgramId });
            }
        }
    }
}