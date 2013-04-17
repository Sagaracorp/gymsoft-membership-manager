using System;
using System.ComponentModel.Composition;
using Cinch;
using GymSoft.AuthenticationModule.Services;
using GymSoft.AuthenticationModule.Views;
using GymSoft.CinchMVVM.Common.Services;
using GymSoft.DB.UsersTable;
using MEFedMVVM.ViewModelLocator;
using Microsoft.Practices.Prism.Regions;

namespace GymSoft.AuthenticationModule.ViewModels
{
    [ExportViewModel("MainViewViewModel")]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class MainViewViewModel : ViewModelBase
    {
        private IViewAwareStatus viewAwareStatus;
        private IMessageBoxService messageBoxService;
        private IViewInjectionService viewInjectionService;
        private IAuthenticateService authenticateService;
        //  private IRegionManager regionManager;
        
        
        public User  CurrentUser { get; set; }
        public String LoggedInMessage { get; set; } 
        /// <summary>
        /// Commands
        /// </summary>
        public SimpleCommand<Object, Object> LogoutCommand { get; private set; }

        [ImportingConstructor]
        public MainViewViewModel( IViewAwareStatus viewAwareStatus, IMessageBoxService messageBoxService, IViewInjectionService viewInjectionService, IAuthenticateService authenticateService)
        {
            //this.regionManager = regionManager;
            this.viewAwareStatus = viewAwareStatus;
            this.messageBoxService = messageBoxService;
            this.viewInjectionService = viewInjectionService;
            this.authenticateService = authenticateService;
            this.viewAwareStatus.ViewLoaded += new Action(viewAwareStatus_ViewLoaded);
            CurrentUser = new User();
            CurrentUser = authenticateService.CurrentUser;
            LoggedInMessage = CurrentUser == null ? "" : String.Format("Currently logged in as: {0}", CurrentUser.UserName.DataValue);
            //Listen for login event
            Mediator.Instance.Register(this);
            LogoutCommand = new SimpleCommand<object, object>(ExecuteLogoutCommand);
        }

        void viewAwareStatus_ViewLoaded()
        {
            //Will need to load up all the UI responsible for this
            //Send the mediator command or somthing
            
            Mediator.Instance.NotifyColleagues("RibbonRegionLoadedMessage", true);
            
        }
        private void ExecuteLogoutCommand(Object args)
        {
            if (viewInjectionService.ClearRegionOfAllViews("RootRegion"))
            {
                if (!viewInjectionService.AddViewToRegion("RootRegion", "LoginView", new LoginView()))
                {
                    messageBoxService.ShowError(viewInjectionService.Error);
                }
            }
            else
            {
                messageBoxService.ShowError(viewInjectionService.Error);
            }
            #region This injects view but it also caches it
            /*var export = ViewModelRepository.Instance.Resolver.Container.GetExport<LoginView>();
            //ViewModelRepository.Instance.Resolver.Container.
            //var export = new LoginView();
            if (export != null)
            {
                object loginView = export.Value;
                //  object loginView = export;
                if (viewInjectionService.ClearRegionOfAllViews("RootRegion"))
                {
                    if (!viewInjectionService.AddViewToRegion("RootRegion", "LoginView", loginView))
                    {
                        messageBoxService.ShowError(viewInjectionService.Error);
                    }
                }
                else
                {
                    messageBoxService.ShowError(viewInjectionService.Error);
                }
            }
            else
            {
                messageBoxService.ShowError("Create view LoginView");
            }*/
            #endregion
        }
    }
}
