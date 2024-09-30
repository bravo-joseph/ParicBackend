using ParicApplication.ParicServices.IParicServices;
using ParicDomain.Entities;
using ParicDomain.IRepository;
using System.Net;
using ParicApplication.ParicServices.DTO.DepartmentsDTO;
using AutoMapper;

namespace ParicApplication.ParicServices
{
	internal class DepartmentService : IDepartmentService
	{
        private readonly IDepartmentRepository _departmentRepository;
		private readonly IMapper _mapper;
        public DepartmentService(IDepartmentRepository departmentRepository, IMapper mapper)
        {
            _departmentRepository = departmentRepository;
			_mapper = mapper;
        }
        public async Task<Department?> CreateDepartment(CreateDepartmentDTO createdepartment)
        {
			Department departmentModel = _mapper.Map<Department>(createdepartment);
			bool DoesExist = await _departmentRepository.DoesExistAsync(departmentModel);
			if (DoesExist)
				return null;
			var department = await _departmentRepository.CreateDepartmentAsync(departmentModel);			
			return department;
		}

		public async Task<Department?> DeleteDepartmentById(int id)
		{
			var results = await _departmentRepository.DeleteDepartment(id);
			if (results != null) {
				return results;
			}
			return null;
		}

		public async Task<IEnumerable<Department>> GetAllDepartments()
		{
			var departments = await _departmentRepository.GetAllDepartmentsAsync();
			return departments;
		}

		public async Task<Department?> GetDepartmentById(int id)
		{
			var departmentModel = await _departmentRepository.GetDepartmentById(id);
			if (departmentModel == null)
			{
				return null;
			}
			return departmentModel;
		}

		public async Task<Department?> UpdateDepartment(int id, UpdateDepartmentDTO updateDepartmentDTO)
		{
			var departmentModel = _mapper.Map<Department>(updateDepartmentDTO);
			var department = await _departmentRepository.UpdateDepartmentAsync(id, departmentModel);
			if (department != null) {
				return department;
			}
			return null;			
		}
	}
}
