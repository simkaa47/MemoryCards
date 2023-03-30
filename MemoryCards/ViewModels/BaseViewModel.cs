using CommunityToolkit.Mvvm.ComponentModel;

namespace MemoryCards.ViewModels
{
    public partial class BaseViewModel:ObservableObject
    {
        public BaseViewModel()
        {

        }
        [ObservableProperty]
        string _title;
        [ObservableProperty]
        string _isBusy;
    }
}
