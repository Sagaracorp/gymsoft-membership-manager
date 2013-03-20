using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using Cinch;
using GymSoft.AuthenticationModule.Services;
using MEFedMVVM.ViewModelLocator;

namespace GymSoft.AuthenticationModule.ViewModels
{
    [ExportViewModel("LoginViewViewModel")]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class LoginViewViewModel : ValidatingViewModelBase
    {
        

        #region Backing Fields
        #region Services
        /// <summary>
        /// Services
        /// </summary>
        private IViewAwareStatus viewAwareStatus;
        private IAuthenticateService authenticateService;
        private IMessageBoxService messageBoxService;
        #endregion
        
        /// <summary>
        /// Backing Fields
        /// </summary>
        private DataWrapper<String> userName;
        private DataWrapper<String> password;
        private readonly IEnumerable<DataWrapperBase> cachedListOfDataWrappers;
        /// <summary>
        /// Validation Rules
        /// </summary>
        private static readonly SimpleRule UserNameCannnotBeEmptyRule;
        private static readonly SimpleRule PasswordCannotBeEmptyRule;
        #endregion

        #region Properties
        /// <summary>
        /// UserName
        /// </summary>
        static PropertyChangedEventArgs userNameArgs =
            ObservableHelper.CreateArgs<LoginViewViewModel>(x => x.UserName);

        public DataWrapper<String> UserName
        {
            get { return userName; }
            set
            {
                userName = value;
                NotifyPropertyChanged(userNameArgs);
            }
        }
        /// <summary>
        /// Password
        /// </summary>
        static PropertyChangedEventArgs passwordArgs =
            ObservableHelper.CreateArgs<LoginViewViewModel>(x => x.Password);

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
        /// Commands
        /// </summary>
        public SimpleCommand<Object, Object> LoginCommand { get; private set; }
        public SimpleCommand<Object, Object> CancelLoginCommand { get; private set; }
        
        /// <summary>
        /// Returns cached collection of DataWrapperBase
        /// </summary>
        public IEnumerable<DataWrapperBase> CachedListOfDataWrappers
        {
            get { return cachedListOfDataWrappers; }
        }
        /// <summary>
        /// Is the View Model Valid
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

        #region Constructors
        [ImportingConstructor]
        public LoginViewViewModel(IViewAwareStatus viewAwareStatus, IAuthenticateService authenticateService, IMessageBoxService messageBoxService)
        {
            //Initialise Services
            this.viewAwareStatus = viewAwareStatus;
            this.authenticateService = authenticateService;
            this.messageBoxService = messageBoxService;
            //Initialise Properties
            UserName = new DataWrapper<string>(this, userNameArgs);
            Password = new DataWrapper<string>(this, passwordArgs);
            cachedListOfDataWrappers =
                DataWrapperHelper.GetWrapperProperties<LoginViewViewModel>(this);

            //Initialise Rules
            userName.AddRule(UserNameCannnotBeEmptyRule);
            password.AddRule(PasswordCannotBeEmptyRule);

            //Initialise Commands
            LoginCommand = new SimpleCommand<object, object>(CanExecuteLoginCommand, ExecuteLoginCommand);
            CancelLoginCommand = new SimpleCommand<object, object>(ExecuteCancelLoginCommand);

        }
        /// <summary>
        /// Static Constructor that defines the validation rules
        /// </summary>
        static LoginViewViewModel()
        {
            UserNameCannnotBeEmptyRule = new SimpleRule("DataValue", "Username cannot be null or empty",
                                        (Object domainObject) =>
                                        {
                                            DataWrapper<String> obj = (DataWrapper<String>)domainObject;
                                            return String.IsNullOrEmpty(obj.DataValue);
                                        });
            PasswordCannotBeEmptyRule = new SimpleRule("DataValue", "Password cannot be null or empty",
                                        (Object domainObject) =>
                                        {
                                            DataWrapper<String> obj = (DataWrapper<String>)domainObject;
                                            return String.IsNullOrEmpty(obj.DataValue);
                                        });
        }
        #endregion

        #region Commands Execution Implementation
        private void ExecuteLoginCommand(Object args)
        {
            //Use Authentication service to check login
            bool loginSuccess = authenticateService.Authenticate(UserName.DataValue.ToLower(), Password.DataValue);
            if (loginSuccess)
            {
                messageBoxService.ShowInformation("Login Success");
            }
            else
            {
                messageBoxService.ShowError("Incorrect username/password combintation");
            }
            //messageBoxService.ShowInformation(String.Format("You clicked login command {0} / {1}", UserName.DataValue,Password.DataValue));
        }
        private bool CanExecuteLoginCommand(Object args)
        {
            return !String.IsNullOrEmpty(UserName.DataValue) && !String.IsNullOrEmpty(Password.DataValue);
        }
        private void ExecuteCancelLoginCommand(Object args)
        {
            UserName.DataValue = String.Empty;
            Password.DataValue = String.Empty;
        }
        #endregion
    }
}
