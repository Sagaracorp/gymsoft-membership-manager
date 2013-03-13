using GymSoft.UserModule.Events;
using GymSoft.UserModule.Model;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Regions;

namespace GymSoft.Controller
{
    public class ApplicationController
    {
        private IRegionManager regionManager;
        private IEventAggregator eventAggregator;

        public ApplicationController(IRegionManager regionManager, IEventAggregator eventAggregator)
        {
            this.regionManager = regionManager;
            this.eventAggregator = eventAggregator;

            //Subscribe to events
            //this.eventAggregator.GetEvent<UserLoginEvent>().Subscribe(this.UserLoginEventFired, true);
            regionManager.RegisterViewWithRegion("TopLevelRegion", typeof(UserModule.Views.UserAuthenticationView));
        }

        private void UserLoginEventFired(User currentUser)
        {
            //Place Home View on the main page

        }
    }
}
