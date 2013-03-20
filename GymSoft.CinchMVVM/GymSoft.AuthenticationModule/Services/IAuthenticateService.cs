using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GymSoft.AuthenticationModule.Services
{
    public interface IAuthenticateService
    {
        bool Authenticate(string username, string password);
    }
}
