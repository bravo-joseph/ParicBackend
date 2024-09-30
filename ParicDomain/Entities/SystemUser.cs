using Microsoft.AspNetCore.Identity;

namespace ParicDomain.Entities
{
	public class SystemUser : IdentityUser
	{
        public int? DepartmentId { get; set; }
		public int? BiodataId { get; set; }
		public int? FamilyInfoId { get; set; }
		public Department? Department { get; set; }
        public BioData? BioData { get; set; }
        public FamilyInfo? FamilyInfo { get; set; }
        

    }
}
