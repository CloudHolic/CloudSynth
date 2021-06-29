using CloudSynth.Core.Interfaces;
using Prism.Regions;

namespace CloudSynth.Piano.ViewModels
{
    public class PianoViewModel : ViewModelBase
    {
        private string _message;
        public string Message
        {
            get => _message;
            set => SetProperty(ref _message, value);
        }

        public PianoViewModel(IRegionManager regionManager) : base(regionManager)
        {
            Message = "Piano View";
        }
    }
}
