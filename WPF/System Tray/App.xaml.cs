namespace ContextMenu
{
    using System;
    using System.Security.Claims;
    using System.Security.Principal;
    using System.Windows;
    using ViewModels;

    /// <summary>
    ///     Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        #region Methods

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            AppDomain.CurrentDomain.SetThreadPrincipal(new ClaimsPrincipal(WindowsIdentity.GetCurrent()));

            var mainView = new MainView
            {
                DataContext = new MainViewModel(),
                Visibility = Visibility.Hidden
            };

            MainWindow = mainView;
        }

        #endregion
    }
}