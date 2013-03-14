using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;
using GymSoft.Common;
using GymSoft.UserModule.Events;
using GymSoft.UserModule.Model;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;

namespace GymSoft.Shell.ViewModels
{
    public class HomeViewViewModel : PropertyChangedImplementation
    {
        private readonly IRegionManager regionManager;
        private readonly IUnityContainer container;
        private readonly IEventAggregator eventAggregator;
        private User loggedInUser;
        public ICommand LogoutCommand { get; set; }
        public ICommand ViewProfileCommand { get; set; }
        
        public User LoggedInUser
        {
            get { return loggedInUser; }
            set { loggedInUser = value; FirePropertyChanged("LoggedInUser");}
        }
        
        public HomeViewViewModel(IRegionManager regionManager, IUnityContainer container, IEventAggregator eventAggregator)
        {
            this.regionManager = regionManager;
            this.container = container;
            this.eventAggregator = eventAggregator;
            //Get the region context user
            //this.LoggedInUser = (User)this.regionManager.Regions["TopLevelRegion"].Context;
            this.LogoutCommand = new DelegateCommand(OnLogoutExecuted);
            this.ViewProfileCommand = new DelegateCommand(OnViewProfileCommandExecuted);
        }

        private void OnViewProfileCommandExecuted()
        {
            this.LoggedInUser = (User)this.regionManager.Regions["TopLevelRegion"].Context;
            FirePropertyChanged("LoggedInUser");
        }


        private void OnLogoutExecuted()
        {
            this.eventAggregator.GetEvent<UserLogoutEvent>().Publish(loggedInUser);
        }
    }
}
