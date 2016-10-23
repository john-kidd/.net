namespace ContextMenu.ViewModels
{
    using System.Configuration;
    using System.Diagnostics;
    using Framework;

    public class QuickSearchViewModel : ViewModelBase
    {
        #region Fields and Constants

        private string _filterText;

        #endregion

        #region Constructors

        public QuickSearchViewModel()
        {
            var browserExe = ConfigurationManager.AppSettings["BrowserExe"];
            var quickSearchUrl = ConfigurationManager.AppSettings["QuickSearchUrl"];

            this.Title = "Quick Search";

            this.ExecuteCommand = new DelegateCommand(
                s => Process.Start(browserExe, string.Format(quickSearchUrl, this.FilterText)),
                s => !string.IsNullOrEmpty(this.FilterText));
        }

        #endregion

        #region Properties

        public DelegateCommand ExecuteCommand { get; set; }

        public string FilterText
        {
            get
            {
                return this._filterText;
            }
            set
            {
                if (value == this._filterText) {
                    return;
                }

                this._filterText = value;
                PropertyDidChange();
                this.ExecuteCommand.RaiseCanExecuteChanged();
            }
        }

        public string Title { get; set; }

        #endregion
    }
}