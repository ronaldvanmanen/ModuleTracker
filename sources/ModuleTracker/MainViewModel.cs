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

namespace ModuleTracker
{
    internal sealed class MainViewModel : ObservableObject
    {
        private IOpenFileService OpenFileService { get; }

        public ICommand OpenFileCommand { get; }

        public ICommand ExitCommand { get; }

        public MainViewModel(IOpenFileService openFileService)
        {
            OpenFileService = openFileService ?? throw new System.ArgumentNullException(nameof(openFileService));
            OpenFileCommand = new RelayCommand(ExecuteOpenFile);
            ExitCommand = new RelayCommand(ExecuteExit);
        }

        private void ExecuteOpenFile()
        {
            var moduleFileNames = OpenFileService.ShowDialog("Open Module...", "Scream Tracker 3|*.s3m");
            foreach (var moduleFileName in moduleFileNames)
            {
            }
        }

        private void ExecuteExit()
        {
            Application.Current.Shutdown();
        }
    }
}
