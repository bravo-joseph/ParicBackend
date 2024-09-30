using ParicDomain.Entities;
using ParicApplication.ParicServices.DTO.DepartmentsDTO;

namespace ParicApplication.ParicServices.IParicServices
{
	public interface IDepartmentService
	{
		Task<IEnumerable<Department>> GetAllDepartments();
		Task<Department?> CreateDepartment(CreateDepartmentDTO createDepartmentDTO);
		Task<Department?> UpdateDepartment(int id, UpdateDepartmentDTO updateDepartmentDTO);
		Task<Department?> GetDepartmentById(int id);
		Task<Department?> DeleteDepartmentById(int id);
	}
}
