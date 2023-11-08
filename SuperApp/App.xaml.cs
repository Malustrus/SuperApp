using SuperApp.ViewModels;
using SuperAppLogic;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;

namespace SuperApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App() : base() 
        {
            AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;
        }

        private System.Reflection.Assembly? CurrentDomain_AssemblyResolve(object? sender, ResolveEventArgs args)
        {
            if (args.Name.Contains("SuperAppLogic"))
            {
                var v = Assembly.LoadFrom("SuperAppLogicEncrypted.dll"); //<=====
                return v;
            }
            return null;
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            BenchProcess benchProcess = new BenchProcess();
            MainWindow = new MainWindow();
            MainWindow.DataContext = new MainViewModel(benchProcess);
            MainWindow.Show();
            benchProcess.Start();
        }
    }
}
