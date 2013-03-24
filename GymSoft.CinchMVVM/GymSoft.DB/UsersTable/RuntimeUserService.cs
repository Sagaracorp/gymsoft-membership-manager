﻿using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Cinch;
using GymSoft.CinchMVVM.Common;
using GymSoft.DB.BusinessUnitsTable;
using MEFedMVVM.ViewModelLocator;
using MySql.Data.MySqlClient;

namespace GymSoft.DB.UsersTable
{
    [ExportService(ServiceType.Runtime, typeof(IUserService))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class RuntimeUserService : IUserService
    {
        #region Properties
        public DataSet UserDataSet { get; set; }
        public string ConnectionString { get; private set; }
        public MySqlConnection MySqlConnection { get; private set; }
        public MySqlCommand MySqlCommand { get; private set; }
        public MySqlDataAdapter MySqlDataAdapter { get; private set; }
        #endregion

        #region Stored Procedures
        public static string FindAllStoredProcedure = "gym_sp_GetAllUsers";
        #endregion

        #region Backgroud Task Method: Easier but I dont like  it much
        private readonly BackgroundTaskManager<object, Users> bgWorker =
            new BackgroundTaskManager<object, Users>();


        public void FindAllAsync(object args, Action<Users> callback)
        {
            bgWorker.TaskFunc = (argument) => FindAll();
            bgWorker.CompletionAction = callback;
            bgWorker.RunBackgroundTask();
        }
        public BackgroundTaskManager<object, Users> BgWorker
        {
            get { return bgWorker; }
        }
        #endregion

        [ImportingConstructor]
        public RuntimeUserService()
        {
            ConnectionString = GymSoftConfigurationManger.GetDatabaseConnection();
            MySqlConnection = new MySqlConnection(ConnectionString);
            MySqlCommand = MySqlConnection.CreateCommand();
            MySqlDataAdapter = new MySqlDataAdapter();
            UserDataSet = new DataSet();
        }
        public Users FindAll(int buId, int userId)
        {
            MySqlCommand.CommandType = CommandType.StoredProcedure;
            MySqlCommand.CommandText = FindAllStoredProcedure;
            MySqlCommand.Parameters.AddWithValue("buid", userId);
            MySqlCommand.Parameters.AddWithValue("userid", userId);
            MySqlCommand.Parameters.Add(new MySqlParameter("@result", MySqlDbType.Int32));
            MySqlCommand.Parameters["@result"].Direction = ParameterDirection.Output;
            MySqlDataAdapter.SelectCommand = MySqlCommand;
            MySqlDataAdapter.Fill(UserDataSet);

            //Now lets return buis
            var users = new Users();
            DataTable dataTable = UserDataSet.Tables[0]; // Only 1 table
            for (var i = 0; i < dataTable.Rows.Count; i++)
            {
                #region Add to list
                users.Add(new User
                {
                    BuId =
                    {
                        DataValue = Int32.Parse(dataTable.Rows[i][(int)UserTableDefinition.BuId].ToString())
                    },
                    UserId = 
                    {
                        DataValue = Int32.Parse(dataTable.Rows[i][(int)UserTableDefinition.UserId].ToString())
                    },
                    UserName = 
                    {
                        DataValue = (dataTable.Rows[i][(int)UserTableDefinition.UserName].ToString())
                    },
                    Password = 
                    {
                        DataValue = (dataTable.Rows[i][(int)UserTableDefinition.Password].ToString())
                    },
                    Status = 
                    {
                        DataValue = (dataTable.Rows[i][(int)UserTableDefinition.Status].ToString())
                    },
                    JobTitle = 
                    {
                        DataValue = (dataTable.Rows[i][(int)UserTableDefinition.JobTitle].ToString())
                    },
                    FirstName = 
                    {
                        DataValue = (dataTable.Rows[i][(int)UserTableDefinition.FirstName].ToString())
                    },
                    MiddleName = 
                    {
                        DataValue = (dataTable.Rows[i][(int)UserTableDefinition.MiddleName].ToString())
                    },
                    LastName = 
                    {
                        DataValue = (dataTable.Rows[i][(int)UserTableDefinition.LastName].ToString())
                    },
                    DateOfBirth = 
                    {
                        DataValue = DateTime.Parse((dataTable.Rows[i][(int)UserTableDefinition.DateOfBirth].ToString()))
                    },
                    EmailAddress = 
                    {
                        DataValue = (dataTable.Rows[i][(int)UserTableDefinition.EmailAddress].ToString())
                    },
                    ContactNum1 =
                    {
                        DataValue = (dataTable.Rows[i][(int)UserTableDefinition.ContactNum1].ToString())
                    },
                    ContactNum2 =
                    {
                        DataValue = (dataTable.Rows[i][(int)UserTableDefinition.ContactNum2].ToString())
                    },
                    ContactNum3 =
                    {
                        DataValue = (dataTable.Rows[i][(int)UserTableDefinition.ContactNum3].ToString())
                    },
                    Address1 =
                    {
                        DataValue = (dataTable.Rows[i][(int)UserTableDefinition.Address1].ToString())
                    },
                    Address2 =
                    {
                        DataValue = (dataTable.Rows[i][(int)UserTableDefinition.Address2].ToString())
                    },
                    Address3 =
                    {
                        DataValue = (dataTable.Rows[i][(int)UserTableDefinition.Address3].ToString())
                    },
                    Parish =
                    {
                        DataValue = (dataTable.Rows[i][(int)UserTableDefinition.Parish].ToString())
                    },
                    Gender = 
                    {
                        DataValue = (dataTable.Rows[i][(int)UserTableDefinition.Gender].ToString())
                    },
                    PhotoPath = 
                    {
                        DataValue = new Uri(dataTable.Rows[i][(int)UserTableDefinition.PhotoPath].ToString(), UriKind.RelativeOrAbsolute)
                    },
                    CreatedAt =
                    {
                        DataValue = DateTime.Parse(dataTable.Rows[i][(int)UserTableDefinition.CreatedAt].ToString())
                    },
                    CreatedBy =
                    {
                        DataValue = Int32.Parse(dataTable.Rows[i][(int)UserTableDefinition.CreatedBy].ToString())
                    },
                    UpdatedAt =
                    {
                        DataValue = DateTime.Parse(dataTable.Rows[i][(int)UserTableDefinition.UpdatedAt].ToString())
                    },
                    UpdatedBy =
                    {
                        DataValue = Int32.Parse(dataTable.Rows[i][(int)UserTableDefinition.UpdatedBy].ToString())
                    }
                });
                #endregion

            }
            return users;
        }

        public Users FindAll()
        {
            return FindAll(1, 1);
        }

        void IUserService.FindAllTask(Action<Users> resultCallback, Action<Exception> exceptionCallBack)
        {
            Task<ResultSet<Users>> task =
                Task.Factory.StartNew(() =>
                {
                    try
                    {
                        Users users = FindAll();
                        return new ResultSet<Users>(users, null);
                    }
                    catch (Exception ex)
                    {
                        return new ResultSet<Users>(null, ex);
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
    }
}
