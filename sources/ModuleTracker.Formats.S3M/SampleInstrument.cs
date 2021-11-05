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

namespace ModuleTracker.Formats.S3M
{
    public sealed class SampleInstrument : Instrument
    {
        public uint LoopStart { get; }

        public uint LoopEnd { get; }

        public byte Volume { get; }

        public SampleInstrumentPacking Packing { get; }

        public SampleInstrumentFlags Flags { get; }

        public uint SampleRate { get; }

        public string SampleName { get; }

        public byte[] SampleData { get; }

        public SampleInstrument(string filename, uint loopStart, uint loopEnd, byte volume, SampleInstrumentPacking packing, SampleInstrumentFlags flags, uint sampleRate, string sampleName, byte[] sampleData)
        : base(filename)
        {
            LoopStart = loopStart;
            LoopEnd = loopEnd;
            Volume = volume;
            Packing = packing;
            Flags = flags;
            SampleRate = sampleRate;
            SampleName = sampleName;
            SampleData = sampleData;
        }
    }
}
