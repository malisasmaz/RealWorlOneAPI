using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealWorlOneAPI.Services {
    public class BasicAuthorizationAttribute : AuthorizeAttribute {
        public BasicAuthorizationAttribute() {
            Policy = "BasicAuthentication";
        }
    }
}
