using System.ComponentModel.Composition;
using MEFedMVVM.ViewModelLocator;

namespace GymSoft.AuthenticationModule.Services
{
    [PartCreationPolicy(CreationPolicy.NonShared)]
    [ExportService(ServiceType.Runtime, typeof(IAuthenticateService))]
    public class AuthenticationService : IAuthenticateService
    {
        public bool Authenticate(string username, string password, int businessUnitId)
        {
            //Should do the database lookup right here..but for now..lets just return true..for test/test
            if (username.Equals("test") && password.Equals("test") && businessUnitId == 1)
                return true;
            else
                return false;
        }
    }
}
