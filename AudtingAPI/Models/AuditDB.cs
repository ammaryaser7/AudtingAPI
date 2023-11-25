using Microsoft.EntityFrameworkCore;

namespace AudtingAPI.Models
{
	public class AuditDB : DbContext
	{

		public AuditDB(DbContextOptions<AuditDB> options)
			: base(options)
		{
		}

		public virtual DbSet<AuditModel> AuditModels { get; set; }
		public virtual DbSet<UserModel> UserModels { get; set; }
		public virtual DbSet<DepartmentModel> DepartmentModels { get; set; }
		public virtual DbSet<EmployeeModel> EmployeeModels { get; set; }

	}
}
