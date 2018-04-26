using System;

namespace OrientationAPI.Services
{
	public class Employees
	{
		public int EmployeeId { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public int DepartmentId { get; set; }
		public DateTime EmployeeStartDate { get; set; }
		public int ComputerId { get; set; }
		public int TrainingProgramId { get; set; }
		public string TrainingProgramName { get; set; }
		public string Name { get; set; }
	}
}