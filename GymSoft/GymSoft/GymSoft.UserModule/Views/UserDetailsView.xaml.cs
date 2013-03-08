using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using GymSoft.UserModule.ViewModels;
using Microsoft.Practices.Prism.Regions;
using GymSoft.UserModule.Model;

namespace GymSoft.UserModule.Views
{
    /// <summary>
    /// Interaction logic for UserDetailsView.xaml
    /// </summary>
    public partial class UserDetailsView : TabItem
    {
        public UserDetailsView( UserDetailsViewModel viewModel)
        {
            InitializeComponent();
            this.DataContext = viewModel;
            RegionContext.GetObservableContext(this).PropertyChanged += 
                (s, e) => viewModel.CurrentUser = 
                    RegionContext.GetObservableContext(this).Value as User;
        }
    }
}
