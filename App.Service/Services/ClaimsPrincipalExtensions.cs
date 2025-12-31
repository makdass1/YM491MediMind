using System.Security.Claims;

namespace App.API.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static Guid GetKeycloakUserId(this ClaimsPrincipal user)
        {
            var sub = user.FindFirstValue("sub") ?? user.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(sub))
                throw new Exception("JWT içinde user id (sub) bulunamadı. Token doğru mu?");
            return Guid.Parse(sub);
        }

    }
}
