using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GymSoft.Common;
using GymSoft.UserModule.Model;
using GymSoft.UserModule.Services;

namespace GymSoft.UserModule.ViewModels
{
    public class UserAuthenticationViewModel : PropertyChangedImplementation
    {
        public UserAuthenticationViewModel(IUserService userService)
        {
            this.userService = userService;
        }
        private string userName;
        private string password;
        private bool isAuthenticated;
        private User currentUser;

        public User CurrentUser
        {
            get { return currentUser; }
            set { currentUser = value; FirePropertyChanged("CurrentUser"); }
        }
        
        public bool IsAuthenticated
        {
            get { return isAuthenticated; }
            set { isAuthenticated = value; FirePropertyChanged("IsAuthenticated"); }
        }
        

        public string Password
        {
            get { return password; }
            set { password = value; FirePropertyChanged("Password"); }
        }
        

        public string UserName
        {
            get { return userName; }
            set { userName = value; FirePropertyChanged("UserName"); }
        }
        
        private IUserService userService;
    }
}
