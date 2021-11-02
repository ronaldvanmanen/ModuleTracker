using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;

namespace ModuleTracker
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static new App Current => (App)Application.Current;

        public IServiceProvider Services { get; } = ConfigureServices();

        private static IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();
            services.AddTransient<MainViewModel>();
            return services.BuildServiceProvider();
        }
    }
}
