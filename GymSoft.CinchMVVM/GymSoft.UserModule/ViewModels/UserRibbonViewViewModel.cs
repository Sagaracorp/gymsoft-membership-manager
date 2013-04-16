using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using Cinch;
using GymSoft.CinchMVVM.Common.Services;
using GymSoft.UserModule.Views;
using MEFedMVVM.ViewModelLocator;

namespace GymSoft.UserModule.ViewModels
{
    [ExportViewModel("UserRibbonViewViewModel")]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class UserRibbonViewViewModel : ViewModelBase
    {
        private IMessageBoxService messageBoxService;
        private IViewAwareStatus viewAwareStatus;
        private IViewInjectionService viewInjectionService;
       
        /// <summary>
        /// Commands
        /// </summary>
        public SimpleCommand<Object, Object> AddNewUserCommand { get; private set; }
        public SimpleCommand<Object, Object> ViewAllUsersCommand { get; private set; }
        public SimpleCommand<Object, Object> ViewAllRolesCommand { get; private set; }

        [ImportingConstructor]
        public UserRibbonViewViewModel(IMessageBoxService messageBoxService, IViewAwareStatus viewAwareStatus, IViewInjectionService viewInjectionService)
        {
            this.messageBoxService = messageBoxService;
            this.viewAwareStatus = viewAwareStatus;
            this.viewInjectionService = viewInjectionService;

            Mediator.Instance.Register(this);
            //Initialise Commands
            AddNewUserCommand = new SimpleCommand<object, object>(CanExecuteAddNewUserCommand, ExecuteAddNewUserCommand);
            ViewAllUsersCommand = new SimpleCommand<object, object>(CanExecuteViewAllUsersCommand, ExecuteViewAllUsersCommand);
            ViewAllRolesCommand = new SimpleCommand<object, object>(CanExecuteViewAllRolesCommand, ExecuteViewAllRolesCommand);
        }
        #region Commands Execution Implementation

        private void ExecuteAddNewUserCommand(Object args)
        {
            //Inject Add User view
            viewInjectionService.ClearRegionOfAllViews("MainContentRegion");
            viewInjectionService.AddViewToRegion("MainContentRegion", "AddNewUserView", new AddNewUserView());
        }

        private bool CanExecuteAddNewUserCommand(Object args)
        {
            return true;
        }
        private bool CanExecuteViewAllUsersCommand(Object args)
        {
            return true;
        }
        private bool CanExecuteViewAllRolesCommand(Object args)
        {
            return true;
        }

        private void ExecuteViewAllUsersCommand(Object args)
        {
            //Inject Add User view
            viewInjectionService.ClearRegionOfAllViews("MainContentRegion");
            viewInjectionService.AddViewToRegion("MainContentRegion", "ViewAllUsersView", new ViewAllUsersView());
        }
        private void ExecuteViewAllRolesCommand(Object args)
        {
            //Inject View all roles view
            viewInjectionService.ClearRegionOfAllViews("MainContentRegion");
            viewInjectionService.AddViewToRegion("MainContentRegion", "ViewAllRolesView", new ViewAllRolesView());
        }
        #endregion
    }
}
