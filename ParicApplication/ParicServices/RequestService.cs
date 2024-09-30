using AutoMapper;
using Microsoft.AspNet.Identity;
using ParicApplication.ParicServices.DTO.RequestsDTO;
using ParicApplication.ParicServices.IParicServices;
using ParicDomain.Entities;
using ParicDomain.IRepository;
using System.Net;

namespace ParicApplication.ParicServices
{
	internal class RequestService : IRequestService
	{
		private readonly IRequestRepository _requestRepository;
		private readonly IMapper _mapper;
        public RequestService(IRequestRepository requestRepository, IMapper mapper)
        {
			_requestRepository = requestRepository;			            
			_mapper = mapper;
        }
		public async Task<IEnumerable<RequestDTO>> GetAllRequests()
		{
			var results = await _requestRepository.GetAllRequests();
			var updatedResults = results.Select(req => _mapper.Map<RequestDTO>(results));
			return updatedResults;
		}

		public async Task<IEnumerable<RequestDTO>> GetMyRequests(SystemUser? user)
		{
			if (user == null)
			{
				return null;
			}
			var results = await _requestRepository.GetMyRequests(user.Id);
			var updatedResults = results.Select(req => _mapper.Map<RequestDTO>(results));
			return updatedResults;
		}

		public async Task<RequestDTO?> RaiseRequests(SystemUser? user, RequestDTO createRequestDto)
		{					
			if (user == null)
			{
				return null;
			}
			var requestModel = _mapper.Map<Requests>(createRequestDto);
			requestModel.RequesterId = user.Id;
			await _requestRepository.CreateRequests(requestModel);
			return createRequestDto;
		}

		public async Task<bool> RevokeRequest(int id)
		{
			var result = await _requestRepository.DeleteRequestStatusAsync(id);
			if (result != null)
			{
				return true;
			}
			return false;

		}
		public async Task<RequestDTO?> UpdateRequestStatus(int id, string status)
		{
			if (status.ToLower() != "rejected" || status.ToLower() != "accepted")
			{
				return null;
			}
			var result = await _requestRepository.UpdateRequestStatusAsync(id, status);
			if (result == null)
			{
				return null;
			}
			return _mapper.Map<RequestDTO>(result);
		}
	}
}
