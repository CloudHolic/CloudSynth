using System;
using CloudSynth.Core.Interfaces;
using LiveCharts;
using LiveCharts.Defaults;
using Prism.Regions;

namespace CloudSynth.Graph.ViewModels
{
    public class GraphViewModel : ViewModelBase
    {
        private ChartValues<ObservablePoint> _sineWaves;
        private const double AxisGap = 0.01; 
        public ChartValues<ObservablePoint> SineWaves
        {
            get => _sineWaves;
            set => SetProperty(ref _sineWaves, value);
        }

        public GraphViewModel(IRegionManager regionManager) : base(regionManager)
        {
            SineWaves = new ChartValues<ObservablePoint>();
            for (double i = -1; i < 1 + AxisGap; i += AxisGap)
                SineWaves.Add(new ObservablePoint(i, Math.Sin(i * Math.PI)));
        }
    }
}
