﻿// This file is part of Module Tracker.
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
using System.Collections.Generic;
using System.Linq;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using ModuleTracker.Formats.S3M;

namespace ModuleTracker.Mvvm.S3M
{
    public sealed class PatternRowViewModel : ObservableObject
    {
        private readonly Module _module;

        private readonly int _patternIndex;

        private readonly int _rowIndex;

        private readonly List<PatternCellViewModel> _channels;

        public List<PatternCellViewModel> Channels => _channels;

        public int PatternIndex => _patternIndex;

        public int RowIndex => _rowIndex;

        public PatternRowViewModel(Module module, int patternIndex, int rowIndex)
        {
            _module = module;
            _patternIndex = patternIndex;
            _rowIndex = rowIndex;

            var pattern = _module.Patterns[_patternIndex];
            var row = pattern[_rowIndex];
            var channels = row.Select(channel => new PatternCellViewModel(channel));
            _channels = new List<PatternCellViewModel>(channels);
        }
    }
}
