using GymSoft.DB.UsersTable;

namespace GymSoft.AuthenticationModule.Services
{
    public interface IAuthenticateService
    {
        bool Authenticate(string username, string password, int businessUnitId);
    }
}
