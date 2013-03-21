namespace GymSoft.DB.BusinessUnitsTable
{
    public interface IBusinessUnitService
    {
        BusinessUnits FindAll(int userId);
        BusinessUnits FindAll();
    }
}
