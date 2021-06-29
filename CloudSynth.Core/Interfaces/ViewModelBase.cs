using Prism.Mvvm;
using Prism.Regions;

namespace CloudSynth.Core.Interfaces
{
    public abstract class ViewModelBase : BindableBase, INavigationAware
    {
        protected IRegionManager RegionManager { get; }

        protected ViewModelBase(IRegionManager regionManager)
        {
            RegionManager = regionManager;
        }

        public virtual bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public virtual void OnNavigatedTo(NavigationContext navigationContext)
        {
            
        }

        public virtual void OnNavigatedFrom(NavigationContext navigationContext)
        {

        }
    }
}
