namespace WPFParentChildBinding
{
    using System.Collections.ObjectModel;
    using System.Windows;

    public class MainWindowViewModel
    {
        #region Constructors

        public MainWindowViewModel()
        {
            this.Pressed = new DelegateCommand(
                (s) => {
                    this.Photos.Add(@"joe.jpg");
                    this.Photos.Add(@"bob.jpg");
                    this.Photos.Add(@"jim.jpg");
                    this.Photos.Add(@"jack.jpg");
                });

            this.Allow = new DelegateCommand(
                (s) => MessageBox.Show("allowed"));

            this.Photos = new ObservableCollection<string>();
        }

        #endregion

        #region Properties

        public DelegateCommand Allow { get; private set; }

        public ObservableCollection<string> Photos { get; private set; }

        public DelegateCommand Pressed { get; private set; }

        #endregion
    }
}