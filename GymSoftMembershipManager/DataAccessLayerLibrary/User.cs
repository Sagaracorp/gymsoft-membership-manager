using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLayerLibrary
{
    public class User : Entity
    {
        #region User Properties
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string Parish { get; set; }
        public string Gender { get; set; }
        public string PhoneNumber1 { get; set; }
        public string PhoneNumber2 { get; set; }
        public string PhoneNumber3 { get; set; }
        public string EmailAddress { get; set; }
        public string PhotoPath { get; set; }
        public string JobTitle { get; set; }
        public string JobDescription { get; set; }
        #endregion

        #region User Relationship Properties
        public IEnumerable<Role> Roles { get; set; }
        public IEnumerable<Action> Actions { get; set; }
        #endregion

        #region Unimplemented Functions
        
        #endregion

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
    }
}
