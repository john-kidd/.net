namespace Metro.Desktop
{
    using System;
    using System.Security.Claims;
    using System.Security.Principal;
    using System.Windows;
    using Gam.AppCentral.Desktop.Framework;
    using Ninject;
    using ViewModels;
    using Views;

    public partial class App : Application
    {
        #region Fields and Constants

        private readonly ITaskPollingService _taskPollingService;

        private readonly MainView _view;

        private readonly MainViewModel _viewModel;

        private IKernel _kernel;

        #endregion

        #region Methods

        protected override void OnStartup(StartupEventArgs e)
        {
            this._kernel = new StandardKernel();

            this._kernel.Bind<ITaskPollingService>().To<TaskPollingService>().InSingletonScope();

            AppDomain.CurrentDomain.SetThreadPrincipal(new ClaimsPrincipal(WindowsIdentity.GetCurrent()));

            var moduleLoader = this._kernel.Get<ModuleLoader>();


            base.OnStartup(e);

            moduleLoader.Run();
        }

        #endregion
    }
}