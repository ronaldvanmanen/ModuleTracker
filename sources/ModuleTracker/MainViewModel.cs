// This file is part of Module Tracker.
//
// Module Tracker is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// Module Tracker is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with Module Tracker.  If not, see <https://www.gnu.org/licenses/>.

using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System.Windows;
using System.Windows.Input;
using ModuleTracker.Formats.S3M;
using ModuleTracker.Mvvm.S3M;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace ModuleTracker
{
    internal sealed class MainViewModel : ObservableObject
    {
        private IOpenFileService OpenFileService { get; }

        public ICommand OpenFileCommand { get; }

        public ICommand ExitCommand { get; }

        public ObservableCollection<ModuleViewModel> Modules { get; }

        public MainViewModel(IOpenFileService openFileService)
        {
            OpenFileService = openFileService ?? throw new System.ArgumentNullException(nameof(openFileService));
            OpenFileCommand = new AsyncRelayCommand(ExecuteOpenFile);
            ExitCommand = new RelayCommand(ExecuteExit);
            Modules = new ObservableCollection<ModuleViewModel>();
        }

        private async Task ExecuteOpenFile()
        {
            var moduleFileNames = OpenFileService.ShowDialog("Open Module...", "Scream Tracker 3|*.s3m");
            await Task.Run(() =>
            {
                foreach (var moduleFileName in moduleFileNames)
                {
                    var module = Module.Deserialize(moduleFileName);
                    var viewModel = new ModuleViewModel(module);
                    Application.Current.Dispatcher.Invoke(() => Modules.Add(viewModel));
                }
            });
        }

        private void ExecuteExit()
        {
            Application.Current.Shutdown();
        }
    }
}
