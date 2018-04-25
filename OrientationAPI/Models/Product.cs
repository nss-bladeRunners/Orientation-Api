using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrientationAPI.Models
{
    public class Product
    {
        public string ProductName { get; set; }
        public double ProductPrice { get; set; }
        public int Quantity { get; set; }
        public int SellerId { get; set; }
        public int ProductId { get; set; }
    }
}