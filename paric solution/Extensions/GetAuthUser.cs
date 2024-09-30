using System.Security.Claims;

namespace ParicPresentation.Extensions
{
	public static class GetAuthUser
	{
		public static string? GetUserEmail(this ClaimsPrincipal user)
		{
			var AuthUser = user.FindFirstValue(ClaimTypes.Email);
			if (AuthUser != null) {
				return AuthUser;
			}
			return null;
		}
	}
}
