using CloudSynth.Core.Interfaces;
using CloudSynth.Piano.Controls;
using Prism.Commands;
using Prism.Regions;

namespace CloudSynth.Piano.ViewModels
{
    internal class PianoViewModel : ViewModelBase
    {
        #region Properties

        private int _octave;
        public int Octave
        {
            get => _octave;
            set => SetProperty(ref _octave, value);
        }

        #endregion

        public PianoViewModel(IRegionManager regionManager) : base(regionManager)
        {
            Octave = 1;
        }

        #region OctaveCommand

        private DelegateCommand<string> _octaveCommand;
        public DelegateCommand<string> OctaveCommand => _octaveCommand ??= new DelegateCommand<string>(ExecuteOctaveCommand);

        private void ExecuteOctaveCommand(string parameter)
        {
            if (parameter == "+")
                Octave++;
            else if(parameter == "-")
                Octave--;
        }

        #endregion
        
        #region PlayCommand

        private DelegateCommand<PianoCommandParameter> _playCommand;
        public DelegateCommand<PianoCommandParameter> PlayCommand => _playCommand ??= new DelegateCommand<PianoCommandParameter>(ExecutePlayCommand);

        private void ExecutePlayCommand(PianoCommandParameter parameter)
        {
            // Do something
        }

        #endregion

        #region StopCommand

        private DelegateCommand<PianoCommandParameter> _stopCommand;
        public DelegateCommand<PianoCommandParameter> StopCommand => _stopCommand ??= new DelegateCommand<PianoCommandParameter>(ExecuteStopCommand);

        private void ExecuteStopCommand(PianoCommandParameter key)
        {
            // Do something
        }

        #endregion
    }
}
