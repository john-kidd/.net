namespace Gam.AppCentral.Desktop.Framework
{
    using System;

    public class DataEventArgs<TData> : EventArgs
    {
        #region Constructors

        public DataEventArgs(TData data)
        {
            this.Data = data;
        }

        #endregion

        #region Properties

        public TData Data { get; private set; }

        #endregion
    }
}