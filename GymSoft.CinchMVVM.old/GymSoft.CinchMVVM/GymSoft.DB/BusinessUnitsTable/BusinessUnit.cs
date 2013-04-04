using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Cinch;

namespace GymSoft.DB.BusinessUnitsTable
{
    public class BusinessUnit : ValidatingObject
    {
        #region Data
        private DataWrapper<Int32> buId;
        private DataWrapper<String> buName; 
        private DataWrapper<String> buEmailAddress;
        private DataWrapper<String> buContactNum1;
        private DataWrapper<String> buContactNum2;
        private DataWrapper<String> buContactNum3;
        private DataWrapper<String> buAddress1;
        private DataWrapper<String> buAddress2;
        private DataWrapper<String> buAddress3;
        private DataWrapper<String> buParish;
        private DataWrapper<String> buCountry;
        private DataWrapper<DateTime> createdAt;
        private DataWrapper<Int32> createdBy;
        private DataWrapper<DateTime> updatedAt;
        private DataWrapper<Int32> updatedBy;
        private IEnumerable<DataWrapperBase> cachedListOfDataWrappers;

        //Rules
        private static SimpleRule BusinessNameRule;
        private static SimpleRule BusinessAddress1Rule;
        private static SimpleRule BusinessParishRule;
        private static SimpleRule BusinessCountryRule;
       #endregion
        #region Constructors

        public BusinessUnit()
        {
            BuId = new DataWrapper<Int32>(this,buIdArgs);
            BuName = new DataWrapper<String>(this,buNameArgs);
            BuEmailAddress = new DataWrapper<String>(this, buEmailAddressArgs);
            BuContactNum1 = new DataWrapper<String>(this, buContactNum1Args);
            BuContactNum2 = new DataWrapper<String>(this, buContactNum2Args);
            BuContactNum3 = new DataWrapper<String>(this, buContactNum3Args);
            BuAddress1 = new DataWrapper<String>(this, buAddress1Args);
            BuAddress2 = new DataWrapper<String>(this, buAddress2Args);
            BuAddress3 = new DataWrapper<String>(this, buAddress3Args);
            BuParish = new DataWrapper<String>(this, buParishArgs);
            BuCountry = new DataWrapper<String>(this, buCountryArgs);
            CreatedAt = new DataWrapper<DateTime>(this, createdAtArgs);
            CreatedBy = new DataWrapper<Int32>(this, createdByArgs);
            UpdatedAt = new DataWrapper<DateTime>(this, updatedAtArgs);
            UpdatedBy = new DataWrapper<Int32>(this, updatedByArgs);
            
            //fetch list of all DataWrappers, so they can be used again later without the
            //need for reflection
            cachedListOfDataWrappers =
                DataWrapperHelper.GetWrapperProperties<BusinessUnit>(this);

            #region Create Validation Rules
            buName.AddRule(BusinessNameRule);
            buAddress1.AddRule(BusinessAddress1Rule);
            buParish.AddRule(BusinessParishRule);
            buCountry.AddRule(BusinessCountryRule);
            #endregion
        }

