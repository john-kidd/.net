namespace ContextMenu.Views
{
    using System.Windows;
    using ViewModels;

    public partial class QuickSearchView
    {
        #region Constructors

        public QuickSearchView()
        {
            this.InitializeComponent();
            DataContext = new QuickSearchViewModel();
        }

        #endregion

        #region Methods

        private void WindowDidLoad(object sender, RoutedEventArgs e)
        {
            var desktopWorkingArea = SystemParameters.WorkArea;
            Left = desktopWorkingArea.Right - Width;
            Top = desktopWorkingArea.Bottom - Height;
        }

        #endregion
    }
}