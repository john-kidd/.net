namespace Metro.Desktop.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Diagnostics;
    using System.Windows;
    using Gam.AppCentral.Desktop.Framework;
    using Models;
    using WpfFramework.Generic;

    public class MainViewModel : ViewModelBase
    {
        #region Constructors

        public MainViewModel(ITaskPollingService taskPollingService)
        {
            this.Actions = new ObservableCollection<ActionViewModel>();
            this.Tasks = new ObservableCollection<TaskViewModel>();
            IsBusy = true;
            BusyMessage = "Loading...";
            taskPollingService.ActiveTasksFound += this.ActiveTasksWereFound;
            this.LoadEmployeeActions();
            this.ActionCommand = new DelegateCommand(
                s => {
                    var index = (int) s;
                    var action = this.Actions[index];
                    if (action == null) {
                        return;
                    }

                    if (action.Url.Contains("http://")) {
                        var browserExe = TryGetAppSetting("BrowserExe");

                        Process.Start(browserExe, action.Url);
                    }
                    else {
                        Process.Start(action.Url);
                    }
                });
        }

        #endregion

        #region Properties

        public DelegateCommand ActionCommand { get; private set; }

        public ObservableCollection<ActionViewModel> Actions { get; private set; }

        public ObservableCollection<TaskViewModel> Tasks { get; private set; }

        #endregion

        #region Methods

        public async void LoadEmployeeActions()
        {
            try {
                var data = await new ActionsService().GetActionsAsync();

                this.Actions.Clear();

                for (var index = 0; index < data.Count; index++) {
                    var action = data[index];
                    this.Actions.Add(new ActionViewModel(action));
                }
            }
            catch (Exception ex) {
                //TODO: how do we handle exceptions
                MessageBox.Show(ex.Message);
            }
            finally {
                IsBusy = false;
            }
        }

        private void ActiveTasksWereFound(object sender, IEnumerable<WorklistItem> e)
        {
            this.Tasks.Clear();

            foreach (var task in e) {
                if (task.Status == "Available") {
                    this.Tasks.Add(new TaskViewModel(task));
                }
            }
        }

        #endregion
    }
}