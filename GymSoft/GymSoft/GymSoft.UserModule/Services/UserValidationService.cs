using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace GymSoft.UserModule.Services
{
    public class UserValidationService : IUserValidationService
    {
        public bool UserNameAlreadyTaken(string userName)
        {
            IUserService userService = new UserMockService(); // Mocking example
            var user = userService.FindAll().Where(u => u.UserName.ToLower() == userName.ToLower());
            return user != null;

        }
        public bool EmailAddressInIncorrectForamt(string emailAddress)
        {
            Regex re = new Regex(@"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*"
                                 + "@"
                                 + @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$",
                                 RegexOptions.IgnoreCase);
            return !re.IsMatch(emailAddress);   
        }
        public bool EmailAddressAlreadyTaken(string emailAddress)
        {
            IUserService userService = new UserMockService(); // Mocking example
            var user = userService.FindAll().Where(u => u.EmailAddress.ToLower() == emailAddress);
            return user != null;
        }
    }
}
