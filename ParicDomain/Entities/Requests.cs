using System.ComponentModel.DataAnnotations.Schema;

namespace ParicDomain.Entities
{
	public class Requests
	{
		public int Id { get; set; }
		public string Caption { get; set; } = string.Empty;
        public int RequestTypeId { get; set; }
		[ForeignKey(nameof(RequestTypeId))]
		public RequestsTypes RequestTypes { get; set; }
        public string RequesterId { get; set; } = string.Empty;
		[ForeignKey(nameof(RequesterId))]
        public SystemUser SystemUser { get; set; }
  //      public int DepartmentId { get; set; }
		//[ForeignKey(nameof(DepartmentId))]
  //      public Department Department { get; set; }
        public string Currency { get; set; } = string.Empty;
		public DateTime NeededDate { get; set; }
		public string Reason { get; set; } = string.Empty;
		public string Status { get; set; } = string.Empty;
	}
}
