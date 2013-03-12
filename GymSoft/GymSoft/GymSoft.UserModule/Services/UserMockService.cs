using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Unity;
using GymSoft.UserModule.Model;
using System.Threading;

namespace GymSoft.UserModule.Services
{
    public class UserMockService : IUserService
    {
        IUnityContainer container;
        Users users;

        public UserMockService(IUnityContainer container)
        {
            this.container = container;
            //container.RegisterInstance<IUserService, UserMockService>();
        }
        public UserMockService()
        {

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
                                                  EmailAddress = "John.Smith@Contoso.com",
                                                  UserName= "John.Smith@Contoso.com",
                                                  Roles = new Roles {
                                                            new Role() {
                                                                Id = 2,
                                                                Name = "Admin"
                                                             }
                                                        },
                                                 Commands = new Commands{
                                                                new Command(){
                                                                    Name = "View All Users",
                                                                    Roles = new Roles{
                                                                        new Role() {
                                                                            Id = 1,
                                                                            Name = "Power User"
                                                                        },
                                                                        new Role() {
                                                                            Id = 2,
                                                                            Name = "Admin"
                                                                        }
                                                                    }
                                                                },
                                                                new Command(){
                                                                    Name = "Delete All Users",
                                                                    Roles = new Roles{                                                                        
                                                                        new Role() {
                                                                            Id = 2,
                                                                            Name = "Admin"
                                                                        }
                                                                    }
                                                                }
                                                            }
                                              },
                                          new User()
                                              {
                                                  Id = 2,
                                                  FirstName = "Bonnie",
                                                  LastName = "Skelly",
                                                  Password = "(206) 555 7301",
                                                  EmailAddress = "Bonnie.Skelly@Contoso.com",
                                                  UserName = "Bonnie.Skelly@Contoso.com",
                                                  Roles = new Roles {
                                                            new Role() {
                                                                Id = 1,
                                                                Name = "Power User"
                                                             }
                                                        },
                                                 Commands = new Commands{
                                                             new Command(){
                                                                 Name = "View All Users",
                                                                 Roles = new Roles{
                                                                     new Role() {
                                                                         Id = 1,
                                                                         Name = "Power User"
                                                                     }
                                                                 }
                                                             }
                                                         }

                                              },
                                          new User()
                                              {
                                                  Id = 3,
                                                  FirstName = "Dana",
                                                  LastName = "Birkby",
                                                  Password = "(425) 555 7492",
                                                  EmailAddress = "Dana.Birkby@Contoso.com",
                                                  UserName = "Dana.Birkby@Contoso.com",
                                                  Roles = new Roles {
                                                            new Role() {
                                                                Id = 1,
                                                                Name = "PowerUser"
                                                             }
                                                        },
                                                  Commands = new Commands{
                                                        new Command(){
                                                            Name = "View All Users",
                                                            Roles = new Roles{
                                                                new Role() {
                                                                    Id = 1,
                                                                    Name = "Power User"
                                                                }
                                                            }
                                                        }
                                                    }
                                              },
                                          new User()
                                              {
                                                  Id = 4,
                                                  FirstName = "David",
                                                  LastName = "Probst",
                                                  Password = "(425) 555 2836",
                                                  EmailAddress = "David.Probst@Contoso.com",
                                                  UserName = "David.Probst@Contoso.com",
                                                  Roles = new Roles(),
                                                  Commands = new Commands()
                                              },
                                              new User()
                                              {
                                                  Id = 5,
                                                  FirstName = "Rainaldo",
                                                  LastName = "Crosboune",
                                                  Password = "(425) 555 2836",
                                                  EmailAddress = "rcrosbourne@gmail.com",
                                                  UserName = "rcrosbourne@gmail.com",
                                                  Roles = new Roles {
                                                            new Role() {
                                                                Id = 2,
                                                                Name = "Admin"
                                                             }
                                                        },
                                                 Commands = new Commands{
                                                                new Command(){
                                                                    Name = "View All Users",
                                                                    Roles = new Roles{
                                                                        new Role() {
                                                                            Id = 1,
                                                                            Name = "Power User"
                                                                        },
                                                                        new Role() {
                                                                            Id = 2,
                                                                            Name = "Admin"
                                                                        }
                                                                    }
                                                                },
                                                                new Command(){
                                                                    Name = "Delete All Users",
                                                                    Roles = new Roles{                                                                        
                                                                        new Role() {
                                                                            Id = 2,
                                                                            Name = "Admin"
                                                                        }
                                                                    }
                                                                }
                                                  }
                                              },
                                      };
            }
            //for (int i = 0; i < 1000000; i++)
            //{
            //    this.users.Add(new User()
            //                        {
            //                            Id = i,
            //                            FirstName = "FirstName " + i,
            //                            LastName = "LastName " + i,
            //                            Password = "sdfsdfs",
            //                            UserName = "username" + i
            //                        });
            //}

            return this.users;
        }

        public Model.User FindById(int id)
        {
            var user = this.users.SingleOrDefault(u => u.Id == id);
            return user;
        }


        public IAsyncResult BeginFindAll(AsyncCallback callback, object asyncState)
        {
            AsyncResult<Users> asyncResult = new AsyncResult<Users>(callback, asyncState);

            ThreadPool.QueueUserWorkItem(
                state =>
                {
                    var users = this.FindAllUsersAsync();
                    asyncResult.SetComplete(users, false);
                });

            return asyncResult;
        }

        private Users FindAllUsersAsync()
        {
            var usersVar = new Users
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
                                          new User()
                                              {
                                                  Id = 4,
                                                  FirstName = "Rainaldo",
                                                  LastName = "Crosboune",
                                                  Password = "(425) 555 2836",
                                                  UserName = "rcrosbourne@gmail.com"
                                              },
                                      };
           /* for (int i = 0; i < 1000000; i++)
            {
                usersVar.Add(new User()
                {
                    Id = i,
                    FirstName = "FirstName " + i,
                    LastName = "LastName " + i,
                    Password = "sdfsdfs",
                    UserName = "username" + i
                });
            }*/
            

            return usersVar;
        }

        public Users EndFindAll(IAsyncResult asyncResult)
        {
            var result = (AsyncResult<Users>)asyncResult;
            AsyncResult<Users>.End(asyncResult);
            return result.Result;
        }


        public bool IsMemberOfRole(User user, string roleName)
        {
            var role = user.Roles.Where(r => r.Name.ToLower() == roleName.ToLower()).SingleOrDefault();
            return role != null;
        }

        public bool HasAccessToCommand(User user, string commandName)
        {

            var command = user.Commands.Where(c => c.Name == commandName).SingleOrDefault();
            return command != null;
        }


        public User Authenticate(string username, string password)
        {
            //Call the Authenticate sub routine
            //Going to just mock this
            if (username == "rcrosbourne@gmail.com" && password == "password")
            {
                return FindAll().Where(u => u.UserName == username).SingleOrDefault();
            }
            else
            {
                return null;
            }
        }
    }
}
