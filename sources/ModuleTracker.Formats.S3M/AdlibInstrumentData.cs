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
    internal abstract class AdlibInstrumentData : InstrumentData
    {
        [FieldOrder(0)]
        public byte[] Reserved0 { get; set; } = new byte[] { 0x00, 0x00, 0x00 };

        [FieldOrder(1)]
        public byte D00 { get; set; }

        [FieldOrder(2)]
        public byte D01 { get; set; }

        [FieldOrder(3)]
        public byte D02 { get; set; }

        [FieldOrder(4)]
        public byte D03 { get; set; }

        [FieldOrder(5)]
        public byte D04 { get; set; }

        [FieldOrder(6)]
        public byte D05 { get; set; }

        [FieldOrder(7)]
        public byte D06 { get; set; }

        [FieldOrder(8)]
        public byte D07 { get; set; }

        [FieldOrder(9)]
        public byte D08 { get; set; }

        [FieldOrder(10)]
        public byte D09 { get; set; }

        [FieldOrder(11)]
        public byte D0A { get; set; }

        [FieldOrder(12)]
        public byte D0B { get; set; }

        [FieldOrder(13)]
        public byte Volume { get; set; }

        [FieldOrder(14)]
        public byte Disk { get; set; }

        [FieldOrder(15)]
        public ushort Reserved1 { get; set; }

        [FieldOrder(16)]
        public uint SampleRate { get; set; }

        [FieldOrder(17)]
        [FieldCount(12)]
        public byte[] Unused { get; set; } = new byte[12];

        [FieldOrder(18)]
        [FieldLength(28)]
        public string SampleName { get; set; } = string.Empty;

        [FieldOrder(19)]
        [FieldLength(4)]
        public string Signature { get; set; } = "SCRI";
    }
}
