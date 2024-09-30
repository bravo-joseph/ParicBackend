using System.Net;

namespace paric_solution.Utils
{
	public class SuccessResponse
	{
		public HttpStatusCode StatusCode { get; set; }
		public string Message { get; set; }
		public Object? Data { get; set; }
		public IEnumerable<Object>? Results { get; set; }
		public string? Token { get; set; }
    }
}
