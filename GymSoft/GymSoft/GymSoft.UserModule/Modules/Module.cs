using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;
using GymSoft.UserModule.Services;
using GymSoft.UserModule.Controllers;

namespace GymSoft.UserModule.Modules
{
    public class Module : IModule
    {
        IRegionManager regionManager;
        IUnityContainer container;
        UserModuleController userModuleController;
        public Module(IRegionManager regionManager, IUnityContainer container)
        {
            this.regionManager = regionManager;
            this.container = container;
        }
        public void Initialize()
        {
            //Register types
            this.container.RegisterType<IUserService, UserMockService>();
            this.userModuleController = this.container.Resolve<UserModuleController>();

            this.container.RegisterType<IUserServiceRepository, UserMockServiceRepository>();
            this.container.RegisterType<IOperationResult, OperationResult>();
            this.container.RegisterType(typeof(IOperationResult<>), typeof(OperationResult<>));


            //Register views with regions 
            regionManager.RegisterViewWithRegion("RibbonRegion", typeof(UserModule.Views.UserRibbonView));
            //regionManager.RegisterViewWithRegion("MainRegion", typeof(UserModule.Views.UserMainRegionView));
            regionManager.RegisterViewWithRegion("UserListRegion", typeof(UserModule.Views.UserListRegionView));
        }
    }
}
