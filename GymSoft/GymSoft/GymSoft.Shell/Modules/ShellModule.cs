using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GymSoft.Shell.Controller;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;

namespace GymSoft.Shell.Modules
{
    public class ShellModule : IModule
    {
        private IUnityContainer container;
        private MainApplicationController applicationController;
        private IRegionManager regionManager;
        public ShellModule(IUnityContainer container, IRegionManager regionManager)
        {
            this.container = container;
            this.regionManager = regionManager;
        }
        public void Initialize()
        {
            this.applicationController = this.container.Resolve<MainApplicationController>();
            regionManager.RegisterViewWithRegion("TopLevelRegion", typeof(UserModule.Views.UserAuthenticationView));
        }
    }
}
