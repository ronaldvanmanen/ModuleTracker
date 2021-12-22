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

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ModuleTracker.Formats.S3M;

namespace ModuleTracker.Mvvm.S3M
{
    public sealed class SampleInstrumentViewModel : InstrumentViewModel
    {
        private new SampleInstrument Instrument => (SampleInstrument)base.Instrument;

        [DisplayName("Sample Length")]
        [Description("The length of the sample in bytes")]
        [Range(0, 64000)]
        public int Length => Instrument.SampleData.Length;

        [DisplayName("Loop Start")]
        [Description("The offset of the loop start in bytes, relative to the start of the sample")]
        [Range(0, 64000)]
        public uint LoopStart => Instrument.LoopStart;

        [DisplayName("Loop End")]
        [Description("The offset of the loop end in bytes, relative to the start of the sample")]
        [Range(0, 64000)]
        public uint LoopEnd => Instrument.LoopEnd;

        [DisplayName("Default Volume")]
        [Description("The default volume of the sample")]
        [Range(0, 63)]
        public byte Volume => Instrument.Volume;

        [DisplayName("Sample Rate")]
        [Description("The sample rate for the middle-C note (C-4)")]
        public uint SampleRate => Instrument.SampleRate;

        [DisplayName("Sample Name")]
        [Description("The human-readable name of the sample")]
        [MaxLength(28)]
        public string SampleName => Instrument.SampleName;

        public SampleInstrumentViewModel(SampleInstrument instrument)
        : base(instrument)
        { }
    }
}
