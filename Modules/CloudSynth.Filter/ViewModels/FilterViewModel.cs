using CloudSynth.Core.Interfaces;
using Prism.Regions;

namespace CloudSynth.Filter.ViewModels
{
    public class FilterViewModel : ViewModelBase
    {
        private string _message;
        public string Message
        {
            get => _message;
            set => SetProperty(ref _message, value);
        }

        public FilterViewModel(IRegionManager regionManager) : base(regionManager)
        {
            Message = "Filter View";
        }
    }
}
