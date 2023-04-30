using CommunityToolkit.Mvvm.ComponentModel;
using MemoryCards.DataAccess;

namespace MemoryCards.Models
{
    public enum MemoryCardGameType
    {
        SingleSimple,
        SingleTimer,
        Multiplayer
        
    }

    public partial  class GameCommonSettings:EntityCommon
    {
        [ObservableProperty]
        private MemoryCardGameType _gameType;
        [ObservableProperty]
        private int _avialableLevel;
        
    }
}
