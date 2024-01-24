using System.Security.Claims;

namespace Vspt.Box.Security;

internal static class SupportedClaimTypes
{
    public const string UserId = ClaimTypes.NameIdentifier;

    public const string TenantId = "tenant_id";

    public const string Permission = "permission";
}
