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
    public sealed class S3MModuleInstrumentViewModel : ObservableObject
    {
        public ObservableCollection<S3MInstrumentViewModel> Instruments { get; }

        private S3MInstrumentViewModel _selectedInstrument = null!;

        public S3MInstrumentViewModel SelectedInstrument
        {
            get => _selectedInstrument;
            set => SetProperty(ref _selectedInstrument, value);
        }

        private S3MModule Module { get; }

        public S3MModuleInstrumentViewModel(S3MModule module)
        {
            Module = module ?? throw new System.ArgumentNullException(nameof(module));
            var instrumentViewModels = Module.Instruments.Select(instrument => CreateViewModel(instrument));
            Instruments = new ObservableCollection<S3MInstrumentViewModel>(instrumentViewModels);
        }

        private static S3MInstrumentViewModel CreateViewModel(S3MInstrument instrument)
        {
            switch (instrument)
            {
                case S3MEmptyInstrument emptyInstrument:
                    return new S3MEmptyInstrumentViewModel(emptyInstrument);

                case S3MAdlibInstrument adlibInstrument:
                    return new S3MAdlibInstrumentViewModel(adlibInstrument);

                case S3MPCMInstrument sampledInstrument:
                    return new S3MPCMInstrumentViewModel(sampledInstrument);
            }
            throw new NotSupportedException();
        }
    }
}
