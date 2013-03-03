using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ApplicationUtilitiesLibrary;
using DataAccessLayerLibrary;

namespace BusinessLogicLayerLibrary.UserBLL
{
    public class UserBLL : PropertyChangedImplementation
    {
        public UserBLL(User user )
        {
            MapDALPropertiesToBLLProperties(user);
        }
        public UserBLL(string firstName, string lastName, string userName, string password,
            string address1, string address2, string address3, string parish, string gender, 
            string phoneNumber1, string phoneNumber2, string phoneNumber3, string emailAddress, 
            string photoPath, string jobTitle, string jobDescription)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.userName = userName;
            this.password = password;
            this.phoneNumber1 = phoneNumber1;
            this.phoneNumber2 = phoneNumber2;
            this.phoneNumber3 = phoneNumber3;
            this.emailAddress = emailAddress;
            this.photoPath = photoPath;
            this.jobTitle = jobTitle;
            this.jobDescription = jobDescription;
        }

        private void MapDALPropertiesToBLLProperties(User user)
        {
            this.firstName = user.FirstName;
            this.lastName = user.LastName;
            this.userName = user.UserName;
            this.password = user.Password;
            this.address1 = user.Address1;
            this.address2 = user.Address2;
            this.address3 = user.Address3;
            this.phoneNumber1 = user.PhoneNumber1;
            this.phoneNumber2 = user.PhoneNumber2;
            this.emailAddress = user.EmailAddress;
            this.photoPath = user.PhotoPath;
            this.jobTitle = user.JobTitle;
            this.jobDescription = user.JobDescription;
        }

        string firstName;
        string lastName;
        string userName;
        string password;
        string address1;
        string address2;
        string address3;
        string parish;
        string gender;
        string phoneNumber1;
        string phoneNumber2;
        string phoneNumber3;
        string emailAddress;
        string photoPath;
        string jobTitle;
        string jobDescription;
        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string Parish { get; set; }
        public string Gender { get; set; }
        public string PhoneNumber1 { get; set; }
        public string PhoneNumber2 { get; set; }
        public string PhoneNumber3 { get; set; }
        public string EmailAddress { get; set; }
        public string PhotoPath { get; set; }
        public string JobTitle { get; set; }
        public string JobDescription { get; set; }
    }
}
