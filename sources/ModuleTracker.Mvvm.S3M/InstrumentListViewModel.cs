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
using Microsoft.Toolkit.Mvvm.ComponentModel;
using ModuleTracker.Formats.S3M;

namespace ModuleTracker.Mvvm.S3M
{
    public sealed class InstrumentListViewModel : ObservableObject
    {
        public ObservableCollection<InstrumentViewModel> Instruments { get; }

        private InstrumentViewModel _selectedInstrument = null!;

        public InstrumentViewModel SelectedInstrument
        {
            get => _selectedInstrument;
            set => SetProperty(ref _selectedInstrument, value);
        }

        private Module Module { get; }

        public InstrumentListViewModel(Module module)
        {
            Module = module ?? throw new ArgumentNullException(nameof(module));
            var instrumentViewModels = Module.Instruments.Select(instrument => CreateViewModel(instrument));
            Instruments = new ObservableCollection<InstrumentViewModel>(instrumentViewModels);
        }

        private static InstrumentViewModel CreateViewModel(Instrument instrument)
        {
            switch (instrument)
            {
                case EmptyInstrument emptyInstrument:
                    return new EmptyInstrumentViewModel(emptyInstrument);

                case AdlibInstrument adlibInstrument:
                    return new AdlibInstrumentViewModel(adlibInstrument);

                case SampleInstrument sampledInstrument:
                    return new SampleInstrumentViewModel(sampledInstrument);
            }
            throw new NotSupportedException();
        }
    }
}
