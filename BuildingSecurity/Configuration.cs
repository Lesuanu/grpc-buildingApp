using IdentityServer4.Models;
using IdentityServer4.Test;

namespace BuildingSecurity
{
    public static class Configuration
    {
        public static IEnumerable<Client> GetClients()
        {
            return new Client[]
            {
                new Client
                {
                    ClientId = "BuildingGrpcClient",

                    AllowedGrantTypes = GrantTypes.ClientCredentials,

                    ClientSecrets =
                    {
                        new Secret("secret".Sha256()),
                    },
                    AllowedScopes = { " " }
                }
            };
        } 

        //An API is a resource in your system that you want to protect. 
        public static IEnumerable<ApiScope> GetApiScopes()
        {
            return new ApiScope[]
            {
                new ApiScope(" ", "")
            };
        }

        public static IEnumerable<ApiResource> ApiResources =>
          new ApiResource[]
          {
          };

        public static IEnumerable<IdentityResource> IdentityResources =>
          new IdentityResource[]
          {
          };

        public static List<TestUser> TestUsers =>
            new List<TestUser>
            {
            };

    }
}
