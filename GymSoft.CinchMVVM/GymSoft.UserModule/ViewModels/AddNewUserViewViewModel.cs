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
    [ExportViewModel("AddNewUserViewViewModel")]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class AddNewUserViewViewModel : ViewModelBase
    {
        private readonly IViewAwareStatus viewAwareStatus;
        private readonly IMessageBoxService messageBoxService;
        private readonly IUserService _userService;

        private AsyncType asyncState = AsyncType.Content;
        private bool isBusy;
        private string waitText;
        private string errorMessage;
        /// <summary>
        /// IsBusy
        /// </summary>
        static PropertyChangedEventArgs isBusyArgs =
            ObservableHelper.CreateArgs<AddNewUserViewViewModel>(x => x.IsBusy);

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
        /// AsyncState
        /// </summary>
        static PropertyChangedEventArgs asyncStateArgs =
            ObservableHelper.CreateArgs<AddNewUserViewViewModel>(x => x.AsyncState);

        public AsyncType AsyncState
        {
            get { return asyncState; }
            private set
            {
                asyncState = value;
                NotifyPropertyChanged(asyncStateArgs);
            }
        }
        /// <summary>
        /// WaitText
        /// </summary>
        static PropertyChangedEventArgs waitTextArgs =
            ObservableHelper.CreateArgs<AddNewUserViewViewModel>(x => x.WaitText);


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
        /// ErrorMessage
        /// </summary>
        static PropertyChangedEventArgs errorMessageArgs =
            ObservableHelper.CreateArgs<AddNewUserViewViewModel>(x => x.ErrorMessage);


        public string ErrorMessage
        {
            get { return errorMessage; }
            private set
            {
                errorMessage = value;
                NotifyPropertyChanged(errorMessageArgs);
            }
        }

        #region Commands
        public SimpleCommand<Object, Object> AddNewUserCommand { get; private set; }
        public SimpleCommand<Object, Object> CancelAddNewUserCommand { get; private set; }
        #endregion

        private User _newUser;
        
        /// <summary>
        /// New User
        /// </summary>
        private static readonly PropertyChangedEventArgs _newUserArgs =
            ObservableHelper.CreateArgs<AddNewUserViewViewModel>(x => x.NewUser);

        public User NewUser
        {
            get { return _newUser; }
            set
            {
                _newUser = value;
                NotifyPropertyChanged(_newUserArgs);
            }
        }

        [ImportingConstructor]
        public AddNewUserViewViewModel(IViewAwareStatus viewAwareStatus, IMessageBoxService messageBoxService, IUserService userService)
        {
            this.viewAwareStatus = viewAwareStatus;
            this.messageBoxService = messageBoxService;
            _userService = userService;
            NewUser = new User();
            //Initialise Commands
            AddNewUserCommand = new SimpleCommand<object, object>(CanAddNewUserCommand, ExecuteAddNewUserCommand);
            CancelAddNewUserCommand = new SimpleCommand<object, object>(ExecuteCancelAddNewUserCommand);
            //this._viewAwareStatus.ViewLoaded += new Action(_viewAwareStatus_ViewLoaded);
        }

        private bool CanAddNewUserCommand(Object args)
        {
            return NewUser.IsValid;
        }

        private void ExecuteCancelAddNewUserCommand(Object args)
        {
            NewUser = new User();
        }
        private void ExecuteAddNewUserCommand(Object args)
        {
            //AsyncState = AsyncType.Busy;
            IsBusy = true;
            WaitText = string.Format("Adding new user");
            _userService.CreateNewUserTask(this.NewUser,NewUserAdded, ErrorAddingNewUser);
            
        }
        private void NewUserAdded(int userId)
        {
            IsBusy = false;
            //AsyncState = AsyncType.Content;
            messageBoxService.ShowInformation(String.Format("New User Added with userId = {0}", userId));
            NewUser = new User();
        }
        private void ErrorAddingNewUser(Exception exception)
        {
            ErrorMessage = exception.Message;
            AsyncState = AsyncType.Error;
            IsBusy = false;
            messageBoxService.ShowError(exception.Message);
        }
        //void _viewAwareStatus_ViewLoaded()
       // {
            
        //}
    }
}
