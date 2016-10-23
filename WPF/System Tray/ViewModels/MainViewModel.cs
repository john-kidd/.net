namespace ContextMenu.ViewModels
{
    using System.Collections.ObjectModel;
    using System.Configuration;
    using System.Threading.Tasks;
    using System.Windows;
    using Framework;
    using Views;

    public class MainViewModel : ViewModelBase
    {
        #region Fields and Constants

        private readonly QuickSearchView _quickSearchView;
        
        #endregion

        #region Constructors

        public MainViewModel()
        {
            var isInRoleUrl = TryGetAppSetting("IsInRoleUrl");

            this._quickSearchView = new QuickSearchView();
            this.MenuItems = new ObservableCollection<MenuItemViewModel>
            {
                new MenuItemViewModel("Dashboard", TryGetAppSetting("DashboardUrl")),
                new MenuItemViewModel("Advanced Search", TryGetAppSetting("AdvancedSearchUrl")),
                new MenuItemViewModel("Quick Search", s => this._quickSearchView.ShowDialog())
            };

            var reportsMenu = new MenuItemViewModel("Reports");
            reportsMenu.AddChild("Standard Reports", TryGetAppSetting("StandardReports"));

            this.MenuItems.Add(reportsMenu);

            var task = Task.Factory.StartNew(
                () => {
                    var url = string.Format(isInRoleUrl, @"IT - Enterprise Business Systems Team");
                    return IsInRole(url);
                });

            var task2 = Task.Factory.StartNew(
                () => {
                    var url = string.Format(isInRoleUrl, @"HR London");
                    return IsInRole(url);
                });

            Task.WaitAll(task, task2);

            if (task.Result || task2.Result) {
                reportsMenu.AddChild("HR Reports", TryGetAppSetting("HRReports"));
            }
        }

        #endregion

        #region Properties

        public ObservableCollection<MenuItemViewModel> MenuItems { get; private set; }

        #endregion

        #region Methods

        private static bool IsInRole(string stsServiceUrl)
        {
            return true;
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