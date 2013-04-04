using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.Linq;
using System.Text;
using System.Windows;
using Cinch;
using MEFedMVVM.ViewModelLocator;
using Microsoft.Practices.Prism.MefExtensions;

namespace GymSoft.CinchMVVM.Shell
{
    public class Bootstrapper : MefBootstrapper, IComposer, IContainerProvider
    {
        private CompositionContainer _compositionContainer;

        protected override void ConfigureAggregateCatalog()
        {
            this.AggregateCatalog.Catalogs.Add(new AssemblyCatalog(typeof (Bootstrapper).Assembly));
            this.AggregateCatalog.Catalogs.Add(new DirectoryCatalog("Modules")); // add all assemblies in the modules
            this.AggregateCatalog.Catalogs.Add(new AssemblyCatalog(typeof (ViewModelBase).Assembly));

            //add a reference to the mefedmvvm services
            this.AggregateCatalog.Catalogs.Add(new AssemblyCatalog(typeof (ViewModelLocator).Assembly));
                // reference the xml data access
        }

        protected override void InitializeShell()
        {
            base.InitializeShell();

            Application.Current.MainWindow = (Shell) this.Shell;
            Application.Current.MainWindow.Show();
        }

        #region Overrides of Bootstrapper

        protected override DependencyObject CreateShell()
        {
            //init MEFedMVVM composed
            MEFedMVVM.ViewModelLocator.LocatorBootstrapper.ApplyComposer(this);

            return this.Container.GetExportedValue<Shell>();
        }

        protected override CompositionContainer CreateContainer()
        {
            // The Prism call to create a container
            var exportProvider = new MEFedMVVMExportProvider(MEFedMVVMCatalog.CreateCatalog(AggregateCatalog));
            _compositionContainer = new CompositionContainer(exportProvider);
            exportProvider.SourceProvider = _compositionContainer;

            return _compositionContainer;
        }

        #endregion

        #region Implementation of IComposer (For MEFedMVVM)

        public ComposablePartCatalog InitializeContainer()
        {
            //return the same catalog as the PRISM one
            return this.AggregateCatalog;
        }

        public IEnumerable<ExportProvider> GetCustomExportProviders()
        {
            //In case you want some custom export providers
            return null;
        }

        #endregion

        CompositionContainer IContainerProvider.CreateContainer()
        {
            // The MEFedMVVM call to create a container
            return _compositionContainer;
        }
    }
}
