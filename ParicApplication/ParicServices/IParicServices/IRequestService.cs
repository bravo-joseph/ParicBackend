using ParicApplication.ParicServices.DTO.RequestsDTO;
using ParicDomain.Entities;

namespace ParicApplication.ParicServices.IParicServices
{
	public interface IRequestService 
	{
		Task<IEnumerable<RequestDTO>> GetAllRequests();
		Task<RequestDTO?> RaiseRequests(SystemUser? user, RequestDTO createRequestDto);
		Task<IEnumerable<RequestDTO>> GetMyRequests(SystemUser? user);
		Task<RequestDTO?> UpdateRequestStatus(int id, string status);
		Task<bool> RevokeRequest(int id);
	}
}
