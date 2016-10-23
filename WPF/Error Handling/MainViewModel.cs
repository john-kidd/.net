namespace Error_Handling
{
    using System.Collections.ObjectModel;
    using WpfFramework.Generic;
    using WpfFramework.UI;

    public class MainViewModel : ViewModelBase
    {
        #region Fields and Constants

        private string _comments = "";
        
        private MainViewModel _original;

        private string _userName = "";

        #endregion

        #region Constructors

        public MainViewModel()
        {
            Validators.Add("Comments", () => string.IsNullOrEmpty(this.Comments) ? "Please enter a comment" : null);
            Validators.Add("UserName", () => string.IsNullOrEmpty(this.UserName) ? "Please enter a user name" : null);

            this.Ages = new ObservableCollection<int>
            {
                20,
                25,
                30,
                35,
                40,
                45,
                50,
                55,
                60
            };

            this.SaveCommand = new DelegateCommand(
                (s) => {
                },
                (s) => this.IsDirty);
        }

        #endregion

        #region Properties

        public int Age { get; set; }

        public ObservableCollection<int> Ages { get; private set; }

        public string Comments
        {
            get
            {
                return this._comments;
            }
            set
            {
                if (value == this._comments) {
                    return;
                }

                this._comments = value;
                PropertyDidChange();
                this.SaveCommand.RaiseCanExecuteChanged();
            }
        }

        public new bool IsDirty
        {
            get
            {
                return IsDirty(this._original, this);
            }
        }

        public DelegateCommand SaveCommand { get; private set; }

        public string UserName
        {
            get
            {
                return this._userName;
            }
            set
            {
                if (value == this._userName) {
                    return;
                }

                this._userName = value;
                PropertyDidChange();
                this.SaveCommand.RaiseCanExecuteChanged();
            }
        }

        #endregion

        #region Methods

        public void Init()
        {
            this._original = Clone(this);
        }

        #endregion
    }
}