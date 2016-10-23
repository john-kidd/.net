namespace AsyncAwait
{
    using System;
    using WpfFramework.Generic;
    using WpfFramework.UI;

    public class MainViewModel : ViewModelBase
    {
        #region Fields and Constants

        private string _message;

        #endregion

        #region Constructors

        public MainViewModel()
        {
            this.TestCommand = new DelegateCommand(this.TestCommandAction);
        }

        #endregion

        #region Properties

        public string Message
        {
            get
            {
                return this._message;
            }
            set
            {
                if (value == this._message) {
                    return;
                }

                this._message = value;
                PropertyDidChange();
            }
        }

        public DelegateCommand TestCommand { get; private set; }

        #endregion

        #region Methods

        private async void TestCommandAction(object sender)
        {
            try {
                IsBusy = true;
                BusyMessage = "Loading";
                var data = await Model.GetMessageAsync();

                this.Message = data;
            }
            catch (Exception ex) {
                //Error = ex.Message;
            }
            finally {
                IsBusy = false;
                BusyMessage = "Ready";
            }
        }

        #endregion
    }
}