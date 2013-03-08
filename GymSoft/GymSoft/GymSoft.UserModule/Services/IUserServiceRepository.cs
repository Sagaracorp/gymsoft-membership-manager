using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GymSoft.UserModule.Model;

namespace GymSoft.UserModule.Services
{
    public interface IUserServiceRepository
    {
        void FindAllUsersAsync(Action<IOperationResult<Users>> callback);
    }
}
