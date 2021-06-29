using CloudSynth.Core;
using CloudSynth.Graph.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace CloudSynth.Graph
{
    public class GraphModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var regionManager = containerProvider.Resolve<IRegionManager>();
            regionManager.RequestNavigate(RegionNames.GraphRegion, nameof(GraphView));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<GraphView>();
        }
    }
}