using CommunityToolkit.Mvvm.ComponentModel;
using SuperAppLogic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperApp.ViewModels
{
    public class ProcessViewModel : ObservableRecipient
    {
        private readonly SuperApp_ProcessManager benchProcess;

        public ObservableCollection<string> ProcessMessages { get; private set; } = new ObservableCollection<string>();

        public ProcessViewModel(SuperApp_ProcessManager benchProcess)
        {
            this.benchProcess = benchProcess;
            benchProcess.OnProcessStatusUpdated += BenchProcess_OnProcessStatusUpdated;
        }

        private void BenchProcess_OnProcessStatusUpdated(string status)
        {
            App.Current.Dispatcher.Invoke(() => { ProcessMessages.Insert(0, status); });
        }
    }
}
