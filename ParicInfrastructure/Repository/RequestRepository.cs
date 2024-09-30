using Microsoft.EntityFrameworkCore;
using ParicDomain.IRepository;
using ParicDomain.Entities;
using ParicInfrastructure.Persistence;

namespace ParicInfrastructure.Repository;
internal class RequestRepository : IRequestRepository
{
	private readonly ParicDbContext _context;
        public RequestRepository(ParicDbContext context)
        {
		_context = context;            
        }
	public async Task<Requests> CreateRequests(Requests request)
	{
		var requests = await _context.Requests.AddAsync(request);
		await _context.SaveChangesAsync();
		return request;
	}

	public async Task<Requests?> DeleteRequestStatusAsync(int id)
	{
		var request = await _context.Requests.FirstOrDefaultAsync(r => r.Id.Equals(id));
		if (request == null) {
			return null;
		}
		_context.Requests.Remove(request);
		await _context.SaveChangesAsync();
		return request;						
	}
	public async Task<IEnumerable<Requests>> GetAllRequests()
	{
		var requests = _context.Requests.Include(user => user.SystemUser).Include(r => r.RequestTypes).AsQueryable();			
		return await requests.ToListAsync();
	}
	public async Task<IEnumerable<Requests>> GetMyRequests(string id)
	{
		var requests = _context.Requests.Include(user => user.SystemUser).Include(r => r.RequestTypes).AsQueryable();
		var MyRequests = requests.Where(r => r.RequesterId.Equals(id)).AsQueryable();
		return await MyRequests.ToListAsync();
	}

	public async Task<Requests> UpdateRequestStatusAsync(int id, string status)
	{
		var request = await _context.Requests.FindAsync(id);
		if (request == null)
		{
			return null;
		}
		request.Status = status;
		await _context.SaveChangesAsync();
		return request;
	}
}
