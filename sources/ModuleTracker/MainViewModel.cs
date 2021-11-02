using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System.Windows;
using System.Windows.Input;

namespace ModuleTracker
{
    public sealed class MainViewModel : ObservableObject
    {
        public ICommand ExitCommand { get; }

        public MainViewModel()
        {
            ExitCommand = new RelayCommand(ExecuteExit);
        }

        private void ExecuteExit()
        {
            Application.Current.Shutdown();
        }
    }
}
