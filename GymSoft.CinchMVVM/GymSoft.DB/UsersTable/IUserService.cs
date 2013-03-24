using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GymSoft.DB.UsersTable
{
    public interface IUserService
    {
        Users FindAll(int buId, int userId); // This user id should be current user. 
        Users FindAll(); // This should be used buy the login screen. 
        void FindAllTask(Action<Users> resultCallback, Action<Exception> exceptionCallBack);
    }
}
