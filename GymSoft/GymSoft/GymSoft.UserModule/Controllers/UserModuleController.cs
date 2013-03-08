using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Prism.Events;
using GymSoft.UserModule.Services;
using GymSoft.UserModule.Events;
using GymSoft.UserModule.Views;

namespace GymSoft.UserModule.Controllers
{
    public class UserModuleController
    {
        IUnityContainer container;
        IRegionManager regionManager;
        IEventAggregator eventAggregator;
        IUserService userService; //Not sure I need that

        public UserModuleController(IUnityContainer container, IRegionManager regionManager,
                                    IEventAggregator eventAggregator, IUserService userService)
        {
            this.container = container;
            this.regionManager = regionManager;
            this.eventAggregator = eventAggregator;
            this.userService = userService;

            //When the ViewAllUsersEvent fires Activate the UserListView
            this.eventAggregator.GetEvent<ViewAllUsersEvent>().Subscribe(this.ViewAllUsersEventFired, true);

        }
        private void ViewAllUsersEventFired(object value)
        {
            IRegion region = this.regionManager.Regions["MainRegion"];
            
            if (region == null)
                return;

            UserMainRegionView userMainRegionView = region.GetView("UserMainRegionView") as UserMainRegionView;
            if (userMainRegionView == null)
            {
                userMainRegionView = this.container.Resolve<UserMainRegionView>();
                region.Add(userMainRegionView, "UserMainRegionView");
            }
            else
            {
                region.Activate(userMainRegionView);
            }
            
        }
    }
}
