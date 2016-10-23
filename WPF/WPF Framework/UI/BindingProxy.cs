namespace WpfFramework.UI
{
    using System.Windows;

    public class BindingProxy : Freezable
    {
        // Using a DependencyProperty as the backing store for Data.  This enables animation, styling, binding, etc...

        #region Fields and Constants

        public static readonly DependencyProperty DataProperty =
            DependencyProperty.Register("Data", typeof (object), typeof (BindingProxy), new UIPropertyMetadata(null));

        #endregion

        #region Properties

        public object Data
        {
            get
            {
                return GetValue(DataProperty);
            }
            set
            {
                SetValue(DataProperty, value);
            }
        }

        #endregion

        #region Methods

        protected override Freezable CreateInstanceCore()
        {
            return new BindingProxy();
        }

        #endregion
    }
}