using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ParicApplication.ParicServices.DTO.FamilyInformationDTO;

namespace ParicPresentation.Controllers
{
	[ApiController]
	[Authorize]
	[Route("api/familyinfo")]
	public class FamilyInformationController : ControllerBase
	{
		[HttpPost]
		public async Task<IActionResult> AddFamilyInformation([FromBody] AddFamilyInformationDTO addFamilydot)
		{
			return Ok();
		}
		[HttpGet]
		[Route("{id}")]
		public async Task<IActionResult> UpdateFamilyInformation([FromRoute] int id , [FromBody] AddFamilyInformationDTO addFamilydot)
		{
			return Ok();
		}
	}
}
