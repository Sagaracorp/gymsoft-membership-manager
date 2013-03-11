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
            var user = userService.FindAll().SingleOrDefault(u => u.UserName.ToLower() == userName);
            return user != null;

        }
        public bool EmailAddressInIncorrectForamt(string emailAddress)
        {
            //Use mail address LOL it pays to Google~~
            // Return emailAddress if strIn is in valid e-mail format. 
           return Regex.IsMatch(emailAddress,
                      @"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                      @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$",
                      RegexOptions.IgnoreCase);                   

        }
        public bool EmailAddressAlreadyTaken(string emailAddress)
        {
            IUserService userService = new UserMockService(); // Mocking example
            var user = userService.FindAll().SingleOrDefault(u => u.EmailAddress.ToLower() == emailAddress);
            return user != null;
        }
    }
}
