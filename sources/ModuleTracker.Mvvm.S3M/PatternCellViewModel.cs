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
using Microsoft.Toolkit.Mvvm.ComponentModel;
using ModuleTracker.Formats.S3M;

namespace ModuleTracker.Mvvm.S3M
{
    public sealed class PatternCellViewModel : ObservableObject
    {
        private readonly PatternCell _cell;

        public string Text
        {
            get
            {
                return $"{Semitone}{Octave} {Instrument} {Volume} {Command} {Info}";
            }
        }

        public string Note
        {
            get
            {
                if (!_cell.NoteAndInstrumentPresent)
                {
                    return "---";
                }
                return $"{Semitone}{Octave}";
            }
        }

        public string Semitone
        {
            get
            {
                if (!_cell.NoteAndInstrumentPresent)
                {
                    return "--";
                }
                return _cell.Semitone switch
                {
                    0 => "C-",
                    1 => "C#",
                    2 => "D-",
                    3 => "D#",
                    4 => "E-",
                    5 => "F-",
                    6 => "F#",
                    7 => "G-",
                    8 => "G#",
                    9 => "A-",
                    10 => "A#",
                    11 => "B-",
                    _ => "..",
                };
            }
        }

        public string Octave
        {
            get
            {
                if (!_cell.NoteAndInstrumentPresent)
                {
                    return "-";
                }
                return _cell.Octave.ToString("D1");
            }
        }

        public string Instrument
        {
            get
            {
                if (!_cell.NoteAndInstrumentPresent)
                {
                    return "--";
                }
                return _cell.Instrument.ToString("D2");
            }
        }

        public string Volume
        {
            get
            {
                if (!_cell.VolumePresent)
                {
                    return "--";
                }
                return _cell.Volume.ToString("D2");
            }
        }

        public string Command
        {
            get
            {
                if (!_cell.CommandAndInfoPresent)
                {
                    return "-";
                }

                return _cell.Command switch
                {
                    0x01 => "A",
                    0x02 => "B",
                    0x03 => "C",
                    0x04 => "D",
                    0x05 => "E",
                    0x06 => "F",
                    0x07 => "G",
                    0x08 => "H",
                    0x09 => "I",
                    0x0A => "J",
                    0x0B => "K",
                    0x0C => "L",
                    0x0D => "M",
                    0x0E => "N",
                    0x0F => "O",
                    0x10 => "P",
                    0x11 => "Q",
                    0x12 => "R",
                    0x13 => "S",
                    0x14 => "T",
                    0x15 => "U",
                    0x16 => "V",
                    0x17 => "W",
                    0x18 => "X",
                    0x19 => "Y",
                    0x1A => "Z",
                    _ => ".",
                };
            }
        }

        public string Info
        {
            get
            {
                if (!_cell.CommandAndInfoPresent)
                {
                    return "--";
                }
                return _cell.Info.ToString("D2");
            }
        }

        public PatternCellViewModel()
        : this(new PatternCell())
        { }

        public PatternCellViewModel(PatternCell cell)
        {
            _cell = cell ?? throw new ArgumentNullException(nameof(cell));
        }
    }
}
