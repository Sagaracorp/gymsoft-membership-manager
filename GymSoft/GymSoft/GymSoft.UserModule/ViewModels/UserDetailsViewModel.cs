using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GymSoft.UserModule.Model;

namespace GymSoft.UserModule.ViewModels
{
    public class UserDetailsViewModel : PropertyChangedImplementation
    {
        public UserDetailsViewModel()
        {

        }
        private User currentUser;
        public string  FirstName 
        {
           get { return this.currentUser.FirstName; }
           set
           {
               this.currentUser.FirstName = value;
               FirePropertyChanged("FirstName");
           }
       }
        public User CurrentUser 
        {
            get { return this.currentUser; }
            set
            {
                this.currentUser = value;
                FirePropertyChanged("CurrentUser");
                this.FirstName = this.currentUser.FirstName;
                FirePropertyChanged("FirstName");
            }
        }
    }
}
