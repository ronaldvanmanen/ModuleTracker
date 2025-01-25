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
using System.Collections;
using System.Collections.Generic;
using ModuleTracker.Formats.S3M;

namespace ModuleTracker.Mvvm.S3M
{
    public sealed class ChannelViewModelCollection : IReadOnlyList<ChannelViewModel>
    {
        private readonly Module _module;

        private readonly ChannelViewModel[] _channels;

        public int Count => _channels.Length;

        public ChannelViewModel this[int index] => _channels[index] ??= new ChannelViewModel(_module, index);

        public ChannelViewModelCollection(Module module)
        {
            _module = module ?? throw new ArgumentNullException(nameof(module));
            _channels = new ChannelViewModel[_module.ChannelSettings.Count];

        }

        public IEnumerator<ChannelViewModel> GetEnumerator()
        {
            for (var index = 0; index < _channels.Length; ++index)
            {
                yield return this[index];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _channels.GetEnumerator();
        }
    }
}
