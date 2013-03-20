using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using MEFedMVVM.ViewModelLocator;

namespace GymSoft.AuthenticationModule.Services
{
    [PartCreationPolicy(CreationPolicy.NonShared)]
    [ExportService(ServiceType.Runtime, typeof(IAuthenticateService))]
    public class AuthenticationService : IAuthenticateService
    {
        public bool Authenticate(string username, string password)
        {
            //Should do the database lookup right here..but for now..lets just return true..for test/test
            if (username.Equals("test") && password.Equals("test"))
                return true;
            else
                return false;
        }
    }
}
