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

using ModuleTracker.Formats.S3M;

namespace ModuleTracker.Mvvm.S3M
{
    public sealed class SampleInstrumentViewModel : InstrumentViewModel
    {
        private new SampleInstrument Instrument => (SampleInstrument)base.Instrument;

        public int Length => Instrument.SampleData.Length;

        public uint LoopStart => Instrument.LoopStart;

        public uint LoopEnd => Instrument.LoopEnd;

        public byte Volume => Instrument.Volume;

        public uint SampleRate => Instrument.SampleRate;

        public string SampleName => Instrument.SampleName;

        public SampleInstrumentViewModel(SampleInstrument instrument)
        : base(instrument)
        {
        }
    }
}
