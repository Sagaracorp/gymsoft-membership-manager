using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using GymSoft.Common;

namespace GymSoft.UserModule.Model
{
    public class Role : Entity
    {
        #region Backing Fields
        private int id;
        private string name;
        private Users users;
        private Commands commands;
        #endregion


        #region Properties
        public Users Users
        {
            get { return users; }
            set { users = value; RaisePropertyChanged("Users"); }
        }


        public string Name
        {
            get { return name; }
            set { name = value; RaisePropertyChanged("Name"); }
        }

        public int Id
        {
            get { return id; }
            set { id = value; RaisePropertyChanged("Id"); }
        }
        public Commands Commands
        {
            get { return commands; }
            set { commands = value; RaisePropertyChanged("Commands"); }
        }
        #endregion
        
        
	
    }
    #region Collection of Role
    public class Roles : ObservableCollection<Role> { }
    #endregion
}
