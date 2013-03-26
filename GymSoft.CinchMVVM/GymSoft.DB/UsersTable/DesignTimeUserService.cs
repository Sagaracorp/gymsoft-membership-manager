using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MEFedMVVM.ViewModelLocator;

namespace GymSoft.DB.UsersTable
{
    [ExportService(ServiceType.DesignTime, typeof(IUserService))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class DesignTimeUserService : IUserService 
    {
        public Users FindAll(int buid, int userId)
        {
            #region FindAll
            var users = new Users();
            for (var i = 0; i < 10; i++)
            {
                users.Add(new User
                {
                    BuId =
                    {
                        DataValue = i
                    },
                    UserId =
                    {
                        DataValue = i
                    },
                    UserName =
                    {
                        DataValue = String.Format("UserName_{0}", i)
                    },
                    Password =
                    {
                        DataValue = String.Format("Password_{0}", i)
                    },
                    Status =
                    {
                        DataValue = String.Format("Status_{0}", i)
                    },
                    JobTitle =
                    {
                        DataValue = String.Format("JobTitle_{0}", i)
                    },
                    FirstName =
                    {
                        DataValue = String.Format("FirstName_{0}", i)
                    },
                    MiddleName =
                    {
                        DataValue = String.Format("MiddleName_{0}", i)
                    },
                    LastName =
                    {
                        DataValue = String.Format("LastName_{0}", i)
                    },
                    DateOfBirth =
                    {
                        DataValue = DateTime.Now
                    },
                    EmailAddress =
                    {
                        DataValue = String.Format("emailaddress{0}@gmail.com", i)
                    },
                    ContactNum1 =
                    {
                        DataValue = String.Format("1876443000{0}", i)
                    },
                    ContactNum2 =
                    {
                        DataValue = String.Format("1876443000{0}", i)
                    },
                    ContactNum3 =
                    {
                        DataValue = String.Format("1876443000{0}", i)
                    },
                    Address1 =
                    {
                        DataValue = String.Format("MyAddress1_{0}", i)
                    },
                    Address2 =
                    {
                        DataValue = String.Format("MyAddress2_{0}", i)
                    },
                    Address3 =
                    {
                        DataValue = String.Format("MyAddress3_{0}", i)
                    },
                    Parish =
                    {
                        DataValue = String.Format("Parish_{0}", i)
                    },
                    Gender =
                    {
                        DataValue = "Male"
                    },
                    PhotoPath =
                    {
                        DataValue = new Uri(String.Format("../Users/Image/{0}", i), UriKind.RelativeOrAbsolute)
                    },
                    CreatedAt =
                    {
                        DataValue = DateTime.Now
                    },
                    CreatedBy =
                    {
                        DataValue = i
                    },
                    UpdatedAt =
                    {
                        DataValue = DateTime.Now
                    },
                    UpdatedBy =
                    {
                        DataValue = i
                    }
                });
            }
            return users;
            #endregion
        }

        public Users FindAll()
        {
            return FindAll(1, 1);
        }

        void IUserService.FindAllTask(Action<Users> resultCallback, Action<Exception> exceptionCallBack)
        {
            resultCallback(FindAll());
        }


        public void CreateNewUserTask(User newUser, Action<int> resultCallback, Action<Exception> exceptionCallBack)
        {
            throw new NotImplementedException();
        }
    }
}
