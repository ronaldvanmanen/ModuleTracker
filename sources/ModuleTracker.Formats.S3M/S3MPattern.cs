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
    public sealed class S3MPattern
    {
        private const int MaxRows = 64;

        private const int MaxChannels = 32;

        private readonly S3MPatternCell[,] _cells = new S3MPatternCell[MaxRows, MaxChannels];

        public S3MPattern()
        {
            for (var row = 0; row < MaxRows; ++row)
            {
                for (var channel = 0; channel < MaxChannels; ++channel)
                {
                    _cells[row, channel] = new S3MPatternCell(new S3MPatternCellData());
                }
            }
        }

        public S3MPatternCell this[int row, int channel]
        {
            get
            {
                return _cells[row, channel];
            }
            set
            {
                _cells[row, channel] = value;
            }
        }
    }
}
