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
        public override async System.Threading.Tasks.Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async System.Threading.Tasks.Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var indentity = new ClaimsIdentity(context.Options.AuthenticationType);
            if (context.UserName == "admin" && context.Password == "admin")
            {
                indentity.AddClaim(new Claim(ClaimTypes.Role, "admin"));
                indentity.AddClaim(new Claim("username", "admin"));
                indentity.AddClaim(new Claim(ClaimTypes.Name, "KhanhLive"));
                var prop = new AuthenticationProperties(new Dictionary<string, string> { { "username1", "admin" }});
                var ticket = new AuthenticationTicket(indentity, prop);
                context.Validated(ticket);
            }
            else if (context.UserName == "user" && context.Password == "user")
            {
                indentity.AddClaim(new Claim(ClaimTypes.Role, "user"));
                indentity.AddClaim(new Claim("username", "user"));
                indentity.AddClaim(new Claim(ClaimTypes.Name, "Member"));
                var prop = new AuthenticationProperties(new Dictionary<string, string> { { "username1", "user" }});
                var ticket = new AuthenticationTicket(indentity, prop);
                context.Validated(ticket);
            }
            else
            {
                context.SetError("invalid_grant", "Provided Username and Password is incorrect");
                return;
            }
        }
    }
}
