using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Cinch;

namespace GymSoft.DB.UsersTable
{
    public class User : ValidatingObject
    {
        #region Data
        private DataWrapper<Int32> buId;
        private DataWrapper<Int32> userId;
        private DataWrapper<String> userName;
        private static DataWrapper<String> password;

        private DataWrapper<String> confirmPassword;
        private DataWrapper<String> status;
        private DataWrapper<String> jobTitle;
        private DataWrapper<String> firstName;
        private DataWrapper<String> middleName;
        private DataWrapper<String> lastName;
        private DataWrapper<DateTime> dateOfBirth;
        private DataWrapper<String> emailAddress;
        private DataWrapper<String> contactNum1;
        private DataWrapper<String> contactNum2;
        private DataWrapper<String> contactNum3;
        private DataWrapper<String> address1;
        private DataWrapper<String> address2;
        private DataWrapper<String> address3;
        private DataWrapper<String> parish;
        private DataWrapper<String> gender;
        private DataWrapper<Uri> photoPath;
        private DataWrapper<DateTime> createdAt;
        private DataWrapper<Int32> createdBy;
        private DataWrapper<DateTime> updatedAt;
        private DataWrapper<Int32> updatedBy;
        private IEnumerable<DataWrapperBase> cachedListOfDataWrappers;
        #endregion

        #region Rules
        private static SimpleRule FirstNameCannotBeEmptyRule;
        private static SimpleRule LastNameCannotBeEmptyRule;
        private static SimpleRule UserNameCannotBeEmptyRule;
        private static SimpleRule PasswordCannotBeEmptyRule;
        private static SimpleRule ConfrimPasswordCannotBeEmptyRule;
        private static SimpleRule ConfirmPasswordAndPasswordMustBeEqualRule;
        private static SimpleRule StatusCannotBeEmptyRule;
        private static SimpleRule JobTitleCannotBeEmpyRule;
        private static SimpleRule EmailAddressMustBeInCorrectFormat;

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
            FirstName = new DataWrapper<String>(this, firstNameArgs);
            MiddleName = new DataWrapper<String>(this, middleNameArgs); ;
            LastName = new DataWrapper<String>(this, lastNameArgs); ;
            DateOfBirth = new DataWrapper<DateTime>(this, dateOfBirthArgs); ;
            EmailAddress = new DataWrapper<String>(this, emailAddressArgs); ;
            ContactNum1 = new DataWrapper<String>(this, contactNum1Args); ;
            ContactNum2 = new DataWrapper<String>(this, contactNum2Args); ;
            ContactNum3 = new DataWrapper<String>(this, contactNum3Args); ;
            Address1 = new DataWrapper<String>(this, address1Args); ;
            Address2 = new DataWrapper<String>(this, address2Args); ;
            Address3 = new DataWrapper<String>(this, address3Args); ;
            Parish = new DataWrapper<String>(this, parishArgs); ;
            Gender = new DataWrapper<String>(this, genderArgs); ;
            PhotoPath = new DataWrapper<Uri>(this, photoPathArgs); ;
            CreatedAt = new DataWrapper<DateTime>(this, createdAtArgs);
            CreatedBy = new DataWrapper<Int32>(this, createdByArgs);
            UpdatedAt = new DataWrapper<DateTime>(this, updatedAtArgs);
            UpdatedBy = new DataWrapper<Int32>(this, updatedByArgs);

        
            //fetch list of all DataWrappers, so they can be used again later without the
            //need for reflection
            cachedListOfDataWrappers =
                DataWrapperHelper.GetWrapperProperties<User>(this);

            #region Create Validation Rules
            firstName.AddRule(FirstNameCannotBeEmptyRule);
            lastName.AddRule(LastNameCannotBeEmptyRule);
            userName.AddRule(UserNameCannotBeEmptyRule);
            password.AddRule(PasswordCannotBeEmptyRule);
            confirmPassword.AddRule(ConfrimPasswordCannotBeEmptyRule);
            confirmPassword.AddRule(ConfirmPasswordAndPasswordMustBeEqualRule);
            status.AddRule(StatusCannotBeEmptyRule);
            jobTitle.AddRule(JobTitleCannotBeEmpyRule);
            emailAddress.AddRule(EmailAddressMustBeInCorrectFormat);
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
            ConfirmPasswordAndPasswordMustBeEqualRule = new SimpleRule("DataValue", "Confirm Password must equal Password",
                       (Object domainObject) =>
                       {
                           DataWrapper<String> obj = (DataWrapper<String>)domainObject;
                           return String.Compare(obj.DataValue, password.DataValue, StringComparison.Ordinal) != 0;
                       });
            
