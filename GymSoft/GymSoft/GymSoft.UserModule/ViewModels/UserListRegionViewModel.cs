using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GymSoft.UserModule.Services;
using System.Windows.Data;
using System.ComponentModel;
using System.Threading.Tasks;
using Microsoft.Practices.Prism.ViewModel;
using Microsoft.Practices.Prism.Events;
using GymSoft.UserModule.Model;
using GymSoft.UserModule.Events;

namespace GymSoft.UserModule.ViewModels
{
    public class UserListRegionViewModel : PropertyChangedImplementation
    {
        public ICollectionView Users { get; set; }
        IUserService userService;
        IEventAggregator eventAggregator;
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
        public UserListRegionViewModel(IUserServiceRepository userRepository, IEventAggregator eventAggregator)
        {
            this.userRepository = userRepository;
            this.eventAggregator = eventAggregator;
            this.userRepository.FindAllUsersAsync(
               (result) =>
               {
                   this.Users = new ListCollectionView(result.Result);
                   FirePropertyChanged("Users");
                   this.Users.CurrentChanged += new EventHandler(this.SelectedUserChanged);                   
                });
            
        }
        private void SelectedUserChanged(object sender, EventArgs e)
        {
            User user = this.Users.CurrentItem as User;
            if (user != null)
            {
                // Publish the EmployeeSelectedEvent event.
                this.eventAggregator.GetEvent<UserSelectedEvent>().Publish(user);
            }
        }
    }
}
