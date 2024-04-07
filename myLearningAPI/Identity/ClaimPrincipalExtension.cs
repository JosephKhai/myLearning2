using System.Security.Claims;

namespace myLearningAPI.Identity
{
    public static class ClaimPrincipalExtension
    {
        public static int GetUserId(this ClaimsPrincipal principal)
        {
            if(principal == null)
            {
                throw new ArgumentNullException(nameof(principal));

            }
            else
            {
                var stringId = principal.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                int.TryParse(stringId, out var userId);

                return userId;
            }
        }
    }
}
