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

        private DelegateCommand<Tonic?> _keyboardCommand;
        public DelegateCommand<Tonic?> KeyboardCommand => _keyboardCommand ??= new DelegateCommand<Tonic?>(ExecuteKeyboardCommand);

        private void ExecuteKeyboardCommand(Tonic? key)
        {
            // Do something
        }
    }
}
