using System.ComponentModel.Composition;
using GymSoft.DB.BusinessUnitsTable;
using MEFedMVVM.ViewModelLocator;

namespace GymSoft.AuthenticationModule.Services
{
    [PartCreationPolicy(CreationPolicy.NonShared)]
    [ExportService(ServiceType.Runtime, typeof(IAuthenticateService))]
    public class AuthenticationService : IAuthenticateService
    {
        public bool Authenticate(string username, string password, string businessUnitName)
        {
            //Should do the database lookup right here..but for now..lets just return true..for test/test
            if (username.Equals("test") && password.Equals("test") && businessUnitName.Equals("Beast-n-Barbells Fitness Centre"))
                return true;
            else
                return false;
        }
    }
}
