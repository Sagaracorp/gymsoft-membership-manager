using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Cinch;
using GymSoft.CinchMVVM.Common;
using GymSoft.CinchMVVM.Common.Utilities;
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

        public Uri DefaultPictureDirectory { get; private set; }
        #endregion

        #region Stored Procedures

        private const string FindAllStoredProcedure = "gym_sp_GetAllUsers";
        private const string AddNewUserStoredProcedure = "gym_sp_CreateNewUser";
        private const string UpdateUserStoredProcedure = "gym_sp_UpdateUser";
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

            DefaultPictureDirectory = GymSoftConfigurationManger.GetUserDefaultPictureDirectory();
        }
        public Users FindAll(int buId, int userId)
        {
            MySqlCommand.CommandType = CommandType.StoredProcedure;
            MySqlCommand.CommandText = FindAllStoredProcedure;
            MySqlCommand.Parameters.Clear();
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
                        DataValue = GetStatus((dataTable.Rows[i][(int)UserTableDefinition.Status].ToString()))
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
                        DataValue = (dataTable.Rows[i][(int)UserTableDefinition.Gender].ToString()).ToUpper() == "MALE" ? 
                                    Gender.Male : Gender.Female
                    },
                    PhotoPath = 
                    {
                        DataValue = GetAbsoluteFilePath(dataTable.Rows[i][(int)UserTableDefinition.PhotoPath].ToString())
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

        private Status GetStatus(string p)
        {
            switch (p.Trim().ToUpper())
            {
                case "ACTIVE":
                    return Status.Active;
                case "INACTIVE":
                    return Status.Inactive;
                case "EXPIRED":
                    return Status.Expired;
                default:
                    return Status.Active;
            }
            
        }

        public string GetAbsoluteFilePath(string relativeFilePath)
		{
			string filepath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            filepath = filepath.Substring(0,filepath.LastIndexOf('\\'));
			filepath = filepath.Substring(0, filepath.LastIndexOf('\\'));
			filepath += "\\Userimages\\" + (String.IsNullOrEmpty(relativeFilePath) ? "default.png" : relativeFilePath);
			
			return filepath;
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


        public void CreateNewUserTask(User newUser, Action<Int32> resultCallback, Action<Exception> exceptionCallBack)
        {
            Task<ResultSet<Int32>> task =
                Task.Factory.StartNew(() =>
                {
                    try
                    {
                        int newUserId = AddNewUser(newUser);
                            
                        return new ResultSet<Int32>(newUserId, null);
                    }
                    catch (Exception ex)
                    {
                        return new ResultSet<Int32>(-99, ex);
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

        private int AddNewUser(User newUser, int buId = 1, int userId = 1)
        {
            //Upload image
            var currentPath = newUser.PhotoPath.DataValue;
            newUser.PhotoPath.DataValue = currentPath.Equals(GymSoftConfigurationManger.GetDefaultUserPicture().ToString()) 
                ? currentPath : UploadUserImage(currentPath);
            MySqlCommand.CommandType = CommandType.StoredProcedure;
            MySqlCommand.CommandText = AddNewUserStoredProcedure;
            MySqlCommand.Parameters.Clear();
            MySqlCommand.Parameters.AddWithValue("buid", buId);
            MySqlCommand.Parameters.AddWithValue("userid", userId);

            MySqlCommand.Parameters.AddWithValue("fname", newUser.FirstName.DataValue);
            MySqlCommand.Parameters.AddWithValue("mname", newUser.MiddleName.DataValue);
            MySqlCommand.Parameters.AddWithValue("lname", newUser.LastName.DataValue);
            MySqlCommand.Parameters.AddWithValue("dob", newUser.DateOfBirth.DataValue);
            MySqlCommand.Parameters.AddWithValue("email", newUser.EmailAddress.DataValue);
            MySqlCommand.Parameters.AddWithValue("num1", newUser.ContactNum1.DataValue);
            MySqlCommand.Parameters.AddWithValue("num2", newUser.ContactNum2.DataValue);
            MySqlCommand.Parameters.AddWithValue("num3", newUser.ContactNum3.DataValue);
            MySqlCommand.Parameters.AddWithValue("add1", newUser.Address1.DataValue);
            MySqlCommand.Parameters.AddWithValue("add2", newUser.Address2.DataValue);
            MySqlCommand.Parameters.AddWithValue("add3", newUser.Address3.DataValue);
            MySqlCommand.Parameters.AddWithValue("par", newUser.Parish.DataValue);
            MySqlCommand.Parameters.AddWithValue("sex", newUser.Gender.DataValue.ToString().ToUpper());
            MySqlCommand.Parameters.AddWithValue("photo", newUser.PhotoPath.DataValue);
            MySqlCommand.Parameters.AddWithValue("uname", newUser.UserName.DataValue);
            MySqlCommand.Parameters.AddWithValue("pwd", newUser.Password.DataValue);
            MySqlCommand.Parameters.AddWithValue("status", newUser.Status.DataValue.ToString().ToUpper());
            MySqlCommand.Parameters.AddWithValue("jt", newUser.JobTitle.DataValue);



            MySqlCommand.Parameters.Add(new MySqlParameter("@newUserId", MySqlDbType.Int32));
            MySqlCommand.Parameters["@newUserId"].Direction = ParameterDirection.Output;
            MySqlCommand.Parameters.Add(new MySqlParameter("@result", MySqlDbType.Int32));
            MySqlCommand.Parameters["@result"].Direction = ParameterDirection.Output;
            MySqlCommand.Connection.Open();
            MySqlCommand.ExecuteNonQuery();
            MySqlCommand.Connection.Close();

            int newUserId = (int)MySqlCommand.Parameters["@newUserId"].Value;
            //Update photoPath with new UserId
            
           // newUser.PhotoPath.DataValue = photoPath;
            //UpdateUser(newUser);
            return (int)MySqlCommand.Parameters["@newUserId"].Value;
        }


        

        private string UploadUserImage(string sourceImage)
        {
            //Copy the source image to 

            var currentDirectory = Directory.GetCurrentDirectory();
            var source = new FileInfo(sourceImage);
            string destination = String.Format(@"{0}\{1}\{2}", Directory.GetCurrentDirectory(),
                                               GymSoftConfigurationManger.GetUserDefaultPictureDirectory().ToString(),
                                               source.Name);

            //Copy file only if sourceImageDirectory is not the same as destinationDirectory
            var destinationDirectory = String.Format(@"{0}\{1}", Directory.GetCurrentDirectory(),
                                               GymSoftConfigurationManger.GetUserDefaultPictureDirectory().ToString());
            var sourceImageDirectory = sourceImage.Substring(0, sourceImage.LastIndexOf('\\')); 

            if(!sourceImageDirectory.Equals(destinationDirectory, StringComparison.CurrentCultureIgnoreCase))
                source.CopyTo(destination, true);
            var relativeDestination = source.Name;
            return relativeDestination;
        }


        public void UpdateUserTask(User user, Action<int> resultCallback, Action<Exception> exceptionCallBack)
        {
            Task<ResultSet<Int32>> task =
                Task.Factory.StartNew(() =>
                {
                    try
                    {
                        int userId = UpdateUser(user);

                        return new ResultSet<Int32>(userId, null);
                    }
                    catch (Exception ex)
                    {
                        return new ResultSet<Int32>(-99, ex);
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

        private int UpdateUser(User user, int buId = 1, int userId = 1)
        {
            var currentPath = user.PhotoPath.DataValue;
            user.PhotoPath.DataValue = currentPath.Equals(GymSoftConfigurationManger.GetDefaultUserPicture().ToString())
                ? currentPath : UploadUserImage(currentPath);
            MySqlCommand.CommandType = CommandType.StoredProcedure;
            MySqlCommand.CommandText = UpdateUserStoredProcedure;
            MySqlCommand.Parameters.Clear();
            MySqlCommand.Parameters.AddWithValue("buid", buId);
            MySqlCommand.Parameters.AddWithValue("userid", userId);
            /*buid int, userid int, personid int, userName VARCHAR(1024), 
             * passwd VARCHAR(1024),stat VARCHAR(1024), jt VARCHAR(1024),
             * fname VARCHAR(1024), mname VARCHAR(1024), lname VARCHAR(1024), 
             * dob date,  email VARCHAR(1024),num1 VARCHAR(20), num2 VARCHAR(20), 
             * num3 VARCHAR(20), add1 VARCHAR(1024), add2 VARCHAR(1024), add3 VARCHAR(1024),
             * par VARCHAR(1024), sex VARCHAR(1024), photo VARCHAR(1024), OUT result int*/
            MySqlCommand.Parameters.AddWithValue("persid", user.UserId.DataValue);
            MySqlCommand.Parameters.AddWithValue("fname", user.FirstName.DataValue);
            MySqlCommand.Parameters.AddWithValue("mname", user.MiddleName.DataValue);
            MySqlCommand.Parameters.AddWithValue("lname", user.LastName.DataValue);
            MySqlCommand.Parameters.AddWithValue("dob", user.DateOfBirth.DataValue);
            MySqlCommand.Parameters.AddWithValue("email", user.EmailAddress.DataValue);
            MySqlCommand.Parameters.AddWithValue("num1", user.ContactNum1.DataValue);
            MySqlCommand.Parameters.AddWithValue("num2", user.ContactNum2.DataValue);
            MySqlCommand.Parameters.AddWithValue("num3", user.ContactNum3.DataValue);
            MySqlCommand.Parameters.AddWithValue("add1", user.Address1.DataValue);
            MySqlCommand.Parameters.AddWithValue("add2", user.Address2.DataValue);
            MySqlCommand.Parameters.AddWithValue("add3", user.Address3.DataValue);
            MySqlCommand.Parameters.AddWithValue("par", user.Parish.DataValue);
            MySqlCommand.Parameters.AddWithValue("sex", user.Gender.DataValue);
            MySqlCommand.Parameters.AddWithValue("photo", user.PhotoPath.DataValue);
            MySqlCommand.Parameters.AddWithValue("stat", user.Status.DataValue);
            MySqlCommand.Parameters.AddWithValue("jt", user.JobTitle.DataValue);


            MySqlCommand.Parameters.Add(new MySqlParameter("@result", MySqlDbType.Int32));
            MySqlCommand.Parameters["@result"].Direction = ParameterDirection.Output;
            MySqlCommand.Connection.Open();
            MySqlCommand.ExecuteNonQuery();
            MySqlCommand.Connection.Close();

            return (int)MySqlCommand.Parameters["@result"].Value;
        }
    }
}
