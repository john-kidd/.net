namespace WpfFramework.UI
{
    using System;
    using System.Runtime.InteropServices;
    using System.Windows;

    /// <summary>
    ///     Interaction logic for HtmlBrowser.xaml
    /// </summary>
    public partial class HtmlBrowser
    {
        #region Fields and Constants

        public static readonly DependencyProperty UrlProperty = 
            DependencyProperty.Register(
                "Url", 
                typeof(string), 
                typeof(HtmlBrowser));

        #endregion

        #region Constructors

        public HtmlBrowser()
        {
            this.InitializeComponent();
        }

        #endregion

        #region Properties

        public string Url
        {
            get
            {
                return (string) GetValue(UrlProperty);
            }
            set
            {
                SetValue(UrlProperty, value);
            }
        }

        #endregion

        #region Methods

        protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);
            if (e.Property == UrlProperty) {
                this.DoNavigate();
            }
        }

        private void DoNavigate()
        {
            if (!string.IsNullOrEmpty(this.Url)) {
                this.Browser.Navigate(this.Url);
            }
        }

        #endregion
    }
}