using BookMyShow.Controllers;
using BookMyShow.DAL;
using BookMyShow.Models;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BookMyShow.Provider
{
    public class OnAuthAppProvider : OAuthAuthorizationServerProvider
    {
        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            // Initialization.  
            string email = context.UserName;
            string passwordVal = context.Password;
            IDALLayer dllLayer = new DALLayer(); ;
            var loginController = new LoginController(dllLayer);
            Login login = new Login();
            login.Email = email;
            login.Password = passwordVal;
            var user = loginController.UserLogin(login);

            if (user == null || user.Status == "Invalid")
            {
                // Settings.  
                context.SetError("invalid_grant", "The email or password is incorrect.");
                return;
            } 
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, "email"));
            ClaimsIdentity oAuthClaimIdentity = new ClaimsIdentity(claims, OAuthDefaults.AuthenticationType);
            AuthenticationTicket ticket = new AuthenticationTicket(oAuthClaimIdentity, new AuthenticationProperties() { });
            context.Validated(ticket);
        }
        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            if (context.ClientId == null)
            { 
                context.Validated();
            }
            return Task.FromResult<object>(null);
        }
    }
}