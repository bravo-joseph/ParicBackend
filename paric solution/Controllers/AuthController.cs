using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ParicDomain.Entities;
using paric_solution.Services.IServices;
using paric_solution.Utils;
using System.Net;
using ParicApplication.ParicServices.DTO.useraccount;

namespace paric_solution.Controllers
{
	[Route("api/auth")]
	[ApiController]
	public class AuthController: ControllerBase
	{
		private readonly UserManager<SystemUser> _userManager;

		private readonly IAccountService _accountService;

		private readonly SignInManager<SystemUser> _signInManager;		
		public AuthController(UserManager<SystemUser> userManager, SignInManager<SystemUser> signInManager, IAccountService accountService)
        {
			_userManager = userManager;
			_signInManager = signInManager;
			_accountService = accountService;			
        }
        [HttpPost("register")]		
		public async Task<IActionResult> RegisterAccount([FromBody] RegisterDTO registerrequestdto)
		{
			SuccessResponse response = new();
			
				if (!ModelState.IsValid)
				{
					return BadRequest("Model state is bad");
				}
				var User = new SystemUser()
				{
					UserName = registerrequestdto.UserName,
					Email = registerrequestdto.Email,
				};
				var createdUser = await _userManager.CreateAsync(User, registerrequestdto.Password);
				if (createdUser.Succeeded)
				{
					var roleResult = await _userManager.AddToRoleAsync(User, "Staff");
					if(roleResult.Succeeded)
					{
						response.StatusCode = HttpStatusCode.OK;
						response.Message = "user added successfully";
						return Ok("done");
					}
					else
					{
						return StatusCode(500, "Role Issue");
					}
				}
				else
				{
					return StatusCode(500, "User Issue");
				}										
		}
		[HttpPost("login")]
		public async Task<IActionResult> Login([FromBody] LoginDTO loginrequestDTO)
		{			
			ErrorResponse errorresponse = new();

			if (!ModelState.IsValid)
			{
				errorresponse.Status = HttpStatusCode.BadRequest;
				errorresponse.Message = "Invalid Request";				
				return BadRequest(errorresponse);
			}			
			var user = _userManager.Users.FirstOrDefault(user => user.Email == loginrequestDTO.Email);
			if(user == null)
			{
				errorresponse.Status = HttpStatusCode.NotFound;
				errorresponse.Message = "Invalid Username or Password";
				return NotFound(errorresponse);
			}
			else
			{
				var passcodeIsTrue = await _signInManager.CheckPasswordSignInAsync(user, loginrequestDTO.Password, false);
				if (passcodeIsTrue.Succeeded)
				{					
					var Token = _accountService.GenerateUserToken(user);
					return Ok(new { status = HttpStatusCode.OK, message = "User Loggged In Successfully", token = Token});
				}
				else
				{					
					return NotFound(errorresponse);
				}
			};
		}
	}
}
