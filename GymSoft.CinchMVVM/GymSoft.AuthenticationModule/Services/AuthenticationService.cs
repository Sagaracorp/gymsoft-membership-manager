using System.ComponentModel.Composition;
using System.Data;
using GymSoft.CinchMVVM.Common;
using GymSoft.DB.UsersTable;
using MEFedMVVM.ViewModelLocator;
using MySql.Data.MySqlClient;

namespace GymSoft.AuthenticationModule.Services
{
    [PartCreationPolicy(CreationPolicy.Shared)]
    [ExportService(ServiceType.Runtime, typeof(IAuthenticateService))]
    public class AuthenticationService : IAuthenticateService
    {
        private const string AuthenticateUserStoredProcedure = "gym_sp_AuthenticateUser";

        private readonly IUserService userService;

        [ImportingConstructor]
        public AuthenticationService(IUserService userService)
        {
            this.userService = userService;
        }

        public bool Authenticate(string username, string password, int businessUnitId)
        {
            var connectionString = GymSoftConfigurationManger.GetDatabaseConnection();
            var mySqlConnection = new MySqlConnection(connectionString);
            var mySqlCommand = mySqlConnection.CreateCommand();

            mySqlCommand.CommandType = CommandType.StoredProcedure;
            mySqlCommand.CommandText = AuthenticateUserStoredProcedure;
            mySqlCommand.Parameters.AddWithValue("buid", businessUnitId);
            mySqlCommand.Parameters.AddWithValue("uname", username);
            mySqlCommand.Parameters.AddWithValue("pass", password);
            mySqlCommand.Parameters.Add(new MySqlParameter("@uid", MySqlDbType.Int32));
            mySqlCommand.Parameters["@uid"].Direction = ParameterDirection.Output;
            mySqlCommand.Parameters.Add(new MySqlParameter("@result", MySqlDbType.Int32));
            mySqlCommand.Parameters["@result"].Direction = ParameterDirection.Output;
            mySqlCommand.Connection.Open();
            mySqlCommand.ExecuteNonQuery();
            mySqlCommand.Connection.Close();

            if (!string.IsNullOrEmpty(mySqlCommand.Parameters["@uid"].Value.ToString()))
            {
                CurrentUser = new User();
                CurrentUser.UserId.DataValue = (int) mySqlCommand.Parameters["@uid"].Value;
                CurrentUser.UserName.DataValue = username.ToLower();

                CurrentUser = userService.FindById((int)mySqlCommand.Parameters["@uid"].Value, businessUnitId);
                //Load Roles
                //Load Actions
                return true;
            }
            return false;
        }

        public DB.UsersTable.User CurrentUser { get; set; }
    }
}
