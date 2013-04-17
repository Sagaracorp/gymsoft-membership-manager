using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Cinch;

namespace GymSoft.DB.ActionsTable
{
    public class Action : ValidatingObject
    {
        #region Data
        private DataWrapper<Int32> buId;
        private DataWrapper<Int32> actionId;
        private DataWrapper<String> entityName;
        private DataWrapper<String> allowedActions;
        private DataWrapper<String> friendlyName;
        private static DataWrapper<String> description;
        private DataWrapper<DateTime> createdAt;
        private DataWrapper<Int32> createdBy;
        private DataWrapper<DateTime> updatedAt;
        private DataWrapper<Int32> updatedBy;
        private IEnumerable<DataWrapperBase> cachedListOfDataWrappers;
        #endregion
        #region Constructors

        public Action()
        {
            BuId = new DataWrapper<Int32>(this,buIdArgs);
            ActionId = new DataWrapper<Int32>(this,actionIdArgs);
            EntityName = new DataWrapper<String>(this, entityNameArgs);
            AllowedActions = new DataWrapper<String>(this, allowedActionsArgs);
            FriendlyName = new DataWrapper<String>(this, friendlyNameArgs);
            Description = new DataWrapper<String>(this, descriptionArgs);
            CreatedAt = new DataWrapper<DateTime>(this, createdAtArgs);
            CreatedBy = new DataWrapper<Int32>(this, createdByArgs);
            UpdatedAt = new DataWrapper<DateTime>(this, updatedAtArgs);
            UpdatedBy = new DataWrapper<Int32>(this, updatedByArgs);
            //fetch list of all DataWrappers, so they can be used again later without the
            //need for reflection
            cachedListOfDataWrappers =
                DataWrapperHelper.GetWrapperProperties<Action>(this);

           
        }

        static Action()
        {
            
        }
        #endregion
        
        #region Public Properties
        /// <summary>
        /// BuId
        /// </summary>
        static PropertyChangedEventArgs buIdArgs =
            ObservableHelper.CreateArgs<Action>(x => x.BuId);
        public DataWrapper<Int32> BuId
        {
            get { return buId; }
            set { buId = value; NotifyPropertyChanged(buIdArgs); }
        }
        /// <summary>
        /// ActionId
        /// </summary>
        static PropertyChangedEventArgs actionIdArgs =
            ObservableHelper.CreateArgs<Action>(x => x.ActionId);
        public DataWrapper<Int32> ActionId
        {
            get { return actionId; }
            set { actionId = value; NotifyPropertyChanged(actionIdArgs); }
        }
        /// <summary>
        /// EntityName
        /// </summary>
        static PropertyChangedEventArgs entityNameArgs =
            ObservableHelper.CreateArgs<Action>(x => x.EntityName);
        public DataWrapper<String> EntityName
        {
            get { return entityName; }
            set { entityName = value; NotifyPropertyChanged(entityNameArgs); }
        }
        /// <summary>
        /// AllowedActions
        /// </summary>
        static PropertyChangedEventArgs allowedActionsArgs =
            ObservableHelper.CreateArgs<Action>(x => x.AllowedActions);
        public DataWrapper<String> AllowedActions
        {
            get { return allowedActions; }
            set { allowedActions = value; NotifyPropertyChanged(allowedActionsArgs); }
        }
        /// <summary>
        /// FriendlyName
        /// </summary>
        static PropertyChangedEventArgs friendlyNameArgs =
            ObservableHelper.CreateArgs<Action>(x => x.FriendlyName);
        public DataWrapper<String> FriendlyName
        {
            get { return friendlyName; }
            set { friendlyName = value; NotifyPropertyChanged(friendlyNameArgs); }
        }
        /// <summary>
        /// Description
        /// </summary>
        static PropertyChangedEventArgs descriptionArgs =
            ObservableHelper.CreateArgs<Action>(x => x.Description);
        public DataWrapper<String> Description
        {
            get { return description; }
            set
            {
                description = value;
                NotifyPropertyChanged(descriptionArgs);
            }
        }

        /// <summary>
        /// CreatedAt
        /// </summary>
        static PropertyChangedEventArgs createdAtArgs =
            ObservableHelper.CreateArgs<Action>(x => x.CreatedAt);
        public DataWrapper<DateTime> CreatedAt
        {
            get { return createdAt; }
            set { createdAt = value; NotifyPropertyChanged(createdAtArgs); }
        }
        /// <summary>
        /// CreatedBy
        /// </summary>
        static PropertyChangedEventArgs createdByArgs =
            ObservableHelper.CreateArgs<Action>(x => x.CreatedBy);
        public DataWrapper<Int32> CreatedBy
        {
            get { return createdBy; }
            set { createdBy = value; NotifyPropertyChanged(createdByArgs); }
        }
        /// <summary>
        /// UpdatedAt
        /// </summary>
        static PropertyChangedEventArgs updatedAtArgs =
            ObservableHelper.CreateArgs<Action>(x => x.UpdatedAt);
        public DataWrapper<DateTime> UpdatedAt
        {
            get { return updatedAt; }
            set { updatedAt = value; NotifyPropertyChanged(updatedAtArgs); }
        }
        /// <summary>
        /// UpdatedBy
        /// </summary>
        static PropertyChangedEventArgs updatedByArgs =
            ObservableHelper.CreateArgs<Action>(x => x.UpdatedBy);
        public DataWrapper<Int32> UpdatedBy
        {
            get { return updatedBy; }
            set { updatedBy = value; NotifyPropertyChanged(updatedByArgs); }
        }

        #endregion

    }
    public class Actions : DispatcherNotifiedObservableCollection<Action>
    {
    }
}
