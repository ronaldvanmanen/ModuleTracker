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
using System.IO;
using System.Linq;

namespace ModuleTracker.Formats.S3M
{
    public sealed class Module
    {
        public string Title { get; set; }

        public byte GlobalVolume { get; set; }

        public byte InitialSpeed { get; set; }

        public byte InitialTempo { get; set; }

        public bool StereoPlayback { get; set; }

        public byte MasterVolume { get; set; }

        public IReadOnlyList<ChannelSetting> ChannelSettings { get; }

        public IList<byte> PatternOrderList { get; }

        public IList<Instrument> Instruments { get; }

        public IList<Pattern> Patterns { get; }

        public Module()
        {
            Title = string.Empty;
            GlobalVolume = 0;
            InitialSpeed = 0;
            InitialTempo = 0;
            StereoPlayback = false;
            MasterVolume = 0;
            ChannelSettings = Enumerable.Range(0, 32).Select(_ => new ChannelSetting()).ToArray();
            PatternOrderList = new List<byte>();
            Instruments = new List<Instrument>();
            Patterns = new List<Pattern>();
        }

        public static Module Deserialize(string filename)
        {
            return ModuleSerializer.Deserialize(filename);
        }

        public static Module Deserialize(Stream stream)
        {
            return ModuleSerializer.Deserialize(stream);
        }
    }
}
