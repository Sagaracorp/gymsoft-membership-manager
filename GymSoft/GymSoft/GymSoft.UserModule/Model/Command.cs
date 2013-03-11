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
        #endregion
    }
    public class Commands : ObservableCollection<Command> { }
}
