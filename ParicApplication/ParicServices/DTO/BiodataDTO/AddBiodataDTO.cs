using Microsoft.AspNetCore.Http;

namespace ParicApplication.ParicServices.DTO.BioDataDTO
{
	public class AddBiodataDTO
	{        
		public IFormFile Resume { get; set; }
		public IFormFile NIN { get; set; }
		public IEnumerable<IFormFile> Certificates { get; set; }
	}
}
