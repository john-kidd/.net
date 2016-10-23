namespace AsyncAwait
{
    using System.Windows;

    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Constructors

        public MainWindow()
        {
            this.InitializeComponent();
            DataContext = new MainViewModel();
        }

        #endregion
    }
}