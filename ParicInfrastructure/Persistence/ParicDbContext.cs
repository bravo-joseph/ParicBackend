using ParicDomain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace ParicInfrastructure.Persistence
{
	internal class ParicDbContext : IdentityDbContext<SystemUser>
	{
		public ParicDbContext(DbContextOptions<ParicDbContext> options) : base(options)
		{

		}
		public DbSet<Department> Departments { get; set; }
		public DbSet<Requests> Requests { get; set; }
		public DbSet<RequestsTypes> RequestsTypes { get; set; }
		public DbSet<FamilyInfo> FamilyInfo { get; set; }
		public DbSet<BioData> BioData { get; set; }
		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);
			var DefaultRequestTypes = new RequestsTypes[] {
				new RequestsTypes()
				{
				Id = 1,
				Name = "Purchase Request",
				},
				new RequestsTypes()
				{
				Id = 2,
				Name = "Cash Request",
				},
			};
			IEnumerable<IdentityRole> roles = new List<IdentityRole>
			{
				new IdentityRole
				{
					Id = "1",
					Name = "Admin",
					NormalizedName = "ADMIN"
				},
				new IdentityRole
				{
					Id = "2",
					Name = "Staff",
					NormalizedName = "STAFF"
				}
			};
			builder.Entity<RequestsTypes>().HasData(DefaultRequestTypes);
			builder.Entity<IdentityRole>().HasData(roles);
		}

	}
}
