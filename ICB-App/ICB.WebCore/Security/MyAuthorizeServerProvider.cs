using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ICB.WebCore.Security
{
    public class MyAuthorizeServerProvider : OAuthAuthorizationServerProvider
    {
        private readonly string _publicClientId;
        public MyAuthorizeServerProvider(string publicClientId)
        {
            if (publicClientId == null)
            {
                throw new ArgumentNullException("publicClientId");
            }

            _publicClientId = publicClientId;
        }
        public MyAuthorizeServerProvider()
        {
            _publicClientId = "publicKey";
        }
        public override System.Threading.Tasks.Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            // Resource owner password credentials does not provide a client ID.
            if (context.ClientId == null)
            {
                context.Validated();
            }

            return Task.FromResult<object>(null);
        }

        public override async System.Threading.Tasks.Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var indentity = new ClaimsIdentity(context.Options.AuthenticationType);
            if (context.UserName == "admin" && context.Password == "admin")
            {
                indentity.AddClaim(new Claim(ClaimTypes.Role, "admin"));
                indentity.AddClaim(new Claim("username", "admin"));
                indentity.AddClaim(new Claim(ClaimTypes.Name, "KhanhLive"));
                indentity.AddClaim(new Claim("guid", Guid.NewGuid().ToString()));
                var prop = new AuthenticationProperties(new Dictionary<string, string> { { "trtrtr", "admin" }});
                var ticket = new AuthenticationTicket(indentity, prop);
                context.Validated(ticket);
            }
            else if (context.UserName == "user" && context.Password == "user")
            {
                indentity.AddClaim(new Claim(ClaimTypes.Role, "user"));
                indentity.AddClaim(new Claim("guid", Guid.NewGuid().ToString()));
                indentity.AddClaim(new Claim("username", "user"));
                indentity.AddClaim(new Claim(ClaimTypes.Name, "Member"));
                var prop = new AuthenticationProperties(new Dictionary<string, string> { { "trtrtrtfgfg", "user" }});
                var ticket = new AuthenticationTicket(indentity, prop);
                context.Validated(ticket);
            }
            else
            {
                context.SetError("invalid_grant", "Provided Username and Password is incorrect");
                return;
            }
        }
        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach (KeyValuePair<string, string> property in context.Properties.Dictionary)
            {
                context.AdditionalResponseParameters.Add(property.Key, property.Value);
            }

            return Task.FromResult<object>(null);
        }
        

        public override Task ValidateClientRedirectUri(OAuthValidateClientRedirectUriContext context)
        {
            if (context.ClientId == _publicClientId)
            {
                Uri expectedRootUri = new Uri(context.Request.Uri, "/");

                if (expectedRootUri.AbsoluteUri == context.RedirectUri)
                {
                    context.Validated();
                }
            }

            return Task.FromResult<object>(null);
        }
    }
}
