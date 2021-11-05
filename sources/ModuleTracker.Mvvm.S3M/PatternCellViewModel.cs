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

using Microsoft.Toolkit.Mvvm.ComponentModel;
using ModuleTracker.Formats.S3M;

namespace ModuleTracker.Mvvm.S3M
{
    public sealed class PatternCellViewModel : ObservableObject
    {
        private PatternCell Model { get; }

        public string Semitone
        {
            get
            {
                if (!Model.NoteAndInstrumentPresent)
                {
                    return "..";
                }
                switch (Model.Semitone)
                {
                    case 0: return "C-";
                    case 1: return "C#";
                    case 2: return "D-";
                    case 3: return "Eb";
                    case 4: return "E-";
                    case 5: return "F-";
                    case 6: return "F#";
                    case 7: return "G-";
                    case 8: return "G#";
                    case 9: return "A-";
                    case 10: return "Bb";
                    case 11: return "B-";
                    default: return "..";
                }
            }
        }

        public string Octave
        {
            get
            {
                if (!Model.NoteAndInstrumentPresent)
                {
                    return ".";
                }
                return Model.Octave.ToString("D1");
            }
        }

        public string Instrument
        {
            get
            {
                if (!Model.NoteAndInstrumentPresent)
                {
                    return "..";
                }
                return Model.Instrument.ToString("D2");
            }
        }

        public string Volume
        {
            get
            {
                if (!Model.VolumePresent)
                {
                    return "..";
                }
                return Model.Volume.ToString("D2");
            }
        }

        public string Command
        {
            get
            {
                if (!Model.CommandAndInfoPresent)
                {
                    return ".";
                }

                switch (Model.Command)
                {
                    case 0x01: return "A";
                    case 0x02: return "B";
                    case 0x03: return "C";
                    case 0x04: return "D";
                    case 0x05: return "E";
                    case 0x06: return "F";
                    case 0x07: return "G";
                    case 0x08: return "H";
                    case 0x09: return "I";
                    case 0x0A: return "J";
                    case 0x0B: return "K";
                    case 0x0C: return "L";
                    case 0x0D: return "M";
                    case 0x0E: return "N";
                    case 0x0F: return "O";
                    case 0x10: return "P";
                    case 0x11: return "Q";
                    case 0x12: return "R";
                    case 0x13: return "S";
                    case 0x14: return "T";
                    case 0x15: return "U";
                    case 0x16: return "V";
                    case 0x17: return "W";
                    case 0x18: return "X";
                    case 0x19: return "Y";
                    case 0x1A: return "Z";
                    default: return ".";
                }
            }
        }

        public string Info
        {
            get
            {
                if (!Model.CommandAndInfoPresent)
                {
                    return "..";
                }
                return Model.Info.ToString("D2");
            }
        }

        public PatternCellViewModel(PatternCell model)
        {
            Model = model ?? throw new System.ArgumentNullException(nameof(model));
        }
    }
}
