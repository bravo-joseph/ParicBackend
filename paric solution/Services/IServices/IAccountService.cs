using ParicDomain.Entities;

namespace paric_solution.Services.IServices
{
    public interface IAccountService
    {
        string GenerateUserToken(SystemUser systemuser);
    }
}
