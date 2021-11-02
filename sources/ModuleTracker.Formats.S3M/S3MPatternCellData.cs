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

using BinarySerialization;

namespace ModuleTracker.Formats.S3M
{
    internal sealed class S3MPatternCellData
    {
        [FieldOrder(0)]
        [FieldBitLength(1)]
        public bool CommandAndInfoPresent { get; set; }

        [FieldOrder(1)]
        [FieldBitLength(1)]
        public bool VolumePresent { get; set; }

        [FieldOrder(2)]
        [FieldBitLength(1)]
        public bool NoteAndInstrumentPresent { get; set; }

        [FieldOrder(3)]
        [FieldBitLength(5)]
        public ushort ChannelNumber { get; set; }

        [FieldOrder(4)]
        [SerializeWhen(nameof(NoteAndInstrumentPresent), true)]
        public byte Note { get; set; }

        [FieldOrder(5)]
        [SerializeWhen(nameof(NoteAndInstrumentPresent), true)]
        public byte Instrument { get; set; }

        [FieldOrder(6)]
        [SerializeWhen(nameof(VolumePresent), true)]
        public byte Volume { get; set; }

        [FieldOrder(7)]
        [SerializeWhen(nameof(CommandAndInfoPresent), true)]
        public byte Command { get; set; }

        [FieldOrder(8)]
        [SerializeWhen(nameof(CommandAndInfoPresent), true)]
        public byte Info { get; set; }
    }
}
