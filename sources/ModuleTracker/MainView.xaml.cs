using System.Windows;
using Microsoft.Extensions.DependencyInjection;

namespace ModuleTracker

{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : Window
    {
        public MainView()
        {
            InitializeComponent();

            DataContext = App.Current.Services.GetService<MainViewModel>();
        }
    }
}
