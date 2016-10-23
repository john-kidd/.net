namespace Metro.Desktop.Converters
{
    using System;
    using System.Globalization;
    using System.Windows.Data;
    using System.Windows.Media.Imaging;

    public class StringToImageSourceConverter : IValueConverter
    {
        #region Methods

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var url = value as string;
            if (string.IsNullOrEmpty(url)) {
                return null;
            }
            var image = new BitmapImage();
            image.BeginInit();
            image.UriSource = new Uri(url);
            image.EndInit();

            return image;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }

        #endregion
    }
}