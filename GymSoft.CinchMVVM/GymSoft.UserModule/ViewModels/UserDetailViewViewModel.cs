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
    [ExportViewModel("UserDetailViewViewModel")]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class UserDetailViewViewModel : ViewModelBase
    {

        private User currentlySelectedUser;
        private readonly IMessageBoxService messageBoxService;
        private readonly IViewAwareStatus viewAwareStatus;

        /// <summary>
        /// CurrentlySelectedUser
        /// </summary>
        static PropertyChangedEventArgs currentlySelectedUserArgs =
            ObservableHelper.CreateArgs<UserDetailViewViewModel>(x => x.CurrentlySelectedUser);


        public User CurrentlySelectedUser
        {
            get { return currentlySelectedUser; }
            private set
            {
                currentlySelectedUser = value;
                NotifyPropertyChanged(currentlySelectedUserArgs);
            }
        }
        [ImportingConstructor]
        public UserDetailViewViewModel(IMessageBoxService messageBoxService, IViewAwareStatus viewAwareStatus)
        {
            this.messageBoxService = messageBoxService;
            this.viewAwareStatus = viewAwareStatus;
            this.viewAwareStatus.ViewLoaded += new Action(viewAwareStatus_ViewLoaded);
        }

        void viewAwareStatus_ViewLoaded()
        {
            Mediator.Instance.Register(this);
        }
        [MediatorMessageSink("CurrentlySelectedUser")]
        void OnCurrentSelectedUserChanged(User selectedUser)
        {
            this.CurrentlySelectedUser = selectedUser;
           // messageBoxService.ShowInformation(String.Format("From userdetailviemodel currentuser is {0}", CurrentlySelectedUser.FirstName.DataValue));
        }
    }
}
