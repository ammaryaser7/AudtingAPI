namespace AudtingAPI.Models
{
	public class EmployeeModel
	{
		public Guid Id { get; set; }
		public string? Name { get; set; }

		public Guid DepartmentModelId { get; set; }
		public string? Position { get; set; }
		
		public virtual DepartmentModel? DepartmentModel { get; set; }

		public virtual List<AuditModel>? AuditModels { get; set; }

	}
}
