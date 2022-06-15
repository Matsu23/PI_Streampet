using StreamPet.Models;

namespace StreamPet.Helper
{
    public interface ISession
    {
        void CreateUserSession(LoginModel user);
        void RemoveUserSession();

        Usuario getSession();



    }
}
