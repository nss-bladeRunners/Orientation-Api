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
    public class TrainingRepository
    {
        private SqlConnection getDb()
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings["BRBangazon"].ConnectionString);
        }
        public int Create(TrainingProgram dto)
        {
            using (var db = getDb())
            {
                db.Open();
                var sql = @"INSERT INTO dbo.TrainingPrograms
                            (name, description, startDate, endDate, maxAttendees)
                            VALUES 
                            (@name, @description, @startDate, @endDate, @maxAttendees)";
                return db.Execute(sql, dto);
            }
        }

        public List<TrainingProgram> GetAllUpcoming()
        {
            using (var db = getDb())
            {
                db.Open();
                var sql = "Select * From dbo.TrainingPrograms WHERE StartDate > GetDate()";
                return db.Query<TrainingProgram>(sql).ToList();
            }
        }

        public List<TrainingProgram> GetTrainingProgramById(int programId)
        {
            using (var db = getDb())
            {
                db.Open();
                var sql = "Select * From dbo.TrainingPrograms WHERE programId = @programId";
                return db.Query<TrainingProgram>(sql, new { programId }).ToList();
            }
        }

        internal int Update(TrainingProgram dto)
        {
            using (var db = getDb())
            {
                db.Open();
                var sql = @"UPDATE [dbo].[TrainingPrograms]
                               SET [Name] = @name
                                  ,[StartDate] = @startDate
                                  ,[EndDate] = @endDate
                                  ,[MaxAttendees] = @maxAttendees
                                  ,[Description] = @Description
                             WHERE ProgramId = @programId";
                return db.Execute(sql, dto);
            }
        }

        internal int Delete(int programId)
        {
            using (var db = getDb())
            {
                db.Open();
                var sql = @"DELETE FROM [dbo].[TrainingPrograms]
                             WHERE ProgramId = @programId AND StartDate > GetDate()";
                return db.Execute(sql, new { programId });
            }
        }

        public List<Employee> GetEmployeesByTrainingId(int employeeTrainingId)
        {
            using (var db = getDb())
            {
                db.Open();
                var sql = @"Select * from dbo.Employees e
                          JOIN dbo.Employee_Training et on e.EmployeeId = et.EmployeeId
                          WHERE et.TrainingProgramId = @employeeTrainingId";
                return db.Query<Employee>(sql, new { employeeTrainingId }).ToList(); 
            }
        }

    }
}