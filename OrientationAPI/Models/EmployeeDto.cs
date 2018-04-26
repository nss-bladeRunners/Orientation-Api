using System;

namespace OrientationAPI.Services
{
	public class EmployeeDto
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public DateTime EmployeeStartDate {get; set;}
		public int DepartmentId { get; set; }
	}
}