using CloudSynth.Core.Interfaces;
using CloudSynth.Core.Models;
using Prism.Regions;

namespace CloudSynth.Graph.ViewModels
{
    public class GraphViewModel : ViewModelBase
    {
        private Series _currentSeries;
        public Series CurrentSeries
        {
            get => _currentSeries;
            set => SetProperty(ref _currentSeries, value);
        }

        public GraphViewModel(IRegionManager regionManager) : base(regionManager)
        {
            CurrentSeries = Series.Sine;
        }
    }
}
