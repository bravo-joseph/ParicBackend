using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace paric_solution.Controllers
{
	[Authorize]
	[ApiController]
	[Route("/api/biodata")]
	public class EmployeeBioDataController :  ControllerBase
	{
        public EmployeeBioDataController()
        {
            
        }
        //[HttpPost]
  //      public async Task<IActionResult> AddEmployeeBioData([FromBody] AddBiodataDTO biodata)
  //      {
  //          return Ok();
  //      }
		//[HttpPut]
		//public async Task<IActionResult> UpdateBiodataDTO([FromBody] AddBiodataDTO biodata)
		//{
		//	return Ok();
		//}
	}
}
