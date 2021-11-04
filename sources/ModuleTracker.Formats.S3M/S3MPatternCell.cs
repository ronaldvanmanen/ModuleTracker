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

namespace ModuleTracker.Formats.S3M
{
    public sealed class S3MPatternCell
    {
        private readonly S3MPatternCellData _data;

        public bool CommandAndInfoPresent => (_data.What & 0x80) != 0;

        public byte Command => _data.Command;

        public byte Info => _data.Info;

        public bool NoteAndInstrumentPresent => (_data.What & 0x20) != 0;

        public byte Octave => (byte)((_data.Note & 0xF0) >> 4);

        public byte Semitone => (byte)(_data.Note & 0x0F);

        public bool VolumePresent => (_data.What & 0x40) != 0;

        public byte Volume => _data.Volume;

        public byte Instrument => _data.Instrument;

        internal S3MPatternCell(S3MPatternCellData data)
        {
            _data = data ?? throw new ArgumentNullException(nameof(data));
        }
    }
}
