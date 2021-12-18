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
using System.IO;
using BinarySerialization;

namespace ModuleTracker.Formats.S3M
{
    internal sealed class ModuleSerializer
    {
        private const int DefaultMonoPanPosition = 0x7;

        private const int DefaultLeftChannelPanPosition = 0x3;

        private const int DefaultRightChannelPanPosition = 0xC;

        public static Module Deserialize(string filename)
        {
            using var fileStream = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read, 65536, false);
            var buffer = new byte[fileStream.Length];
            fileStream.Read(buffer, 0, buffer.Length);
            using var memoryStream = new MemoryStream(buffer);
            return Deserialize(memoryStream);
        }

        public static Module Deserialize(Stream stream)
        {
            if (stream is null)
            {
                throw new ArgumentNullException(nameof(stream));
            }

            var moduleSerializer = new BinarySerializer();
            var moduleHeader = moduleSerializer.Deserialize<ModuleHeader>(stream);
            var module = new Module
            {
                Title = moduleHeader.Title,
                GlobalVolume = moduleHeader.GlobalVolume,
                GlobalSpeed = moduleHeader.InitialSpeed,
                GlobalTempo = moduleHeader.InitialTempo,
                StereoPlayback = moduleHeader.StereoPlayback,
                MasterVolume = moduleHeader.MasterVolume
            };

            foreach (var instrumentPointer in moduleHeader.InstrumentPointerList)
            {
                var instrumentOffset = instrumentPointer << 4;
                stream.Seek(instrumentOffset, SeekOrigin.Begin);
                var instrumentHeader = moduleSerializer.Deserialize<InstrumentHeader>(stream);
                switch (instrumentHeader.Data)
                {
                    case EmptyInstrumentData:
                    {
                        var instrument = new EmptyInstrument(instrumentHeader.Filename);
                        module.Instruments.Add(instrument);
                        break;
                    }

                    case AdlibInstrumentData instrumentData:
                    {
                        var instrument = new AdlibInstrument(instrumentHeader.Filename, instrumentData.SampleName);
                        module.Instruments.Add(instrument);
                        break;
                    }

                    case SampleInstrumentData instrumentData:
                    {
                        var sampleDataPointer = (instrumentData.UpperSampleDataPointer << 16) & instrumentData.LowerSampleDataPointer;
                        var sampleDataOffset = sampleDataPointer << 4;
                        var sampleDataLength = instrumentData.Length & 0xFFFF;
                        var sampleData = new byte[sampleDataLength];
                        stream.Seek(sampleDataOffset, SeekOrigin.Begin);
                        stream.Read(sampleData, 0, sampleData.Length);
                        var instrument = new SampleInstrument(instrumentHeader.Filename,
                            instrumentData.LoopStart,
                            instrumentData.LoopEnd,
                            instrumentData.Volume,
                            instrumentData.Packing,
                            instrumentData.Flags,
                            instrumentData.SampleRate,
                            instrumentData.SampleName,
                            sampleData);
                        module.Instruments.Add(instrument);
                        break;
                    }
                }
            }

            foreach (var patternPointer in moduleHeader.PatternPointerList)
            {
                var pattern = new Pattern();
                module.Patterns.Add(pattern);
                if (patternPointer == 0)
                {
                    continue;
                }

                var patternOffset = patternPointer << 4;
                stream.Seek(patternOffset, SeekOrigin.Begin);
                var packedPattern = moduleSerializer.Deserialize<PackedPattern>(stream);
                using (var rowDataStream = new MemoryStream(packedPattern.Data))
                {
                    for (var row = 0; row < 64; ++row)
                    {
                        while (true)
                        {
                            var cellData = moduleSerializer.Deserialize<PatternCellData>(rowDataStream);
                            if (cellData.What == 0)
                            {
                                break;
                            }

                            var channel = cellData.What & 0x1F;
                            var cell = pattern[row, channel];
                            cell.CommandAndInfoPresent = (cellData.What & 0x80u) != 0;
                            cell.Command = cellData.Command;
                            cell.Info = cellData.Info;
                            cell.NoteAndInstrumentPresent = (cellData.What & 0x20u) != 0;
                            cell.Octave = (byte)(cellData.Note >> 4);
                            cell.Semitone = (byte)(cellData.Note & 0xF);
                            cell.Instrument = cellData.Instrument;
                        }
                    }
                }
            }

            for (var i = 0; i < moduleHeader.ChannelSettings.Length; ++i)
            {
                var channelSettingData = moduleHeader.ChannelSettings[i];

                var channelSetting = module.ChannelSettings[i];
                channelSetting.Unused = channelSettingData.Unused;
                channelSetting.Disabled = channelSettingData.Disabled;
                channelSetting.Type = channelSettingData.Type;
                channelSetting.Pan = DefaultMonoPanPosition;

                if (moduleHeader.ChannelPanSettings != null)
                {
                    var panSettings = moduleHeader.ChannelPanSettings[i];
                    if (panSettings.PanSpecified)
                    {
                        channelSetting.Pan = panSettings.Pan;
                    }
                    else
                    {
                        switch (channelSetting.Type)
                        {
                            case ChannelType.LeftSampleChannel1:
                            case ChannelType.LeftSampleChannel2:
                            case ChannelType.LeftSampleChannel3:
                            case ChannelType.LeftSampleChannel4:
                            case ChannelType.LeftSampleChannel5:
                            case ChannelType.LeftSampleChannel6:
                            case ChannelType.LeftSampleChannel7:
                            case ChannelType.LeftSampleChannel8:
                                channelSetting.Pan = DefaultLeftChannelPanPosition;
                                break;

                            case ChannelType.RightSampleChannel1:
                            case ChannelType.RightSampleChannel2:
                            case ChannelType.RightSampleChannel3:
                            case ChannelType.RightSampleChannel4:
                            case ChannelType.RightSampleChannel5:
                            case ChannelType.RightSampleChannel6:
                            case ChannelType.RightSampleChannel7:
                            case ChannelType.RightSampleChannel8:
                                channelSetting.Pan = DefaultRightChannelPanPosition;
                                break;
                        }
                    }
                }
                else
                {
                    if (moduleHeader.StereoPlayback)
                    {
                        switch (channelSetting.Type)
                        {
                            case ChannelType.LeftSampleChannel1:
                            case ChannelType.LeftSampleChannel2:
                            case ChannelType.LeftSampleChannel3:
                            case ChannelType.LeftSampleChannel4:
                            case ChannelType.LeftSampleChannel5:
                            case ChannelType.LeftSampleChannel6:
                            case ChannelType.LeftSampleChannel7:
                            case ChannelType.LeftSampleChannel8:
                                channelSetting.Pan = 0x3;
                                break;

                            case ChannelType.RightSampleChannel1:
                            case ChannelType.RightSampleChannel2:
                            case ChannelType.RightSampleChannel3:
                            case ChannelType.RightSampleChannel4:
                            case ChannelType.RightSampleChannel5:
                            case ChannelType.RightSampleChannel6:
                            case ChannelType.RightSampleChannel7:
                            case ChannelType.RightSampleChannel8:
                                channelSetting.Pan = 0xC;
                                break;
                        }
                    }
                }
            }

            foreach (var patternOrder in moduleHeader.PatternOrderList)
            {
                module.PatternOrderList.Add(patternOrder);
            }

            return module;
        }
    }
}
