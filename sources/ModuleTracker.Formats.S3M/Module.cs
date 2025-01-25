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

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ModuleTracker.Formats.S3M
{
    public sealed class Module
    {
        public const int MaxTitleLength = 28;

        public const byte MinVolume = 0x0;

        public const byte MaxVolume = 0x40;

        public const byte MinSpeed = 0x1;

        public const byte MaxSpeed = 0xFF;

        public const byte DefaultSpeed = 0x6;

        public const byte MinTempo = 0x20;

        public const byte MaxTempo = 0xFF;

        public const byte DefaultTempo = 0x7D;

        public const byte MinMasterVolume = 0;

        public const byte MaxMasterVolume = 0x7F;

        private string _title;

        private byte _globalVolume;

        private byte _globalSpeed;

        private byte _globalTempo;

        private bool _stereoPlayback;

        private byte _masterVolume;

        private readonly ChannelSetting[] _channelSettings;

        private readonly List<byte> _patternOrderList;

        private readonly List<Instrument> _instruments;

        private readonly List<Pattern> _patterns;

        public string Title
        {
            get => _title;
            set
            {
                if (value.Length > MaxTitleLength)
                {
                    throw new ArgumentException($"The maximum length of a song title is {MaxTitleLength} characters", nameof(value));
                }

                _title = value;
            }
        }

        public byte GlobalVolume
        {
            get => _globalVolume;
            set
            {
                if (value < MinVolume || value > MaxVolume)
                {
                    throw new ArgumentOutOfRangeException(
                        nameof(value),
                        value,
                        $"Global volume must be in range [{MinVolume}-{MaxVolume}]");
                }

                _globalVolume = value;
            }
        }

        public byte GlobalSpeed
        {
            get => _globalSpeed;
            set
            {
                if (value < MinSpeed || value > MaxSpeed)
                {
                    throw new ArgumentOutOfRangeException(
                        nameof(value),
                        value,
                        $"Global speed must be in range [{MinSpeed}-{MinSpeed}]");
                }

                _globalSpeed = value;
            }
        }

        public byte GlobalTempo
        {
            get => _globalTempo;
            set
            {
                if (value < MinTempo || value > MaxTempo)
                {
                    throw new ArgumentOutOfRangeException(
                        nameof(value),
                        value,
                        $"Global tempo must be in range [{MinTempo}-{MaxTempo}]");
                }

                _globalTempo = value;
            }
        }

        public bool StereoPlayback { get => _stereoPlayback; set => _stereoPlayback = value; }

        public byte MasterVolume
        {
            get => _masterVolume;
            set
            {
                if (value < MinMasterVolume || value > MaxMasterVolume)
                {
                    throw new ArgumentOutOfRangeException(
                        nameof(value),
                        value,
                        $"Master volume must be in range [{MinMasterVolume}-{MaxMasterVolume}]");
                }

                _masterVolume = value;
            }
        }

        public IReadOnlyList<ChannelSetting> ChannelSettings => _channelSettings;

        public IList<byte> PatternOrderList => _patternOrderList;

        public IList<Instrument> Instruments => _instruments;

        public IList<Pattern> Patterns => _patterns;

        public Module()
        {
            _title = string.Empty;
            _globalVolume = 0;
            _globalSpeed = DefaultSpeed;
            _globalTempo = DefaultTempo;
            _stereoPlayback = false;
            _masterVolume = 0;
            _channelSettings = new ChannelSetting[32];
            _patternOrderList = new List<byte>();
            _instruments = new List<Instrument>();
            _patterns = new List<Pattern>();

            for (var i = 0; i < _channelSettings.Length; ++i)
            {
                _channelSettings[i] = new ChannelSetting();
            }
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
