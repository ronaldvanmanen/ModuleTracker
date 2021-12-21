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

using Microsoft.Extensions.DependencyInjection;
using ModuleTracker.Formats.S3M;
using ModuleTracker.Mvvm.S3M;
using ModuleTracker.Services;
using System;
using System.Windows;

namespace ModuleTracker
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var services = new ServiceCollection();
            services.AddSingleton<IOpenFileService, OpenFileService>();
            services.AddSingleton<IPropertyEditorService, PropertyEditorService>();
            services.AddTransient<MainViewModel>();

            var serviceProvider = services.BuildServiceProvider();
            var propertyEditorService = serviceProvider.GetService<IPropertyEditorService>();
            propertyEditorService?.RegisterPropertyEditor<Module>(module => new ModulePropertiesViewModel(module));
            propertyEditorService?.RegisterPropertyEditor<ModuleDocumentViewModel>(moduleViewModel => new ModulePropertiesViewModel(moduleViewModel.Module));

            var mainViewModel = serviceProvider.GetService<MainViewModel>();
            var mainView = new MainView(mainViewModel!);
            mainView.Show();
        }
    }
}
