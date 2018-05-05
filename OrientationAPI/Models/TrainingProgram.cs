using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrientationAPI.Models
{
    public class TrainingProgram
    {
        public int ProgramId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int MaxAttendees { get; set; }
        public int AttendeeCount { get; set; }
        public int RemainingSeats { get { return MaxAttendees - AttendeeCount; } } 
    }
}