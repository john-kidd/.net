namespace ContextMenu.ViewModels
{
    using System;
    using System.Collections.ObjectModel;
    using System.Configuration;
    using System.Diagnostics;
    using Framework;

    public class MenuItemViewModel : ViewModelBase
    {
        #region Constructors

        public MenuItemViewModel()
        {
            this.Children = new ObservableCollection<MenuItemViewModel>();
        }

        public MenuItemViewModel(string header)
            : this()
        {
            this.Header = header;
        }

        public MenuItemViewModel(string header, string url)
            : this(header)
        {
            var browserExe = TryGetAppSetting("BrowserExe");
            this.ActionCommand = new DelegateCommand(s => Process.Start(browserExe, url));
            this.Children = new ObservableCollection<MenuItemViewModel>();
        }

        public MenuItemViewModel(string header, Action<object> action)
            : this(header)
        {
            this.ActionCommand = new DelegateCommand(action);
        }

        #endregion

        #region Properties

        public DelegateCommand ActionCommand { get; private set; }

        public ObservableCollection<MenuItemViewModel> Children { get; private set; }

        public string Header { get; set; }

        #endregion

        #region Methods

        public void AddChild(string header, string url)
        {
            this.Children.Add(new MenuItemViewModel(header, url));
        }

        public void AddChild(string header, Action<object> action)
        {
            this.Children.Add(new MenuItemViewModel(header, action));
        }

        private static string TryGetAppSetting(string key)
        {
            var value = ConfigurationManager.AppSettings[key];

            if (string.IsNullOrEmpty(value)) {
                throw new ConfigurationErrorsException(string.Format("Failed to retrieve app setting [{0}]", key));
            }

            return value;
        }

        #endregion
    }
}