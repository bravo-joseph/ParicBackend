using Microsoft.EntityFrameworkCore;
using ParicDomain.Entities;
using ParicInfrastructure.Persistence;
using ParicDomain.IRepository;

namespace ParicInfrastructure.Repository
{
	internal class DepartmentRepository : IDepartmentRepository
	{
		private readonly ParicDbContext _context;
        public DepartmentRepository(ParicDbContext context)
        {
			_context = context;            
        }
        public async Task<Department> CreateDepartmentAsync(Department department)
		{			
			await _context.AddAsync(department);
		    await _context.SaveChangesAsync();
			return department;					
		}

		public async Task<Department?> DeleteDepartment(int id)
		{
			var department = await _context.Departments.FirstOrDefaultAsync(d => d.Id == id);
			if( department == null)
			{
				return null;
			}
			_context.Departments.Remove(department);
			_context.SaveChanges();
			return department;
		}

		public async Task<bool> DoesExistAsync(Department department)
		{
			bool IsExists = await _context.Departments.AnyAsync(d => d.DepartmentName.ToLower().Equals(department.DepartmentName.ToLower()));
			if (IsExists)
			{
				return true;
			}
			return false;
		}

		public async Task<IEnumerable<Department>> GetAllDepartmentsAsync()
		{
			var departments = _context.Departments.AsQueryable();
			await departments.ToListAsync();
			return departments;
		}

		public async Task<Department?> GetDepartmentById(int id)
		{
			var results = await _context.Departments.FindAsync(id);
			if (results == null)
			{
				return null;
			}
			return results;			
		}
		public async Task<Department?> UpdateDepartmentAsync(int id, Department updateDepartmentDTO)
		{
			var departmentModel = await _context.Departments.FindAsync(id);
			if(departmentModel == null)
			{
				return null;
			}
			departmentModel.DepartmentName = updateDepartmentDTO.DepartmentName;
			departmentModel.ManagerId = updateDepartmentDTO.ManagerId;
			await _context.SaveChangesAsync();

			return departmentModel;
		}
	}
}
