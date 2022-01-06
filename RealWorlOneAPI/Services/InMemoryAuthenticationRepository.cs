using RealWorlOneAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealWorlOneAPI.Services {
    public class InMemoryAuthenticationRepository : IAuthenticationRepository {

        //public static List<User> UserList = new List<User>() { new User { Username = "mali", Password = "demo" } };

        private readonly UsersAPIContext context;

        public static User currentUser;

        public InMemoryAuthenticationRepository(UsersAPIContext context) {
            this.context = context;
        }

        public string Login(User user) {
            if (currentUser != null) {
                return "Logout before login";
            }
            else if (context.Users.Any(x => x.Username == user.Username && x.Password == user.Password)) {
                currentUser = new User { Username = user.Username, Password = user.Password };
                return "Login Successful";
            }
            else return "Username or Password invalid";
        }

        public string Logout(User user) {
            if (currentUser != null) {
                currentUser = null;
                return "Logout successful";
            }
            else {
                return "Logout Error";
            }
        }
    }
}
