using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using Cinch;
using GymSoft.DB.UsersTable;
using MEFedMVVM.ViewModelLocator;

namespace GymSoft.UserModule.ViewModels
{
    [ExportViewModel("UserListViewViewModel")]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class UserListViewViewModel : ViewModelBase
    {
        private readonly IViewAwareStatus viewAwareStatus;
        private readonly IMessageBoxService messageBoxService;
        private readonly IUserService userService;
        private Users users;
        private bool isBusy;
        private string waitText;

        /// <summary>
        /// Users
        /// </summary>
        static PropertyChangedEventArgs usersArgs =
            ObservableHelper.CreateArgs<UserListViewViewModel>(x => x.Users);


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
        /// IsBusy
        /// </summary>
        static PropertyChangedEventArgs isBusyArgs =
            ObservableHelper.CreateArgs<UserListViewViewModel>(x => x.IsBusy);


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
            ObservableHelper.CreateArgs<UserListViewViewModel>(x => x.WaitText);


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
        public UserListViewViewModel(IViewAwareStatus viewAwareStatus, IMessageBoxService messageBoxService, IUserService userService)
        {
            this.viewAwareStatus = viewAwareStatus;
            this.messageBoxService = messageBoxService;
            this.userService = userService;

            this.viewAwareStatus.ViewLoaded += new Action(viewAwareStatus_ViewLoaded);
        }

        void viewAwareStatus_ViewLoaded()
        {
            //Get the users
            WaitText = "Getting those user records";
            IsBusy = true;
            userService.FindAllTask(UsersLoadedSuccess, UserLoadedFailure);
        }

        public void UsersLoadedSuccess(Users users)
        {
            IsBusy = false;
            this.Users = users;
            
        }
        public void UserLoadedFailure(Exception exception)
        {
            isBusy = false;
            messageBoxService.ShowError(exception.Message);   
        }
    }
}
