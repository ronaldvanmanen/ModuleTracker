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
using System.Windows.Input;

namespace ModuleTracker.Mvvm
{
    public sealed class CommandMapping : Freezable
    {
        public static readonly DependencyProperty BindingsProperty =
            DependencyProperty.RegisterAttached(
                "BindingsInternal",
                typeof(CommandMappingCollection),
                typeof(CommandMapping),
                new PropertyMetadata(BindingsPropertyChanged));

        public static CommandMappingCollection GetBindings(DependencyObject element)
        {
            if (element == null)
            {
                throw new ArgumentNullException(nameof(element));
            }

            var bindings = (CommandMappingCollection)element.GetValue(BindingsProperty);
            if (bindings != null)
                return bindings;

            bindings = new CommandMappingCollection();
            element.SetValue(BindingsProperty, bindings);
            return bindings;
        }

        public static void SetBindings(DependencyObject element, CommandMappingCollection value)
        {
            if (element == null)
            {
                throw new ArgumentNullException("element");
            }

            element.SetValue(BindingsProperty, value);
        }

        private static void BindingsPropertyChanged(object dependencyObject, DependencyPropertyChangedEventArgs eventArgs)
        {
            var element = dependencyObject as UIElement;
            if (element == null)
                return;

            var bindings = eventArgs.NewValue as CommandMappingCollection;
            if (bindings == null)
                return;

            foreach (var binding in bindings)
            {
                var source = CommandMapping.GetSource(binding);
                if (source == null)
                    continue;

                var sink = CommandMapping.GetSink(binding);
                if (sink == null)
                    continue;

                var commandBinding = new System.Windows.Input.CommandBinding(
                    source,
                    (s, e) => sink.Execute(e.Parameter),
                    (s, e) => e.CanExecute = sink.CanExecute(e.Parameter));

                element.CommandBindings.Add(commandBinding);
            }
        }

        public static readonly DependencyProperty SourceProperty =
            DependencyProperty.RegisterAttached(
                "Source",
                typeof(ICommand),
                typeof(CommandMapping),
                new PropertyMetadata());

        public static ICommand GetSource(DependencyObject element)
        {
            if (element == null)
            {
                throw new ArgumentNullException("element");
            }

            return (ICommand)element.GetValue(SourceProperty);
        }

        public static void SetSource(DependencyObject element, ICommand value)
        {
            if (element == null)
            {
                throw new ArgumentNullException("element");
            }

            element.SetValue(SourceProperty, value);
        }

        public static readonly DependencyProperty SinkProperty =
            DependencyProperty.RegisterAttached(
                "Sink",
                typeof(ICommand),
                typeof(CommandMapping),
                new PropertyMetadata());

        public static ICommand GetSink(DependencyObject dependencyObject)
        {
            if (dependencyObject == null)
            {
                throw new ArgumentNullException("dependencyObject");
            }

            return (ICommand)dependencyObject.GetValue(SinkProperty);
        }

        public static void SetSink(DependencyObject dependencyObject, ICommand command)
        {
            if (dependencyObject == null)
            {
                throw new ArgumentNullException("dependencyObject");
            }

            dependencyObject.SetValue(SinkProperty, command);
        }

        protected override Freezable CreateInstanceCore()
        {
            return new CommandMapping();
        }
    }
}
