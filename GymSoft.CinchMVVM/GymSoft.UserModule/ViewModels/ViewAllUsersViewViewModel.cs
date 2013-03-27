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
        
       

        [ImportingConstructor]
        public ViewAllUsersViewViewModel(IMessageBoxService messageBoxService, IViewAwareStatus viewAwareStatus, 
            IViewInjectionService viewInjectionService)
        {
            this.messageBoxService = messageBoxService;
            this.viewAwareStatus = viewAwareStatus;
            this.viewInjectionService = viewInjectionService;
            Mediator.Instance.Register(this);
            viewAwareStatus.ViewLoaded += new Action(viewAwareStatus_ViewLoaded);
        }

        void viewAwareStatus_ViewLoaded()
        {
          //Inject UserDetailView into UserDetailRegion
            viewInjectionService.AddViewToRegion("UserListRegion", "UserListView", new UserListView());
        }
    }
}
