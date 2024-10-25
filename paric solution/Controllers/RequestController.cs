using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ParicPresentation.Extensions;
using ParicApplication.ParicServices.DTO.RequestsDTO;
using ParicApplication.ParicServices.IParicServices;
using ParicDomain.Entities;
using System.Net;

namespace paric_solution.Controllers
{
	[Authorize]
	[ApiController]
	[Route("/api/requests")]
	public class RequestController : ControllerBase
	{		
		private readonly IRequestService _requestService;

		private readonly UserManager<SystemUser> _userManager;
		
		private readonly IMapper _mapper;
        public RequestController(IRequestService requestService, IMapper mapper, UserManager<SystemUser> userManger)
        {
            _requestService = requestService;
			_userManager = userManger;
			_mapper = mapper;
        }
		[HttpGet]
		public async Task<IActionResult> GetAllRequests()
		{			
			var requests = await _requestService.GetAllRequests();
			return Ok(new {status = HttpStatusCode.OK, message = "Requests Gotten Successfully", data = requests });
		}
		[HttpPost("raise")]
		public async Task<IActionResult> RaiseRequest([FromBody] RequestDTO requestDTO)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			var userEmail = User.GetUserEmail();
			var user = await _userManager.FindByEmailAsync(userEmail ?? "");
			var result = await _requestService.RaiseRequests(user, requestDTO);
			if (result == null)
			{
				return NotFound(new { message = "User Not Found", status = HttpStatusCode.NotFound });
			}					
			return Ok(new {message = "Request Created Successfully", status = HttpStatusCode.Accepted, data=requestDTO});			
		}
		[HttpGet]
		[Route("{userId}")]
		public async Task<IActionResult> GetMyRequest([FromRoute] string userId)
		{
			var userEmail = User.GetUserEmail();
			var user = await _userManager.FindByEmailAsync(userEmail ?? "josephgabriel018@gmail.com");
			var result = await _requestService.GetMyRequests(user);
			if (result == null) {
				NotFound(new { message = "User Not Found", status = HttpStatusCode.NotFound });
			}			
			return Ok(result);
		}
		[HttpPatch]
		[Route("{id:int}")]
		[Route("{status}")]
		public async Task<IActionResult> UpdateRequestStatus([FromRoute] int id, [FromRoute] string status)
		{
			var result = await _requestService.UpdateRequestStatus(id,status);
			if (result == null) {
				BadRequest();
			}
			return Ok( new { status = HttpStatusCode.OK, message = "status updated", data = result });
		}
		[HttpDelete]
		[Route("{id}")]
		public async Task<IActionResult> RevokeRequest([FromRoute] int id)
		{
			var result = await _requestService.RevokeRequest(id);
			if (!result)
			{
				return NotFound(new { status = HttpStatusCode.NotFound, message = "Unable to Revoke Request" });
			}
			return Ok(new {status = HttpStatusCode.OK , message = "Requests Revoked"});			
		}
	}
}
