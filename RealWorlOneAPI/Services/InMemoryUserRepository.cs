using RealWorlOneAPI.Models;
using System.Linq;

namespace RealWorlOneAPI.Services {
    public class InMemoryUserRepository : IUserRepository {
        private readonly UsersAPIContext context;

        public InMemoryUserRepository(UsersAPIContext context) {
            this.context = context;
        }

        public User Add(User user) {
            var addedUser = context.Add(user);
            context.SaveChanges();
            user.Username = addedUser.Entity.Username;

            return user;
        }


        public void Delete(User user) {
            context.Remove(user);
            context.SaveChanges();
        }

        public User GetById(string username) {
            return context.Users.SingleOrDefault(x => x.Username == username);
        }

        public void Update(User user) {
            var UserToUpdate = GetById(user.Username);
            UserToUpdate.Username = user.Username;
            UserToUpdate.Password = user.Password;
            context.Update(UserToUpdate);
            context.SaveChanges();
        }
    }
}
