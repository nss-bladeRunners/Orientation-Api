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
    }
}