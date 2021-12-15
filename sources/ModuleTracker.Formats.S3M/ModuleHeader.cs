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
        [SerializeAs(SerializedType = SerializedType.TerminatedString, StringTerminator = '\0', PaddingValue = 0)]
        public string Title { get; set; } = string.Empty;

        [FieldOrder(1)]
        [FieldEndianness(Endianness.Little)]
        public byte SignatureByte { get; set; } = 0x1A;

        [FieldOrder(2)]
        [FieldEndianness(Endianness.Little)]
        public ModuleType Type { get; set; }

        [FieldOrder(3)]
        [FieldEndianness(Endianness.Little)]
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
        [SerializeAs(SerializedType = SerializedType.SizedString)]
        public string Signature { get; set; } = "SCRM";

        [FieldOrder(11)]
        [FieldEndianness(Endianness.Little)]
        public byte GlobalVolume { get; set; }

        [FieldOrder(12)]
        [FieldEndianness(Endianness.Little)]
        public byte InitialSpeed { get; set; }

        [FieldOrder(13)]
        [FieldEndianness(Endianness.Little)]
        public byte InitialTempo { get; set; }

        [FieldOrder(14)]
        [FieldEndianness(Endianness.Little)]
        [FieldBitLength(7)]
        public byte MasterVolume { get; set; }

        [FieldOrder(15)]
        [FieldEndianness(Endianness.Little)]
        [FieldBitLength(1)]
        public bool StereoPlayback { get; set; }

        [FieldOrder(16)]
        [FieldEndianness(Endianness.Little)]
        public byte UltraClickRemoval { get; set; }

        [FieldOrder(17)]
        [FieldEndianness(Endianness.Little)]
        public byte ChannelPanSettingsPresent { get; set; }

        [FieldOrder(18)]
        [FieldCount(8)]
        [FieldEndianness(Endianness.Little)]
        public byte[] Reserved2 { get; set; } = new byte[8];

        [FieldOrder(19)]
        [FieldEndianness(Endianness.Little)]
        public ushort SpecialCustomDataPointer { get; set; }

        [FieldOrder(20)]
        [FieldCount(32)]
        [FieldEndianness(Endianness.Little)]
        public ChannelSettingData[] ChannelSettings { get; set; } = null!;

        [FieldOrder(21)]
        [FieldCount(nameof(OrderCount))]
        [FieldEndianness(Endianness.Little)]
        public byte[] PatternOrderList { get; set; } = null!;

        [FieldOrder(22)]
        [FieldCount(nameof(InstrumentCount))]
        [FieldEndianness(Endianness.Little)]
        public ushort[] InstrumentPointerList { get; set; } = null!;

        [FieldOrder(23)]
        [FieldCount(nameof(PatternCount))]
        [FieldEndianness(Endianness.Little)]
        public ushort[] PatternPointerList { get; set; } = null!;

        private const byte ChannelPanSettingsPresentValue = 252;

        [FieldOrder(24)]
        [FieldCount(32)]
        [ItemLength(1)]
        [SerializeWhen(nameof(ChannelPanSettingsPresent), ChannelPanSettingsPresentValue)]
        public ChannelPanSettingData[] ChannelPanSettings { get; set; } = null!;
    }
}
