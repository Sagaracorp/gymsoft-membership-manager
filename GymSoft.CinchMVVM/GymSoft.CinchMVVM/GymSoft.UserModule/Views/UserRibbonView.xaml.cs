using System.ComponentModel.Composition;
using Telerik.Windows.Controls;

namespace GymSoft.UserModule.Views
{
    /// <summary>
    /// Interaction logic for UserRibbonView.xaml
    /// </summary>
    [Export(typeof(UserRibbonView))]
    public partial class UserRibbonView : RadRibbonTab
    {
        public UserRibbonView()
        {
            InitializeComponent();
        }
    }
}
