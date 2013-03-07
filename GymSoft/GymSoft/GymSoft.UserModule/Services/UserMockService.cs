using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Unity;
using GymSoft.UserModule.Model;

namespace GymSoft.UserModule.Services
{
    public class UserMockService : IUserService
    {
        IUnityContainer container;
        Users users;

        public UserMockService(IUnityContainer container)
        {
            //this.container = container;
            //container.RegisterInstance<IUserService, UserMockService>();
        }
        public Users FindAll()
        {
            if (this.users == null)
            {
                // Dummy Data.
                this.users = new Users
                                      {
                                          new User()
                                              {
                                                  Id = 1,
                                                  FirstName = "John",
                                                  LastName = "Smith",
                                                  Password = "passwordfill",
                                                  UserName= "John.Smith@Contoso.com"
                                              },
                                          new User()
                                              {
                                                  Id = 2,
                                                  FirstName = "Bonnie",
                                                  LastName = "Skelly",
                                                  Password = "(206) 555 7301",
                                                  UserName = "Bonnie.Skelly@Contoso.com"
                                              },
                                          new User()
                                              {
                                                  Id = 3,
                                                  FirstName = "Dana",
                                                  LastName = "Birkby",
                                                  Password = "(425) 555 7492",
                                                  UserName = "Dana.Birkby@Contoso.com"
                                              },
                                          new User()
                                              {
                                                  Id = 4,
                                                  FirstName = "David",
                                                  LastName = "Probst",
                                                  Password = "(425) 555 2836",
                                                  UserName = "David.Probst@Contoso.com"
                                              },
                                      };
            }

            return this.users;
        }

        public Model.User FindById(int id)
        {
            var user = this.users.SingleOrDefault(u => u.Id == id);
            return user;
        }
    }
}
