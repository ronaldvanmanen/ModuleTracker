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

using System.Collections;
using System.Collections.Generic;

namespace ModuleTracker.Formats.S3M
{
    public sealed class PatternRow : IReadOnlyList<PatternCell>
    {
        private const int MaxChannels = 32;

        private readonly PatternCell[] _cells = new PatternCell[MaxChannels];

        public int Count => _cells.Length;

        public PatternRow()
        {
            for (var channel = 0; channel < _cells.Length; ++channel)
            {
                _cells[channel] = new PatternCell();
            }
        }

        public PatternCell this[int channel]
        {
            get
            {
                return _cells[channel];
            }
            set
            {
                _cells[channel] = value;
            }
        }

        public IEnumerator<PatternCell> GetEnumerator()
        {
            return ((IEnumerable<PatternCell>)_cells).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _cells.GetEnumerator();
        }
    }
}
