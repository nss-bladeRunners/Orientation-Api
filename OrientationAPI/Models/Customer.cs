﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrientationAPI.Models
{
	public class Customer
	{
		public int CustomerId { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Phone { get; set; }
		public bool IsActive { get; set; }
	}
}