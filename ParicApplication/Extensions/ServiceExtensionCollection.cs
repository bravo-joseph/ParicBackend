using Microsoft.Extensions.DependencyInjection;
using ParicApplication.Mapper;
using ParicApplication.ParicServices;
using ParicApplication.ParicServices.IParicServices;

namespace ParicApplication.Extensions
{
	public static class ServiceExtensionCollection
	{
		public static void AddApplication(this IServiceCollection builder)
		{			
			builder.AddScoped<IDepartmentService, DepartmentService>();
			builder.AddScoped<IRequestService, RequestService>();
			builder.AddAutoMapper(typeof(MappingConfig));			
		}
	}
}
