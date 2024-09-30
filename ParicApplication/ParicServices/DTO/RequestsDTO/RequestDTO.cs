namespace ParicApplication.ParicServices.DTO.RequestsDTO
{
	public class RequestDTO
	{
		public string Caption { get; set; }		
		public int RequestTypeId { get; set; }					
		public string Currency { get; set; } = string.Empty;
		public DateTime NeededDate { get; set; }
		public string Reason { get; set; } = string.Empty;
	}
}