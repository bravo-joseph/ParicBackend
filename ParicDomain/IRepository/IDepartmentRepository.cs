using ParicDomain.Entities;

namespace ParicDomain.IRepository
{
	public interface IDepartmentRepository
	{
		Task<Department> CreateDepartmentAsync(Department department);
		Task<IEnumerable<Department>> GetAllDepartmentsAsync();
		Task<Department?> UpdateDepartmentAsync(int id, Department Department);
		Task<Department?> GetDepartmentById(int id);
		Task<Department?> DeleteDepartment(int id);
		Task<bool> DoesExistAsync(Department department);
		
	}
}
