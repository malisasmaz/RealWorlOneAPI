using RealWorlOneAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealWorlOneAPI.Services {
    public interface IUserRepository {
        User Add(User user);
        void Delete(User user);
        User GetById(string username);
        void Update(User user);
    }
}
