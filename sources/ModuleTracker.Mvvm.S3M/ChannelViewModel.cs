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
    public sealed class ChannelViewModel : ObservableObject
    {
        private readonly Module _module;

        private readonly int _index;

        public ChannelViewModel(Module module, int index)
        {
            _module = module ?? throw new ArgumentNullException(nameof(module));
            _index = index;
        }

        public bool Unused
        {
            get => _module.ChannelSettings[_index].Unused;
            set
            {
                SetProperty(_module.ChannelSettings[_index].Unused, value, _module,
                    (module, unused) => module.ChannelSettings[_index].Unused = unused);
            }
        }

        public bool Disabled
        {
            get => _module.ChannelSettings[_index].Disabled;
            set
            {
                SetProperty(_module.ChannelSettings[_index].Disabled, value, _module,
                    (module, disabled) => module.ChannelSettings[_index].Disabled = disabled);
            }
        }

        public byte Pan
        {
            get => _module.ChannelSettings[_index].Pan;
            set
            {
                SetProperty(_module.ChannelSettings[_index].Pan, value, _module,
                    (module, pan) => module.ChannelSettings[_index].Pan = pan);
            }
        }
    }
}
