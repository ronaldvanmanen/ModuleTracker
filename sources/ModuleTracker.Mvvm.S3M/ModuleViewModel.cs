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
using Microsoft.Toolkit.Mvvm.ComponentModel;
using ModuleTracker.Formats.S3M;

namespace ModuleTracker.Mvvm.S3M
{
    public sealed class ModuleViewModel : ObservableObject
    {
        private readonly Module _module;

        private PatternListViewModel _patterns;

        private InstrumentListViewModel _instruments;

        public string Title => _module.Title;

        public PatternListViewModel Patterns =>
            _patterns ??= new PatternListViewModel(_module);

        public InstrumentListViewModel Instruments =>
            _instruments ??= new InstrumentListViewModel(_module);

        public ModuleViewModel(Module module)
        {
            _module = module ?? throw new ArgumentNullException(nameof(module));
            _patterns = null!;
            _instruments = null!;
        }
    }
}
