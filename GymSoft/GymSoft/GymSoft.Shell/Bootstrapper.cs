using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Prism.UnityExtensions;
using System.Windows;
using Microsoft.Practices.Prism.Modularity;

namespace GymSoft.Shell
{
    public class Bootstrapper : UnityBootstrapper
    {
        protected override System.Windows.DependencyObject CreateShell()
        {
            return new Shell();
        }
        protected override void InitializeShell()
        {
            base.InitializeShell();
            App.Current.MainWindow = (Window)this.Shell;
            App.Current.MainWindow.Show();            
        }
        protected override void ConfigureModuleCatalog()
        {
            base.ConfigureModuleCatalog();
            //Add the modules as they are created
            ModuleCatalog moduleCatalog = (ModuleCatalog)this.ModuleCatalog;
            moduleCatalog.AddModule(typeof(UserModule.Modules.Module));
            moduleCatalog.AddModule(typeof(RoleModule.Modules.RoleModule));
            moduleCatalog.AddModule(typeof(GymSoft.Shell.Modules.ShellModule));
        }
    }
}
