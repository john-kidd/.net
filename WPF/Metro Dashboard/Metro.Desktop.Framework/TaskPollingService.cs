namespace Gam.AppCentral.Desktop.Framework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows.Threading;

    public class TaskPollingService : ITaskPollingService
    {
        #region Fields and Constants

        private readonly DispatcherTimer _timer;

        #endregion

        #region Constructors

        public TaskPollingService()
        {
            this._timer = new DispatcherTimer();
            this._timer.Tick += this.IntervalHasElapsed;
            this._timer.Interval = new TimeSpan(0, 1, 0);
        }

        #endregion

        #region Events

        public event EventHandler<IEnumerable<WorklistItem>> ActiveTasksFound;

        #endregion

        #region Properties

        public bool IsStarted { get; private set; }

        #endregion

        #region Methods

        public void Start()
        {
            this._timer.Start();
            this.CheckForWorkflowTasks();
            this.IsStarted = true;
        }

        public void Stop()
        {
            this._timer.Stop();
            this.IsStarted = false;
        }

        protected virtual void ActiveTasksWereFound(IEnumerable<WorklistItem> e)
        {
            var handler = this.ActiveTasksFound;
            if (handler != null) {
                handler(this, e);
            }
        }

        private async void CheckForWorkflowTasks()
        {
            var workflowTasks = await Task.Run(
                () => {
                    Thread.Sleep(5000);

                    return new List<WorklistItem>
                    {
                        new WorklistItem
                        {
                            Action = "http://www.google.co.uk",
                            AssignedUser = Thread.CurrentPrincipal.Identity.Name,
                            StartDate = DateTime.Now.AddDays(-1),
                            Status = "Available",
                            Title = "Setup Fund Strategy"
                        }
                    };
                });

            try {
                if (workflowTasks != null && workflowTasks.Any(x => x.Status == "Available")) {
                    this.ActiveTasksWereFound(workflowTasks);
                }
            } catch (AggregateException ae) {
            }
        }

        private void IntervalHasElapsed(object sender, EventArgs e)
        {
            this.CheckForWorkflowTasks();
        }

        #endregion
    }
}