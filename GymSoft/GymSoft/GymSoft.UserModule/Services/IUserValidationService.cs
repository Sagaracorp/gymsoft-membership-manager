using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GymSoft.UserModule.Services
{
    public interface IUserValidationService
    {
        bool UserNameAlreadyTaken(string userName);

        bool EmailAddressInIncorrectForamt(string emailAddress);

        bool EmailAddressAlreadyTaken(string emailAddress);
    }
}
