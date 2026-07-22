using System.Security.Claims;

namespace server.Common
{
    public static class UserClaimsExtensions
    {
        public static int GetUserId(this ClaimsPrincipal user)
        {
            var value = user.FindFirst(
                ClaimTypes.NameIdentifier)?.Value;

            return int.Parse(value!);
        }

        public static string GetRole(this ClaimsPrincipal user)
        {
            return user.FindFirst(
                ClaimTypes.Role)?.Value ?? "";
        }
    }
}