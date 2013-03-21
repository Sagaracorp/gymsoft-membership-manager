using System;
using System.ComponentModel.Composition;
using System.Data;
using MEFedMVVM.ViewModelLocator;
using MySql.Data.MySqlClient;

namespace GymSoft.DB.BusinessUnitsTable
{
    [ExportService(ServiceType.Runtime, typeof(IBusinessUnitService))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class RuntimeBusinessUnitService : IBusinessUnitService
    {
        public DataSet BusinessUnitDataSet { get; set; }
        public string ConnectionString { get; set; }
        public MySqlConnection MySqlConnection { get; set; }
        public MySqlCommand MySqlCommand { get; set; }
        public MySqlDataAdapter MySqlDataAdapter { get; set; }
        #region Stored Procedures
        public static string FindAllStoredProcedure = "gym_sp_GetBUs";
        #endregion
        
        
        public RuntimeBusinessUnitService()
        {
            //To Do ..find a way to move this into a configuration file
            ConnectionString = "Server=gymsoft.db.10266153.hostedresource.com; Port=3306; Database=gymsoft; Uid=gymsoft; Pwd='G3tf!t12';";

            //ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["gymsoftdb"].ConnectionString;
            MySqlConnection = new MySqlConnection(ConnectionString);
            MySqlCommand = MySqlConnection.CreateCommand();
            MySqlDataAdapter = new MySqlDataAdapter();
            BusinessUnitDataSet = new DataSet();
        }
        /// <summary>
        /// Returns All Business Units in the table
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>BusinessUnits</returns>
    
        public BusinessUnits FindAll(int userId)
        {
            MySqlCommand.CommandType = CommandType.StoredProcedure;
            MySqlCommand.CommandText = FindAllStoredProcedure;
            MySqlCommand.Parameters.AddWithValue("userid", userId);
            MySqlCommand.Parameters.Add(new MySqlParameter("@result", MySqlDbType.Int32));
            MySqlCommand.Parameters["@result"].Direction = ParameterDirection.Output;
            MySqlDataAdapter.SelectCommand = MySqlCommand;
            MySqlDataAdapter.Fill(BusinessUnitDataSet);

            //Now lets return buis
            var businessUnits = new BusinessUnits();
            DataTable dataTable = BusinessUnitDataSet.Tables[0]; // Only 1 table
            for (var i = 0; i < dataTable.Rows.Count; i++)
            {
                #region Add to list
                businessUnits.Add(new BusinessUnit
                {
                    BuId =
                    {
                        DataValue = Int32.Parse(dataTable.Rows[i][(int)BusinessUnitTableDefinition.BuId].ToString())
                    },
                    BuName =
                    {
                        DataValue = (dataTable.Rows[i][(int)BusinessUnitTableDefinition.BuName].ToString())
                    },
                    BuEmailAddress =
                    {
                        DataValue = (dataTable.Rows[i][(int)BusinessUnitTableDefinition.BuEmailAddress].ToString())
                    },
                    BuContactNum1 =
                    {
                        DataValue = (dataTable.Rows[i][(int)BusinessUnitTableDefinition.BuContactNum1].ToString())
                    },
                    BuContactNum2 =
                    {
                        DataValue = (dataTable.Rows[i][(int)BusinessUnitTableDefinition.BuContactNum2].ToString())
                    },
                    BuContactNum3 =
                    {
                        DataValue = (dataTable.Rows[i][(int)BusinessUnitTableDefinition.BuContactNum3].ToString())
                    },
                    BuAddress1 =
                    {
                        DataValue = (dataTable.Rows[i][(int)BusinessUnitTableDefinition.BuAddress1].ToString())
                    },
                    BuAddress2 =
                    {
                        DataValue = (dataTable.Rows[i][(int)BusinessUnitTableDefinition.BuAddress2].ToString())
                    },
                    BuAddress3 =
                    {
                        DataValue = (dataTable.Rows[i][(int)BusinessUnitTableDefinition.BuAddress3].ToString())
                    },
                    BuParish =
                    {
                        DataValue = (dataTable.Rows[i][(int)BusinessUnitTableDefinition.BuParish].ToString())
                    },
                    BuCountry =
                    {
                        DataValue = (dataTable.Rows[i][(int)BusinessUnitTableDefinition.BuCountry].ToString())
                    },
                    CreatedAt =
                    {
                        DataValue = DateTime.Parse(dataTable.Rows[i][(int)BusinessUnitTableDefinition.CreatedAt].ToString())
                    },
                    CreatedBy =
                    {
                        DataValue = Int32.Parse(dataTable.Rows[i][(int)BusinessUnitTableDefinition.CreatedBy].ToString())
                    },
                    UpdatedAt =
                    {
                        DataValue = DateTime.Parse(dataTable.Rows[i][(int)BusinessUnitTableDefinition.UpdatedAt].ToString())
                    },
                    UpdatedBy =
                    {
                        DataValue = Int32.Parse(dataTable.Rows[i][(int)BusinessUnitTableDefinition.UpdatedBy].ToString())
                    }
                });
                #endregion
                
            }
            return businessUnits;
        }

        public BusinessUnits FindAll()
        {
            return FindAll(1); //Default user id 
        }
    }
}
