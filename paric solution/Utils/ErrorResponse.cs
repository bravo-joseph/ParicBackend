using System.Net;

namespace paric_solution.Utils
{
	public class ErrorResponse
	{
        public HttpStatusCode Status { get; set; }
		public string Message { get; set; } = string.Empty;
    }
}
