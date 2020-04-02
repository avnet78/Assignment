using UserSignUp.Domain;

namespace UserSignUp.BusinessServices.Repository.Interface
{
    public interface IUserRepository
    {
        User AddUser(User newUser);
        User UpdateActivation(int id, string code);
        bool UpdateActivation(string code);
        User GetUserInfo(int id);
        bool UserExists(string email);
        User Login(string username, string password);
    }
}
