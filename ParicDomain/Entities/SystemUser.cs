using Microsoft.AspNetCore.Identity;

namespace ParicDomain.Entities
{
	public class SystemUser : IdentityUser
	{
		public Department? Department { get; set; }
        public BioData? BioData { get; set; }
        public FamilyInfo? FamilyInfo { get; set; }        

    }
}
