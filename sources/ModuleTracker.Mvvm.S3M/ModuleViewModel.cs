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
using System.ComponentModel.DataAnnotations;
using ModuleTracker.Formats.S3M;

namespace ModuleTracker.Mvvm.S3M
{
    public sealed class ModuleViewModel : DocumentViewModel
    {
        private readonly Module _module;

        private readonly ChannelViewModelCollection _channels;

        private readonly PatternViewModelCollection _patterns;

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
                SetProperty(_module.Title, value, _module, (module, title) => module.Title = title);
            }
        }

        [Category("General")]
        [DisplayName("Global Volume")]
        [Description("Sets the global volume of the module affecting all channels.")]
        [Range(0, 40)]
        public byte GlobalVolume
        {
            get
            {
                return _module.GlobalVolume;
            }
            set
            {
                SetProperty(_module.GlobalVolume, value, _module, (module, globalVolume) => module.GlobalVolume = globalVolume);
            }
        }

        [Category("General")]
        [DisplayName("Initial Speed")]
        [Description("Sets the speed at which the module is played when no other speed is specified.")]
        [DefaultValue(6)]
        public byte InitialSpeed
        {
            get
            {
                return _module.InitialSpeed;
            }
            set
            {
                SetProperty(_module.InitialSpeed, value, _module, (module, globalSpeed) => module.InitialSpeed = globalSpeed);
            }
        }

        [Category("General")]
        [DisplayName("Initial Tempo")]
        [Description("Sets the tempo at which the module is played when no other tempo is specified.")]
        [DefaultValue(0x7D)]
        public byte InitialTempo
        {
            get
            {
                return _module.InitialTempo;
            }
            set
            {
                SetProperty(_module.InitialTempo, value, _module, (module, globalTempo) => module.InitialTempo = globalTempo);
            }
        }

        [Category("General")]
        [DisplayName("Stereo")]
        [Description("Enable stereo playblack of the module on stereo cards, otherwise the song will be played mono regardless of the channel allocations.")]
        public bool StereoPlayback
        {
            get
            {
                return _module.StereoPlayback;
            }
            set
            {
                SetProperty(_module.StereoPlayback, value, _module, (module, stereo) => module.StereoPlayback = stereo);
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
                SetProperty(_module.MasterVolume, value, _module, (module, masterVolume) => module.MasterVolume = masterVolume);
            }
        }

        [Browsable(false)]
        public ChannelViewModelCollection Channels => _channels;

        [Browsable(false)]
        public PatternViewModelCollection Patterns => _patterns;

        public ModuleViewModel(Module module)
        : base(module.Title)
        {
            _module = module ?? throw new ArgumentNullException(nameof(module));
            _channels = new ChannelViewModelCollection(_module);
            _patterns = new PatternViewModelCollection(_module);
        }
    }
}
