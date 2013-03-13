using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;

namespace GymSoft.RoleModule.Modules
{
    public class RoleModule : IModule
    {
        IRegionManager regionManager;

        public RoleModule(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
        }
        public void Initialize()
        {
            //regionManager.RegisterViewWithRegion("RibbonRegion", typeof(GymSoft.RoleModule.Views.RoleRibbonView));
        }
    }
}
