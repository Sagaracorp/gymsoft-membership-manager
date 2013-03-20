using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using Cinch;
using MEFedMVVM.ViewModelLocator;

namespace GymSoft.AuthenticationModule.ViewModels
{
    [ExportViewModel("LoginViewViewModel")]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class LoginViewViewModel : ViewModelBase
    {
        private IViewAwareStatus viewAwareStatus;
        [ImportingConstructor]
        public LoginViewViewModel(IViewAwareStatus viewAwareStatus)
        {
            this.viewAwareStatus = viewAwareStatus;
        }
    }
}