        static BusinessUnit()
        {
            BusinessNameRule = new SimpleRule("DataValue", "Business Name can not be empty",
                      (Object domainObject) =>
                      {
                          DataWrapper<String> obj = (DataWrapper<String>)domainObject;
                          return String.IsNullOrEmpty(obj.DataValue);
                      });
            BusinessAddress1Rule = new SimpleRule("DataValue", "Address 1 can not be empty",
                      (Object domainObject) =>
                      {
                          DataWrapper<String> obj = (DataWrapper<String>)domainObject;
                          return String.IsNullOrEmpty(obj.DataValue);
                      });
            BusinessParishRule = new SimpleRule("DataValue", "Parish can not be empty",
                      (Object domainObject) =>
                      {
                          DataWrapper<String> obj = (DataWrapper<String>)domainObject;
                          return String.IsNullOrEmpty(obj.DataValue);
                      });
            BusinessCountryRule = new SimpleRule("DataValue", "Country can not be empty",
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
            ObservableHelper.CreateArgs<BusinessUnit>(x => x.BuId);
        public DataWrapper<Int32> BuId
        {
            get { return buId; }
            set { buId = value; NotifyPropertyChanged(buIdArgs); }
        }
        /// <summary>
        /// BuName
        /// </summary>
        static PropertyChangedEventArgs buNameArgs =
            ObservableHelper.CreateArgs<BusinessUnit>(x => x.BuName);
        public DataWrapper<String> BuName
        {
            get { return buName; }
            set { buName = value; NotifyPropertyChanged(buNameArgs); }
        }
        /// <summary>
        /// BuEmailAddress
        /// </summary>
        static PropertyChangedEventArgs buEmailAddressArgs =
            ObservableHelper.CreateArgs<BusinessUnit>(x => x.BuEmailAddress);
        public DataWrapper<String> BuEmailAddress
        {
            get { return buEmailAddress; }
            set { buEmailAddress = value; NotifyPropertyChanged(buEmailAddressArgs); }
        }
        /// <summary>
        /// BuContactNum1
        /// </summary>
        static PropertyChangedEventArgs buContactNum1Args =
            ObservableHelper.CreateArgs<BusinessUnit>(x => x.BuContactNum1);
        public DataWrapper<String> BuContactNum1
        {
            get { return buContactNum1; }
            set { buContactNum1 = value; NotifyPropertyChanged(buContactNum1Args); }
        }
        /// <summary>
        /// BuContactNum2
        /// </summary>
        static PropertyChangedEventArgs buContactNum2Args =
            ObservableHelper.CreateArgs<BusinessUnit>(x => x.BuContactNum2);
        public DataWrapper<String> BuContactNum2
        {
            get { return buContactNum2; }
            set { buContactNum2 = value; NotifyPropertyChanged(buContactNum2Args); }
        }
        /// <summary>
        /// BuContactNum3
        /// </summary>
        static PropertyChangedEventArgs buContactNum3Args =
            ObservableHelper.CreateArgs<BusinessUnit>(x => x.BuContactNum3);
        public DataWrapper<String> BuContactNum3
        {
            get { return buContactNum3; }
            set { buContactNum3 = value; NotifyPropertyChanged(buContactNum3Args); }
        }
        /// <summary>
        /// BuAddress1
        /// </summary>
        static PropertyChangedEventArgs buAddress1Args =
            ObservableHelper.CreateArgs<BusinessUnit>(x => x.BuAddress1);
        public DataWrapper<String> BuAddress1
        {
            get { return buAddress1; }
            set { buAddress1 = value; NotifyPropertyChanged(buAddress1Args); }
        }
        /// <summary>
        /// BuAddress2
        /// </summary>
        static PropertyChangedEventArgs buAddress2Args =
            ObservableHelper.CreateArgs<BusinessUnit>(x => x.BuAddress2);
        public DataWrapper<String> BuAddress2
        {
            get { return buAddress2; }
            set { buAddress2 = value; NotifyPropertyChanged(buAddress2Args); }
        }
        /// <summary>
        /// BuAddress3
        /// </summary>
        static PropertyChangedEventArgs buAddress3Args =
            ObservableHelper.CreateArgs<BusinessUnit>(x => x.BuAddress3);
        public DataWrapper<String> BuAddress3
        {
            get { return buAddress3; }
            set { buAddress3 = value; NotifyPropertyChanged(buAddress3Args); }
        }
        /// <summary>
        /// BuParish
        /// </summary>
        static PropertyChangedEventArgs buParishArgs =
            ObservableHelper.CreateArgs<BusinessUnit>(x => x.BuParish);
        public DataWrapper<String> BuParish
        {
            get { return buParish; }
            set { buParish = value; NotifyPropertyChanged(buParishArgs); }
        }
        /// <summary>
        /// BuCountry
        /// </summary>
        static PropertyChangedEventArgs buCountryArgs =
            ObservableHelper.CreateArgs<BusinessUnit>(x => x.BuCountry);
        public DataWrapper<String> BuCountry
        {
            get { return buCountry; }
            set { buCountry = value; NotifyPropertyChanged(buCountryArgs); }
        }
        /// <summary>
        /// CreatedAt
        /// </summary>
        static PropertyChangedEventArgs createdAtArgs =
            ObservableHelper.CreateArgs<BusinessUnit>(x => x.CreatedAt);
        public DataWrapper<DateTime> CreatedAt
        {
            get { return createdAt; }
            set { createdAt = value; NotifyPropertyChanged(createdAtArgs); }
        }
        /// <summary>
        /// CreatedBy
        /// </summary>
        static PropertyChangedEventArgs createdByArgs =
            ObservableHelper.CreateArgs<BusinessUnit>(x => x.CreatedBy);
        public DataWrapper<Int32> CreatedBy
        {
            get { return createdBy; }
            set { createdBy = value; NotifyPropertyChanged(createdByArgs); }
        }
        /// <summary>
        /// UpdatedAt
        /// </summary>
        static PropertyChangedEventArgs updatedAtArgs =
            ObservableHelper.CreateArgs<BusinessUnit>(x => x.UpdatedAt);
        public DataWrapper<DateTime> UpdatedAt
        {
            get { return updatedAt; }
            set { updatedAt = value; NotifyPropertyChanged(updatedAtArgs); }
        }
        /// <summary>
        /// UpdatedBy
        /// </summary>
        static PropertyChangedEventArgs updatedByArgs =
            ObservableHelper.CreateArgs<BusinessUnit>(x => x.UpdatedBy);
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
    public class BusinessUnits : ObservableCollection<BusinessUnit>
    {
        
    }
}