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
        /// <summary>
        /// L'application ne contient que les viewmodels et views spécifique au banc.
        /// La logique métier est dans la dll SuperAppLogic (Process, Datamanger...).
        /// </summary>
        public App() : base() 
        {
            AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;
        }

        private System.Reflection.Assembly? CurrentDomain_AssemblyResolve(object? sender, ResolveEventArgs args)
        {
            //Evènement déclanché si SuperAppLogic.dll est introuvable. Dans cet exemple elle est renommée en SuperAppLogicEncrypted.dll
            if (args.Name.Contains("SuperAppLogic"))
            {
                //On peut fournir içi la dll a charger avec une méthode spécifique pour la lecture du fichier. C'est ici qu'il faut appeler la blackbox pour déchiffrer.
                //Pour l'exemple :
                var assembly = Assembly.LoadFrom("SuperAppLogicEncrypted.dll");
                //En réallité :
                //var v = Assembly.Load(byte[] rawAssembly); // Chargement depuis un flux binaire renvoyé par la blackbox
                return assembly;
            }
            return null;
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            SuperApp_ProcessManager benchProcess = new SuperApp_ProcessManager();
            MainWindow = new MainWindow();
            MainWindow.DataContext = new MainViewModel(benchProcess);
            MainWindow.Show();
            benchProcess.Start();
        }
    }
}
