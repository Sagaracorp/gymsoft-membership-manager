using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Cinch;

namespace GymSoft.DB.UsersTable
{
    public class User : ValidatingObject
    {
        #region Data
        private DataWrapper<Int32> buId;
        private DataWrapper<Int32> userId;
        private DataWrapper<String> userName;
        private DataWrapper<String> password;
        private DataWrapper<String> confirmPassword;
        private DataWrapper<String> status;
        private DataWrapper<String> jobTitle;
        private DataWrapper<DateTime> createdAt;
        private DataWrapper<Int32> createdBy;
        private DataWrapper<DateTime> updatedAt;
        private DataWrapper<Int32> updatedBy;
        private IEnumerable<DataWrapperBase> cachedListOfDataWrappers;
        #endregion

        #region Rules

        private static SimpleRule UserNameCannotBeEmptyRule;
        private static SimpleRule PasswordCannotBeEmptyRule;
        private static SimpleRule ConfrimPasswordCannotBeEmptyRule;
        private static SimpleRule ConfirmPasswordAndPasswordMustBeEqualRule;
        private static SimpleRule StatusCannotBeEmptyRule;
        private static SimpleRule JobTitleCannotBeEmpyRule;

        #endregion

        #region Constructors

        public User()
        {
            BuId = new DataWrapper<Int32>(this,buIdArgs);
            UserId = new DataWrapper<Int32>(this,userIdArgs);
            UserName = new DataWrapper<String>(this, userNameArgs);
            Password = new DataWrapper<String>(this, passwordArgs);
            ConfirmPassword = new DataWrapper<String>(this, confirmPasswordArgs);
            Status = new DataWrapper<String>(this, statusArgs);
            JobTitle = new DataWrapper<String>(this, jobTitleArgs);
            CreatedAt = new DataWrapper<DateTime>(this, createdAtArgs);
            CreatedBy = new DataWrapper<Int32>(this, createdByArgs);
            UpdatedAt = new DataWrapper<DateTime>(this, updatedAtArgs);
            UpdatedBy = new DataWrapper<Int32>(this, updatedByArgs);

            //fetch list of all DataWrappers, so they can be used again later without the
            //need for reflection
            cachedListOfDataWrappers =
                DataWrapperHelper.GetWrapperProperties<User>(this);

            #region Create Validation Rules
            userName.AddRule(UserNameCannotBeEmptyRule);
            password.AddRule(PasswordCannotBeEmptyRule);
            confirmPassword.AddRule(ConfrimPasswordCannotBeEmptyRule);
            confirmPassword.AddRule(ConfirmPasswordAndPasswordMustBeEqualRule);
            status.AddRule(StatusCannotBeEmptyRule);
            jobTitle.AddRule(JobTitleCannotBeEmpyRule);
            #endregion
        }

        static User()
        {
            UserNameCannotBeEmptyRule = new SimpleRule("DataValue", "User Name can not be empty",
                       (Object domainObject) =>
                       {
                           DataWrapper<String> obj = (DataWrapper<String>)domainObject;
                           return String.IsNullOrEmpty(obj.DataValue);
                       });
            PasswordCannotBeEmptyRule = new SimpleRule("DataValue", "Password can not be empty",
                       (Object domainObject) =>
                       {
                           DataWrapper<String> obj = (DataWrapper<String>)domainObject;
                           return String.IsNullOrEmpty(obj.DataValue);
                       });
            ConfrimPasswordCannotBeEmptyRule = new SimpleRule("DataValue", "Confirm Password can not be empty",
                       (Object domainObject) =>
                       {
                           DataWrapper<String> obj = (DataWrapper<String>)domainObject;
                           return String.IsNullOrEmpty(obj.DataValue);
                       });
            StatusCannotBeEmptyRule = new SimpleRule("DataValue", "Status can not be empty",
                       (Object domainObject) =>
                       {
                           DataWrapper<String> obj = (DataWrapper<String>)domainObject;
                           return String.IsNullOrEmpty(obj.DataValue);
                       });
            JobTitleCannotBeEmpyRule = new SimpleRule("DataValue", "Password can not be empty",
                       (Object domainObject) =>
                       {
                           DataWrapper<String> obj = (DataWrapper<String>)domainObject;
                           return String.IsNullOrEmpty(obj.DataValue);
                       });
        }
        #endregion

