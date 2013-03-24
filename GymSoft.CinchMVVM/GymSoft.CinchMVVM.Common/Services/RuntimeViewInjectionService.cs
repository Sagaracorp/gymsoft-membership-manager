using System;
using System.ComponentModel.Composition;
using MEFedMVVM.ViewModelLocator;
using Microsoft.Practices.Prism.Regions;

namespace GymSoft.CinchMVVM.Common.Services
{
    [PartCreationPolicy(CreationPolicy.NonShared)]
    [ExportService(ServiceType.Runtime, typeof(IViewInjectionService))]
    public class RuntimeViewInjectionService : IViewInjectionService
    {
        private readonly IRegionManager regionManager;
        //private string error;
        public string Error { get; set; }
        
        [ImportingConstructor]
        public RuntimeViewInjectionService(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
            Error = String.Empty;
        }
        public bool AddViewToRegion(string regionName, string viewName, object viewType)
        {
            try
            {
                IRegion region = regionManager.Regions[regionName];
                region.Add(viewType, viewName);
                region.Activate(viewType);
                return true;
            }
            catch (Exception exception)
            {
                Error = exception.Message;
                return false;

            }
        }
        public bool ClearRegionOfAllViews(string regionName)
        {
            try
            {
                if (regionManager.Regions[regionName] != null)
                {
                    IRegion region = regionManager.Regions[regionName];
                    foreach (var view in region.Views)
                    {
                          region.Remove(view);
                    }
                    return true;
                }
                else
                {
                    Error = string.Format("No region called {0} was found", regionName);
                    return false;
                }
               
                
            }
            catch (Exception exception)
            {

                Error = exception.Message;
                return false;
            }
        }

        public bool ClearRegionOfView(string regionName, object view)
        {
            try
            {
                IRegion region = regionManager.Regions[regionName];
                region.Remove(view);
                return true;
            }
            catch (Exception exception)
            {
                Error = exception.Message;
                return false;
            }
        }


        public void RegisterViewWithRegion(string regionName, object viewType)
        {
            this.regionManager.RegisterViewWithRegion(regionName, () => viewType);
        }
    }
}
