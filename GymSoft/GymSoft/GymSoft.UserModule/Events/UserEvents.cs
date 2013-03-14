using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Prism.Events;
using GymSoft.UserModule.Model;

namespace GymSoft.UserModule.Events
{
    public class ViewAllUsersEvent : CompositePresentationEvent<object>
    {
    }
    public class DeleteAllUsersEvent : CompositePresentationEvent<object>
    {
    }
    public class UserSelectedEvent : CompositePresentationEvent<User>
    {
    }
    public class UserLoginEvent : CompositePresentationEvent<User>
    {
    }
    public class UserLogoutEvent : CompositePresentationEvent<object>
    {
    }
    
}
