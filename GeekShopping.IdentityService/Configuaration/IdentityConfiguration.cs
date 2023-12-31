﻿using Duende.IdentityServer;
using Duende.IdentityServer.Models;

namespace GeekShopping.IdentityService.Configuaration
{
    public static class IdentityConfiguration
    {
        public const string Admin = "admin";
        public const string Customer = "Customer";

        public static IEnumerable<IdentityResource> IdentityResources =>
            new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Email(),
                new IdentityResources.Profile()
                
            };
        public static IEnumerable<ApiScope> ApiScopes =>
        new List<ApiScope>
        {
            new ApiScope("geek_shoppping", "GeekShopping Server"),
            new ApiScope(name:"read","Read data"),
            new ApiScope(name: "write","Write data"),
            new ApiScope(name: "delete","Delete data"),
        };
        public static IEnumerable<Client> Clients =>
            new List<Client>
            {
                new Client
                {
                    ClientId="clinet",
                    ClientSecrets={new Secret("my_super_secret".Sha256())},
                    AllowedGrantTypes= GrantTypes.ClientCredentials,
                    AllowedScopes={"read","write","profile"}

                },           
                new Client
                {
                    ClientId="geek_shopping",
                    ClientSecrets={new Secret("my_super_secret".Sha256())},
                    AllowedGrantTypes= GrantTypes.Code,
                    RedirectUris={"http://localhost:24786/signin-oidc"},
                    PostLogoutRedirectUris={"http://localhost:24786/signout-callback-oidc"},
                    AllowedScopes=new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId, 
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        "geek_shopping"

                    }

                }
            };
    }
}
