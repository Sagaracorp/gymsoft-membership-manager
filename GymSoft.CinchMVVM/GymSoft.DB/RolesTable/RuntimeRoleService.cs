using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using GymSoft.CinchMVVM.Common;
using MEFedMVVM.ViewModelLocator;
using MySql.Data.MySqlClient;

namespace GymSoft.DB.RolesTable
{
    [ExportService(ServiceType.Runtime, typeof(IRoleService))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class RuntimeRoleService : IRoleService
    {
        #region Properties
        public DataSet RoleDataSet { get; set; }
        public string ConnectionString { get; private set; }
        public MySqlConnection MySqlConnection { get; private set; }
        public MySqlCommand MySqlCommand { get; private set; }
        public MySqlDataAdapter MySqlDataAdapter { get; private set; }
        #endregion

        #region Stored Procedures

        private const string FindAllStoredProcedure = "gym_sp_GetAllRoles";
        private const string AddNewRoleStoredProcedure = "gym_sp_CreateNewRole";
        private const string UpdateRoleStoredProcedure = "gym_sp_UpdateRole";
        #endregion

        [ImportingConstructor]
        public RuntimeRoleService()
        {

            ConnectionString = GymSoftConfigurationManger.GetDatabaseConnection();
            MySqlConnection = new MySqlConnection(ConnectionString);
            MySqlCommand = MySqlConnection.CreateCommand();
            MySqlDataAdapter = new MySqlDataAdapter();
            RoleDataSet = new DataSet();
        }

        public Roles FindAll(int userId = 1)
        {
            MySqlCommand.CommandType = CommandType.StoredProcedure;
            MySqlCommand.CommandText = FindAllStoredProcedure;
            MySqlCommand.Parameters.Clear();
            MySqlCommand.Parameters.AddWithValue("userid", userId);
            MySqlCommand.Parameters.Add(new MySqlParameter("@result", MySqlDbType.Int32));
            MySqlCommand.Parameters["@result"].Direction = ParameterDirection.Output;
            MySqlDataAdapter.SelectCommand = MySqlCommand;
            MySqlDataAdapter.Fill(RoleDataSet);

            //Now lets return buis
            var roles = new Roles();
            DataTable dataTable = RoleDataSet.Tables[0]; // Only 1 table



            for (var i = 0; i < dataTable.Rows.Count; i++)
            {
                #region Add to list
                roles.Add(new Role
                {
                    BuId =
                    {
                        DataValue = Int32.Parse(dataTable.Rows[i][(int)RoleTableDefinition.BuId].ToString())
                    },
                    RoleId = 
                    {
                        DataValue = Int32.Parse(dataTable.Rows[i][(int)RoleTableDefinition.RoleId].ToString())
                    },
                    RoleName =
                    {
                        DataValue = (dataTable.Rows[i][(int)RoleTableDefinition.RoleName].ToString())
                    },
                    Description = 
                    {
                        DataValue = (dataTable.Rows[i][(int)RoleTableDefinition.Description].ToString())
                    },
                    CreatedAt =
                    {
                        DataValue = DateTime.Parse(dataTable.Rows[i][(int)RoleTableDefinition.CreatedAt].ToString())
                    },
                    CreatedBy =
                    {
                        DataValue = Int32.Parse(dataTable.Rows[i][(int)RoleTableDefinition.CreatedBy].ToString())
                    },
                    UpdatedAt =
                    {
                        DataValue = DateTime.Parse(dataTable.Rows[i][(int)RoleTableDefinition.UpdatedAt].ToString())
                    },
                    UpdatedBy =
                    {
                        DataValue = Int32.Parse(dataTable.Rows[i][(int)RoleTableDefinition.UpdatedBy].ToString())
                    }
                });
                #endregion

            }
            return roles;
        }
        public void FindAllTask(Action<Roles> resultCallback, Action<Exception> exceptionCallBack)
        {
            Task<ResultSet<Roles>> task =
                 Task.Factory.StartNew(() =>
                 {
                     try
                     {
                         Roles roles = FindAll();
                         return new ResultSet<Roles>(roles, null);
                     }
                     catch (Exception ex)
                     {
                         return new ResultSet<Roles>(null, ex);
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

        public void CreateNewRoleTask(Role newUser, Action<int> resultCallback, Action<Exception> exceptionCallBack)
        {
            throw new NotImplementedException();
        }

        public void UpdateRoleTask(Role user, Action<int> resultCallback, Action<Exception> exceptionCallBack)
        {
            throw new NotImplementedException();
        }
    }
}
