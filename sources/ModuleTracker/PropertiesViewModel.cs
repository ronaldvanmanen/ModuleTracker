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

using Microsoft.Toolkit.Mvvm.Messaging;
using ModuleTracker.Mvvm;

namespace ModuleTracker
{
    public sealed class PropertiesViewModel : ToolboxViewModel, IRecipient<ActiveObjectChangedMessage>
    {
        private object _activeObject = null!;

        public object ActiveObject
        {
            get => _activeObject;

            private set => SetProperty(ref _activeObject, value);
        }


        public void Receive(ActiveObjectChangedMessage message)
        {
            ActiveObject = message.Value;
        }

        public PropertiesViewModel()
        : base("Properties")
        { }

        protected override void OnActivated()
        {
            base.OnActivated();

            if (Messenger.IsRegistered<ActiveObjectChangedMessage>(this))
            {
                return;
            }

            Messenger.Register<PropertiesViewModel, ActiveObjectChangedMessage>(this, (recipient, message) => recipient.Receive(message));
        }

        protected override void OnDeactivated()
        {
            base.OnDeactivated();

            if (!Messenger.IsRegistered<ActiveObjectChangedMessage>(this))
            {
                return;
            }

            Messenger.Unregister<ActiveObjectChangedMessage>(this);
        }
    }
}
