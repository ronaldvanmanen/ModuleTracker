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
    public sealed class S3MPatternRowViewModel : ObservableObject
    {
        private readonly S3MPatternRow _row;

        private S3MPatternCellViewModel _channel0;
        private S3MPatternCellViewModel _channel1;
        private S3MPatternCellViewModel _channel2;
        private S3MPatternCellViewModel _channel3;
        private S3MPatternCellViewModel _channel4;
        private S3MPatternCellViewModel _channel5;
        private S3MPatternCellViewModel _channel6;
        private S3MPatternCellViewModel _channel7;
        private S3MPatternCellViewModel _channel8;
        private S3MPatternCellViewModel _channel9;
        private S3MPatternCellViewModel _channel10;
        private S3MPatternCellViewModel _channel11;
        private S3MPatternCellViewModel _channel12;
        private S3MPatternCellViewModel _channel13;
        private S3MPatternCellViewModel _channel14;
        private S3MPatternCellViewModel _channel15;
        private S3MPatternCellViewModel _channel16;
        private S3MPatternCellViewModel _channel17;
        private S3MPatternCellViewModel _channel18;
        private S3MPatternCellViewModel _channel19;
        private S3MPatternCellViewModel _channel20;
        private S3MPatternCellViewModel _channel21;
        private S3MPatternCellViewModel _channel22;
        private S3MPatternCellViewModel _channel23;
        private S3MPatternCellViewModel _channel24;
        private S3MPatternCellViewModel _channel25;
        private S3MPatternCellViewModel _channel26;
        private S3MPatternCellViewModel _channel27;
        private S3MPatternCellViewModel _channel28;
        private S3MPatternCellViewModel _channel29;
        private S3MPatternCellViewModel _channel30;
        private S3MPatternCellViewModel _channel31;

        public S3MPatternCellViewModel Channel0 => _channel0 ??= new S3MPatternCellViewModel(_row[0]);
        public S3MPatternCellViewModel Channel1 => _channel1 ??= new S3MPatternCellViewModel(_row[1]);
        public S3MPatternCellViewModel Channel2 => _channel2 ??= new S3MPatternCellViewModel(_row[2]);
        public S3MPatternCellViewModel Channel3 => _channel3 ??= new S3MPatternCellViewModel(_row[3]);
        public S3MPatternCellViewModel Channel4 => _channel4 ??= new S3MPatternCellViewModel(_row[4]);
        public S3MPatternCellViewModel Channel5 => _channel5 ??= new S3MPatternCellViewModel(_row[5]);
        public S3MPatternCellViewModel Channel6 => _channel6 ??= new S3MPatternCellViewModel(_row[6]);
        public S3MPatternCellViewModel Channel7 => _channel7 ??= new S3MPatternCellViewModel(_row[7]);
        public S3MPatternCellViewModel Channel8 => _channel8 ??= new S3MPatternCellViewModel(_row[8]);
        public S3MPatternCellViewModel Channel9 => _channel9 ??= new S3MPatternCellViewModel(_row[9]);
        public S3MPatternCellViewModel Channel10 => _channel10 ??= new S3MPatternCellViewModel(_row[10]);
        public S3MPatternCellViewModel Channel11 => _channel11 ??= new S3MPatternCellViewModel(_row[11]);
        public S3MPatternCellViewModel Channel12 => _channel12 ??= new S3MPatternCellViewModel(_row[12]);
        public S3MPatternCellViewModel Channel13 => _channel13 ??= new S3MPatternCellViewModel(_row[13]);
        public S3MPatternCellViewModel Channel14 => _channel14 ??= new S3MPatternCellViewModel(_row[14]);
        public S3MPatternCellViewModel Channel15 => _channel15 ??= new S3MPatternCellViewModel(_row[15]);
        public S3MPatternCellViewModel Channel16 => _channel16 ??= new S3MPatternCellViewModel(_row[16]);
        public S3MPatternCellViewModel Channel17 => _channel17 ??= new S3MPatternCellViewModel(_row[17]);
        public S3MPatternCellViewModel Channel18 => _channel18 ??= new S3MPatternCellViewModel(_row[18]);
        public S3MPatternCellViewModel Channel19 => _channel19 ??= new S3MPatternCellViewModel(_row[19]);
        public S3MPatternCellViewModel Channel20 => _channel20 ??= new S3MPatternCellViewModel(_row[20]);
        public S3MPatternCellViewModel Channel21 => _channel21 ??= new S3MPatternCellViewModel(_row[21]);
        public S3MPatternCellViewModel Channel22 => _channel22 ??= new S3MPatternCellViewModel(_row[22]);
        public S3MPatternCellViewModel Channel23 => _channel23 ??= new S3MPatternCellViewModel(_row[23]);
        public S3MPatternCellViewModel Channel24 => _channel24 ??= new S3MPatternCellViewModel(_row[24]);
        public S3MPatternCellViewModel Channel25 => _channel25 ??= new S3MPatternCellViewModel(_row[25]);
        public S3MPatternCellViewModel Channel26 => _channel26 ??= new S3MPatternCellViewModel(_row[26]);
        public S3MPatternCellViewModel Channel27 => _channel27 ??= new S3MPatternCellViewModel(_row[27]);
        public S3MPatternCellViewModel Channel28 => _channel28 ??= new S3MPatternCellViewModel(_row[28]);
        public S3MPatternCellViewModel Channel29 => _channel29 ??= new S3MPatternCellViewModel(_row[29]);
        public S3MPatternCellViewModel Channel30 => _channel30 ??= new S3MPatternCellViewModel(_row[30]);
        public S3MPatternCellViewModel Channel31 => _channel31 ??= new S3MPatternCellViewModel(_row[31]);

        public S3MPatternRowViewModel(S3MPatternRow row)
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
