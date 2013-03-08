using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using GymSoft.UserModule.ViewModels;

namespace GymSoft.UserModule.Model
{
    public class User : PropertyChangedImplementation
    {
        public int Id { get; set; }
        private string firstName;
        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            set
            {
                this.firstName = value;
                FirePropertyChanged("FirstName");
            }
        }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string PhotoPath { get; set; }
    }
    public class Users : ObservableCollection<User>
    {
    }
}
