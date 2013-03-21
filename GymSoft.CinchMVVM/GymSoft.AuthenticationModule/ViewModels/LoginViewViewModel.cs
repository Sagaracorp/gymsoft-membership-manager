using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Globalization;
using System.Linq;
using System.Text;
using Cinch;
using GymSoft.AuthenticationModule.Services;
using GymSoft.DB.BusinessUnitsTable;
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
        private IBusinessUnitService businessUnitService;

        #endregion

        /// <summary>
        /// Backing Fields
        /// </summary>
        private DataWrapper<String> userName;

        private DataWrapper<String> password;
        private BusinessUnits businessUnits;
        private DataWrapper<String> selectedBusinessUnit;
        private readonly IEnumerable<DataWrapperBase> cachedListOfDataWrappers;

        /// <summary>
        /// Validation Rules
        /// </summary>
        private static readonly SimpleRule UserNameCannnotBeEmptyRule;
        private static readonly SimpleRule PasswordCannotBeEmptyRule;
        private static readonly SimpleRule SelectedBusinessUnitCannotBeEmpty;

        #endregion

        #region Properties

        /// <summary>
        /// Selected Business Unit
        /// </summary>
        private static PropertyChangedEventArgs selectedbusinessUnitArgs =
            ObservableHelper.CreateArgs<LoginViewViewModel>(x => x.SelectedBusinessUnit);

        public DataWrapper<String> SelectedBusinessUnit
        {
            get { return selectedBusinessUnit; }
            set
            {
                selectedBusinessUnit = value;
                NotifyPropertyChanged(selectedbusinessUnitArgs);
            }
        }

        /// <summary>
        /// Business Units
        /// </summary>
        private static PropertyChangedEventArgs businessUnitsArgs =
            ObservableHelper.CreateArgs<LoginViewViewModel>(x => x.BusinessUnits);

        public BusinessUnits BusinessUnits
        {
            get { return businessUnits; }
            set
            {
                businessUnits = value;
                NotifyPropertyChanged(businessUnitsArgs);
            }
        }

        /// <summary>
        /// UserName
        /// </summary>
        private static PropertyChangedEventArgs userNameArgs =
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
        private static PropertyChangedEventArgs passwordArgs =
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
        public LoginViewViewModel(IViewAwareStatus viewAwareStatus, IAuthenticateService authenticateService,
                                  IMessageBoxService messageBoxService, IBusinessUnitService businessUnitService)
        {
            //Initialise Services
            this.viewAwareStatus = viewAwareStatus;
            this.authenticateService = authenticateService;
            this.messageBoxService = messageBoxService;
            this.businessUnitService = businessUnitService;
            //Initialise Properties
            UserName = new DataWrapper<string>(this, userNameArgs);
            Password = new DataWrapper<string>(this, passwordArgs);
            SelectedBusinessUnit = new DataWrapper<String>(this, businessUnitsArgs);
            this.businessUnits = new BusinessUnits();
            businessUnits = businessUnitService.FindAll(); //Without Threading

            cachedListOfDataWrappers =
                DataWrapperHelper.GetWrapperProperties<LoginViewViewModel>(this);

            //Initialise Rules
            userName.AddRule(UserNameCannnotBeEmptyRule);
            password.AddRule(PasswordCannotBeEmptyRule);
            selectedBusinessUnit.AddRule(SelectedBusinessUnitCannotBeEmpty);

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
                                                                DataWrapper<String> obj =
                                                                    (DataWrapper<String>) domainObject;
                                                                return String.IsNullOrEmpty(obj.DataValue);
                                                            });
            PasswordCannotBeEmptyRule = new SimpleRule("DataValue", "Password cannot be null or empty",
                                                       (Object domainObject) =>
                                                           {
                                                               DataWrapper<String> obj =
                                                                   (DataWrapper<String>) domainObject;
                                                               return String.IsNullOrEmpty(obj.DataValue);
                                                           });
            SelectedBusinessUnitCannotBeEmpty = new SimpleRule("DataValue", "Please select a BU",
                                                               (Object domainObject) =>
                                                                   {
                                                                       DataWrapper<String> obj =
                                                                           (DataWrapper<String>) domainObject;
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
                messageBoxService.ShowInformation(String.Format("Login Success {0} {1} {2}", UserName.DataValue, Password.DataValue,SelectedBusinessUnit.DataValue));
            }
            else
            {
                messageBoxService.ShowError("Incorrect username/password combintation");
            }
            //messageBoxService.ShowInformation(String.Format("You clicked login command {0} / {1}", UserName.DataValue,Password.DataValue));
        }

        private bool CanExecuteLoginCommand(Object args)
        {
            return !String.IsNullOrEmpty(UserName.DataValue) && !String.IsNullOrEmpty(Password.DataValue) && !String.IsNullOrEmpty(SelectedBusinessUnit.DataValue);
        }

        private void ExecuteCancelLoginCommand(Object args)
        {
            UserName.DataValue = String.Empty;
            Password.DataValue = String.Empty;
            SelectedBusinessUnit.DataValue = String.Empty;
        }
        #endregion
    }
}
