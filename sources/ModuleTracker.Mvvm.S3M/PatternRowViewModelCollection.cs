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
using System.Collections.ObjectModel;
using ModuleTracker.Formats.S3M;

namespace ModuleTracker.Mvvm.S3M
{
    public sealed class PatternRowViewModelCollection
    : IList<PatternRowViewModel>
    , IList
    {
        private readonly Module _module;

        private readonly Dictionary<int, PatternRowViewModel> _items;

        public PatternRowViewModel this[int index]
        {
            get
            {
                if (!_items.TryGetValue(index, out var item))
                {
                    var patternIndex = Math.DivRem(index, 64, out var rowIndex);
                    item = new PatternRowViewModel(_module, patternIndex, rowIndex);
                    _items.Add(index, item);
                }
                return item;
            }

            set => throw new NotSupportedException();
        }

        object? IList.this[int index]
        {
            get => this[index];

            set => throw new NotSupportedException();
        }

        public int Count => _module.Patterns.Count * 64;

        public bool IsReadOnly => true;

        public bool IsFixedSize => false;

        public bool IsSynchronized => false;

        public object SyncRoot => this;

        public PatternRowViewModelCollection(Module module)
        {
            _module = module ?? throw new ArgumentNullException(nameof(module));
            _items = new Dictionary<int, PatternRowViewModel>();
        }

        public IEnumerator<PatternRowViewModel> GetEnumerator()
        {
            for (var i = 0; i < Count; ++i)
            {
                yield return this[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        public int IndexOf(PatternRowViewModel item)
        {
            return item.PatternIndex * item.RowIndex;
        }

        public void Insert(int index, PatternRowViewModel item)
        {
            throw new NotSupportedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotSupportedException();
        }

        public void Add(PatternRowViewModel item)
        {
            throw new NotSupportedException();
        }

        public void Clear()
        {
            throw new NotSupportedException();
        }

        public bool Contains(PatternRowViewModel item)
        {
            throw new NotSupportedException();
        }

        public void CopyTo(PatternRowViewModel[] array, int arrayIndex)
        {
            throw new NotSupportedException();
        }

        public bool Remove(PatternRowViewModel item)
        {
            throw new NotSupportedException();
        }

        public int Add(object? value)
        {
            throw new NotImplementedException();
        }

        public bool Contains(object? value)
        {
            throw new NotImplementedException();
        }

        public int IndexOf(object? value)
        {
            if (value is PatternRowViewModel viewModel)
            {
                return IndexOf(viewModel);
            }
            return -1;
        }

        public void Insert(int index, object? value)
        {
            throw new NotImplementedException();
        }

        public void Remove(object? value)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(Array array, int index)
        {
            throw new NotImplementedException();
        }
    }
}
