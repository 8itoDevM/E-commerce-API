using Microsoft.AspNetCore.Identity;

namespace fakeshop.API.Repositories {
    public interface ITokenRepository {
        string CreateJWTToken(IdentityUser user, List<string> roles);
    }
}
