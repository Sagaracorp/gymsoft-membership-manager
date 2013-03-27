using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using Cinch;
using MEFedMVVM.ViewModelLocator;

namespace GymSoft.UserModule.ViewModels
{
    [ExportViewModel("UserDetailViewModel")]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class UserDetailViewViewModel : ViewModelBase
    {
       
        [ImportingConstructor]
        public UserDetailViewViewModel()
        {
            
        }
    }
}
