using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using GymSoft.AuthenticationModule.Views;
using Microsoft.Practices.Prism.MefExtensions.Modularity;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;

namespace GymSoft.AuthenticationModule
{
    [ModuleExport(typeof(GymSoft.AuthenticationModule.Module))]
    public class Module : IModule
    {
        private readonly IRegionManager regionManager;
        
        [ImportingConstructor]
        public Module(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
        }
        public void Initialize()
        {
            //Inject Login view into Root Region
            regionManager.RegisterViewWithRegion("RootRegion", typeof(LoginView));
        }
    }
}
