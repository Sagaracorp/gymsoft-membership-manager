using GymSoft.DB.UsersTable;

namespace GymSoft.AuthenticationModule.Services
{
    public interface IAuthenticateService
    {
        User CurrentUser { get; set; }     
        bool Authenticate(string username, string password, int businessUnitId);
    }
}
