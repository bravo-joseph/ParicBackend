using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ParicDomain.Entities;
using ParicDomain.IRepository;
using ParicInfrastructure.Persistence;
using ParicInfrastructure.Repository;

namespace ParicInfrastructure.Extensions
{
	public static class ServiceCollectionExtension
	{
		public static void AddInfrastructure(this IServiceCollection builder,IConfiguration configuration)
		{
			builder.AddScoped<IDepartmentRepository, DepartmentRepository>();
			builder.AddScoped<IRequestRepository, RequestRepository>();
			builder.AddIdentity<SystemUser, IdentityRole>(options =>
			{
				options.Password.RequiredLength = 8;
				options.Password.RequireDigit = true;
				options.Password.RequireLowercase = true;
				options.Password.RequireNonAlphanumeric = true;
				options.Password.RequireUppercase = true;
			}).AddEntityFrameworkStores<ParicDbContext>();
			builder.AddDbContext<ParicDbContext>(options =>
			{				
				options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
				options.EnableDetailedErrors(detailedErrorsEnabled: true);
			});
		}
	}
}
