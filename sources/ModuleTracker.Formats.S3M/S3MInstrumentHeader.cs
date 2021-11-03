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
    internal sealed class S3MInstrumentHeader
    {
        [FieldOrder(0)]
        public S3MInstrumentType Type { get; set; }

        [FieldOrder(1)]
        [FieldLength(12)]
        [FieldEncoding("ASCII")]
        public string Filename { get; set; } = string.Empty;

        [FieldOrder(2)]
        [Subtype(nameof(Type), S3MInstrumentType.Empty, typeof(S3MEmptyInstrumentData))]
        [Subtype(nameof(Type), S3MInstrumentType.Pcm, typeof(S3MPCMInstrumentData))]
        [Subtype(nameof(Type), S3MInstrumentType.AdlibMelody, typeof(S3MAdlibMelodyInstrumentData))]
        [Subtype(nameof(Type), S3MInstrumentType.AdlibBass, typeof(S3MAdlibBassInstrumentData))]
        [Subtype(nameof(Type), S3MInstrumentType.AdlibSnare, typeof(S3MAdlibSnareInstrumentData))]
        [Subtype(nameof(Type), S3MInstrumentType.AdlibTomTom, typeof(S3MAdlibTomTomInstrumentData))]
        [Subtype(nameof(Type), S3MInstrumentType.AdlibTopCymbal, typeof(S3MAdlibTopCymbalInstrumentData))]
        [Subtype(nameof(Type), S3MInstrumentType.AdlibHiHat, typeof(S3MAdlibHiHatInstrumentData))]
        [SubtypeDefault(typeof(S3MEmptyInstrumentData))]
        public S3MInstrumentData Data { get; set; } = new S3MEmptyInstrumentData();
    }
}
