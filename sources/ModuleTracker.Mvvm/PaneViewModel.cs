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

using System.ComponentModel;
using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace ModuleTracker.Mvvm
{
    public abstract class PaneViewModel : ObservableRecipient
    {
        private string _paneContentId = null!;

        private string _paneTitle = null!;

        private bool _isPaneActive;

        private bool _isPaneSelected;

        [Browsable(false)]
        public string PaneContentId
        {
            get
            {
                return _paneContentId;
            }
            set
            {
                SetProperty(ref _paneContentId, value);
            }
        }

        [Browsable(false)]
        public string PaneTitle
        {
            get
            {
                return _paneTitle;
            }
            set
            {
                SetProperty(ref _paneTitle, value);
            }
        }

        [Browsable(false)]
        public bool IsPaneActive
        {
            get
            {
                return _isPaneActive;
            }
            set
            {
                SetProperty(ref _isPaneActive, value);
            }
        }

        [Browsable(false)]
        public bool IsPaneSelected
        {
            get
            {
                return _isPaneSelected;
            }
            set
            {
                SetProperty(ref _isPaneSelected, value);
            }
        }
    }
}
