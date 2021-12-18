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

using System.Collections.Generic;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using ModuleTracker.Formats.S3M;

namespace ModuleTracker.Mvvm.S3M
{
    public sealed class PatternViewModel : ObservableObject
    {
        private readonly Module _module;

        private readonly int _patternIndex;

        private readonly Dictionary<PatternRow, PatternRowViewModel> _rowViewModels;

        public int Count => _module.Patterns[_patternIndex].Count;

        public PatternRowViewModel this[int rowIndex]
        {
            get
            {
                var row = _module.Patterns[_patternIndex][rowIndex];
                if (_rowViewModels.TryGetValue(row, out var rowViewModel))
                {
                    return rowViewModel;
                }

                rowViewModel = new PatternRowViewModel(_module, _patternIndex, rowIndex);
                _rowViewModels.Add(row, rowViewModel);
                return rowViewModel;
            }
        }

        public PatternViewModel(Module module, int patternIndex)
        {
            _module = module;
            _patternIndex = patternIndex;
            _rowViewModels = new Dictionary<PatternRow, PatternRowViewModel>();
        }

        public int IndexOf(PatternRowViewModel item)
        {
            return -1;
        }
    }
}
