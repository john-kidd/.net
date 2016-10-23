using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Error_Handling
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var viewModel = new MainViewModel();
            viewModel.Init();
            var view = new MainView
            {
                DataContext = viewModel
            };

            MainWindow = view;
            view.Show();
        }
    }
}
