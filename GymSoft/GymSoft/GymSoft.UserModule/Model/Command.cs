using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GymSoft.Common;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace GymSoft.UserModule.Model
{
    public class Command : Entity
    {
        #region Backing Fields
        private string name;
        private int id;
        private Roles roles;
        #endregion

        #region Properties
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
        public Roles Roles
        {
            get { return roles; }
            set { roles = value; RaisePropertyChanged("Roles"); }
        }
        #endregion

        #region Validation Rules
        public override string this[string columnName]
        {
            get
            {
                string errorMessage = String.Empty;
                switch (columnName)
                {
                    case "Name":
                        if (String.IsNullOrEmpty(Name))
                        {
                            errorMessage = "Command Name is required";
                        }
                        break;
                    default:
                        break;
                }
                return errorMessage;
            }
        }
        #endregion
    }
    public class Commands : ObservableCollection<Command> { }
}
