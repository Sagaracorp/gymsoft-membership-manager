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
        public abstract static IEnumerable<Entity> FindAll();
        public abstract static Entity Find(int id);
        public abstract static int DeleteAll(int user); // Returns the number of rows marked as deleted
        public abstract static int Delete(int id, int user); // Returns the number of rows marked as deleted
        public abstract static int Insert(Entity entity, int user); //Returns the number of rows inserted 1 on success 0 on failure
        public abstract static int Update(Entity entity, int user); //Returns the number of rows inserted 1 on success 0 on failure
        public abstract static int BulkInsert(IEnumerable<Entity> entities, int user); // Returns the number of rows Inserted
        public abstract static bool IsNewRecord(Entity entity); // Check if entity is new record or existing
        #endregion 

        #region Object Methods
        public bool Save(int user)
        {
            bool result;
            // Save the object to the database. Returns true if save was sucessful false otherwise
            if (IsNewRecord(this))
            {
                result = Insert(this, user);
            }
            else
            {
                result = Update(this, user);
            }
            return result == 1;
        }
        public bool Delete(int user)
        {
            bool result = Delete(this.Id, user);
            return result == 1;
        }
        #endregion


        
    }
}