        #region Public Properties
        /// <summary>
        /// BuId
        /// </summary>
        static PropertyChangedEventArgs buIdArgs =
            ObservableHelper.CreateArgs<User>(x => x.BuId);
        public DataWrapper<Int32> BuId
        {
            get { return buId; }
            set { buId = value; NotifyPropertyChanged(buIdArgs); }
        }
        /// <summary>
        /// UserId
        /// </summary>
        static PropertyChangedEventArgs userIdArgs =
            ObservableHelper.CreateArgs<User>(x => x.UserId);
        public DataWrapper<Int32> UserId
        {
            get { return userId; }
            set { userId = value; NotifyPropertyChanged(userIdArgs); }
        }
        /// <summary>
        /// UserName
        /// </summary>
        static PropertyChangedEventArgs userNameArgs =
            ObservableHelper.CreateArgs<User>(x => x.UserName);
        public DataWrapper<String> UserName
        {
            get { return userName; }
            set { userName = value; NotifyPropertyChanged(userNameArgs); }
        }
        /// <summary>
        /// Password
        /// </summary>
        static PropertyChangedEventArgs passwordArgs =
            ObservableHelper.CreateArgs<User>(x => x.Password);
        public DataWrapper<String> Password
        {
            get { return password; }
            set { password = value; NotifyPropertyChanged(passwordArgs); }
        }
        /// <summary>
        /// Confirm Password
        /// </summary>
        static PropertyChangedEventArgs confirmPasswordArgs =
            ObservableHelper.CreateArgs<User>(x => x.ConfirmPassword);
        public DataWrapper<String> ConfirmPassword
        {
            get { return confirmPassword; }
            set { confirmPassword = value; NotifyPropertyChanged(confirmPasswordArgs); }
        }
        /// <summary>
        /// Status
        /// </summary>
        static PropertyChangedEventArgs statusArgs =
            ObservableHelper.CreateArgs<User>(x => x.Status);
        public DataWrapper<String> Status
        {
            get { return status; }
            set { status = value; NotifyPropertyChanged(statusArgs); }
        }
        /// <summary>
        /// JobTitle
        /// </summary>
        static PropertyChangedEventArgs jobTitleArgs =
            ObservableHelper.CreateArgs<User>(x => x.JobTitle);
        public DataWrapper<String> JobTitle
        {
            get { return jobTitle; }
            set { jobTitle = value; NotifyPropertyChanged(jobTitleArgs); }
        }
        /// <summary>
        /// CreatedAt
        /// </summary>
        static PropertyChangedEventArgs createdAtArgs =
            ObservableHelper.CreateArgs<User>(x => x.CreatedAt);
        public DataWrapper<DateTime> CreatedAt
        {
            get { return createdAt; }
            set { createdAt = value; NotifyPropertyChanged(createdAtArgs); }
        }
        /// <summary>
        /// CreatedBy
        /// </summary>
        static PropertyChangedEventArgs createdByArgs =
            ObservableHelper.CreateArgs<User>(x => x.CreatedBy);
        public DataWrapper<Int32> CreatedBy
        {
            get { return createdBy; }
            set { createdBy = value; NotifyPropertyChanged(createdByArgs); }
        }
        /// <summary>
        /// UpdatedAt
        /// </summary>
        static PropertyChangedEventArgs updatedAtArgs =
            ObservableHelper.CreateArgs<User>(x => x.UpdatedAt);
        public DataWrapper<DateTime> UpdatedAt
        {
            get { return updatedAt; }
            set { updatedAt = value; NotifyPropertyChanged(updatedAtArgs); }
        }
        /// <summary>
        /// UpdatedBy
        /// </summary>
        static PropertyChangedEventArgs updatedByArgs =
            ObservableHelper.CreateArgs<User>(x => x.UpdatedBy);
        public DataWrapper<Int32> UpdatedBy
        {
            get { return updatedBy; }
            set { updatedBy = value; NotifyPropertyChanged(updatedByArgs); }
        }
        #endregion
        #region Overrides

        /// <summary>
        /// Is the Model Valid
        /// </summary>
        public override bool IsValid
        {
            get
            {
                //return base.IsValid and use DataWrapperHelper, if you are
                //using DataWrappers
                return base.IsValid &&
                    DataWrapperHelper.AllValid(cachedListOfDataWrappers);
            }
        }
        #endregion
        
    }
    public class Users : DispatcherNotifiedObservableCollection<User>
    {
    }
}
