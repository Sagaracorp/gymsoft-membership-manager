using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using GymSoft.UserModule.Model;

namespace GymSoft.UserModule.Services
{
    public class UserMockServiceRepository : IUserServiceRepository
    {
        private IUserService userService;
        private SynchronizationContext synchronizationContext = System.Threading.SynchronizationContext.Current ?? 
                                                                new SynchronizationContext();

        public UserMockServiceRepository() : this(new UserMockService())
        {

        }
        public UserMockServiceRepository(IUserService userService)
        {
            this.userService = userService;
        }

        public void FindAllUsersAsync(Action<IOperationResult<Model.Users>> callback)
        {
            IAsyncResult asyncResult = this.userService.BeginFindAll(
                (ar) =>
                {
                    OperationResult<Users> operationResult = new OperationResult<Users>();
                    try
                    {
                        operationResult.Result = userService.EndFindAll(ar);                            
                    }
                    catch (Exception ex)
                    {
                        operationResult.Error = ex;
                    }

                    synchronizationContext.Post(
                        (state) =>
                        {
                            callback(operationResult);
                        },
                        null);
                },
                null);
        }
    }
}
