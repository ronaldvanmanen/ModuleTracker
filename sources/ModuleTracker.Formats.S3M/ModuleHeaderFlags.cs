﻿// This file is part of Module Tracker.
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

namespace ModuleTracker.Formats.S3M
{
    [Flags]
    internal enum ModuleHeaderFlags : ushort
    {
        ST2Vibrato = 0x1,
        ST2Tempo = 0x2,
        AmigaSlides = 0x4,
        ZeroVolumeOptimizations = 0x8,
        AmigaLimits = 0x10,
        EnableSoundBlasterFilterSfx = 0x20,
        SpecialCustomDataInFile = 0x80
    }
}
