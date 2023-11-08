using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;

namespace Launcher
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App() : base() 
        {
            //AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;
            
        }

        private Assembly? CurrentDomain_AssemblyResolve(object? sender, ResolveEventArgs args)
        {
            //throw new NotImplementedException();
            return null;
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var businessAssembly = Assembly.LoadFrom("SuperAppLogic.dll");
            Type type = businessAssembly.GetType("SuperAppLogic.ViewModels.MainViewModel");
            ResourceDictionary rd = new ResourceDictionary();
            rd.Source = new Uri(@"pack://application:,,,/SuperAppLogic;component/Dictionary.xaml");
            this.Resources.MergedDictionaries.Add(rd);
            var mainViewModel = Activator.CreateInstance(type);
            MainWindow = new MainWindow();
            MainWindow.DataContext = mainViewModel;
            MainWindow.Show();
        }
    }
}
