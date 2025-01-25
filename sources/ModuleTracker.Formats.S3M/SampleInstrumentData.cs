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
    internal sealed class SampleInstrumentData : InstrumentData
    {
        [FieldOrder(0)]
        public byte UpperSampleDataPointer { get; set; }

        [FieldOrder(1)]
        public ushort LowerSampleDataPointer { get; set; }

        [FieldOrder(2)]
        public uint Length { get; set; }

        [FieldOrder(3)]
        public uint LoopStart { get; set; }

        [FieldOrder(4)]
        public uint LoopEnd { get; set; }

        [FieldOrder(5)]
        public byte Volume { get; set; }

        [FieldOrder(6)]
        public byte Reserved { get; set; }

        [FieldOrder(7)]
        public SampleInstrumentPacking Packing { get; set; }

        [FieldOrder(8)]
        public SampleInstrumentFlags Flags { get; set; }

        [FieldOrder(9)]
        public uint SampleRate { get; set; }

        [FieldOrder(10)]
        [FieldCount(12)]
        public byte[] Internal { get; set; } = new byte[12];

        [FieldOrder(11)]
        [FieldLength(28)]
        public string SampleName { get; set; } = string.Empty;

        [FieldOrder(12)]
        [FieldLength(4)]
        public string Signature { get; set; } = "SCRS";
    }
}
