using CloudSynth.Core.Interfaces;
using LiveCharts;
using Prism.Regions;

namespace CloudSynth.Graph.ViewModels
{
    public class GraphViewModel : ViewModelBase
    {
        private ChartValues<double> _values1;
        public ChartValues<double> Values1
        {
            get => _values1;
            set => SetProperty(ref _values1, value);
        }

        public GraphViewModel(IRegionManager regionManager) : base(regionManager)
        {
            Values1 = new ChartValues<double> {1, 2, 3, 4, 5};
        }
    }
}
