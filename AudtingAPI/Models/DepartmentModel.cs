namespace AudtingAPI.Models
{
	public class DepartmentModel
	{
		public Guid Id { get; set; }
		public string? Name { get; set; }

		public virtual List<EmployeeModel>? employeeModels { get; set; }
	}
}
