using IdentityServer4.Models;

namespace IdentityServer
{
    public static class Config
    {
        public static IEnumerable<ApiScope> ApiScopes =>
          new[]
          {
        new ApiScope("meetupApi.read")
          };
        public static IEnumerable<ApiResource> ApiResources => new[]
        {
      new ApiResource("meetupApi")
      {
        Scopes = new List<string> { "meetupApi.read"},
        ApiSecrets = new List<Secret> {new Secret("ScopeSecret".Sha256())},
      }
    };

        public static IEnumerable<Client> Clients =>
          new[]
          {
        // m2m client credentials flow client
        new Client
        {
          ClientId = "test.client",
          ClientName = "Client Credentials Client",

          AllowedGrantTypes = GrantTypes.ClientCredentials,
          ClientSecrets = {new Secret("SuperSecretPassword".Sha256())},

          AllowedScopes = { "meetupApi.read" }
        },

        // interactive client using code flow + pkce
        new Client
        {
          ClientId = "interactive",
          ClientSecrets = {new Secret("SuperSecretPassword".Sha256())},

          AllowedGrantTypes = GrantTypes.Code,

          RedirectUris = {"https://localhost:5444/signin-oidc"},
          FrontChannelLogoutUri = "https://localhost:5444/signout-oidc",
          PostLogoutRedirectUris = {"https://localhost:5444/signout-callback-oidc"},

          AllowOfflineAccess = true,
          AllowedScopes = {"openid", "profile", "meetupApi.read"},
          RequirePkce = true,
          RequireConsent = true,
          AllowPlainTextPkce = false
        },
          };
    }
}
