using GymSoft.DB.BusinessUnitsTable;

namespace GymSoft.AuthenticationModule.Services
{
    public interface IAuthenticateService
    {
        bool Authenticate(string username, string password, int businessUnitId);
    }
}
