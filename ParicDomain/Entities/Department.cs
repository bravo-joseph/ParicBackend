using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParicDomain.Entities
{
	public class Department
	{
        public int Id { get; set; }
        public string DepartmentName { get; set; }
		public string ManagerId { get; set; }

        [Range(1, 9999999999)]
        public decimal InitialBudget { get; set; } = 10000;
		[ForeignKey(nameof(ManagerId))]
		public SystemUser SystemUser { get; set; }
    }
}
