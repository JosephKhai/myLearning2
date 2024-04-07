using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace myLearning.Common.WebApi.Identity
{
    public static class ClaimPrincipalExtension
    {
        public static int GetUserId(this ClaimsPrincipal principal)
        {
            if (principal == null) {
                throw new ArgumentNullException(nameof(principal));
            }

            var stringId = principal.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            int.TryParse(stringId, out var currentUserId);
            return currentUserId;
        }
    }
}
