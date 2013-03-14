using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GymSoft.Shell.Events;
using GymSoft.Shell.ViewModels;
using GymSoft.Shell.Views;
using GymSoft.UserModule.Events;
using GymSoft.UserModule.Model;
using GymSoft.UserModule.Views;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;

namespace GymSoft.Shell.Controller
{
    public  class MainApplicationController
    {
        private IRegionManager regionManager;
        private IEventAggregator eventAggregator;
        private IUnityContainer container;

        public MainApplicationController(IRegionManager regionManager, IEventAggregator eventAggregator, IUnityContainer container)
        {
            this.regionManager = regionManager;
            this.eventAggregator = eventAggregator;
            this.container = container;

            eventAggregator.GetEvent<UserLoginEvent>().Subscribe(this.UserLoginEventFired, true);
            eventAggregator.GetEvent<UserLogoutEvent>().Subscribe(this.UserLogoutEventFired, true);
        }

        private void UserLogoutEventFired(object obj)
        {
            var region = this.regionManager.Regions["TopLevelRegion"];
            if (region == null)
                return;


            var loginView = region.GetView("LoginView") as UserAuthenticationView;
            if (loginView == null)
            {
                loginView = this.container.Resolve<UserAuthenticationView>();
                //Clear the login view
                region.Remove((HomeView)region.Views.First());
                region.Add(loginView, "LoginView");
            }
            else
            {
                region.Activate(loginView);
            }
            this.regionManager.Regions["TopLevelRegion"].Context = null;
        }

        private void UserLoginEventFired(User currentUser)
        {
            var region = this.regionManager.Regions["TopLevelRegion"];

            
            if (region == null)
                return;

            
            var homeView = region.GetView("HomeView") as HomeView;
            if (homeView == null)
            {
                homeView = this.container.Resolve<HomeView>();
                //Clear the login view
                region.Remove((UserAuthenticationView)region.Views.First());
                region.Add(homeView, "HomeView");
            }
            else
            {
                region.Activate(homeView);
            }
            //Add Current user to region context.
            this.regionManager.Regions["TopLevelRegion"].Context = currentUser;
            //Send event to notify all modules that the ribbonRegion is now available
            //eventAggregator.GetEvent<RibbonViewAvailableEvent>().Publish(currentUser);
        }
    }
}
