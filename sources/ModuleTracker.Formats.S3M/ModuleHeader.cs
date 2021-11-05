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

using System.Collections.Generic;
using BinarySerialization;

namespace ModuleTracker.Formats.S3M
{
    internal sealed class ModuleHeader
    {
        [FieldOrder(0)]
        [FieldLength(28)]
        [FieldEncoding("ASCII")]
        public string Title { get; set; } = string.Empty;

        [FieldOrder(1)]
        public byte SignatureByte { get; set; } = 0x1A;

        [FieldOrder(2)]
        public ModuleType Type { get; set; }

        [FieldOrder(3)]
        [FieldCount(2)]
        public ushort Reserved0 { get; set; }

        [FieldOrder(4)]
        [FieldEndianness(Endianness.Little)]
        public ushort OrderCount { get; set; }

        [FieldOrder(5)]
        [FieldEndianness(Endianness.Little)]
        public ushort InstrumentCount { get; set; }

        [FieldOrder(6)]
        [FieldEndianness(Endianness.Little)]
        public ushort PatternCount { get; set; }

        [FieldOrder(7)]
        [FieldEndianness(Endianness.Little)]
        public ModuleHeaderFlags Flags { get; set; }

        [FieldOrder(8)]
        [FieldEndianness(Endianness.Little)]
        public ushort TrackerVersion { get; set; }

        [FieldOrder(9)]
        [FieldEndianness(Endianness.Little)]
        public ushort FileFormatVersion { get; set; }

        [FieldOrder(10)]
        [FieldLength(4)]
        [FieldEncoding("ASCII")]
        public string Signature { get; set; } = "SCRM";

        [FieldOrder(11)]
        public byte GlobalVolume { get; set; }

        [FieldOrder(12)]
        public byte InitialSpeed { get; set; }

        [FieldOrder(13)]
        public byte InitialTempo { get; set; }

        [FieldOrder(14)]
        public byte MasterVolume { get; set; }

        [FieldOrder(15)]
        [FieldCount(10)]
        public byte[] Reserved2 { get; set; } = new byte[10];

        [FieldOrder(16)]
        [FieldEndianness(Endianness.Little)]
        public ushort SpecialCustomDataPointer { get; set; }

        [FieldOrder(17)]
        [FieldCount(32)]
        public byte[] ChannelSettings { get; set; } = new byte[32];

        [FieldOrder(18)]
        [FieldCount(nameof(OrderCount))]
        public List<byte> PatternOrderList { get; set; } = new List<byte>();

        [FieldOrder(19)]
        [FieldCount(nameof(InstrumentCount))]
        [FieldEndianness(Endianness.Little)]
        public List<ushort> InstrumentPointerList { get; set; } = new List<ushort>();

        [FieldOrder(20)]
        [FieldCount(nameof(PatternCount))]
        [FieldEndianness(Endianness.Little)]
        public List<ushort> PatternPointerList { get; set; } = new List<ushort>();
    }
}
