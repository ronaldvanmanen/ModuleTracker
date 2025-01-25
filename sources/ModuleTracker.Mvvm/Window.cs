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
using System.Windows;

namespace ModuleTracker.Mvvm
{
    public static class Window
    {
        public static readonly DependencyProperty CommandMappingsProperty =
            DependencyProperty.RegisterAttached(
                "CommandMappingsInternal",
                typeof(CommandMappingCollection),
                typeof(CommandMapping),
                new PropertyMetadata(CommandMappingsPropertyChanged));

        public static CommandMappingCollection GetCommandMappings(DependencyObject element)
        {
            if (element == null)
            {
                throw new ArgumentNullException(nameof(element));
            }

            var bindings = (CommandMappingCollection)element.GetValue(CommandMappingsProperty);
            if (bindings != null)
            {
                return bindings;
            }

            bindings = new CommandMappingCollection();
            element.SetValue(CommandMappingsProperty, bindings);
            return bindings;
        }

        public static void SetCommandMappings(DependencyObject element, CommandMappingCollection value)
        {
            if (element == null)
            {
                throw new ArgumentNullException(nameof(element));
            }

            element.SetValue(CommandMappingsProperty, value);
        }

        private static void CommandMappingsPropertyChanged(object dependencyObject, DependencyPropertyChangedEventArgs eventArgs)
        {
            var element = dependencyObject as UIElement;
            if (element == null)
            {
                return;
            }

            var bindings = eventArgs.NewValue as CommandMappingCollection;
            if (bindings == null)
            {
                return;
            }

            foreach (var binding in bindings)
            {
                var source = CommandMapping.GetSource(binding);
                if (source == null)
                {
                    continue;
                }

                var sink = CommandMapping.GetSink(binding);
                if (sink == null)
                {
                    continue;
                }

                var commandBinding = new System.Windows.Input.CommandBinding(
                    source,
                    (s, e) => sink.Execute(e.Parameter),
                    (s, e) => e.CanExecute = sink.CanExecute(e.Parameter));

                element.CommandBindings.Add(commandBinding);
            }
        }
    }
}
