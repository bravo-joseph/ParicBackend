using System.ComponentModel.DataAnnotations;

namespace ParicApplication.ParicServices.DTO.DepartmentsDTO
{
	public class UpdateDepartmentDTO
	{
		[Required]
		[MinLength(5)]
		public string DepartmentName { get; set; }
		[Required]
		public string ManagerId { get; set; }		
	}
}
