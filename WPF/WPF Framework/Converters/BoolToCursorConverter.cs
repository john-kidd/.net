namespace WpfFramework.Converters
{
    using System;
    using System.Globalization;
    using System.Windows.Data;
    using System.Windows.Input;

    public class BoolToCursorConverter : IValueConverter
    {
        #region Methods

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) {
                return null;
            }

            bool test;
            if (bool.TryParse(value.ToString(), out test)) {
                return test ? Cursors.Wait : Cursors.Arrow;
            }

            return Cursors.Arrow;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }

        #endregion
    }
}