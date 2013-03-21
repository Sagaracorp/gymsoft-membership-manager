using System;

namespace GymSoft.DB.BusinessUnitsTable
{
    public interface IBusinessUnitService
    {
        BusinessUnits FindAll(int userId);
        BusinessUnits FindAll();
        void FindAllAsync(object nothing, Action<BusinessUnits> callback);
    }
}
