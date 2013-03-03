using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLayerLibrary
{
    public class Action : Entity
    {
        public static override IEnumerable<Entity> FindAll()
        {
            throw new NotImplementedException();
        }

        public static override Entity Find(int id)
        {
            throw new NotImplementedException();
        }

        public static override int DeleteAll(int user)
        {
            throw new NotImplementedException();
        }

        public static override int Delete(int id, int user)
        {
            throw new NotImplementedException();
        }

        public static override int Insert(Entity entity, int user)
        {
            throw new NotImplementedException();
        }

        public static override int Update(Entity entity, int user)
        {
            throw new NotImplementedException();
        }

        public static override int BulkInsert(IEnumerable<Entity> entities, int user)
        {
            throw new NotImplementedException();
        }

        public static override bool IsNewRecord(Entity entity)
        {
            throw new NotImplementedException();
        }
    }
}
