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

using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using ModuleTracker.Formats.S3M;
using System.Linq;

namespace ModuleTracker.Mvvm.S3M
{
    public sealed class PatternListViewModel : ObservableObject
    {
        private int _currentPatternIndex;

        private Module Module { get; }

        private List<PatternViewModel> Patterns { get; set; }

        public PatternViewModel CurrentPattern
        {
            get
            {
                return Patterns[CurrentPatternIndex];
            }
        }

        public int CurrentPatternIndex
        {
            get => _currentPatternIndex;
            set
            {
                SetProperty(ref _currentPatternIndex, value);
                OnPropertyChanged(nameof(CurrentPattern));
                GotoFirstPatternCommand.NotifyCanExecuteChanged();
                GotoPreviousPatternCommand.NotifyCanExecuteChanged();
                GotoNextPatternCommand.NotifyCanExecuteChanged();
                GotoLastPatternCommand.NotifyCanExecuteChanged();
            }
        }

        public int FirstPatternIndex => 0;

        public int LastPatternIndex => Module.Patterns.Count - 1;

        public IRelayCommand GotoFirstPatternCommand { get; }

        public IRelayCommand GotoPreviousPatternCommand { get; }

        public IRelayCommand GotoNextPatternCommand { get; }

        public IRelayCommand GotoLastPatternCommand { get; }

        public PatternListViewModel(Module module)
        {
            Module = module ?? throw new ArgumentNullException(nameof(module));
            var patterns = Module.Patterns.Select(pattern => new PatternViewModel(pattern));
            Patterns = new List<PatternViewModel>(patterns);
            GotoFirstPatternCommand = new RelayCommand(GotoFirstPattern, CanGotoFirstPattern);
            GotoPreviousPatternCommand = new RelayCommand(GotoPreviousPattern, CanGotoPreviousPattern);
            GotoNextPatternCommand = new RelayCommand(GotoNextPattern, CanGotoNextPattern);
            GotoLastPatternCommand = new RelayCommand(GotoLastPattern, CanGotoLastPattern);
        }

        private void GotoFirstPattern()
        {
            CurrentPatternIndex = FirstPatternIndex;
        }

        private bool CanGotoFirstPattern()
        {
            return CurrentPatternIndex > FirstPatternIndex;
        }

        private void GotoPreviousPattern()
        {
            --CurrentPatternIndex;
        }

        private bool CanGotoPreviousPattern()
        {
            return CurrentPatternIndex > FirstPatternIndex;
        }

        private void GotoNextPattern()
        {
            ++CurrentPatternIndex;
        }

        private bool CanGotoNextPattern()
        {
            return CurrentPatternIndex < LastPatternIndex;
        }

        private void GotoLastPattern()
        {
            CurrentPatternIndex = LastPatternIndex;
        }

        private bool CanGotoLastPattern()
        {
            return CurrentPatternIndex < LastPatternIndex;
        }
    }
}
