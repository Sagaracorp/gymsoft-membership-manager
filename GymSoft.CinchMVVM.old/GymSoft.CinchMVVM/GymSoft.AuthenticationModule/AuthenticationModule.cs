using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using Cinch;
using GymSoft.AuthenticationModule.Views;
using GymSoft.CinchMVVM.Common.Services;
using Microsoft.Practices.Prism.MefExtensions.Modularity;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;

namespace GymSoft.AuthenticationModule
{
    [ModuleExport(typeof(GymSoft.AuthenticationModule.AuthenticationModule))]
    public class AuthenticationModule : IModule
    {
        private readonly IViewInjectionService viewInjectionService;
        private readonly IMessageBoxService messageBoxService;

        
        [ImportingConstructor]
        public AuthenticationModule(IViewInjectionService viewInjectionService, IMessageBoxService messageBoxService)
        {
            this.viewInjectionService = viewInjectionService;
            this.messageBoxService = messageBoxService;
        }
        public void Initialize()
        {
            if (viewInjectionService.ClearRegionOfAllViews("RootRegion"))
            {
                //Disable Authentication
               if (!viewInjectionService.AddViewToRegion("RootRegion", "MainView", new MainView()))
                {
                    messageBoxService.ShowError(viewInjectionService.Error);
                }
                //Enable Authentication
               /* if (!viewInjectionService.AddViewToRegion("RootRegion", "LoginView", new LoginView()))
                {
                    messageBoxService.ShowError(viewInjectionService.Error);
                }*/
            }
            else
            {
                messageBoxService.ShowError(viewInjectionService.Error);
            }
        }
    }
}
