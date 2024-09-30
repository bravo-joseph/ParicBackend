using System.ComponentModel.DataAnnotations;

namespace ParicApplication.ParicServices.DTO.DepartmentsDTO
{
	public class CreateDepartmentDTO
	{
		[Required]
		[MinLength(5)]
        public string DepartmentName { get; set; }
		[Required]
        public string ManagerId { get; set; }
		[Required]
		public decimal InitialBudget { get; set; }
    }
}
