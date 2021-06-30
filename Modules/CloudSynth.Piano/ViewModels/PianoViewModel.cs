using CloudSynth.Core.Interfaces;
using CloudSynth.Core.Models;
using Prism.Commands;
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
            
        }

        #region PlayCommand

        private DelegateCommand<Tonic?> _playCommand;
        public DelegateCommand<Tonic?> PlayCommand => _playCommand ??= new DelegateCommand<Tonic?>(ExecutePlayCommand);

        private void ExecutePlayCommand(Tonic? key)
        {
            // Do something
        }

        #endregion

        #region StopCommand

        private DelegateCommand<Tonic?> _stopCommand;
        public DelegateCommand<Tonic?> StopCommand => _stopCommand ??= new DelegateCommand<Tonic?>(ExecuteStopCommand);

        private void ExecuteStopCommand(Tonic? key)
        {
            // Do something
        }

        #endregion
    }
}
