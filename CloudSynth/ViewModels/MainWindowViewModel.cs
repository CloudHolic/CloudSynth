using Prism.Mvvm;

namespace CloudSynth.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "CloudSynth";
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        public MainWindowViewModel()
        {

        }
    }
}
