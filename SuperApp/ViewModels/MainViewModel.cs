using CommunityToolkit.Mvvm.ComponentModel;
using SuperAppLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperApp.ViewModels
{
    public class MainViewModel : ObservableRecipient
    {
        public ObservableRecipient CurrentViewModel { get; private set; }
        public ProcessViewModel ProcessViewModel { get; private set; }

        public MainViewModel(SuperApp_ProcessManager benchProcess)
        {
            ProcessViewModel = new ProcessViewModel(benchProcess);
            CurrentViewModel = ProcessViewModel;
        }
    }
}
