using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using Cinch;
using GymSoft.CinchMVVM.Common.Services;
using GymSoft.DB.UsersTable;
using GymSoft.UserModule.Views;
using MEFedMVVM.ViewModelLocator;

namespace GymSoft.UserModule.ViewModels
{
    [ExportViewModel("ViewAllUsersViewViewModel")]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class ViewAllUsersViewViewModel : ViewModelBase
    {
        private readonly IMessageBoxService messageBoxService;
        private readonly IViewAwareStatus viewAwareStatus;
        private readonly IViewInjectionService viewInjectionService;
        private readonly IUserService userService;

        private Users users;
        private User currentlySelectedUser;
        
        private bool isBusy;
        private string waitText;

        /// <summary>
        /// Users
        /// </summary>
        static PropertyChangedEventArgs usersArgs =
            ObservableHelper.CreateArgs<ViewAllUsersViewViewModel>(x => x.Users);


        public Users Users
        {
            get { return users; }
            private set
            {
                users = value;
                NotifyPropertyChanged(usersArgs);
            }
        }
        /// <summary>
        /// CurrentlySelectedUser
        /// </summary>
        static PropertyChangedEventArgs currentlySelectedUserArgs =
            ObservableHelper.CreateArgs<ViewAllUsersViewViewModel>(x => x.CurrentlySelectedUser);


        public User CurrentlySelectedUser
        {
            get { return currentlySelectedUser; }
            private set
            {
                currentlySelectedUser = value;
                NotifyPropertyChanged(currentlySelectedUserArgs);
                Mediator.Instance.NotifyColleagues<User>("CurrentlySelectedUser", currentlySelectedUser);
            }
        }
        /// <summary>
        /// IsBusy
        /// </summary>
        static PropertyChangedEventArgs isBusyArgs =
            ObservableHelper.CreateArgs<ViewAllUsersViewViewModel>(x => x.IsBusy);


        public bool IsBusy
        {
            get { return isBusy; }
            private set
            {
                isBusy = value;
                NotifyPropertyChanged(isBusyArgs);
            }
        }
        /// <summary>
        /// WaitText
        /// </summary>
        static PropertyChangedEventArgs waitTextArgs =
            ObservableHelper.CreateArgs<ViewAllUsersViewViewModel>(x => x.WaitText);


        public string WaitText
        {
            get { return waitText; }
            private set
            {
                waitText = value;
                NotifyPropertyChanged(waitTextArgs);
            }
        }


        [ImportingConstructor]
        public ViewAllUsersViewViewModel(IMessageBoxService messageBoxService, IViewAwareStatus viewAwareStatus, 
            IViewInjectionService viewInjectionService, IUserService userService)
        {
            this.messageBoxService = messageBoxService;
            this.viewAwareStatus = viewAwareStatus;
            this.userService = userService;
            this.viewInjectionService = viewInjectionService;
            Mediator.Instance.Register(this);
            viewAwareStatus.ViewLoaded += new Action(viewAwareStatus_ViewLoaded);
        }

        void viewAwareStatus_ViewLoaded()
        {
            IsBusy = true;
            WaitText = "Getting those users";
            userService.FindAllTask(LoadUsers, ErrorLoadUsers);
            //UserListView userListView = ViewModelRepository.Instance.Resolver.Container.GetExport<UserListView>().Value;
            //viewInjectionService.AddOrActivateViewInRegion("UserListRegion", "UserListView", userListView );
            //Inject UserDetailView into UserDetailRegion
            //viewInjectionService.ClearRegionOfAllViews("UserListRegion");
            //viewInjectionService.ClearRegionOfView("UserListRegion", "UserListView");
            //viewInjectionService.ClearRegionOfAllViews("UserDetailRegion");
            //viewInjectionService.AddViewToRegion("UserListRegion", "UserListView", new UserListView());
            //viewInjectionService.AddViewToRegion("UserDetailRegion", "UserDetailView", new UserDetailView());
        }
        void LoadUsers(Users result)
        {
            IsBusy = false;
            this.Users = result;
        }
        void ErrorLoadUsers(Exception exception)
        {
            IsBusy = false;
            messageBoxService.ShowError(exception.Message);
        }
    }
}
