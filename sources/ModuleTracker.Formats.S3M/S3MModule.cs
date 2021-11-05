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
using BinarySerialization;

namespace ModuleTracker.Formats.S3M
{
    public sealed class S3MModule
    {
        public string Title { get; set; }

        public byte InitialSpeed { get; set; }

        public byte InitialTempo { get; set; }

        public List<byte> PatternOrderList { get; }

        public List<S3MInstrument> Instruments { get; }

        public List<S3MPattern> Patterns { get; }

        public S3MModule()
        {
            Title = string.Empty;
            InitialSpeed = 0;
            InitialTempo = 0;
            PatternOrderList = new List<byte>();
            Instruments = new List<S3MInstrument>();
            Patterns = new List<S3MPattern>();
        }

        public static S3MModule Deserialize(string filename)
        {
            using (var fileStream = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read, 65536, false))
            {
                var buffer = new byte[fileStream.Length];
                fileStream.Read(buffer, 0, buffer.Length);
                using (var memoryStream = new MemoryStream(buffer))
                {
                    return Deserialize(memoryStream);
                }
            }
        }

        public static S3MModule Deserialize(Stream stream)
        {
            var serializer = new BinarySerializer();
            var header = serializer.Deserialize<S3MModuleHeader>(stream);
            var instruments = new List<S3MInstrument>(header.InstrumentPointerList.Count);

            foreach (var instrumentPointer in header.InstrumentPointerList)
            {
                var instrumentOffset = instrumentPointer << 4;
                stream.Seek(instrumentOffset, SeekOrigin.Begin);
                var instrumentHeader = serializer.Deserialize<S3MInstrumentHeader>(stream);
                switch (instrumentHeader.Data)
                {
                    case S3MEmptyInstrumentData:
                        {
                            var instrument = new S3MEmptyInstrument(instrumentHeader.Filename);
                            instruments.Add(instrument);
                            break;
                        }

                    case S3MAdlibInstrumentData instrumentData:
                        {
                            var instrument = new S3MAdlibInstrument(instrumentHeader.Filename,
                                instrumentData.SampleName);
                            instruments.Add(instrument);
                            break;
                        }

                    case S3MPCMInstrumentData instrumentData:
                        {
                            var sampleDataPointer = (instrumentData.UpperSampleDataPointer << 16) & instrumentData.LowerSampleDataPointer;
                            var sampleDataOffset = sampleDataPointer << 4;
                            var sampleDataLength = instrumentData.Length & 0xFFFF;
                            var sampleData = new byte[sampleDataLength];
                            stream.Seek(sampleDataOffset, SeekOrigin.Begin);
                            stream.Read(sampleData, 0, sampleData.Length);
                            var instrument = new S3MPCMInstrument(instrumentHeader.Filename,
                                instrumentData.LoopStart,
                                instrumentData.LoopEnd,
                                instrumentData.Volume,
                                instrumentData.Packing,
                                instrumentData.Flags,
                                instrumentData.SampleRate,
                                instrumentData.SampleName,
                                sampleData);
                            instruments.Add(instrument);
                            break;
                        }
                }
            }

            var patterns = new List<S3MPattern>(header.PatternPointerList.Count);
            foreach (var patternPointer in header.PatternPointerList)
            {
                var patternOffset = patternPointer << 4;
                stream.Seek(patternOffset, SeekOrigin.Begin);
                var packedPattern = serializer.Deserialize<S3MPackedPattern>(stream);
                var pattern = new S3MPattern();
                using (var rowDataStream = new MemoryStream(packedPattern.Data))
                {
                    for (var row = 0; row < 64; ++row)
                    {
                        while (true)
                        {
                            var cellData = serializer.Deserialize<S3MPatternCellData>(rowDataStream);
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
                patterns.Add(pattern);
            }

            var module = new S3MModule();
            module.Title = header.Title;
            module.InitialSpeed = header.InitialSpeed;
            module.InitialTempo = header.InitialTempo;
            module.Instruments.AddRange(instruments);
            module.Patterns.AddRange(patterns);
            module.PatternOrderList.AddRange(header.PatternOrderList);
            return module;
        }
    }
}
