using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLayerLibrary
{
    public abstract class Entity 
    {
        #region Public Properties
        public int Id { get; private set; }
        public DateTime InsertedAt { get; private set; }
        public int InsertedBy { get; set; }
        public DateTime UpdatedAt { get; private set; }
        public int UpdatedBy { get; set; }
        public string status { get; set; } //The status of the record. (Deleted/Disabled/Active etc)
        //TODO
        //Error Handling procedures
        #endregion

        #region Class methods
        public abstract IEnumerable<Entity> FindAll();
        public abstract Entity Find(int id);
        public abstract int DeleteAll(int user); // Returns the number of rows marked as deleted
        public abstract int Delete(int user); // Returns the number of rows marked as deleted
        public abstract int Insert(int user); //Returns the number of rows inserted 1 on success 0 on failure
        public abstract int Update(int user); //Returns the number of rows inserted 1 on success 0 on failure
        public abstract int BulkInsert(IEnumerable<Entity> entities, int user); // Returns the number of rows Inserted
        public abstract bool IsNewRecord(); // Check if entity is new record or existing
        #endregion 

        #region Object Methods
        public bool Save(int user)
        {
            int result;
            // Save the object to the database. Returns true if save was sucessful false otherwise
            if (this.IsNewRecord())
            {
                result = this.Insert(user);
            }
            else
            {
                result = this.Update(user);
            }
            return (result == 1);
        }
        public bool Destroy(int user)
        {
            int result = this.Delete(user);
            return (result == 1);
        }
        #endregion


        
    }
}