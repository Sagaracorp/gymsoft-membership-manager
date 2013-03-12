using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using GymSoft.Common;
using GymSoft.UserModule.Model;
using GymSoft.UserModule.Services;
using Microsoft.Practices.Prism.Commands;

namespace GymSoft.UserModule.ViewModels
{
    public class UserAuthenticationViewModel : PropertyChangedImplementation
    {
        public UserAuthenticationViewModel(IUserService userService)
        {
            this.userService = userService;
            //this.userName = "";
           // this.password = "";
            
            //Commands
            this.LoginCommand = new DelegateCommand(OnLoginExecuted, CanLoginExecute);
            this.CancelCommand = new DelegateCommand(OnCancelExecuted);
        }
        private string userName;
        private string password;
        private bool isAuthenticated;
        private User currentUser;
        public ICommand LoginCommand { get; set; }
        public ICommand CancelCommand { get; set; }
        void OnLoginExecuted()
        {
            this.currentUser = userService.Authenticate(UserName, Password);
            if (currentUser != null)
            {
                this.isAuthenticated = true;
                FirePropertyChanged("CurrentUser");
                //send login event with eaggregator possibly
            }
            else
            {
                isAuthenticated = false;
                //Place some error condtions
            }
        }
        bool CanLoginExecute()
        {
            return UserName != "" && Password != "";
            
        }

        void OnCancelExecuted()
        {
            UserName = string.Empty;
            Password = string.Empty;
        }

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
