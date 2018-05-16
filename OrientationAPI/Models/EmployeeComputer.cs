using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrientationAPI.Models
{
    public class EmployeeComputer
    {
        public int EmployeeComputerId {get; set;}
        public int EmployeeId {get; set;}
        public int ComputerId {get; set;}
        public DateTime AssignedDate {get; set;}
        public DateTime ReturnedDate {get; set;}
    }
}