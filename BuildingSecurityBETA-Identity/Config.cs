using IdentityServer4;
using IdentityServer4.Models;

namespace BuildingSecurityBETA_Identity
{
    public class Config
    {
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };
        }

        public static IEnumerable<ApiScope> GetApiScopes()
        {
             return new ApiScope[]
             {
                new ApiScope("BuildingAPI")
             };
        }

        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("BuildingAPI", "My Building API")
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "clientID-mvc",

                    ClientName = "BuldingMVC Client",

                    AllowedGrantTypes = GrantTypes.ClientCredentials,

                    ClientSecrets =
                    {
                        new Secret("myBUildingSecret".Sha256())
                    },

                    AllowedScopes = { "BuildingAPI" }
                },

                new Client
                {
                    ClientId = "clientID",

                    AllowedGrantTypes = GrantTypes.ClientCredentials,

                    ClientSecrets =
                    {
                        new Secret("myBUildingSecret".Sha256())
                    },

                    RedirectUris = { "https://localhost:/signin-oidc"},
                    PostLogoutRedirectUris = { "https://localhost:/signout-callback-oidc"},

                    AllowedScopes = {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "BuildingAPI"
                    },

                    AllowOfflineAccess = true,
                    RequirePkce = true,
                }
            };
        }
    }
}
