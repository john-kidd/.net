namespace Metro.Desktop.ViewModels
{
    using System;
    using Gam.AppCentral.Desktop.Framework;
    using WpfFramework.Generic;

    public class TaskViewModel : ViewModelBase
    {
        #region Constructors

        public TaskViewModel(WorklistItem task)
        {
            this.Url = task.Action;
            this.Header = task.Title;
            this.Status = task.Status;
            this.AllocatedUser = task.AssignedUser;
            this.StartDate = task.StartDate;
        }

        #endregion

        #region Properties

        public DelegateCommand ActionCommand { get; private set; }

        public string AllocatedUser { get; set; }

        public string AvailableActions { get; set; }

        public string Header { get; set; }

        public DateTime StartDate { get; set; }

        public string Status { get; set; }

        public string Url { get; set; }

        #endregion
    }
}