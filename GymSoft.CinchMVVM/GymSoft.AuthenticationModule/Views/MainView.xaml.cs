using System.ComponentModel.Composition;
using System.Windows.Controls;

namespace GymSoft.AuthenticationModule.Views
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    [Export]
    public partial class MainView : UserControl
    {
        public MainView()
        {
            InitializeComponent();
        }
    }
}
