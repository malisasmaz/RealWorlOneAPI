using RealWorlOneAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealWorlOneAPI.Services {
    public interface IAuthenticationRepository {
        string Login(User user);
        string Logout(User user);
    }
}
