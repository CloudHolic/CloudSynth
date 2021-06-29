using CloudSynth.Core;
using CloudSynth.Piano.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace CloudSynth.Piano
{
    public class PianoModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var regionManager = containerProvider.Resolve<IRegionManager>();
            regionManager.RequestNavigate(RegionNames.PianoRegion, nameof(PianoView));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<PianoView>();
        }
    }
}