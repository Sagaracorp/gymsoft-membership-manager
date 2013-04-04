namespace GymSoft.CinchMVVM.Common.Services
{
    public interface IViewInjectionService
    {
        string Error { get; set; }
        
        bool AddViewToRegion(string regionName, string viewName, object viewType);
        bool ClearRegionOfAllViews(string regionName);
        bool ClearRegionOfView(string regionName, object view);
        bool ClearRegionOfView(string regionName, string view);
        bool AddOrActivateViewInRegion(string regionName, string viewName, object view = null);
        void RegisterViewWithRegion(string regionName, object view);
    }
}
