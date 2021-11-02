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
using Microsoft.Win32;

namespace ModuleTracker
{
    internal sealed class OpenFileService : IOpenFileService
    {
        public string[] ShowDialog(string title, string filter)
        {
            var dialog = new OpenFileDialog
            {
                Title = title,
                Filter = filter
            };

            var dialogResult = dialog.ShowDialog();
            if (dialogResult == true)
            {
                return dialog.FileNames;
            }
            return Array.Empty<string>();
        }
    }
}