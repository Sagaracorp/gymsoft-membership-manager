using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GymSoft.DB.ActionsTable
{
    public interface IActionService
    {
        void FindAllTask(Action<Actions> resultCallback, Action<Exception> exceptionCallBack);
        void FindAllActionsForUserTask(int userId, Action<Actions> resultCallback, Action<Exception> exceptionCallBack);
        void FindAllActionsForRoleTask(int roleId, Action<Actions> resultCallback, Action<Exception> exceptionCallBack);
        Actions FindAllForUser(int personId, int userId=1, int buId=1);
    }
}
