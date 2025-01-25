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

using System.Windows.Input;

namespace ModuleTracker.Mvvm
{
    /// <summary>
    ///     Provides a standard set of application related commands.
    /// </summary>
    public static class ApplicationCommands
    {
        /// <summary>
        ///     Represents the Close All command.
        /// </summary>
        private static readonly RoutedUICommand _closeAll = new RoutedUICommand(
            StringResources.CloseAll,
            "CloseAll",
            typeof(ApplicationCommands));

        /// <summary>
        ///     Represents the Save All command.
        /// </summary>
        private static readonly RoutedUICommand _saveAll = new RoutedUICommand(
            StringResources.SaveAll,
            "SaveAll",
            typeof(ApplicationCommands),
            new InputGestureCollection { new KeyGesture(Key.S, ModifierKeys.Control | ModifierKeys.Shift) });

        /// <summary>
        ///     Represents the Save All command.
        /// </summary>
        private static readonly RoutedUICommand _exit = new RoutedUICommand(
            StringResources.Exit,
            "Exit",
            typeof(ApplicationCommands),
            new InputGestureCollection { new KeyGesture(Key.F4, ModifierKeys.Alt) });

        /// <summary>
        ///     Gets the value that represents the New command.
        /// </summary>
        /// <value>
        ///     The command.
        /// </value>
        public static RoutedUICommand New
        {
            get { return System.Windows.Input.ApplicationCommands.New; }
        }

        /// <summary>
        ///     Gets the value that represents the Open command.
        /// </summary>
        /// <value>
        ///     The command.
        /// </value>
        public static RoutedUICommand Open
        {
            get { return System.Windows.Input.ApplicationCommands.Open; }
        }

        /// <summary>
        ///     Gets the value that represents the Close command.
        /// </summary>
        /// <value>
        ///     The command.
        /// </value>
        public static RoutedUICommand Close
        {
            get { return System.Windows.Input.ApplicationCommands.Close; }
        }

        /// <summary>
        ///     Gets the value that represents the Close All command.
        /// </summary>
        /// <value>
        ///     The command.
        /// </value>
        public static RoutedUICommand CloseAll
        {
            get { return _closeAll; }
        }

        /// <summary>
        ///     Gets the value that represents the Save command.
        /// </summary>
        /// <value>
        ///     The command.
        /// </value>
        public static RoutedUICommand Save
        {
            get { return System.Windows.Input.ApplicationCommands.Save; }
        }

        /// <summary>
        ///     Gets the value that represents the Save All command.
        /// </summary>
        /// <value>
        ///     The command.
        /// </value>
        public static RoutedUICommand SaveAll
        {
            get { return _saveAll; }
        }

        /// <summary>
        ///     Gets the value that represents the Delete command.
        /// </summary>
        /// <value>
        ///     The command.
        /// </value>
        public static RoutedUICommand SaveAs
        {
            get { return System.Windows.Input.ApplicationCommands.SaveAs; }
        }

        /// <summary>
        ///     Gets the value that represents the Print command.
        /// </summary>
        /// <value>
        ///     The command.
        /// </value>
        public static RoutedUICommand Print
        {
            get { return System.Windows.Input.ApplicationCommands.Print; }
        }

        /// <summary>
        ///     Gets the value that represents the Print Preview command.
        /// </summary>
        /// <value>
        ///     The command.
        /// </value>
        public static RoutedUICommand PrintPreview
        {
            get { return System.Windows.Input.ApplicationCommands.PrintPreview; }
        }

        /// <summary>
        ///     Gets the value that represents the Cancel Print command.
        /// </summary>
        /// <value>
        ///     The command.
        /// </value>
        public static RoutedUICommand CancelPrint
        {
            get { return System.Windows.Input.ApplicationCommands.CancelPrint; }
        }

