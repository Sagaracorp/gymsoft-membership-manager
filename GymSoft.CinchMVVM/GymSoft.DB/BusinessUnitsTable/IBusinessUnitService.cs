using System;

namespace GymSoft.DB.BusinessUnitsTable
{
    public interface IBusinessUnitService
    {
        BusinessUnits FindAll(int userId); // This user id should be current user. 
        BusinessUnits FindAll(); // This should be used buy the login screen. 
        void FindAllTask(Action<BusinessUnits> resultCallback, Action<Exception> exceptionCallBack);
    }
}
