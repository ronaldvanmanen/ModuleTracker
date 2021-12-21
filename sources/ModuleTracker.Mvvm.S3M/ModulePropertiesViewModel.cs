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
using Microsoft.Toolkit.Mvvm.ComponentModel;
using ModuleTracker.Formats.S3M;

namespace ModuleTracker.Mvvm.S3M
{
    public sealed class ModulePropertiesViewModel : ObservableObject
    {
        private readonly Module _module;

        [Category("General")]
        [DisplayName("Song Title")]
        [Description("Sets the title of the module.")]
        [MaxLength(Module.MaxTitleLength)]
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
        [Range(Module.MinVolume, Module.MaxVolume)]
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
        [DisplayName("Global Speed")]
        [Description("Sets the speed at which the module is played when no other speed is specified.")]
        [DefaultValue(Module.DefaultSpeed)]
        [Range(Module.MinSpeed, Module.MaxSpeed)]
        public byte GlobalSpeed
        {
            get
            {
                return _module.GlobalSpeed;
            }
            set
            {
                SetProperty(_module.GlobalSpeed, value, _module, (module, globalSpeed) => module.GlobalSpeed = globalSpeed);
            }
        }

        [Category("General")]
        [DisplayName("Global Tempo")]
        [Description("Sets the tempo at which the module is played when no other tempo is specified.")]
        [DefaultValue(Module.DefaultTempo)]
        public byte GlobalTempo
        {
            get
            {
                return _module.GlobalTempo;
            }
            set
            {
                SetProperty(_module.GlobalTempo, value, _module, (module, globalTempo) => module.GlobalTempo = globalTempo);
            }
        }

        [Category("General")]
        [DisplayName("Stereo Playback")]
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
        [Range(Module.MinMasterVolume, Module.MaxMasterVolume)]
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

        public ModulePropertiesViewModel(Module module)
        {
            _module = module ?? throw new ArgumentNullException(nameof(module));
        }
    }
}
