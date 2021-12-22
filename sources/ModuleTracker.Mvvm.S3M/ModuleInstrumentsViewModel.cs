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

using System.Collections.ObjectModel;
using System.Linq;
using Microsoft.Toolkit.Mvvm.Messaging;
using ModuleTracker.Formats.S3M;

namespace ModuleTracker.Mvvm.S3M
{
    public sealed class ModuleInstrumentsViewModel : ToolboxViewModel, IRecipient<ActiveObjectChangedMessage>
    {
        public ObservableCollection<InstrumentViewModel> Instruments { get; } = new ObservableCollection<InstrumentViewModel>();

        private InstrumentViewModel _selectedInstrument = null!;

        public InstrumentViewModel SelectedInstrument
        {
            get => _selectedInstrument;

            set => SetProperty(ref _selectedInstrument, value);
        }

        public void Receive(ActiveObjectChangedMessage message)
        {
            Instruments.Clear();

            var module = GetModule(message);
            if (module != null)
            {
                foreach (var instrument in module.Instruments.Select(instrument => CreateViewModel(instrument)))
                {
                    Instruments.Add(instrument);
                }
            }
        }

        private static Module? GetModule(ActiveObjectChangedMessage message)
        {
            return message.Value switch
            {
                ModuleDocumentViewModel viewModel => viewModel.Module,
                Module module => module,
                _ => null,
            };
        }

        protected override void OnActivated()
        {
            base.OnActivated();

            if (Messenger.IsRegistered<ActiveObjectChangedMessage>(this))
            {
                return;
            }

            Messenger.Register<ModuleInstrumentsViewModel, ActiveObjectChangedMessage>(this, (recipient, message) => recipient.Receive(message));
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

        private static InstrumentViewModel CreateViewModel(Instrument instrument)
        {
            switch (instrument)
            {
                case EmptyInstrument emptyInstrument:
                    return new EmptyInstrumentViewModel(emptyInstrument);

                case AdlibInstrument adlibInstrument:
                    return new AdlibInstrumentViewModel(adlibInstrument);

                case SampleInstrument sampledInstrument:
                    return new SampleInstrumentViewModel(sampledInstrument);
            }
            return null!;
        }
    }
}