        /// <summary>
        ///     Gets the value that represents the Exit command.
        /// </summary>
        /// <value>
        ///     The command.
        /// </value>
        public static RoutedUICommand Exit
        {
            get { return _exit; }
        }

        /// <summary>
        ///     Gets the value that represents the Undo command.
        /// </summary>
        /// <value>
        ///     The command.
        /// </value>
        public static RoutedUICommand Undo
        {
            get { return System.Windows.Input.ApplicationCommands.Undo; }
        }

        /// <summary>
        ///     Gets the value that represents the Redo command.
        /// </summary>
        /// <value>
        ///     The command.
        /// </value>
        public static RoutedUICommand Redo
        {
            get { return System.Windows.Input.ApplicationCommands.Redo; }
        }

        /// <summary>
        ///     Gets the value that represents the Cut command.
        /// </summary>
        /// <value>
        ///     The command.
        /// </value>
        public static RoutedUICommand Cut
        {
            get { return System.Windows.Input.ApplicationCommands.Cut; }
        }

        /// <summary>
        ///     Gets the value that represents the Copy command.
        /// </summary>
        /// <value>
        ///     The command.
        /// </value>
        public static RoutedUICommand Copy
        {
            get { return System.Windows.Input.ApplicationCommands.Copy; }
        }

        /// <summary>
        ///     Gets the value that represents the Paste command.
        /// </summary>
        /// <value>
        ///     The command.
        /// </value>
        public static RoutedUICommand Paste
        {
            get { return System.Windows.Input.ApplicationCommands.Paste; }
        }

        /// <summary>
        ///     Gets the value that represents the Delete command.
        /// </summary>
        /// <value>
        ///     The command.
        /// </value>
        public static RoutedUICommand Delete
        {
            get { return System.Windows.Input.ApplicationCommands.Delete; }
        }

        /// <summary>
        ///     Gets the value that represents the Delete command.
        /// </summary>
        /// <value>
        ///     The command.
        /// </value>
        public static RoutedUICommand SelectAll
        {
            get { return System.Windows.Input.ApplicationCommands.SelectAll; }
        }

        /// <summary>
        ///     Gets the value that represents the Find command.
        /// </summary>
        /// <value>
        ///     The command.
        /// </value>
        public static RoutedUICommand Find
        {
            get { return System.Windows.Input.ApplicationCommands.Find; }
        }

        /// <summary>
        ///     Gets the value that represents the Replace command.
        /// </summary>
        /// <value>
        ///     The command.
        /// </value>
        public static RoutedUICommand Replace
        {
            get { return System.Windows.Input.ApplicationCommands.Replace; }
        }

        /// <summary>
        ///     Gets the value that represents the Properties command.
        /// </summary>
        /// <value>
        ///     The command.
        /// </value>
        public static RoutedUICommand Properties
        {
            get { return System.Windows.Input.ApplicationCommands.Properties; }
        }

        /// <summary>
        ///     Gets the value that represents the Context Menu command.
        /// </summary>
        /// <value>
        ///     The command.
        /// </value>
        public static RoutedUICommand ContextMenu
        {
            get { return System.Windows.Input.ApplicationCommands.ContextMenu; }
        }

        /// <summary>
        ///     Gets the value that represents the Correction List command.
        /// </summary>
        /// <value>
        ///     The command.
        /// </value>
        public static RoutedUICommand CorrectionList
        {
            get { return System.Windows.Input.ApplicationCommands.CorrectionList; }
        }

        /// <summary>
        ///     Gets the value that represents the Stop command.
        /// </summary>
        /// <value>
        ///     The command.
        /// </value>
        public static RoutedUICommand Stop
        {
            get { return System.Windows.Input.ApplicationCommands.Stop; }
        }

        /// <summary>
        ///     Gets the value that represents the Help command.
        /// </summary>
        /// <value>
        ///     The command.
        /// </value>
        public static RoutedUICommand Help
        {
            get { return System.Windows.Input.ApplicationCommands.Help; }
        }
    }
}
