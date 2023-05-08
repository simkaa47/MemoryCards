using CommunityToolkit.Mvvm.ComponentModel;

namespace MemoryCards.Persistance.Models
{
    public enum MemoryCardGameType
    {
        SingleSimple,
        SingleTimer,
        Multiplayer

    }

    public partial class GameCommonSettings : EntityCommon
    {
        [ObservableProperty]
        private MemoryCardGameType _gameType;
        [ObservableProperty]
        private int _avialableLevel;

    }
}
