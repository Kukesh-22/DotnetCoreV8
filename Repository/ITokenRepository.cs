using Microsoft.AspNetCore.Identity;

namespace Dotnet_v8.Repository
{
    public interface ITokenRepository
    {
        string CreateJWTToken(IdentityUser user, List<string> roles);
    }
}
