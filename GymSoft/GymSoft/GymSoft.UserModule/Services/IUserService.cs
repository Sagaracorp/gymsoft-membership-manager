using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GymSoft.UserModule.Model;

namespace GymSoft.UserModule.Services
{
    /// <summary>
    /// This interface should encapulate all the services 
    /// that should be available to the user
    /// </summary>
    public interface IUserService
    {
        Users FindAll(); //Returns all users from the database;
        User FindById(int id);// Returns the user referenced by id
        //Attempting Asynchrons calls
        IAsyncResult BeginFindAll(AsyncCallback callback, object asyncState);
        Users EndFindAll(IAsyncResult asyncResult);
        bool IsMemberOfRole(User user, string roleName);
        bool HasAccessToCommand(User user, string commandName);
    }
}