            StatusCannotBeEmptyRule = new SimpleRule("DataValue", "Status can not be empty",
                       (Object domainObject) =>
                       {
                           DataWrapper<String> obj = (DataWrapper<String>)domainObject;
                           return String.IsNullOrEmpty(obj.DataValue);
                       });
            JobTitleCannotBeEmpyRule = new SimpleRule("DataValue", "Job Title can not be empty",
                       (Object domainObject) =>
                       {
                           DataWrapper<String> obj = (DataWrapper<String>)domainObject;
                           return String.IsNullOrEmpty(obj.DataValue);
                       });
            FirstNameCannotBeEmptyRule = new SimpleRule("DataValue", "First Name can not be empty",
                       (Object domainObject) =>
                       {
                           DataWrapper<String> obj = (DataWrapper<String>)domainObject;
                           return String.IsNullOrEmpty(obj.DataValue);
                       });
            LastNameCannotBeEmptyRule = new SimpleRule("DataValue", "Last Name can not be empty",
                       (Object domainObject) =>
                       {
                           DataWrapper<String> obj = (DataWrapper<String>)domainObject;
                           return String.IsNullOrEmpty(obj.DataValue);
                       });
            EmailAddressMustBeInCorrectFormat = new SimpleRule("DataValue", "Email Address must be in correct format",
                       (Object domainObject) =>
                       {
                           DataWrapper<String> obj = (DataWrapper<String>)domainObject;
                           if (obj.DataValue != null)
                           {
                               Regex re = new Regex(@"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*"
                                                    + "@"
                                                    + @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$",
                                                    RegexOptions.IgnoreCase);
                               return !re.IsMatch(obj.DataValue.ToLower());
                           }
                           else
                           {
                               return true;
                           }
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
            set 
            { 
                password = value;
                NotifyPropertyChanged(passwordArgs); 
            }
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
        /// FirstName
        /// </summary>
        static PropertyChangedEventArgs firstNameArgs =
            ObservableHelper.CreateArgs<User>(x => x.FirstName);
        public DataWrapper<String> FirstName
        {
            get { return firstName; }
            set { firstName = value; NotifyPropertyChanged(firstNameArgs); }
        }
        /// <summary>
        /// LastName
        /// </summary>
        static PropertyChangedEventArgs lastNameArgs =
            ObservableHelper.CreateArgs<User>(x => x.LastName);
        public DataWrapper<String> LastName
        {
            get { return lastName; }
            set { lastName = value; NotifyPropertyChanged(lastNameArgs); }
        }
        /// <summary>
        /// MiddleName
        /// </summary>
        static PropertyChangedEventArgs middleNameArgs =
            ObservableHelper.CreateArgs<User>(x => x.MiddleName);
        public DataWrapper<String> MiddleName
        {
            get { return middleName; }
            set { middleName = value; NotifyPropertyChanged(middleNameArgs); }
        }
        /// <summary>
        /// DateOfBirth
        /// </summary>
        static PropertyChangedEventArgs dateOfBirthArgs =
            ObservableHelper.CreateArgs<User>(x => x.DateOfBirth);
        public DataWrapper<DateTime> DateOfBirth
        {
            get { return dateOfBirth; }
            set { dateOfBirth = value; NotifyPropertyChanged(dateOfBirthArgs); }
        }
        /// <summary>
        /// EmailAddress
        /// </summary>
        static PropertyChangedEventArgs emailAddressArgs =
            ObservableHelper.CreateArgs<User>(x => x.EmailAddress);
        public DataWrapper<String> EmailAddress
        {
            get { return emailAddress; }
            set { emailAddress = value; NotifyPropertyChanged(emailAddressArgs); }
        }
        /// <summary>
        /// ContactNum1
        /// </summary>
        static PropertyChangedEventArgs contactNum1Args =
            ObservableHelper.CreateArgs<User>(x => x.ContactNum1);
        public DataWrapper<String> ContactNum1
        {
            get { return contactNum1; }
            set { contactNum1 = value; NotifyPropertyChanged(contactNum1Args); }
        }
        /// <summary>
        /// ContactNum2
        /// </summary>
        static PropertyChangedEventArgs contactNum2Args =
            ObservableHelper.CreateArgs<User>(x => x.ContactNum2);
        public DataWrapper<String> ContactNum2
        {
            get { return contactNum2; }
            set { contactNum2 = value; NotifyPropertyChanged(contactNum2Args); }
        }
        /// <summary>
        /// ContactNum3
        /// </summary>
        static PropertyChangedEventArgs contactNum3Args =
            ObservableHelper.CreateArgs<User>(x => x.ContactNum3);
        public DataWrapper<String> ContactNum3
        {
            get { return contactNum3; }
            set { contactNum3 = value; NotifyPropertyChanged(contactNum3Args); }
        }
        /// <summary>
        /// Address2
        /// </summary>
        static PropertyChangedEventArgs address2Args =
            ObservableHelper.CreateArgs<User>(x => x.Address2);
        public DataWrapper<String> Address2
        {
            get { return address2; }
            set { address2 = value; NotifyPropertyChanged(address2Args); }
        }
        /// <summary>
        /// Address3
        /// </summary>
        static PropertyChangedEventArgs address3Args =
            ObservableHelper.CreateArgs<User>(x => x.Address3);
        public DataWrapper<String> Address3
        {
            get { return address3; }
            set { address3 = value; NotifyPropertyChanged(address3Args); }
        }
        /// <summary>
        /// Address1
        /// </summary>
        static PropertyChangedEventArgs address1Args =
            ObservableHelper.CreateArgs<User>(x => x.Address1);
        public DataWrapper<String> Address1
        {
            get { return address1; }
            set { address1 = value; NotifyPropertyChanged(address1Args); }
        }
        /// <summary>
        /// Parish
        /// </summary>
        static PropertyChangedEventArgs parishArgs =
            ObservableHelper.CreateArgs<User>(x => x.Parish);
        public DataWrapper<String> Parish
        {
            get { return parish; }
            set { parish = value; NotifyPropertyChanged(parishArgs); }
        }
        /// <summary>
        /// Gender
        /// </summary>
        static PropertyChangedEventArgs genderArgs =
            ObservableHelper.CreateArgs<User>(x => x.Gender);
        public DataWrapper<String> Gender
        {
            get { return gender; }
            set { gender = value; NotifyPropertyChanged(genderArgs); }
        }
        /// <summary>
        /// PhotoPath
        /// </summary>
        static PropertyChangedEventArgs photoPathArgs =
            ObservableHelper.CreateArgs<User>(x => x.PhotoPath);
        public DataWrapper<Uri> PhotoPath
        {
            get { return photoPath; }
            set { photoPath = value; NotifyPropertyChanged(photoPathArgs); }
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