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
using System.Collections.Generic;
using ModuleTracker.Formats.S3M;

namespace ModuleTracker.Mvvm.S3M
{
    public sealed class S3MPatternViewModel
    {
        private readonly S3MPattern _pattern;

        public IEnumerable<S3MPatternRowViewModel> Rows
        {
            get
            {
                for (var row = 0; row < _pattern.RowCount; ++row)
                {
                    yield return new S3MPatternRowViewModel(_pattern[row]);
                }
            }
        }

        public S3MPatternViewModel(S3MPattern pattern)
        {
            _pattern = pattern ?? throw new ArgumentNullException(nameof(pattern));
        }
    }
}
