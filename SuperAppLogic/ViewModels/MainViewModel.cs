using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperAppLogic.ViewModels
{
    public class MainViewModel : ObservableRecipient
    {
        public ObservableRecipient CurrentViewModel { get; private set; }
        public FirstViewModel FirstViewModel { get; private set; }
        public SecondViewModel SecondViewModel { get; private set; }

        public MainViewModel()
        {
            FirstViewModel = new FirstViewModel();
            SecondViewModel = new SecondViewModel();
            CurrentViewModel = FirstViewModel;
        }
    }
}
