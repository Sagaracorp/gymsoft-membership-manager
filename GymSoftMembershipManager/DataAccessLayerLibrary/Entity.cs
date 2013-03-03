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
        public bool IsDeleted { get; set; } //The actual record isnt deleted only marked as deleted 
        //TODO
        //Error Handling procedures
        #endregion

        #region Static (Class methods)
        //public static IEnumerable<Entity> FindAll();
       // public static Entity Find(int id);
       // public static int DeleteAll(int user); // Returns the number of rows marked as deleted
          public abstract int Delete(int user); // Returns the number of rows marked as deleted
          public abstract int Insert(int user); //Returns the number of rows inserted 1 on success 0 on failure
          public abstract int Update(int user); //Returns the number of rows inserted 1 on success 0 on failure
        //public static int BulkInsert(IEnumerable<Entity> entities, int user); // Returns the number of rows Inserted
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