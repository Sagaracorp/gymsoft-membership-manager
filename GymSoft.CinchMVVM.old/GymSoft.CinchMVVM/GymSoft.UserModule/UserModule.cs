using System.ComponentModel.Composition;
using System.Threading;
using Cinch;
using GymSoft.CinchMVVM.Common.Services;
using GymSoft.UserModule.Views;
using Microsoft.Practices.Prism.MefExtensions.Modularity;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;

namespace GymSoft.UserModule
{
    [ModuleExport(typeof(GymSoft.UserModule.UserModule))]
    public class UserModule : IModule
    {
        private readonly IViewInjectionService viewInjectionService;
        private readonly IMessageBoxService messageBoxService;
       
        [ImportingConstructor]
        public UserModule(IViewInjectionService viewInjectionService, IMessageBoxService messageBoxService)
        {
            this.viewInjectionService = viewInjectionService;
            this.messageBoxService = messageBoxService;
           

        }
        public void Initialize()
        {
            Mediator.Instance.Register(this);
        }

        [MediatorMessageSink("RibbonRegionLoadedMessage")]
        public void OnRibbonRegionLoaded(bool e)
        {
            if (!viewInjectionService.AddViewToRegion("MainRibbonRegion", "UserRibbonView", new UserRibbonView()))
            {
                messageBoxService.ShowError(viewInjectionService.Error);
            }
        }
    }
}