using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using paric_solution.Utils;
using ParicApplication.ParicServices.DTO.DepartmentsDTO;
using ParicApplication.ParicServices.IParicServices;
using System.Net;

namespace paric_solution.Controllers
{
	[ApiController]
	[Authorize]
	[Route("/api/department")]
	public class DepartmentController : ControllerBase
	{
		private readonly IMapper _mapper;
		private readonly IDepartmentService _departmentService;
        public DepartmentController(IMapper mapper, IDepartmentService departmentService)
        {
            _mapper = mapper;
			_departmentService = departmentService;
        }
		[HttpPost("create")]
        public async Task<IActionResult> CreateDepartment([FromBody] CreateDepartmentDTO createdepartment)
		{
			ErrorResponse errResponse = new();			
			if(!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			var result = await _departmentService.CreateDepartment(createdepartment);
			if(result == null)
			{
				errResponse.Status = HttpStatusCode.BadRequest;
				errResponse.Message = "Department Already Exists";
				return BadRequest(errResponse);
			}
			var successResponse = new
			{
				Message = "Department Created Successfully",
				StatusCode = HttpStatusCode.OK,
			};
			return CreatedAtAction(nameof(CreateDepartment), successResponse);								
		}
		[HttpPut]
		[Route("{id:int}")]
		public async Task<IActionResult> UpdateDepartment([FromRoute] int id, [FromBody] UpdateDepartmentDTO updateDepartmentDTO)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}			
			var department = await _departmentService.UpdateDepartment(id, updateDepartmentDTO);
			if (department == null) {
				return NotFound();
			}
			return Ok(new { status = HttpStatusCode.OK, message = "Department Updated Successfully", data = department});
		}
		[HttpGet]
		[Route("{id:int}")]
		public async Task<IActionResult> GetDepartmentById([FromRoute] int id)
		{		
			var departmentModel = await _departmentService.GetDepartmentById(id);
			if(departmentModel == null)
			{
				return NotFound(new { status = HttpStatusCode.NotFound, message = "Department Does not Exist" });
			}
			return Ok(new { status = HttpStatusCode.OK, message = "Success", data = departmentModel });
		}
		[HttpDelete]
		[Route("{id:int}")]
		public async Task<IActionResult> DeleteDepartment([FromRoute] int id)
		{
			var results = await _departmentService.DeleteDepartmentById(id);
			if (results == null)
			{
				return NotFound(new { status = HttpStatusCode.NotFound, message = " Department not Found" });
			}
			return NoContent();
		}
		[HttpGet]
		public async Task<IActionResult> GetAllDepartments()
		{
			var departments = await _departmentService.GetAllDepartments();
			return Ok(new { status = HttpStatusCode.OK, data = departments, message="Departments Retrived Successfully"});
		}
	}
}
