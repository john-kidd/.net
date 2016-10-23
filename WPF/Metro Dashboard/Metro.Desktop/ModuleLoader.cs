namespace Metro.Desktop
{
    using System.Windows;
    using Gam.AppCentral.Desktop.Framework;
    using ViewModels;
    using Views;

    public class ModuleLoader
    {
        #region Fields and Constants

        private readonly ITaskPollingService _taskPollingService;

        private readonly MainView _view;

        private readonly MainViewModel _viewModel;

        #endregion

        #region Constructors

        public ModuleLoader(MainView view, MainViewModel viewModel, ITaskPollingService taskPollingService)
        {
            this._view = view;
            this._viewModel = viewModel;
            this._taskPollingService = taskPollingService;

            this._view.Loaded += this.ViewDidLoaded;
        }

        #endregion

        #region Methods

        public void Run()
        {
            this._view.DataContext = this._viewModel;
            this._view.Show();
        }

        private void ViewDidLoaded(object sender, RoutedEventArgs e)
        {
            this._taskPollingService.Start();
        }

        #endregion
    }
}