namespace Gam.AppCentral.Desktop.Framework
{
    using System;
    using System.Collections.Generic;

    public interface ITaskPollingService
    {
        #region Events

        event EventHandler<IEnumerable<WorklistItem>> ActiveTasksFound;

        #endregion

        #region Properties

        bool IsStarted { get; }

        #endregion

        #region Methods

        void Start();

        void Stop();

        #endregion
    }
}