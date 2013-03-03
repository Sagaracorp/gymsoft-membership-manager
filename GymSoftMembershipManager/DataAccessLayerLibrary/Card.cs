using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLayerLibrary
{
    public class Card : Entity
    {

        public override bool IsNewRecord()
        {
            throw new NotImplementedException();
        }

        public override int Delete(int user)
        {
            throw new NotImplementedException();
        }

        public override int Insert(int user)
        {
            throw new NotImplementedException();
        }

        public override int Update(int user)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<Entity> FindAll()
        {
            throw new NotImplementedException();
        }

        public override Entity Find(int id)
        {
            throw new NotImplementedException();
        }

        public override int DeleteAll(int user)
        {
            throw new NotImplementedException();
        }

        public override int BulkInsert(IEnumerable<Entity> entities, int user)
        {
            throw new NotImplementedException();
        }
    }
}
