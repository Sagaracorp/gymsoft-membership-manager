using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;

namespace GymSoft.UserModule.Modules
{
    public class Module : IModule
    {
        IRegionManager regionManager;
        public Module(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
        }
        public void Initialize()
        {
            regionManager.RegisterViewWithRegion("RibbonRegion", typeof(UserModule.Views.UserRibbonView));
        }
    }
}
