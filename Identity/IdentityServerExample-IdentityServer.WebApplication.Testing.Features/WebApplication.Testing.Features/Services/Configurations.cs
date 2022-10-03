using IdentityServer4;
using IdentityServer4.Models;

namespace WebApplication1.Testing.Features.Services
{
    public sealed class Configurations
    {
        public static IEnumerable<ApiResource> Apis =>
            new List<ApiResource>
            {
                new ApiResource("api_1", "My_API_Client")
            };

        public static IEnumerable<Client> Clients =>
            new List<Client>
            {
                new Client {
                    AccessTokenLifetime = 18000,
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    ClientId = "ropc_client",
                    ClientSecrets = { new Secret("secret_1".Sha256()) },
                    AllowedScopes = {
                        IdentityServerConstants.StandardScopes.OpenId
                    }
                }
            };

        public static IEnumerable<IdentityResource> IdentityResources() =>
            new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
            };
    }
}
