using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GymSoft.UserModule.Services;
using System.Windows.Data;
using System.ComponentModel;
using System.Threading.Tasks;
using Microsoft.Practices.Prism.ViewModel;

namespace GymSoft.UserModule.ViewModels
{
    public class UserListRegionViewModel : PropertyChangedImplementation
    {
        public ICollectionView Users { get; set; }
        IUserService userService;

        IUserServiceRepository userRepository;
        /*
        public UserListRegionViewModel(IUserService userService)
        {
          this.userService = userService;
           
            this.Users = new ListCollectionView(userService.FindAll());           
        }*/
      //  public UserListRegionViewModel() : this(new UserMockServiceRepository())
       // {

        //}
        public UserListRegionViewModel(IUserServiceRepository userRepository)
        {
            this.userRepository = userRepository;
            this.userRepository.FindAllUsersAsync(
               (result) =>
               {
                   this.Users = new ListCollectionView(result.Result);
                   FirePropertyChanged("Users");
                   
                });
        }        
    }
}
