using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using Cinch;
using MEFedMVVM.ViewModelLocator;

namespace GymSoft.UserModule.ViewModels
{
    [ExportViewModel("UserRibbonViewViewModel")]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class UserRibbonViewViewModel : ViewModelBase
    {
        private IMessageBoxService messageBoxService;
        private IViewAwareStatus viewAwareStatus;

        [ImportingConstructor]
        public UserRibbonViewViewModel(IMessageBoxService messageBoxService, IViewAwareStatus viewAwareStatus)
        {
            this.messageBoxService = messageBoxService;
            this.viewAwareStatus = viewAwareStatus;
        }
    }
}
