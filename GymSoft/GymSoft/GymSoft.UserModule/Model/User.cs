using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using GymSoft.UserModule.ViewModels;
using GymSoft.Common;
using GymSoft.UserModule.Services;

namespace GymSoft.UserModule.Model
{
    public class User : Entity
    {
        #region Backing Fields
        //private readonly int id;
        private int id; //This will need to be read only when the user service is online
        private string firstName;
        private string lastName;
        private string middleInitial;
        private string userName;
        private string password;
        private string address1;
        private string address2;
        private string address3;
        private string parish;
        private string gender;
        private string phoneNumber1;
        private string phoneNumber2;
        private string phoneNumber3;
        private string emailAddress;
        private string photoPath;
        private string jobTitle;
        private Roles roles;
        private Commands commands;
        
        #endregion

        #region Properties
        public int Id { get { return this.id; } set { this.id = value; RaisePropertyChanged("Id"); } }
        public string FirstName
        {
            get { return this.firstName; }
            set { this.firstName = value; RaisePropertyChanged("FirstName"); }
        }
        public string Password
        {
            get { return password; }
            set { password = value; RaisePropertyChanged("Password"); }
        }
        public string UserName
        {
            get { return userName; }
            set { userName = value; RaisePropertyChanged("UserName"); }
        }
        public string MiddleInitial
        {
            get { return middleInitial; }
            set { middleInitial = value; RaisePropertyChanged("MiddleInitial"); }
        }
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; RaisePropertyChanged("LastName"); }
        }        
        public string Address3
        {
            get { return address3; }
            set { address3 = value; RaisePropertyChanged("Address3"); }
        }
        public string Parish
        {
            get { return parish; }
            set { parish = value; RaisePropertyChanged("Parish"); }
        }
        public string Gender
        {
            get { return gender; }
            set { gender = value; RaisePropertyChanged("Gender"); }
        }
        public string PhoneNumber1
        {
            get { return phoneNumber1; }
            set { phoneNumber1 = value; RaisePropertyChanged("PhoneNumber1"); }
        }

        public string PhoneNumber2
        {
            get { return phoneNumber2; }
            set { phoneNumber2 = value; RaisePropertyChanged("PhoneNumber2"); }
        }
        public string PhoneNumber3
        {
            get { return phoneNumber3; }
            set { phoneNumber3 = value; RaisePropertyChanged("PhoneNumber3"); }
        }
        public string EmailAddress
        {
            get { return emailAddress; }
            set { emailAddress = value; RaisePropertyChanged("EmailAddress"); }
        }
        public string PhotoPath
        {
            get { return photoPath; }
            set { photoPath = value; RaisePropertyChanged("PhotoPath"); }
        }
        public string JobTitle
        {
            get { return jobTitle; }
            set { jobTitle = value; RaisePropertyChanged("JobTitle"); }
        }
        public string Address1
        {
            get { return address1; }
            set { address1 = value; RaisePropertyChanged("Address1"); }
        }

        public string Address2
        {
            get { return address2; }
            set { address2 = value; RaisePropertyChanged("Address2"); }
        }
        public Roles Roles
        {
            get { return roles; }
            set { roles = value; RaisePropertyChanged("Roles");  }
        }
        public Commands Commands
        {
            get { return commands; }
            set { commands = value; RaisePropertyChanged("Commands"); }
        }
        #endregion

        #region Validation Rules
        public override string this[string columnName]
        {   get
            {
                string errorMessage = String.Empty;
                switch (columnName)
                {
                    case "FirstName" :
                        if (String.IsNullOrEmpty(FirstName))
                        {
                            errorMessage = "First Name is required";
                            Error = "First Name is required";
                        }
                        break;
                    case "LastName":
                        if (String.IsNullOrEmpty(LastName))
                        {
                            errorMessage = "Last Name is required";
                            Error = "Last Name is required";
                        }
                        break;
                    case "UserName":
                        if (String.IsNullOrEmpty(UserName))
                        {
                            errorMessage = "User Name is required";
                            Error = "User Name is required";
                            break;
                        }
                        if (UserNameAlreadyTaken(UserName))
                        {
                            errorMessage = "User Name already taken";
                            Error = "User Name already taken";
                            break;
                        }
                        break;
                    case "Password":
                        if (String.IsNullOrEmpty(Password))
                        {
                            errorMessage = "Password is required";
                            Error = "Password is required";
                        }
                        break;
                    case "EmailAddress" :
                        if (String.IsNullOrEmpty(EmailAddress))
                        {
                            errorMessage = "Email Address is required";
                            Error = "Email Address is required";
                            break;
                        }
                        if (EmailAddressInIncorrectForamt(EmailAddress))
                        {
                            errorMessage = "Email Address is in an incorrect format";
                            Error = "Email Address is in an incorrect format";
                            break;
                        }
                        if (EmailAddressAlreadyTaken(EmailAddress))
                        {
                            errorMessage = "Email Address is already taken";
                            Error = "Email Address is already taken";
                            break;
                        }
                        break;
                    default:
                        break;
                }
                return errorMessage;
            }
        }
        #region Validation Methods
        private bool EmailAddressInIncorrectForamt(string emailAddress)
        {
            IUserValidationService validationService = new UserValidationService();
            return validationService.EmailAddressInIncorrectForamt(emailAddress);
        }

        private bool EmailAddressAlreadyTaken(string emailAddress)
        {
            IUserValidationService validationService = new UserValidationService();
            return validationService.EmailAddressAlreadyTaken(emailAddress);
        }

        private bool UserNameAlreadyTaken(string userName)
        {
            IUserValidationService validationService = new UserValidationService();
            return validationService.UserNameAlreadyTaken(userName);
        }        
        #endregion
        
        #endregion
    }

    #region Collection of Users
    public class Users : ObservableCollection<User>
    {}
    #endregion
    
}
