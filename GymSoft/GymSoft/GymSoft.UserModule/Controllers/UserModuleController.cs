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
using GymSoft.UserModule.Model;
using GymSoft.UserModule.ViewModels;

namespace GymSoft.UserModule.Controllers
{
    public class UserModuleController
    {
        IUnityContainer container;
        IRegionManager regionManager;
        IEventAggregator eventAggregator;
       // IUserService userService; //Not sure I need that

        public UserModuleController(IUnityContainer container, IRegionManager regionManager,
                                    IEventAggregator eventAggregator, IUserService userService)
        {
            this.container = container;
            this.regionManager = regionManager;
            this.eventAggregator = eventAggregator;
         //   this.userService = userService;

            //When the ViewAllUsersEvent fires Activate the UserListView
            this.eventAggregator.GetEvent<UserLoginEvent>().Subscribe(this.UserLoginEventFired, true);
            //this.eventAggregator.GetEvent<ViewAllUsersEvent>().Subscribe(this.ViewAllUsersEventFired, true);
            // this.eventAggregator.GetEvent<DeleteAllUsersEvent>().Subscribe(this.DeleteAllUsersEventFired, true);
            //this.eventAggregator.GetEvent<UserSelectedEvent>().Subscribe(this.UserSelectedEventFired, true);

        }

        private void UserLoginEventFired(User currentUser)
        {
            regionManager.RegisterViewWithRegion("RibbonRegion", typeof(UserModule.Views.UserRibbonView));
        }

        #region Just Going to put all the stuff in here
        private void UserSelectedEventFired(User userSelected)
        {
            IRegion region = this.regionManager.Regions["UserDetailsRegion"];

            if (region == null)
                return;
            UserDetailsView view = region.GetView("UserDetailsView") as UserDetailsView;

            if (view == null)
            {
                view = this.container.Resolve<UserDetailsView>();
                region.Add(view, "UserDetailsView");
            }
            else
            {
                region.Activate(view);
            }
            // Set the current employee property on the view model.
            UserDetailsViewModel viewModel = view.DataContext as UserDetailsViewModel;
            if (viewModel != null)
            {
                viewModel.CurrentUser = userSelected;
            }

        }
        private void DeleteAllUsersEventFired(object value)
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
        #endregion
        
    }
}