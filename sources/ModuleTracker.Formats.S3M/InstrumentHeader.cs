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
    internal sealed class InstrumentHeader
    {
        [FieldOrder(0)]
        public InstrumentType Type { get; set; }

        [FieldOrder(1)]
        [FieldLength(12)]
        [FieldEncoding("ASCII")]
        public string Filename { get; set; } = string.Empty;

        [FieldOrder(2)]
        [Subtype(nameof(Type), InstrumentType.Empty, typeof(EmptyInstrumentData))]
        [Subtype(nameof(Type), InstrumentType.Sample, typeof(SampleInstrumentData))]
        [Subtype(nameof(Type), InstrumentType.AdlibMelody, typeof(AdlibMelodyInstrumentData))]
        [Subtype(nameof(Type), InstrumentType.AdlibBass, typeof(AdlibBassInstrumentData))]
        [Subtype(nameof(Type), InstrumentType.AdlibSnare, typeof(AdlibSnareInstrumentData))]
        [Subtype(nameof(Type), InstrumentType.AdlibTomTom, typeof(AdlibTomTomInstrumentData))]
        [Subtype(nameof(Type), InstrumentType.AdlibTopCymbal, typeof(AdlibTopCymbalInstrumentData))]
        [Subtype(nameof(Type), InstrumentType.AdlibHiHat, typeof(AdlibHiHatInstrumentData))]
        [SubtypeDefault(typeof(EmptyInstrumentData))]
        public InstrumentData Data { get; set; } = new EmptyInstrumentData();
    }
}
