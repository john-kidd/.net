namespace Metro.Desktop.Models
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows.Media;
    using ViewModels;

    public class ActionsService
    {
        #region Methods

        public async Task<List<ActionModel>> GetActionsAsync()
        {
            var task = await Task.Run(
                () => {
                    Thread.Sleep(1200);

                    return new List<ActionModel>
                    {
                        new ActionModel
                        {
                            BackgroundColour = "#36B7E5",
                            ForegroundColour = "#FFFFFF",
                            Group = "Fund Reports",
                            Header = "Asset Classes"
                        },
                        new ActionModel
                        {
                            BackgroundColour = "#36B7E5",
                            ForegroundColour = "#FFFFFF",
                            Group = "Fund Reports",
                            Header = "Valuations"
                        },
                        new ActionModel
                        {
                            BackgroundColour = "#36B7E5",
                            ForegroundColour = "#FFFFFF",
                            Group = "Fund Reports",
                            Header = "Contribution"
                        },
                        new ActionModel
                        {
                            BackgroundColour = "#36B7E5",
                            ForegroundColour = "#FFFFFF",
                            Group = "Fund Admin",
                            Header = "Create Fund"
                        },
                        new ActionModel
                        {
                            BackgroundColour = "#36B7E5",
                            ForegroundColour = "#FFFFFF",
                            Group = "Fund Admin",
                            Header = "Edit Fund"
                        },
                        new ActionModel
                        {
                            BackgroundColour = "#36B7E5",
                            ForegroundColour = "#FFFFFF",
                            Group = "Finance",
                            Header = "Expenses"
                        }
                    };
                });

            return task;
        }

        #endregion
    }
}