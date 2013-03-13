using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using GymSoft.Common;
using GymSoft.UserModule.Events;
using GymSoft.UserModule.Model;
using GymSoft.UserModule.Services;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Events;

namespace GymSoft.UserModule.ViewModels
{
    public class UserAuthenticationViewModel : Entity
    {
        public UserAuthenticationViewModel(IUserService userService, IEventAggregator eventAggregator)
        {
            this.userService = userService;
            this.eventAggregator = eventAggregator;
            this.userName = "";
            this.password = "";
            //Error = "";
            //Commands
            this.LoginCommand = new DelegateCommand(OnLoginExecuted, CanLoginExecute);
            this.CancelCommand = new DelegateCommand(OnCancelExecuted);
        }

        private IEventAggregator eventAggregator;
        private string userName;
        private string password;
        private bool isAuthenticated;
        private IUserService userService;
        private User currentUser;
        public ICommand LoginCommand { get; set; }
        public ICommand CancelCommand { get; set; }
        void OnLoginExecuted()
        {
            this.currentUser = userService.Authenticate(UserName, Password);
            if (currentUser != null)
            {
                this.isAuthenticated = true;
                RaisePropertyChanged("CurrentUser");
                Error = "Login Success";
                RaisePropertyChanged("Error");
                //send login event with eaggregator possibly with the current user
                this.eventAggregator.GetEvent<UserLoginEvent>().Publish(currentUser);
            }
            else
            {
                isAuthenticated = false;
                Error = "Invalid username/password combo";
                RaisePropertyChanged("Error");
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
            //RaisePropertyChanged("Error");
        }

        public User CurrentUser
        {
            get { return currentUser; }
            set { currentUser = value; RaisePropertyChanged("CurrentUser"); }
        }
        
        public bool IsAuthenticated
        {
            get { return isAuthenticated; }
            set { isAuthenticated = value; RaisePropertyChanged("IsAuthenticated"); }
        }
        

        public string Password
        {
            get { return password; }
            set 
            { 
                password = value;
                RaisePropertyChanged("Password");
                RaisePropertyChanged("Error");
                ((DelegateCommand)this.LoginCommand).RaiseCanExecuteChanged(); 
            }
        }
        

        public string UserName
        {
            get { return userName; }
            set 
            { 
                userName = value;
                RaisePropertyChanged("UserName");
                RaisePropertyChanged("Error");
                ((DelegateCommand)this.LoginCommand).RaiseCanExecuteChanged();
            }
        }
        #region IDataErrorInfo
        public override string this[string columnName]
        {
            get
            {
                Error = String.Empty;
                
                if (columnName == "Password")
                {
                    if (String.IsNullOrEmpty(Password))
                    {
                        Error = "Password cannot be empty";
                        return "Password cannot be empty";
                    }
                }
                if (columnName == "UserName")
                {
                    if (String.IsNullOrEmpty(UserName))
                    {
                        Error = "User Name cannot be empty";
                        return "User Name cannot be empty";
                    }
                }
                return "";
            }
        }
        #endregion

        
    }
}
