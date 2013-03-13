using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;

namespace GymSoft.Controller.Modules
{
    public class ControllerModule : IModule
    {
        private IRegionManager regionManager;
        private IUnityContainer container;
        private ApplicationController applicationController;
        
        public ControllerModule(IRegionManager regionManager, IUnityContainer container)
        {
            this.regionManager = regionManager;
            this.container = container;
        }
        public void Initialize()
        {
            //Register the regionmanager as a singleton
            //container.Resolve(ControllerModule)
            this.applicationController = container.Resolve<ApplicationController>();
        }
    }
}
