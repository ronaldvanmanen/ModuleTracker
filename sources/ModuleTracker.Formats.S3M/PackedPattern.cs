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
    internal sealed class PackedPattern
    {
        [FieldOrder(0)]
        [FieldEndianness(Endianness.Little)]
        public ushort Length { get; set; }

        [FieldOrder(1)]
        [FieldCount(nameof(Length), ConverterType = typeof(PackedPatternLengthConverter))]
        public byte[] Data { get; set; } = null!;
    }
}
