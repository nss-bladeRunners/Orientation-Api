using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrientationAPI.Models
{
    public class Computer
    {
        public int ComputerId {get; set;}
        public string Manufacturer {get; set;}
        public string Make {get; set;}
        public DateTime Date {get; set;}
    }
}