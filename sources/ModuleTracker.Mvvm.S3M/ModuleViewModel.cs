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
using System.ComponentModel;
using ModuleTracker.Formats.S3M;

namespace ModuleTracker.Mvvm.S3M
{
    public sealed class ModuleViewModel : DocumentViewModel
    {
        private readonly Module _module;

        private readonly PatternListViewModel _patterns;

        private readonly InstrumentListViewModel _instruments;

        [Category("General")]
        [DisplayName("Title")]
        [Description("Sets the title of the module.")]
        public string Title
        {
            get
            {
                return _module.Title;
            }
            set
            {
                SetProperty(_module.Title, value, _module, (module, title) => _module.Title = title);
            }
        }

        [Category("General")]
        [DisplayName("Global Volume")]
        [Description("Sets the global volume of the module.")]
        public byte GlobalVolume
        {
            get
            {
                return _module.GlobalVolume;
            }
            set
            {
                SetProperty(_module.GlobalVolume, value, _module, (module, globalVolume) => _module.GlobalVolume = globalVolume);
            }
        }

        [Category("General")]
        [DisplayName("Initial Speed")]
        [Description("Sets the initial speed of the module.")]
        public byte InitialSpeed
        {
            get
            {
                return _module.InitialSpeed;
            }
            set
            {
                SetProperty(_module.InitialSpeed, value, _module, (module, initialSpeed) => _module.InitialSpeed = initialSpeed);
            }
        }

        [Category("General")]
        [DisplayName("Initial Tempo")]
        [Description("Sets the initial tempo of the module.")]
        public byte InitialTempo
        {
            get
            {
                return _module.InitialTempo;
            }
            set
            {
                SetProperty(_module.InitialTempo, value, _module, (module, initialSpeed) => _module.InitialTempo = initialSpeed);
            }
        }

        [Category("General")]
        [DisplayName("Master Volume")]
        [Description("Sets the master volume of the module.")]
        public byte MasterVolume
        {
            get
            {
                return _module.MasterVolume;
            }
            set
            {
                SetProperty(_module.MasterVolume, value, _module, (module, masterVolume) => _module.MasterVolume = masterVolume);
            }
        }

        [Browsable(false)]
        public PatternListViewModel Patterns => _patterns;

        [Browsable(false)]
        public InstrumentListViewModel Instruments => _instruments;

        public ModuleViewModel(Module module)
        : base(module.Title)
        {
            _module = module ?? throw new ArgumentNullException(nameof(module));
            _patterns = new PatternListViewModel(_module);
            _instruments = new InstrumentListViewModel(_module);
        }
    }
}
