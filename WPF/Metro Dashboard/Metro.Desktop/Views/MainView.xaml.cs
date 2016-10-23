namespace Metro.Desktop.Views
{
    using Telerik.Windows.Controls;
    using ViewModels;

    /// <summary>
    ///     Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView: RadWindow
    {
        #region Constructors

        public MainView()
        {
            this.InitializeComponent();
        }

        #endregion
        
        private void BindingDidComplete(object sender, AutoGeneratingTileEventArgs e)
        {
            
            e.Tile.Group = ((ActionViewModel)e.Tile.Content).Group;

            e.Tile.Background = ((ActionViewModel) e.Tile.Content).BackgroundColour;
            e.Tile.Foreground = ((ActionViewModel)e.Tile.Content).ForegroundColour;
        }
    }
}