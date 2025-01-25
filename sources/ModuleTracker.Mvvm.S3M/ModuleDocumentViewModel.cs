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
using System.Linq;
using System.Windows.Input;
using Microsoft.Toolkit.Mvvm.Input;
using ModuleTracker.Formats.S3M;

namespace ModuleTracker.Mvvm.S3M
{
    public sealed class ModuleDocumentViewModel : DocumentViewModel
    {
        private readonly Module _module;

        private readonly ChannelViewModelCollection _channels;

        private readonly PatternViewModelCollection _patterns;

        private readonly ObservableCollection<int> _patternOrderList;

        private readonly RelayCommand _gotoFirstPatternCommand;

        private readonly RelayCommand _gotoPreviousPatternCommand;

        private readonly RelayCommand _gotoNextPatternCommand;

        private readonly RelayCommand _gotoLastPatternCommand;

        public int PatternIndex
        {
            get => _patterns.PatternIndex;
            set
            {
                if (_patterns.GotoPattern(value))
                {
                    _gotoFirstPatternCommand.NotifyCanExecuteChanged();
                    _gotoPreviousPatternCommand.NotifyCanExecuteChanged();
                    _gotoNextPatternCommand.NotifyCanExecuteChanged();
                    _gotoLastPatternCommand.NotifyCanExecuteChanged();
                    OnPropertyChanged(nameof(PatternIndex));
                    OnPropertyChanged(nameof(LastPatternIndex));
                }
            }
        }

        public int LastPatternIndex => _patterns.PatternCount - 1;

        public ICommand GotoFirstPatternCommand => _gotoFirstPatternCommand;

        public ICommand GotoPreviousPatternCommand => _gotoPreviousPatternCommand;

        public ICommand GotoNextPatternCommand => _gotoNextPatternCommand;

        public ICommand GotoLastPatternCommand => _gotoLastPatternCommand;

        public ChannelViewModelCollection Channels => _channels;

        public PatternViewModelCollection Patterns => _patterns;

        public ObservableCollection<int> PatternOrder => _patternOrderList;

        public Module Module => _module;

        public ModuleDocumentViewModel(Module module)
        {
            _module = module ?? throw new ArgumentNullException(nameof(module));
            _channels = new ChannelViewModelCollection(_module);
            _patterns = new PatternViewModelCollection(_module);
            _patternOrderList = new ObservableCollection<int>(_module.PatternOrderList.Select(patternOrder => (int)patternOrder));
            _gotoFirstPatternCommand = new RelayCommand(GotoFirstPattern, CanGotoFirstPattern);
            _gotoPreviousPatternCommand = new RelayCommand(GotoPreviousPattern, CanGotoPreviousPattern);
            _gotoNextPatternCommand = new RelayCommand(GotoNextPattern, CanGotoNextPattern);
            _gotoLastPatternCommand = new RelayCommand(GotoLastPattern, CanGotoLastPattern);
        }

        private void GotoFirstPattern()
        {
            PatternIndex = 0;
        }

        private bool CanGotoFirstPattern()
        {
            return PatternIndex > 0 && LastPatternIndex > 0;
        }

        private void GotoPreviousPattern()
        {
            PatternIndex = PatternIndex - 1;
        }

        private bool CanGotoPreviousPattern()
        {
            return PatternIndex > 0 && LastPatternIndex > 1;
        }

        private void GotoNextPattern()
        {
            PatternIndex = PatternIndex + 1;
        }

        private bool CanGotoNextPattern()
        {
            return PatternIndex < LastPatternIndex;
        }

        private void GotoLastPattern()
        {
            PatternIndex = LastPatternIndex;
        }

        private bool CanGotoLastPattern()
        {
            return PatternIndex < LastPatternIndex;
        }
    }
}
