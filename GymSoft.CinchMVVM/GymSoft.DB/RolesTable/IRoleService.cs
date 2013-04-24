using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GymSoft.DB.RolesTable
{
    public interface IRoleService
    {
        void FindAllTask(Action<Roles> resultCallback, Action<Exception> exceptionCallBack);
        void CreateNewRoleTask(Role newUser, Action<Int32> resultCallback, Action<Exception> exceptionCallBack);
        void UpdateRoleTask(Role user, Action<Int32> resultCallback, Action<Exception> exceptionCallBack);

        Roles FindAllForUser(System.Data.DataTable userRolesTable, int userId);
    }
}
