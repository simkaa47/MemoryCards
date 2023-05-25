using CommunityToolkit.Mvvm.ComponentModel;

namespace MemoryCards.Models
{
    public partial class GameSettings:ObservableObject 
    {
        [ObservableProperty]
        private GameMode _mode;

        
    }

    public enum GameMode
    {
        Single,
        Timer,
        Multiplayer
    }

    
}
