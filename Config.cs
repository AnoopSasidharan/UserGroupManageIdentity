// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace UserGroupManage.Identity
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResource("roles","Your roles(s)",new List<string>()
                {
                    JwtClaimTypes.Role
                })
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("usergroupmanageapi")
            };
        public static IEnumerable<ApiResource> Apis =>
           new ApiResource[]
           {
                new ApiResource("usergroupmanageapi", "user group manage API",new List<string>(){"role" })
                {
                    Scopes = new []{ "usergroupmanageapi" }
                }
           };
        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                new Client
                {
                    ClientName = "User Management Client",
                    ClientId = "usermgmt-client",
                    AllowedGrantTypes =  GrantTypes.Implicit,
                    RedirectUris = new List<string>
                    {
                        "http://localhost:4200/auth-callback",
                        "https://lemon-island-0b3fcc910.azurestaticapps.net/auth-callback",
                        "https://localhost:5007/auth-callback",
                        "https://usergroupmanageapp.azurewebsites.net/auth-callback"
                    },
                    RequirePkce = true,
                    AllowAccessTokensViaBrowser = true,
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "usergroupmanageapi",
                        "roles"
                    },
                    AllowedCorsOrigins = new List<string>
                    { 
                        "http://localhost:4200",
                        "https://lemon-island-0b3fcc910.azurestaticapps.net",
                        "https://localhost:5007",
                        "https://usergroupmanageapp.azurewebsites.net"
                    },
                    RequireClientSecret = false,
                    PostLogoutRedirectUris = new List<string> 
                    { 
                        "http://localhost:4200/signout-callback" ,
                        "http://localhost:4200",
                        "https://lemon-island-0b3fcc910.azurestaticapps.net/auth-callback",
                        "https://localhost:5007/",
                        "https://usergroupmanageapp.azurewebsites.net"
                    },
                    RequireConsent = false,
                    AccessTokenLifetime = 600
                }
            };
    }
}