using CommunityToolkit.Mvvm.ComponentModel;

namespace MemoryCards.Models
{
    public partial class GameSettings:ObservableObject 
    {
        [ObservableProperty]
        private GameMode _mode;
        [ObservableProperty]
        CardsNumberInfo _cardsNumberInfo;
        
    }

    public enum GameMode
    {
        Single,
        Timer,
        Multiplayer
    }

    
}
