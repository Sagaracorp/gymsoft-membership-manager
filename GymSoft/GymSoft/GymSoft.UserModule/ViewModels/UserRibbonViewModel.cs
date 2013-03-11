using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Microsoft.Practices.Prism.Events;
using System.Windows.Input;
using Telerik.Windows.Controls;
using GymSoft.UserModule.Events;


namespace GymSoft.UserModule.ViewModels
{
    public class UserRibbonViewModel 
    {
        IEventAggregator eventAggregator;
        public UserRibbonViewModel(IEventAggregator eventAggregator)
        {
            this.eventAggregator = eventAggregator;
            this.ViewAllUsersCommand = new DelegateCommand(this.ExecuteViewAllUsers, 
                this.ViewAllUsersCanExecute);
            this.DeleteAllUsersCommand = new DelegateCommand(this.ExecuteDeleteAllUsers,
                this.DeleteAllUsersCanExecute);
        }

        public ICommand ViewAllUsersCommand { get; private set; }
        public ICommand DeleteAllUsersCommand { get; private set; }

        private void ExecuteDeleteAllUsers(object o)
        {
            //Fire View All Users Event
            this.eventAggregator.GetEvent<DeleteAllUsersEvent>().Publish(o);
        }
        private bool DeleteAllUsersCanExecute(object c)
        {
            return false; //This will depend on user authorization level
        }

        private void ExecuteViewAllUsers(object o)
        {
            //Fire View All Users Event
            this.eventAggregator.GetEvent<ViewAllUsersEvent>().Publish(o);
        }
        private bool ViewAllUsersCanExecute(object c)
        {
            return true; //This will depend on user authorization level
        }        
    }
}
