using System.Windows;
using CloudSynth.Controls;
using CloudSynth.Views;
using CloudSynth.Filter;
using CloudSynth.Graph;
using CloudSynth.Piano;
using Prism.Ioc;
using Prism.Modularity;

namespace CloudSynth
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }
        
        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<FilterModule>();
            moduleCatalog.AddModule<GraphModule>();
            moduleCatalog.AddModule<PianoModule>();
        }
    }
}
