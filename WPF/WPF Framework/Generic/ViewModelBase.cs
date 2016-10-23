namespace WpfFramework.Generic
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Configuration;
    using System.Runtime.CompilerServices;
    using Properties;

    public abstract class ViewModelBase : IDataErrorInfo, INotifyPropertyChanged
    {
        #region Fields and Constants

        protected readonly Dictionary<string, Func<string>> Validators;

        private string _busyMessage;

        private bool _isBusy;

        #endregion

        #region Constructors

        protected ViewModelBase()
        {
            this.Validators = new Dictionary<string, Func<string>>();
        }

        #endregion

        #region Events

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Properties

        public string BusyMessage
        {
            get
            {
                return this._busyMessage;
            }
            set
            {
                if (value == this._busyMessage) {
                    return;
                }

                this._busyMessage = value;
                this.PropertyDidChange();
            }
        }

        public string Error
        {
            get
            {
                return null;
            }
        }

        public bool IsBusy
        {
            get
            {
                return this._isBusy;
            }
            set
            {
                if (value == this._isBusy) {
                    return;
                }

                this._isBusy = value;
                this.PropertyDidChange();
            }
        }
        
        public bool IsValid
        {
            get
            {
                foreach (var key in this.Validators.Keys) {
                    if (this.Validators.ContainsKey(key) && this.Validators[key] != null) {
                        return false;
                    }
                }

                return true;
            }
        }

        #endregion

        #region Indexers

        public string this[string propertyName]
        {
            get
            {
                if (this.Validators.ContainsKey(propertyName)) {
                    return this.Validators[propertyName]();
                }

                return null;
            }
        }

        #endregion

        #region Methods

        public static T Clone<T>(T source) where T : new()
        {
            var json = DataContractJsonSerialiser.Serialise(source);
            return DataContractJsonSerialiser.Deserialise<T>(json);
        }

        public static bool IsDirty<T>(T sourceA, T sourceB) where T : class
        {
            // We cannot get memory streams for null objects
            // so let's assume the wors and say it's dirty
            if (sourceA == null || sourceB == null) {
                return true;
            }

            var a = DataContractJsonSerialiser.Serialise(sourceA);
            var b = DataContractJsonSerialiser.Serialise(sourceB);

            return String.CompareOrdinal(a, b) != 0;
        }
        
        protected static string TryGetAppSetting(string key)
        {
            var value = ConfigurationManager.AppSettings[key];

            if (string.IsNullOrEmpty(value)) {
                throw new ConfigurationErrorsException(string.Format("Failed to retrieve app setting [{0}]", key));
            }

            return value;
        }

        protected static string TryGetAppSetting(string fileName, string key)
        {
            var libConfig = ConfigurationManager.OpenMappedExeConfiguration(
                new ExeConfigurationFileMap
                {
                    ExeConfigFilename = fileName
                },
                ConfigurationUserLevel.None);

            var section = (libConfig.GetSection("appSettings") as AppSettingsSection);

            if (section != null) {
                var setting = section.Settings[key];

                if (string.IsNullOrEmpty(setting.Key)) {
                    throw new ConfigurationErrorsException(string.Format("Failed to retrieve app setting [{0}]", key));
                }

                return setting.Value;
            }
            return null;
        }

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