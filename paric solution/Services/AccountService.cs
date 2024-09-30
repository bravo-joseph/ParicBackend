using Microsoft.IdentityModel.Tokens;
//using paric_solution.Models;
using ParicDomain.Entities;
using paric_solution.Services.IServices;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace paric_solution.Services
{
	public class AccountService : IAccountService
	{
		private readonly SymmetricSecurityKey _secretKey;
		private readonly IConfiguration _config;
        public AccountService(IConfiguration config)
        {
			_config = config;
			_secretKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_config["JWT:SigningKey"]));
        }
		public string GenerateUserToken(SystemUser systemuser)
		{
			var claims = new Claim[]
			{
				new Claim(ClaimTypes.Email, systemuser.Email),
				new Claim(ClaimTypes.GivenName, systemuser.UserName),
			};
			var credentials = new SigningCredentials(_secretKey, SecurityAlgorithms.HmacSha512Signature);
			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(claims),
				Expires = DateTime.Now.AddDays(30),
				SigningCredentials = credentials,
				Issuer = _config["JWT:Issuer"],
				Audience = _config["JWT:Audience"]
			};
			var tokenHandler = new JwtSecurityTokenHandler();
			var token = tokenHandler.CreateToken(tokenDescriptor);
			return tokenHandler.WriteToken(token);
		}
	}
}
