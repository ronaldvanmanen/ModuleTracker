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
    public sealed class PatternRowViewModel : ObservableObject
    {
        private readonly PatternRow _row;

        private PatternCellViewModel _channel0;
        private PatternCellViewModel _channel1;
        private PatternCellViewModel _channel2;
        private PatternCellViewModel _channel3;
        private PatternCellViewModel _channel4;
        private PatternCellViewModel _channel5;
        private PatternCellViewModel _channel6;
        private PatternCellViewModel _channel7;
        private PatternCellViewModel _channel8;
        private PatternCellViewModel _channel9;
        private PatternCellViewModel _channel10;
        private PatternCellViewModel _channel11;
        private PatternCellViewModel _channel12;
        private PatternCellViewModel _channel13;
        private PatternCellViewModel _channel14;
        private PatternCellViewModel _channel15;
        private PatternCellViewModel _channel16;
        private PatternCellViewModel _channel17;
        private PatternCellViewModel _channel18;
        private PatternCellViewModel _channel19;
        private PatternCellViewModel _channel20;
        private PatternCellViewModel _channel21;
        private PatternCellViewModel _channel22;
        private PatternCellViewModel _channel23;
        private PatternCellViewModel _channel24;
        private PatternCellViewModel _channel25;
        private PatternCellViewModel _channel26;
        private PatternCellViewModel _channel27;
        private PatternCellViewModel _channel28;
        private PatternCellViewModel _channel29;
        private PatternCellViewModel _channel30;
        private PatternCellViewModel _channel31;

        public PatternCellViewModel Channel0 => _channel0 ??= new PatternCellViewModel(_row[0]);
        public PatternCellViewModel Channel1 => _channel1 ??= new PatternCellViewModel(_row[1]);
        public PatternCellViewModel Channel2 => _channel2 ??= new PatternCellViewModel(_row[2]);
        public PatternCellViewModel Channel3 => _channel3 ??= new PatternCellViewModel(_row[3]);
        public PatternCellViewModel Channel4 => _channel4 ??= new PatternCellViewModel(_row[4]);
        public PatternCellViewModel Channel5 => _channel5 ??= new PatternCellViewModel(_row[5]);
        public PatternCellViewModel Channel6 => _channel6 ??= new PatternCellViewModel(_row[6]);
        public PatternCellViewModel Channel7 => _channel7 ??= new PatternCellViewModel(_row[7]);
        public PatternCellViewModel Channel8 => _channel8 ??= new PatternCellViewModel(_row[8]);
        public PatternCellViewModel Channel9 => _channel9 ??= new PatternCellViewModel(_row[9]);
        public PatternCellViewModel Channel10 => _channel10 ??= new PatternCellViewModel(_row[10]);
        public PatternCellViewModel Channel11 => _channel11 ??= new PatternCellViewModel(_row[11]);
        public PatternCellViewModel Channel12 => _channel12 ??= new PatternCellViewModel(_row[12]);
        public PatternCellViewModel Channel13 => _channel13 ??= new PatternCellViewModel(_row[13]);
        public PatternCellViewModel Channel14 => _channel14 ??= new PatternCellViewModel(_row[14]);
        public PatternCellViewModel Channel15 => _channel15 ??= new PatternCellViewModel(_row[15]);
        public PatternCellViewModel Channel16 => _channel16 ??= new PatternCellViewModel(_row[16]);
        public PatternCellViewModel Channel17 => _channel17 ??= new PatternCellViewModel(_row[17]);
        public PatternCellViewModel Channel18 => _channel18 ??= new PatternCellViewModel(_row[18]);
        public PatternCellViewModel Channel19 => _channel19 ??= new PatternCellViewModel(_row[19]);
        public PatternCellViewModel Channel20 => _channel20 ??= new PatternCellViewModel(_row[20]);
        public PatternCellViewModel Channel21 => _channel21 ??= new PatternCellViewModel(_row[21]);
        public PatternCellViewModel Channel22 => _channel22 ??= new PatternCellViewModel(_row[22]);
        public PatternCellViewModel Channel23 => _channel23 ??= new PatternCellViewModel(_row[23]);
        public PatternCellViewModel Channel24 => _channel24 ??= new PatternCellViewModel(_row[24]);
        public PatternCellViewModel Channel25 => _channel25 ??= new PatternCellViewModel(_row[25]);
        public PatternCellViewModel Channel26 => _channel26 ??= new PatternCellViewModel(_row[26]);
        public PatternCellViewModel Channel27 => _channel27 ??= new PatternCellViewModel(_row[27]);
        public PatternCellViewModel Channel28 => _channel28 ??= new PatternCellViewModel(_row[28]);
        public PatternCellViewModel Channel29 => _channel29 ??= new PatternCellViewModel(_row[29]);
        public PatternCellViewModel Channel30 => _channel30 ??= new PatternCellViewModel(_row[30]);
        public PatternCellViewModel Channel31 => _channel31 ??= new PatternCellViewModel(_row[31]);

        public PatternRowViewModel(PatternRow row)
        {
            _row = row ?? throw new ArgumentNullException(nameof(row));
            _channel0 = null!;
            _channel1 = null!;
            _channel2 = null!;
            _channel3 = null!;
            _channel4 = null!;
            _channel5 = null!;
            _channel6 = null!;
            _channel7 = null!;
            _channel8 = null!;
            _channel9 = null!;
            _channel10 = null!;
            _channel11 = null!;
            _channel12 = null!;
            _channel13 = null!;
            _channel14 = null!;
            _channel15 = null!;
            _channel16 = null!;
            _channel17 = null!;
            _channel18 = null!;
            _channel19 = null!;
            _channel20 = null!;
            _channel21 = null!;
            _channel22 = null!;
            _channel23 = null!;
            _channel24 = null!;
            _channel25 = null!;
            _channel26 = null!;
            _channel27 = null!;
            _channel28 = null!;
            _channel29 = null!;
            _channel30 = null!;
            _channel31 = null!;
        }
    }
}
