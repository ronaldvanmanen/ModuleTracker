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
    internal sealed class PatternCellData
    {
        [Ignore]
        public byte What
        {
            get
            {
                byte result = Channel;
                result |= (byte)((CommandAndInfoSpecified ? 1 : 0) << 7);
                result |= (byte)((VolumeSpecified ? 1 : 0) << 6);
                result |= (byte)((NoteAndInstrumentSpecified ? 1 : 0) << 5);
                return result;
            }
        }

        [FieldOrder(0)]
        [FieldBitLength(5)]
        [SerializeAs(SerializedType.UInt1)]
        public byte Channel { get; set; }

        [FieldOrder(1)]
        [FieldBitLength(1)]
        public bool NoteAndInstrumentSpecified { get; set; }

        [FieldOrder(2)]
        [FieldBitLength(1)]
        public bool VolumeSpecified { get; set; }

        [FieldOrder(3)]
        [FieldBitLength(1)]
        public bool CommandAndInfoSpecified { get; set; }

        [FieldOrder(4)]
        [SerializeAs(SerializedType.UInt1)]
        [SerializeWhen(nameof(NoteAndInstrumentSpecified), true)]
        public byte Note { get; set; }

        [FieldOrder(5)]
        [SerializeAs(SerializedType.UInt1)]
        [SerializeWhen(nameof(NoteAndInstrumentSpecified), true)]
        public byte Instrument { get; set; }

        [FieldOrder(6)]
        [SerializeAs(SerializedType.UInt1)]
        [SerializeWhen(nameof(VolumeSpecified), true)]
        public byte Volume { get; set; }

        [FieldOrder(7)]
        [SerializeAs(SerializedType.UInt1)]
        [SerializeWhen(nameof(CommandAndInfoSpecified), true)]
        public byte Command { get; set; }

        [FieldOrder(8)]
        [SerializeAs(SerializedType.UInt1)]
        [SerializeWhen(nameof(CommandAndInfoSpecified), true)]
        public byte Info { get; set; }
    }
}
