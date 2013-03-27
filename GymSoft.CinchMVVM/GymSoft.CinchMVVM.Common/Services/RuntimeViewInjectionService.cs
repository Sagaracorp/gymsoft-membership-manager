using System;
using System.ComponentModel.Composition;
using System.Linq;
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
                var existingView = region.Views.FirstOrDefault();
                if (existingView == null)
                {
                    region.Add(viewType, viewName);
                    region.Activate(viewType);
                }
                else
                {
                    region.Activate(existingView);
                }
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


        public bool ClearRegionOfView(string regionName, string view)
        {
            try
            {
                IRegion region = regionManager.Regions[regionName];
                var existingView = region.GetView(view);
                if (existingView != null)
                {
                    region.Remove(existingView);
                }
                return true;
            }
            catch (Exception exception)
            {
                Error = exception.Message;
                return false;
            }
        }


        public bool AddOrActivateViewInRegion(string regionName, string viewName, object view = null)
        {
            try
            {
                //Get region
                IRegion region = regionManager.Regions[regionName];
                var existingView = region.GetView(viewName);
                if (existingView != null)
                {
                    region.Activate(existingView);
                }
                else
                {
                    region.Add(view, viewName);
                    region.Activate(view);
                }
                return true;
            }
            catch (Exception exception)
            {
                Error = exception.Message;
                return false;
            }
        }
    }
}
