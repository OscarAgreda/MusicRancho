using Duende.IdentityServer;
using Duende.IdentityServer.Models;
using IdentityModel;

namespace MusicRancho_Identity
{
    public static class SD
    {
        public const string Admin = "admin";
        public const string Employee = "employee";
        public const string Customer = "customer";

        // https://docs.duendesoftware.com/identityserver/v6/fundamentals/resources/identity/
        public static IEnumerable<IdentityResource> IdentityResources
            => new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Email(),
                new IdentityResources.Profile()
            };

        public static IEnumerable<ApiResource> ApiResources
            => new List<ApiResource>
            {
                new ApiResource("dataEventRecords" )
                {
                    ApiSecrets =
                    {
                        new Secret("dataEventRecordsSecret".Sha256())
                    },
                    UserClaims =
                    {
                        "role",
                        "dataEventRecords",
                        "dataEventRecords.admin",
                        "dataEventRecords.user"
                    }
                },
                new ApiResource("WebAPI" )
                {
                    UserClaims = { "role" }
                }
            };

        // https://docs.duendesoftware.com/identityserver/v6/apis/add_apis/
        public static IEnumerable<ApiScope> ApiScopes
            => new List<ApiScope>
            {
                new ApiScope(IdentityServerConstants.LocalApi.ScopeName),
                new ApiScope("music", "Music Server"),
                new ApiScope(name: "read", displayName: "Read your data."),
                new ApiScope(name: "write", displayName: "Write your data."),
                new ApiScope(name: "delete", displayName: "Delete your data.")
        };

        // https://docs.duendesoftware.com/identityserver/v6/fundamentals/clients/
        // https://docs.duendesoftware.com/identityserver/v6/apis/add_apis/
        // apps that are requesting tokens from identity server to access the api

        // blazor wasm 
        //https://docs.duendesoftware.com/identityserver/v6/quickstarts/7_blazor/
        //https://github.com/DuendeSoftware/Samples/tree/main/IdentityServer/v6/BFF/BlazorWasm

        public static IEnumerable<Client> Clients
            => new List<Client>
            {
                new Client
                {
                    ClientId = "service.client",
                    AllowOfflineAccess = true,
                    RequireClientSecret = false,
                    AlwaysIncludeUserClaimsInIdToken = true,
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    AllowedScopes =
                    {
                        "music",
                        "api1",
                        "api2.read_only",
                        IdentityServerConstants.LocalApi.ScopeName
                    }
                },
                new Client
                {
                    ClientId = "music",
                    RequireClientSecret = false,
                    AccessTokenLifetime = 900,
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    AllowedGrantTypes = GrantTypes.Code,
                    AlwaysIncludeUserClaimsInIdToken = true,
                    AllowedScopes =
                    {
                        "music",
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        JwtClaimTypes.Role
                    },
                    AllowOfflineAccess = true,
                    RedirectUris =
                    {
                        "https://localhost:7002/signin-oidc"
                    },
                    PostLogoutRedirectUris =
                    {
                        "https://localhost:7002/signout-callback-oidc"
                    }
                }
            };
    }
}
