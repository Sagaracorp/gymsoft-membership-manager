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
    public class UserRibbonViewModel : INotifyPropertyChanged
    {
        IEventAggregator eventAggregator;
        public UserRibbonViewModel(IEventAggregator eventAggregator)
        {
            this.eventAggregator = eventAggregator;
            this.ViewAllUsersCommand = new DelegateCommand(this.ExecuteViewAllUsers, 
                this.ViewAllUsersCanExecute);           
        }

        public ICommand ViewAllUsersCommand { get; private set; }
        private void ExecuteViewAllUsers(object o)
        {
            //Fire View All Users Event
            this.eventAggregator.GetEvent<ViewAllUsersEvent>().Publish(o);
        }
        private bool ViewAllUsersCanExecute(object c)
        {
            return true; //This will depend on user authorization level
        }

        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
}
