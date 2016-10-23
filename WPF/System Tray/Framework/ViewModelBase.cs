namespace ContextMenu.Framework
{
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using Properties;

    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        #region Events

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Methods

        [NotifyPropertyChangedInvocator]
        protected virtual void PropertyDidChange([CallerMemberName] string propertyName = null)
        {
            var handler = this.PropertyChanged;
            if (handler != null) {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion
    }
}