using System;
using System.ComponentModel.Composition;
using System.Data;
using System.Threading;
using System.Threading.Tasks;
using Cinch;
using GymSoft.CinchMVVM.Common;
using GymSoft.DB.UsersTable;
using MEFedMVVM.ViewModelLocator;
using MySql.Data.MySqlClient;

namespace GymSoft.DB.BusinessUnitsTable
{
    [ExportService(ServiceType.Runtime, typeof(IBusinessUnitService))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class RuntimeBusinessUnitService : IBusinessUnitService
    {
        #region Properties
        public DataSet BusinessUnitDataSet { get; set; }
        public string ConnectionString { get; private set; }
        public MySqlConnection MySqlConnection { get; private set; }
        public MySqlCommand MySqlCommand { get; private set; }
        public MySqlDataAdapter MySqlDataAdapter { get; private set; }
        #endregion

        #region Stored Procedures
        public static string FindAllStoredProcedure = "gym_sp_GetBUs";
        #endregion

        #region Backgroud Task Method: Easier but I dont like  it much
        private BackgroundTaskManager<object, BusinessUnits> bgWorker =
            new BackgroundTaskManager<object, BusinessUnits>();
        
        
        public void FindAllAsync(object args, Action<BusinessUnits> callback)
        {
            bgWorker.TaskFunc = (argument) => FindAll();
            bgWorker.CompletionAction = callback;
            bgWorker.RunBackgroundTask();
        }
        public BackgroundTaskManager<object, BusinessUnits> BgWorker
        {
            get { return bgWorker; }
        }
        #endregion

        #region Constructor
        [ImportingConstructor]
        public RuntimeBusinessUnitService()
        {
            ConnectionString = GymSoftConfigurationManger.GetDatabaseConnection();
            MySqlConnection = new MySqlConnection(ConnectionString);
            MySqlCommand = MySqlConnection.CreateCommand();
            MySqlDataAdapter = new MySqlDataAdapter();
            BusinessUnitDataSet = new DataSet();
        }
        #endregion

        #region Retrival Methods
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


        #region The Async Task Method: My favorite. Lambdas baby

        void IBusinessUnitService.FindAllTask(Action<BusinessUnits> resultCallback, Action<Exception> exceptionCallBack)
        {
            Task<ResultSet<BusinessUnits>> task =
                Task.Factory.StartNew(() =>
                {
                    try
                    {
                        BusinessUnits businessUnits = FindAll();
                        return new ResultSet<BusinessUnits>(businessUnits, null);
                    }
                    catch (Exception ex)
                    {
                        return new ResultSet<BusinessUnits>(null, ex);
                    }
                });
            task.ContinueWith(r =>
            {
                if (r.Result.Exception != null)
                {
                    //An error occured
                    exceptionCallBack(r.Result.Exception);
                }
                else
                {
                    //Return the results
                    resultCallback(r.Result.Data);
                }
            }, CancellationToken.None, TaskContinuationOptions.None,
                TaskScheduler.FromCurrentSynchronizationContext());
        }
        #endregion
        #endregion
    }
}
