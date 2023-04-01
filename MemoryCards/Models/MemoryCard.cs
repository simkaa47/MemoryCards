using CommunityToolkit.Mvvm.ComponentModel;
using MemoryCards.ViewModels;

namespace MemoryCards.Models
{
    public partial  class MemoryCard : PropertyChangedBase, ICloneable
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }
        [ObservableProperty]
        public CardState _state;

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }

    public enum CardState
    {
        Closed,
        WaitForPair,
        Opened
    }
}
