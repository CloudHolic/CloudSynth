using CloudSynth.Core.Interfaces;
using Prism.Regions;

namespace CloudSynth.Graph.ViewModels
{
    public class GraphViewModel : ViewModelBase
    {
        private string _message;
        public string Message
        {
            get => _message;
            set => SetProperty(ref _message, value);
        }

        public GraphViewModel(IRegionManager regionManager) : base(regionManager)
        {
            Message = "Graph View";
        }
    }
}
