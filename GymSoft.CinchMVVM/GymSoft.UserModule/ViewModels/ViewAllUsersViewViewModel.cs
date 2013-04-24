using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using Cinch;
using GymSoft.AuthenticationModule.Services;
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
        private readonly IOpenFileService openFileService;
        private readonly IAuthenticateService authenticateService;
        private bool canUpdate = false;
        private Users users;
        private User currentlySelectedUser;
        
        private bool isBusy;
        private string waitText;

        private bool isBusyUpdatingUser;
        private string updatingUserWaitText;

        public SimpleCommand<Object, Object> UpdateUserCommand { get; private set; }
        public SimpleCommand<Object, Object> UploadUserImageCommand { get; private set; }
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
                if (CurrentlySelectedUser.UserActions.DataValue != null && CurrentlySelectedUser.UserActions.DataValue.Count > 0)
                {
                    foreach (var action in CurrentlySelectedUser.UserRoles.DataValue)
                    {
                        messageBoxService.ShowInformation(action.RoleName.DataValue);
                    }
                    
                }
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
        /// <summary>
        /// IsBusyUpdatingUser
        /// </summary>
        static PropertyChangedEventArgs isBusyUpdatingUserArgs =
            ObservableHelper.CreateArgs<ViewAllUsersViewViewModel>(x => x.IsBusyUpdatingUser);


        public bool IsBusyUpdatingUser
        {
            get { return isBusyUpdatingUser; }
            private set
            {
                isBusyUpdatingUser = value;
                NotifyPropertyChanged(isBusyUpdatingUserArgs);
            }
        }
        /// <summary>
        /// UpdatingUserWaitText
        /// </summary>
        static PropertyChangedEventArgs updatingUserWaitTextArgs =
            ObservableHelper.CreateArgs<ViewAllUsersViewViewModel>(x => x.UpdatingUserWaitText);

        public string UpdatingUserWaitText
        {
            get { return updatingUserWaitText; }
            private set
            {
                updatingUserWaitText = value;
                NotifyPropertyChanged(updatingUserWaitTextArgs);
            }
        }


        [ImportingConstructor]
        public ViewAllUsersViewViewModel(IMessageBoxService messageBoxService, IViewAwareStatus viewAwareStatus,
            IViewInjectionService viewInjectionService, IUserService userService, IOpenFileService openFileService, IAuthenticateService authenticateService)
        {
            this.messageBoxService = messageBoxService;
            this.viewAwareStatus = viewAwareStatus;
            this.userService = userService;
            this.viewInjectionService = viewInjectionService;
            this.openFileService = openFileService;
            this.authenticateService = authenticateService;
            Mediator.Instance.Register(this);
            //Initialise Commands
            UpdateUserCommand = new SimpleCommand<object, object>(CanExecuteUpdateUserCommand, ExecuteUpdateUserCommand);
            UploadUserImageCommand = new SimpleCommand<object, object>(CanExecuteUploadUserImageCommand,
                                                                       ExecuteUploadUserImageCommand);
            viewAwareStatus.ViewLoaded += new Action(viewAwareStatus_ViewLoaded);
        }

        void viewAwareStatus_ViewLoaded()
        {
            IsBusy = true;
            WaitText = "Getting those users";
            userService.FindAllTask(LoadUsers, ErrorLoadUsers);
        }
        void LoadUsers(Users result)
        {
            IsBusy = false;
            this.Users = result;
            canUpdate = true;
            
        }
        void ErrorLoadUsers(Exception exception)
        {
            IsBusy = false;
            messageBoxService.ShowError(exception.Message);
        }
        private bool CanExecuteUploadUserImageCommand(Object args)
        {
            return authenticateService.CurrentUser != null && (canUpdate && authenticateService.CurrentUser.CanExecuteAction("ExecuteUploadUserImageCommand"));
        }

        private void ExecuteUploadUserImageCommand(Object args)
        {
            //User File open service to get the file
            openFileService.InitialDirectory = @"C:\";
            openFileService.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";

            var result = openFileService.ShowDialog(null);
            if (result.HasValue && result.Value == true)
            {
                var fileName = openFileService.FileName;
                CurrentlySelectedUser.PhotoPath.DataValue = fileName;
            }
        }
        public void UploadUserImageCompleted(int userId)
        {
            messageBoxService.ShowInformation(String.Format("Image for user {0} was uploaded", userId));
        }
        public void UploadUserImageException(Exception exception)
        {
            messageBoxService.ShowError(exception.Message);
        }

        private bool CanExecuteUpdateUserCommand(Object args)
        {
            //return CurrentlySelectedUser.IsValid;
            return authenticateService.CurrentUser != null && (canUpdate && authenticateService.CurrentUser.CanExecuteAction("ExecuteUpdateUserCommand"));
        }

        
        private void ExecuteUpdateUserCommand(Object args)
        {
            //AsyncState = AsyncType.Busy;
            IsBusyUpdatingUser = true;
            UpdatingUserWaitText = string.Format("Updating user");
            userService.UpdateUserTask(this.CurrentlySelectedUser, UserUpdated, ErrorUpdatingUser);

        }
        private void UserUpdated(int userId)
        {
            IsBusyUpdatingUser = false;
            //AsyncState = AsyncType.Content;
            messageBoxService.ShowInformation(String.Format("User updated with userId = {0}", userId));
        }
        private void ErrorUpdatingUser(Exception exception)
        {
            //ErrorMessage = exception.Message;
            //AsyncState = AsyncType.Error;
            IsBusyUpdatingUser = false;
            messageBoxService.ShowError(exception.Message);
        }

        
    }
}
