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

namespace ModuleTracker.Formats.S3M
{
    public sealed class Pattern
    {
        private const int MaxRows = 64;

        private readonly PatternRow[] _rows = new PatternRow[MaxRows];

        public int RowCount => MaxRows;

        public Pattern()
        {
            for (var row = 0; row < MaxRows; ++row)
            {
                _rows[row] = new PatternRow();
            }
        }

        public PatternRow this[int row]
        {
            get
            {
                return _rows[row];
            }
        }

        public PatternCell this[int row, int channel]
        {
            get
            {
                return _rows[row][channel];
            }
            set
            {
                _rows[row][channel] = value;
            }
        }
    }
}
