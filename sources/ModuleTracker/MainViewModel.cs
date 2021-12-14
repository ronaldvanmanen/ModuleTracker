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

using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Toolkit.Mvvm.Messaging;
using ModuleTracker.Formats.S3M;
using ModuleTracker.Mvvm;
using ModuleTracker.Mvvm.S3M;
using ModuleTracker.Services;

namespace ModuleTracker
{
    internal sealed class MainViewModel : ObservableRecipient
    {
        private DocumentViewModel _activeDocument = null!;

        public DocumentViewModel ActiveDocument
        {
            get => _activeDocument;

            set
            {
                if (SetProperty(ref _activeDocument, value))
                {
                    Messenger.Send(new ActiveObjectChangedMessage(_activeDocument));
                }
            }
        }

        public ObservableCollection<DocumentViewModel> Documents { get; }

        public ObservableCollection<ToolboxViewModel> Tools { get; }

        private IOpenFileService OpenFileService { get; }

        public ICommand OpenFileCommand { get; }

        public ICommand ExitCommand { get; }

        public MainViewModel(IOpenFileService openFileService)
        {
            OpenFileService = openFileService ?? throw new ArgumentNullException(nameof(openFileService));
            OpenFileCommand = new AsyncRelayCommand(ExecuteOpenFile);
            ExitCommand = new RelayCommand(ExecuteExit);
            Documents = new ObservableCollection<DocumentViewModel>();
            Tools = new ObservableCollection<ToolboxViewModel>
            {
                new PropertiesViewModel
                {
                    IsPaneVisible = true
                }
            };
        }

        private async Task ExecuteOpenFile()
        {
            var moduleFileNames = OpenFileService.ShowDialog("Open Module...", "Scream Tracker 3|*.s3m");
            await Task.Run(() =>
            {
                foreach (var moduleFileName in moduleFileNames)
                {
                    var module = Module.Deserialize(moduleFileName);
                    var moduleViewModel = new ModuleViewModel(module);
                    Application.Current.Dispatcher.Invoke(() => Documents.Add(moduleViewModel));
                }
            });
        }

        private void ExecuteExit()
        {
            Application.Current.Shutdown();
        }
    }
}
