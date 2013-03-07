using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GymSoft.UserModule.Services;
using System.Windows.Data;
using System.ComponentModel;

namespace GymSoft.UserModule.ViewModels
{
    public class UserListRegionViewModel
    {
        public ICollectionView Users { get; set; }
        IUserService userService;
        
        public UserListRegionViewModel(IUserService userService)
        {
            this.userService = userService;
            this.Users = new ListCollectionView(userService.FindAll());
        }
    }
}
