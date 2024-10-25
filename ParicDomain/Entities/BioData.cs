using System.ComponentModel.DataAnnotations.Schema;

namespace ParicDomain.Entities
{
	public class BioData
	{
		public int Id { get; set; }
		public string UserId { get; set; }
		[ForeignKey("UserId")]
		public SystemUser User { get; set; }
		public string Resume { get; set; }
		public string NIN { get; set; }		
	
	}
}
