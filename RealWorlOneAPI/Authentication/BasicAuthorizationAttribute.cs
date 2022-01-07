using Microsoft.AspNetCore.Authorization;

namespace RealWorlOneAPI.Services {
    public class BasicAuthorizationAttribute : AuthorizeAttribute {
        public BasicAuthorizationAttribute() {
            Policy = "BasicAuthentication";
        }
    }
}
