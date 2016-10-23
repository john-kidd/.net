namespace Metro.Desktop.ViewModels
{
    using System.Windows.Media;
    using Gam.AppCentral.Desktop.Framework;
    using Models;
    using WpfFramework.Generic;

    public class ActionViewModel : ViewModelBase
    {
        #region Fields and Constants

        private Brush _backgroundColour;

        private Brush _foregroundColour;

        #endregion

        #region Constructors

        public ActionViewModel(ActionModel action)
        {
            this.BackgroundColour = CreateSolidColorBrush(action.BackgroundColour);
            this.ForegroundColour = CreateSolidColorBrush(action.ForegroundColour);
            this.Group = action.Group;
            this.Header = action.Header;
            this.Url = action.Url;
        }

        #endregion

        #region Properties

        public DelegateCommand ActionCommand { get; private set; }

        public Brush BackgroundColour
        {
            get
            {
                return this._backgroundColour;
            }
            set
            {
                this._backgroundColour = value;
                PropertyDidChange();
            }
        }

        public Brush ForegroundColour
        {
            get
            {
                return this._foregroundColour;
            }
            set
            {
                this._foregroundColour = value;
                PropertyDidChange();
            }
        }

        public string Group { get; set; }

        public string Header { get; set; }

        public string Url { get; private set; }

        #endregion

        #region Methods

        protected static Brush CreateSolidColorBrush(string hex)
        {
            if (string.IsNullOrEmpty(hex)) {
                return new SolidColorBrush(Colors.WhiteSmoke);
            }

            var brush = (Brush) (new BrushConverter().ConvertFrom(hex));

            return brush;
        }

        #endregion
    }
}