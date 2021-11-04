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
        [SerializeAs(SerializedType.UInt1)]
        public byte What { get; set; }

        [FieldOrder(1)]
        [SerializeAs(SerializedType.UInt1)]
        [SerializeWhen(nameof(What), true, ConverterType = typeof(S3MPatternCellDataWhatConverter), ConverterParameter = (byte)0x20u)]
        public byte Note { get; set; }

        [FieldOrder(2)]
        [SerializeAs(SerializedType.UInt1)]
        [SerializeWhen(nameof(What), true, ConverterType = typeof(S3MPatternCellDataWhatConverter), ConverterParameter = (byte)0x20u)]
        public byte Instrument { get; set; }

        [FieldOrder(3)]
        [SerializeAs(SerializedType.UInt1)]
        [SerializeWhen(nameof(What), true, ConverterType = typeof(S3MPatternCellDataWhatConverter), ConverterParameter = (byte)0x40u)]
        public byte Volume { get; set; }

        [FieldOrder(4)]
        [SerializeAs(SerializedType.UInt1)]
        [SerializeWhen(nameof(What), true, ConverterType = typeof(S3MPatternCellDataWhatConverter), ConverterParameter = (byte)0x80u)]
        public byte Command { get; set; }

        [FieldOrder(5)]
        [SerializeAs(SerializedType.UInt1)]
        [SerializeWhen(nameof(What), true, ConverterType = typeof(S3MPatternCellDataWhatConverter), ConverterParameter = (byte)0x80u)]
        public byte Info { get; set; }
    }
}
