using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace TestTaskWpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static DatabaseContext databaseContext = new DatabaseContext();

        protected override async void OnStartup(StartupEventArgs e)
        {
            var currentDomain = AppDomain.CurrentDomain;
            var basePath = currentDomain.BaseDirectory.Replace("\\bin\\Debug\\", "");
            currentDomain.SetData("DataDirectory", basePath);

            await Task.WhenAny(
                databaseContext.Companies.LoadAsync(),
                databaseContext.Departments.LoadAsync(),
                databaseContext.Employees.LoadAsync()
                );

            base.OnStartup(e);
        }

        internal static DbContext Database { get => databaseContext; }
    }
}
