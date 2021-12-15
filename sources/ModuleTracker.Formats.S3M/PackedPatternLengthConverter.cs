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

using System.Diagnostics;
using BinarySerialization;

namespace ModuleTracker.Formats.S3M
{
    internal sealed class PackedPatternLengthConverter : IValueConverter
    {
        public object Convert(object value, object parameter, BinarySerializationContext context)
        {
            if (value is ushort length)
            {
                var result = length - sizeof(ushort);
                Debug.Assert(result > 0);
                return result;
            }
            return 0;
        }

        public object ConvertBack(object value, object parameter, BinarySerializationContext context)
        {
            if (value is ushort length)
            {
                return length + sizeof(ushort);
            }
            return 0;
        }
    }
}
