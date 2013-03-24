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
        private readonly IViewAwareStatus _viewAwareStatus;
        private readonly IMessageBoxService _messageBoxService;
        private readonly IUserService _userService;

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
            _viewAwareStatus = viewAwareStatus;
            _messageBoxService = messageBoxService;
            _userService = userService;
            NewUser = new User();
            this._viewAwareStatus.ViewLoaded += new Action(_viewAwareStatus_ViewLoaded);
        }

        void _viewAwareStatus_ViewLoaded()
        {
            
        }
    }
}
