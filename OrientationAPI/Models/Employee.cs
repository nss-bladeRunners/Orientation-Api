using System;

namespace OrientationAPI.Services
{
	public class Employee
	{
		public int EmployeeId { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public int DepartmentId { get; set; }
		public DateTime EmployeeStartDate { get; set; }
		public int ComputerId { get; set; }
		public int TrainingProgramId { get; set; }
		public string TrainingProgramName { get; set; }
		public string DepartmentName { get; set; }
		public string ComputerMake { get; set; }
	}
}