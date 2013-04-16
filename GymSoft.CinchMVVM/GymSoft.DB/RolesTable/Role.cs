using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Cinch;

namespace GymSoft.DB.RolesTable
{
    public class Role : ValidatingObject
    {
        #region Data
        private DataWrapper<Int32> buId;
        private DataWrapper<Int32> roleId;
        private DataWrapper<String> roleName;
        private static DataWrapper<String> description;
        private DataWrapper<DateTime> createdAt;
        private DataWrapper<Int32> createdBy;
        private DataWrapper<DateTime> updatedAt;
        private DataWrapper<Int32> updatedBy;
        private IEnumerable<DataWrapperBase> cachedListOfDataWrappers;
        #endregion
        #region Rules
        private static SimpleRule RoleNameCannotBeEmptyRule;
        #endregion
        #region Constructors

        public Role()
        {
            BuId = new DataWrapper<Int32>(this,buIdArgs);
            RoleId = new DataWrapper<Int32>(this,roleIdArgs);
            RoleName = new DataWrapper<String>(this, roleNameArgs);
            Description = new DataWrapper<String>(this, descriptionArgs);
            CreatedAt = new DataWrapper<DateTime>(this, createdAtArgs);
            CreatedBy = new DataWrapper<Int32>(this, createdByArgs);
            UpdatedAt = new DataWrapper<DateTime>(this, updatedAtArgs);
            UpdatedBy = new DataWrapper<Int32>(this, updatedByArgs);
            //fetch list of all DataWrappers, so they can be used again later without the
            //need for reflection
            cachedListOfDataWrappers =
                DataWrapperHelper.GetWrapperProperties<Role>(this);

            #region Create Validation Rules
            roleName.AddRule(RoleNameCannotBeEmptyRule);
            #endregion
        }

        static Role()
        {
            RoleNameCannotBeEmptyRule = new SimpleRule("DataValue", "Role Name can not be empty",
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
            ObservableHelper.CreateArgs<Role>(x => x.BuId);
        public DataWrapper<Int32> BuId
        {
            get { return buId; }
            set { buId = value; NotifyPropertyChanged(buIdArgs); }
        }
        /// <summary>
        /// RoleId
        /// </summary>
        static PropertyChangedEventArgs roleIdArgs =
            ObservableHelper.CreateArgs<Role>(x => x.RoleId);
        public DataWrapper<Int32> RoleId
        {
            get { return roleId; }
            set { roleId = value; NotifyPropertyChanged(roleIdArgs); }
        }
        /// <summary>
        /// RoleName
        /// </summary>
        static PropertyChangedEventArgs roleNameArgs =
            ObservableHelper.CreateArgs<Role>(x => x.RoleName);
        public DataWrapper<String> RoleName
        {
            get { return roleName; }
            set { roleName = value; NotifyPropertyChanged(roleNameArgs); }
        }
        /// <summary>
        /// Description
        /// </summary>
        static PropertyChangedEventArgs descriptionArgs =
            ObservableHelper.CreateArgs<Role>(x => x.Description);
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
            ObservableHelper.CreateArgs<Role>(x => x.CreatedAt);
        public DataWrapper<DateTime> CreatedAt
        {
            get { return createdAt; }
            set { createdAt = value; NotifyPropertyChanged(createdAtArgs); }
        }
        /// <summary>
        /// CreatedBy
        /// </summary>
        static PropertyChangedEventArgs createdByArgs =
            ObservableHelper.CreateArgs<Role>(x => x.CreatedBy);
        public DataWrapper<Int32> CreatedBy
        {
            get { return createdBy; }
            set { createdBy = value; NotifyPropertyChanged(createdByArgs); }
        }
        /// <summary>
        /// UpdatedAt
        /// </summary>
        static PropertyChangedEventArgs updatedAtArgs =
            ObservableHelper.CreateArgs<Role>(x => x.UpdatedAt);
        public DataWrapper<DateTime> UpdatedAt
        {
            get { return updatedAt; }
            set { updatedAt = value; NotifyPropertyChanged(updatedAtArgs); }
        }
        /// <summary>
        /// UpdatedBy
        /// </summary>
        static PropertyChangedEventArgs updatedByArgs =
            ObservableHelper.CreateArgs<Role>(x => x.UpdatedBy);
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
    public class Roles : DispatcherNotifiedObservableCollection<Role>
    {
    }
}
