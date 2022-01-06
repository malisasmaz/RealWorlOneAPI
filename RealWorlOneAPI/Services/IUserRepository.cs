using RealWorlOneAPI.Models;

namespace RealWorlOneAPI.Services {
    public interface IUserRepository {
        User Add(User user);
        void Delete(User user);
        User GetById(string username);
        void Update(User user);
    }
}
