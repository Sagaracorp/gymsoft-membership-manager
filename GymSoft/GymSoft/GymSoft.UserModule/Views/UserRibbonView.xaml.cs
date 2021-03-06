﻿using System;
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
using Telerik.Windows.Controls;
using GymSoft.UserModule.ViewModels;

namespace GymSoft.UserModule.Views
{
    /// <summary>
    /// Interaction logic for UserRibbonView.xaml
    /// </summary>
    public partial class UserRibbonView : RadRibbonTab
    {
        public UserRibbonView(UserRibbonViewModel viewModel)
        {
            InitializeComponent();
            this.DataContext = viewModel;
        }
    }
}
