using MemoryCards.Models;
using MemoryCards.Services;

namespace MemoryCards.ViewModels
{
    public partial class GameSettingsViewModel:PropertyChangedBase 
    {
        public GameSettings GameSettings { get; } = new GameSettings();
        
        public List<CardsNumberInfo> CardsNumbers => GetCardsNumbers.GetNumbers();
    }
}
