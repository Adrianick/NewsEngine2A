using System.Security.Claims;
using System.Security.Principal;

namespace NewsEngine2A.Identity
{
    public static class IdentityExtensions
    {
        public static string GetCompanyId(this IIdentity identity)
        {
            Claim claim = ((ClaimsIdentity)identity).FindFirst(("CompanyId"));
            return (claim != null) ? claim.Value : string.Empty;
        }
    }
}