namespace GymSoft.CinchMVVM.Common.Services
{
    public interface IViewInjectionService
    {
        string Error { get; set; }
        bool AddViewToRegion(string regionName, string viewName, object viewType);
        bool ClearRegionOfAllViews(string regionName);
        bool ClearRegionOfView(string regionName, object view);
    }
}
