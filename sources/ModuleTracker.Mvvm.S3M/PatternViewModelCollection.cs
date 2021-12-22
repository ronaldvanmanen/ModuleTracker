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
using System.Collections.Specialized;
using System.ComponentModel;
using ModuleTracker.Formats.S3M;

namespace ModuleTracker.Mvvm.S3M
{
    public sealed class PatternViewModelCollection
    : IList<PatternRowViewModel>
    , IList
    , INotifyCollectionChanged
    , INotifyPropertyChanging
    , INotifyPropertyChanged
    {
        public event NotifyCollectionChangedEventHandler? CollectionChanged;

        public event PropertyChangingEventHandler? PropertyChanging;

        public event PropertyChangedEventHandler? PropertyChanged;

        private readonly Module _module;

        private readonly Dictionary<int, PatternViewModel> _patterns;

        private int _patternIndex;

        public PatternRowViewModel this[int index]
        {
            get
            {
                return GetItemAt(index);
            }

            set => throw new NotSupportedException();
        }

        object? IList.this[int index]
        {
            get => this[index];

            set => throw new NotSupportedException();
        }

        public int Count
        {
            get
            {
                var pattern = GetOrCreatePattern(_patternIndex);
                var count = pattern.Count;
                return count;
            }
        }

        public bool IsReadOnly => true;

        public bool IsFixedSize => true;

        public bool IsSynchronized => false;

        public object SyncRoot => this;

        public int PatternIndex => _patternIndex;

        public int PatternCount => _module.Patterns.Count;

        public PatternViewModelCollection(Module module)
        {
            _module = module ?? throw new ArgumentNullException(nameof(module));
            _patterns = new Dictionary<int, PatternViewModel>();
        }

        public void GotoFirstPattern()
        {
            GotoPattern(0);
        }

        public void GotoPreviousPattern()
        {
            GotoPattern(PatternIndex - 1);
        }

        public void GotoNextPattern()
        {
            GotoPattern(PatternIndex + 1);
        }

        public void GotoLastPattern()
        {
            GotoPattern(PatternCount - 1);
        }

        public bool GotoPattern(int patternIndex)
        {
            if (patternIndex < 0 || patternIndex >= _module.Patterns.Count)
            {
                return false;
            }

            PropertyChanging?.Invoke(this, new PropertyChangingEventArgs(nameof(PatternIndex)));
            PropertyChanging?.Invoke(this, new PropertyChangingEventArgs(nameof(PatternCount)));

            _patternIndex = patternIndex;

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PatternIndex)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PatternCount)));
            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));

            return true;
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
            return _patterns.GetEnumerator();
        }

        public int IndexOf(PatternRowViewModel item)
        {
            var pattern = GetOrCreatePattern(_patternIndex);
            var index = pattern.IndexOf(item);
            return index;
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

        private PatternRowViewModel GetItemAt(int index)
        {
            var pattern = GetOrCreatePattern(_patternIndex);
            var patternRow = pattern[index];
            return patternRow;
        }

        private PatternViewModel GetOrCreatePattern(int index)
        {
            if (_patterns.TryGetValue(_patternIndex, out var pattern))
            {
                return pattern;
            }

            pattern = new PatternViewModel(_module, index);
            _patterns.Add(_patternIndex, pattern);
            return pattern;
        }
    }
}
