using CloudSynth.Core;
using CloudSynth.Filter.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace CloudSynth.Filter
{
    public class FilterModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var regionManager = containerProvider.Resolve<IRegionManager>();
            regionManager.RequestNavigate(RegionNames.FilterRegion, nameof(FilterView));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<FilterView>();
        }
    }
}