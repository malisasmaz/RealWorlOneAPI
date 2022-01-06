using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RealWorlOneAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RealWorlOneAPI.Services {
    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions> {
        private readonly UsersAPIContext context;
        public BasicAuthenticationHandler(
            IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock,
            UsersAPIContext context
            )
    : base(options, logger, encoder, clock) {
            this.context = context;

        }

        protected override Task<AuthenticateResult> HandleAuthenticateAsync() {
            Response.Headers.Add("WWW-Authenticate", "Basic");

            if (!Request.Headers.ContainsKey("Authorization")) {
                return Task.FromResult(AuthenticateResult.Fail("Authorization header missing."));
            }

            // Get authorization key
            var authorizationHeader = Request.Headers["Authorization"].ToString();
            var authHeaderRegex = new Regex(@"Basic (.*)");

            if (!authHeaderRegex.IsMatch(authorizationHeader)) {
                return Task.FromResult(AuthenticateResult.Fail("Authorization code not formatted properly."));
            }

            var authBase64 = Encoding.UTF8.GetString(Convert.FromBase64String(authHeaderRegex.Replace(authorizationHeader, "$1")));
            var authSplit = authBase64.Split(Convert.ToChar(":"), 2);
            var authUsername = authSplit[0];
            var authPassword = authSplit.Length > 1 ? authSplit[1] : throw new Exception("Unable to get password");

            if (!IsAuthorizedUser(authUsername, authPassword)) {
                return Task.FromResult(AuthenticateResult.Fail("The username or password is not correct."));
            }

            var authenticatedUser = new AuthenticatedUser("BasicAuthentication", true, "roundthecode");
            var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(authenticatedUser));

            return Task.FromResult(AuthenticateResult.Success(new AuthenticationTicket(claimsPrincipal, Scheme.Name)));
        }

        public bool IsAuthorizedUser(string username, string password) {
            // In this method we can handle our database logic here...

            //TODO: default user added 
            if (!context.Users.Any(x => x.Username == "mali")) {
                context.Users.Add(new User { Username = "mali", Password = "demo" });
                context.SaveChanges();
            }

            return context.Users.Any(x => x.Username == username && x.Password == password);

        }
    }
}

