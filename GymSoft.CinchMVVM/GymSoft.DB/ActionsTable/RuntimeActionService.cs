using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using GymSoft.CinchMVVM.Common;
using GymSoft.DB.ActionsTable;
using MEFedMVVM.ViewModelLocator;
using MySql.Data.MySqlClient;

namespace GymSoft.DB.ActionsTable
{
    [ExportService(ServiceType.Runtime, typeof(IActionService))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class RuntimeActionService : IActionService
    {
        #region Properties
        public DataSet ActionDataSet { get; set; }
        public string ConnectionString { get; private set; }
        public MySqlConnection MySqlConnection { get; private set; }
        public MySqlCommand MySqlCommand { get; private set; }
        public MySqlDataAdapter MySqlDataAdapter { get; private set; }
        #endregion

        #region Stored Procedures

        private const string FindAllStoredProcedure = "gym_sp_GetAllActions";
        private const string FindAllActionsForRole = "gym_sp_GetAllActionsForRole";
        private const string FindAllActionsForUser = "gym_sp_GetAllActionsForUser";
        #endregion
        [ImportingConstructor]
        public RuntimeActionService()
        {
            ConnectionString = GymSoftConfigurationManger.GetDatabaseConnection();
            MySqlConnection = new MySqlConnection(ConnectionString);
            MySqlCommand = MySqlConnection.CreateCommand();
            MySqlDataAdapter = new MySqlDataAdapter();
            ActionDataSet = new DataSet();
        }
        public Actions FindAll(int userId = 1, int buId = 1)
        {
            MySqlCommand.CommandType = CommandType.StoredProcedure;
            MySqlCommand.CommandText = FindAllStoredProcedure;
            MySqlCommand.Parameters.Clear();
            MySqlCommand.Parameters.AddWithValue("buid", buId);
            MySqlCommand.Parameters.AddWithValue("userid", userId);
            MySqlCommand.Parameters.Add(new MySqlParameter("@result", MySqlDbType.Int32));
            MySqlCommand.Parameters["@result"].Direction = ParameterDirection.Output;
            MySqlDataAdapter.SelectCommand = MySqlCommand;
            MySqlDataAdapter.Fill(ActionDataSet);

            //Now lets return buis
            var actions = new Actions();
            DataTable dataTable = ActionDataSet.Tables[0]; // Only 1 table



            for (var i = 0; i < dataTable.Rows.Count; i++)
            {
                #region Add to list
                actions.Add(new Action
                {
                    BuId =
                    {
                        DataValue = Int32.Parse(dataTable.Rows[i][(int)ActionTableDefinition.BuId].ToString())
                    },
                    ActionId = 
                    {
                        DataValue = Int32.Parse(dataTable.Rows[i][(int)ActionTableDefinition.ActionId].ToString())
                    },
                    EntityName = 
                    {
                        DataValue = (dataTable.Rows[i][(int)ActionTableDefinition.EntityName].ToString())
                    },
                    AllowedActions = 
                    {
                        DataValue = (dataTable.Rows[i][(int)ActionTableDefinition.AllowedActions].ToString())
                    },
                    FriendlyName = 
                    {
                        DataValue = (dataTable.Rows[i][(int)ActionTableDefinition.FriendlyName].ToString())
                    },
                    Description =
                    {
                        DataValue = (dataTable.Rows[i][(int)ActionTableDefinition.Description].ToString())
                    },
                    CreatedAt =
                    {
                        DataValue = DateTime.Parse(dataTable.Rows[i][(int)ActionTableDefinition.CreatedAt].ToString())
                    },
                    CreatedBy =
                    {
                        DataValue = Int32.Parse(dataTable.Rows[i][(int)ActionTableDefinition.CreatedBy].ToString())
                    },
                    UpdatedAt =
                    {
                        DataValue = DateTime.Parse(dataTable.Rows[i][(int)ActionTableDefinition.UpdatedAt].ToString())
                    },
                    UpdatedBy =
                    {
                        DataValue = Int32.Parse(dataTable.Rows[i][(int)ActionTableDefinition.UpdatedBy].ToString())
                    }
                });
                #endregion

            }
            return actions;
        }
        public Actions FindAllForUser(int personId, int userId = 1, int buId = 1)
        {
            MySqlCommand.CommandType = CommandType.StoredProcedure;
            MySqlCommand.CommandText = FindAllActionsForUser;
            MySqlCommand.Parameters.Clear();
            MySqlCommand.Parameters.AddWithValue("buid", buId);
            MySqlCommand.Parameters.AddWithValue("userid", userId);
            MySqlCommand.Parameters.AddWithValue("personid", personId);
            MySqlCommand.Parameters.Add(new MySqlParameter("@result", MySqlDbType.Int32));
            MySqlCommand.Parameters["@result"].Direction = ParameterDirection.Output;
            MySqlDataAdapter.SelectCommand = MySqlCommand;
            MySqlDataAdapter.Fill(ActionDataSet);

            //Now lets return buis
            var actions = new Actions();
            DataTable dataTable = ActionDataSet.Tables[0]; // Only 1 table



            for (var i = 0; i < dataTable.Rows.Count; i++)
            {
                #region Add to list
                actions.Add(new Action
                {
                    BuId =
                    {
                        DataValue = Int32.Parse(dataTable.Rows[i][(int)ActionTableDefinition.BuId].ToString())
                    },
                    ActionId =
                    {
                        DataValue = Int32.Parse(dataTable.Rows[i][(int)ActionTableDefinition.ActionId].ToString())
                    },
                    EntityName =
                    {
                        DataValue = (dataTable.Rows[i][(int)ActionTableDefinition.EntityName].ToString())
                    },
                    AllowedActions =
                    {
                        DataValue = (dataTable.Rows[i][(int)ActionTableDefinition.AllowedActions].ToString())
                    },
                    FriendlyName =
                    {
                        DataValue = (dataTable.Rows[i][(int)ActionTableDefinition.FriendlyName].ToString())
                    },
                    Description =
                    {
                        DataValue = (dataTable.Rows[i][(int)ActionTableDefinition.Description].ToString())
                    },
                    CreatedAt =
                    {
                        DataValue = DateTime.Parse(dataTable.Rows[i][(int)ActionTableDefinition.CreatedAt].ToString())
                    },
                    CreatedBy =
                    {
                        DataValue = Int32.Parse(dataTable.Rows[i][(int)ActionTableDefinition.CreatedBy].ToString())
                    },
                    UpdatedAt =
                    {
                        DataValue = DateTime.Parse(dataTable.Rows[i][(int)ActionTableDefinition.UpdatedAt].ToString())
                    },
                    UpdatedBy =
                    {
                        DataValue = Int32.Parse(dataTable.Rows[i][(int)ActionTableDefinition.UpdatedBy].ToString())
                    }
                });
                #endregion

            }
            return actions;
        }
        public Actions FindAllForRole(int roleId, int userId = 1, int buId = 1)
        {
            MySqlCommand.CommandType = CommandType.StoredProcedure;
            MySqlCommand.CommandText = FindAllActionsForRole;
            MySqlCommand.Parameters.Clear();
            MySqlCommand.Parameters.AddWithValue("buid", buId);
            MySqlCommand.Parameters.AddWithValue("userid", userId);
            MySqlCommand.Parameters.AddWithValue("roleid", roleId);
            MySqlCommand.Parameters.Add(new MySqlParameter("@result", MySqlDbType.Int32));
            MySqlCommand.Parameters["@result"].Direction = ParameterDirection.Output;
            MySqlDataAdapter.SelectCommand = MySqlCommand;
            MySqlDataAdapter.Fill(ActionDataSet);

            //Now lets return buis
            var actions = new Actions();
            DataTable dataTable = ActionDataSet.Tables[0]; // Only 1 table



            for (var i = 0; i < dataTable.Rows.Count; i++)
            {
                #region Add to list
                actions.Add(new Action
                {
                    BuId =
                    {
                        DataValue = Int32.Parse(dataTable.Rows[i][(int)ActionTableDefinition.BuId].ToString())
                    },
                    ActionId =
                    {
                        DataValue = Int32.Parse(dataTable.Rows[i][(int)ActionTableDefinition.ActionId].ToString())
                    },
                    EntityName =
                    {
                        DataValue = (dataTable.Rows[i][(int)ActionTableDefinition.EntityName].ToString())
                    },
                    AllowedActions =
                    {
                        DataValue = (dataTable.Rows[i][(int)ActionTableDefinition.AllowedActions].ToString())
                    },
                    FriendlyName =
                    {
                        DataValue = (dataTable.Rows[i][(int)ActionTableDefinition.FriendlyName].ToString())
                    },
                    Description =
                    {
                        DataValue = (dataTable.Rows[i][(int)ActionTableDefinition.Description].ToString())
                    },
                    CreatedAt =
                    {
                        DataValue = DateTime.Parse(dataTable.Rows[i][(int)ActionTableDefinition.CreatedAt].ToString())
                    },
                    CreatedBy =
                    {
                        DataValue = Int32.Parse(dataTable.Rows[i][(int)ActionTableDefinition.CreatedBy].ToString())
                    },
                    UpdatedAt =
                    {
                        DataValue = DateTime.Parse(dataTable.Rows[i][(int)ActionTableDefinition.UpdatedAt].ToString())
                    },
                    UpdatedBy =
                    {
                        DataValue = Int32.Parse(dataTable.Rows[i][(int)ActionTableDefinition.UpdatedBy].ToString())
                    }
                });
                #endregion

            }
            return actions;
        }

        public void FindAllTask(Action<Actions> resultCallback, Action<Exception> exceptionCallBack)
        {
            Task<ResultSet<Actions>> task =
                 Task.Factory.StartNew(() =>
                 {
                     try
                     {
                         Actions actions = FindAll();
                         return new ResultSet<Actions>(actions, null);
                     }
                     catch (Exception ex)
                     {
                         return new ResultSet<Actions>(null, ex);
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

        public void FindAllActionsForUserTask(int userId, Action<Actions> resultCallback, Action<Exception> exceptionCallBack)
        {
            Task<ResultSet<Actions>> task =
                 Task.Factory.StartNew(() =>
                 {
                     try
                     {
                         Actions actions = FindAllForUser(userId);
                         return new ResultSet<Actions>(actions, null);
                     }
                     catch (Exception ex)
                     {
                         return new ResultSet<Actions>(null, ex);
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


        public void FindAllActionsForRoleTask(int roleId, Action<Actions> resultCallback, Action<Exception> exceptionCallBack)
        {
            Task<ResultSet<Actions>> task =
                 Task.Factory.StartNew(() =>
                 {
                     try
                     {
                         Actions actions = FindAllForRole(roleId);
                         return new ResultSet<Actions>(actions, null);
                     }
                     catch (Exception ex)
                     {
                         return new ResultSet<Actions>(null, ex);
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



        public Actions FindAllForUser(DataTable userActionsTable, int userId)
        {
            Actions userActions = new Actions();

            DataRow[] userActionRows = userActionsTable.Select(String.Format("userid={0}", userId));
            foreach (var userActionRow in userActionRows)
            {
                #region Add userActions

                userActions.Add(new Action
                    {
                        BuId =
                            {
                                DataValue = Int32.Parse(userActionRow[1].ToString())
                            },
                        ActionId =
                            {
                                DataValue = Int32.Parse(userActionRow[2].ToString())
                            },
                        EntityName =
                            {
                                DataValue = (userActionRow[3].ToString())
                            },
                        AllowedActions =
                            {
                                DataValue = (userActionRow[4].ToString())
                            },
                        FriendlyName =
                            {
                                DataValue = (userActionRow[5].ToString())
                            },
                        Description =
                            {
                                DataValue = (userActionRow[6].ToString())
                            },
                        CreatedAt =
                            {
                                DataValue = DateTime.Parse(userActionRow[7].ToString())
                            },
                        CreatedBy =
                            {
                                DataValue = Int32.Parse(userActionRow[8].ToString())
                            },
                        UpdatedAt =
                            {
                                DataValue = DateTime.Parse(userActionRow[9].ToString())
                            },
                        UpdatedBy =
                            {
                                DataValue = Int32.Parse(userActionRow[10].ToString())
                            }
                    });

                #endregion
                
            }
            return userActions;
        }
    }
}
