using CommunityToolkit.Mvvm.ComponentModel;
using MemoryCards.ViewModels;

namespace MemoryCards.Models
{
    public partial class GameInfo : PropertyChangedBase
    {
        public GameInfo()
        {
            timeOfStart = DateTime.Now;
        }

        [ObservableProperty]
        private int _points;
        [ObservableProperty]
        private int _serial;
        [ObservableProperty]
        private List<MemoryCard> _gameCards;
        [ObservableProperty]
        MemoryCard _selectedCard;
        [ObservableProperty]
        private bool _isProcessing = true;
        [ObservableProperty]
        private TimeSpan _time;

        public DateTime timeOfStart;

    }

    
}
