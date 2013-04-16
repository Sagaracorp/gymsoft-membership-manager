using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using Cinch;
using GymSoft.CinchMVVM.Common.Services;
using GymSoft.DB.RolesTable;
using MEFedMVVM.ViewModelLocator;

namespace GymSoft.UserModule.ViewModels
{
    [ExportViewModel("ViewAllRolesViewViewModel")]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class ViewAllRolesViewViewModel : ViewModelBase
    {
        private readonly IMessageBoxService messageBoxService;
        private readonly IViewAwareStatus viewAwareStatus;
        private readonly IViewInjectionService viewInjectionService;
        private readonly IRoleService roleService;
        private readonly IOpenFileService openFileService;
        private bool canUpdate = false;
        private Roles roles;
        private Role currentlySelectedRole;
        
        private bool isBusy;
        private string waitText;

        private bool isBusyUpdatingUser;
        private string updatingUserWaitText;

        public SimpleCommand<Object, Object> UpdateRoleCommand { get; private set; }
        /// <summary>
        /// Roles
        /// </summary>
        static PropertyChangedEventArgs rolesArgs =
            ObservableHelper.CreateArgs<ViewAllRolesViewViewModel>(x => x.Roles);


        public Roles Roles
        {
            get { return roles; }
            private set
            {
                roles = value;
                NotifyPropertyChanged(rolesArgs);
            }
        }
        /// <summary>
        /// CurrentlySelectedRole
        /// </summary>
        static PropertyChangedEventArgs currentlySelectedRoleArgs =
            ObservableHelper.CreateArgs<ViewAllRolesViewViewModel>(x => x.CurrentlySelectedRole);


        public Role CurrentlySelectedRole
        {
            get { return currentlySelectedRole; }
            private set
            {
                currentlySelectedRole = value;
                NotifyPropertyChanged(currentlySelectedRoleArgs);
                Mediator.Instance.NotifyColleagues<Role>("CurrentlySelectedRole", currentlySelectedRole);
            }
        }
        /// <summary>
        /// IsBusy
        /// </summary>
        static PropertyChangedEventArgs isBusyArgs =
            ObservableHelper.CreateArgs<ViewAllRolesViewViewModel>(x => x.IsBusy);


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
            ObservableHelper.CreateArgs<ViewAllRolesViewViewModel>(x => x.WaitText);

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
            ObservableHelper.CreateArgs<ViewAllRolesViewViewModel>(x => x.IsBusyUpdatingUser);


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
            ObservableHelper.CreateArgs<ViewAllRolesViewViewModel>(x => x.UpdatingUserWaitText);

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
        public ViewAllRolesViewViewModel(IMessageBoxService messageBoxService, IViewAwareStatus viewAwareStatus,
            IViewInjectionService viewInjectionService, IRoleService roleService, IOpenFileService openFileService)
        {
            this.messageBoxService = messageBoxService;
            this.viewAwareStatus = viewAwareStatus;
            this.roleService = roleService;
            this.viewInjectionService = viewInjectionService;
            this.openFileService = openFileService;
            Mediator.Instance.Register(this);
            //Initialise Commands
            UpdateRoleCommand = new SimpleCommand<object, object>(CanExecuteUpdateRoleCommand, ExecuteUpdateRoleCommand);
            viewAwareStatus.ViewLoaded += new Action(viewAwareStatus_ViewLoaded);
        }

        void viewAwareStatus_ViewLoaded()
        {
            IsBusy = true;
            WaitText = "Getting those roles";
            roleService.FindAllTask(LoadRoles, ErrorLoadRoles);
        }
        void LoadRoles(Roles result)
        {
            IsBusy = false;
            this.Roles = result;
            canUpdate = true;
        }
        void ErrorLoadRoles(Exception exception)
        {
            IsBusy = false;
            messageBoxService.ShowError(exception.Message);
        }

        private bool CanExecuteUpdateRoleCommand(Object args)
        {
            //return CurrentlySelectedUser.IsValid;
            return canUpdate;
        }

        
        private void ExecuteUpdateRoleCommand(Object args)
        {
            //AsyncState = AsyncType.Busy;
            IsBusyUpdatingUser = true;
            UpdatingUserWaitText = string.Format("Updating role");
            roleService.UpdateRoleTask(this.CurrentlySelectedRole, RoleUpdated, ErrorUpdatingRole);

        }
        private void RoleUpdated(int roleId)
        {
            IsBusyUpdatingUser = false;
            //AsyncState = AsyncType.Content;
            messageBoxService.ShowInformation(String.Format("Role updated with userId = {0}", roleId));
        }
        private void ErrorUpdatingRole(Exception exception)
        {
            //ErrorMessage = exception.Message;
            //AsyncState = AsyncType.Error;
            IsBusyUpdatingUser = false;
            messageBoxService.ShowError(exception.Message);
        }
    }
}
