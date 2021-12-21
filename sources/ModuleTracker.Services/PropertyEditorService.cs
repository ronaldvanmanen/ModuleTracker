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
using System.Collections.Generic;

namespace ModuleTracker.Services
{
    public sealed class PropertyEditorService : IPropertyEditorService
    {
        private readonly Dictionary<Type, Delegate> _factoryMethods = new Dictionary<Type, Delegate>();

        public object? GetPropertyEditor(object editableObject)
        {
            if (_factoryMethods.TryGetValue(editableObject.GetType(), out var factoryMethod))
            {
                return factoryMethod.DynamicInvoke(new object[] { editableObject });
            }
            return editableObject;
        }

        public void RegisterPropertyEditor<T>(Func<T, object> factoryMethod)
        {
            _factoryMethods.Add(typeof(T), factoryMethod);
        }

        public void UnregisterPropertyEditor<T>()
        {
            _factoryMethods.Remove(typeof(T));
        }
    }
}
