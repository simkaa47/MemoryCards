using CommunityToolkit.Mvvm.ComponentModel;
using MemoryCards.ViewModels;

namespace MemoryCards.Models
{
    public class MemoryCard : PropertyChangedBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }
        [ObservableProperty]
        public CardState _state;
    }

    public enum CardState
    {
        Closed,
        WaitForPair,
        Opened
    }
}
