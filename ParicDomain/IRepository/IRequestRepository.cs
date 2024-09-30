using ParicDomain.Entities;

namespace ParicDomain.IRepository
{
	public interface IRequestRepository
	{
		Task<IEnumerable<Requests>> GetAllRequests();
		Task<Requests> CreateRequests(Requests request);
		Task<IEnumerable<Requests>> GetMyRequests(string id);
		Task<Requests> UpdateRequestStatusAsync(int id, string status);
		Task<Requests?> DeleteRequestStatusAsync(int id);
	}
}
