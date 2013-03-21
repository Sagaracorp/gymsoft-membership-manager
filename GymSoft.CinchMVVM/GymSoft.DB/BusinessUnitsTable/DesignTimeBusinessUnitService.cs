using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using MEFedMVVM.ViewModelLocator;

namespace GymSoft.DB.BusinessUnitsTable
{
    [ExportService(ServiceType.DesignTime, typeof(IBusinessUnitService))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class DesignTimeBusinessUnitService : IBusinessUnitService
    {
        public BusinessUnits FindAll(int userId)
        {
            BusinessUnits businessUnits = new BusinessUnits();
       
                businessUnits.Add(new BusinessUnit
                    {
                        BuId =
                            {
                                DataValue = 1
                                    
                            },
                        BuName =
                            {
                                DataValue = "Design Business Name"
                            },
                        BuEmailAddress =
                            {
                                DataValue = "designbuemail@gmail.com"
                                    
                            },
                        BuContactNum1 =
                            {
                                DataValue = "18764431234"
                            },
                        BuContactNum2 =
                            {
                                DataValue = "18764431234"
                            },
                        BuContactNum3 =
                            {
                                DataValue = "18764431234"
                                    
                            },
                        BuAddress1 =
                            {
                                DataValue = "13 Design Address Street"
                            },
                        BuAddress2 =
                            {
                                DataValue = "Design Town"
                            },
                        BuAddress3 =
                            {
                                DataValue = ""
                            },
                        BuParish =
                            {
                                DataValue = "Design Parish"
                            },
                        BuCountry =
                            {
                                DataValue = "JamRock"
                            },
                        CreatedAt =
                            {
                                DataValue = DateTime.Now
                            },
                        CreatedBy =
                            {
                                DataValue = 1
                                    
                            },
                        UpdatedAt =
                            {
                                DataValue = DateTime.Now
                            },
                        UpdatedBy =
                            {
                                DataValue = 1
                            }
                    });

            return businessUnits;
        }
        public BusinessUnits FindAll()
        {
            return FindAll(1);
        }


        public void FindAllAsync(object nothing, Action<BusinessUnits> callback)
        {
            return;
        }
    }
}
