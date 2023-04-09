using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MemoryCards.Models;
using MemoryCards.Services;
using System.Collections.ObjectModel;
using System.Diagnostics;


namespace MemoryCards.ViewModels
{
    public partial class GameViewModel:PropertyChangedBase
    {
        GetCardsService _getCardsService;
        GameService _gameService;

        [ObservableProperty]
        public List<MemoryCard> _gameCards;


        public GameViewModel(GetCardsService getCardsService , GameService gameService)
        {
            _getCardsService = getCardsService;
            _gameService = gameService;
        }
        [ObservableProperty]
        MemoryCard _selectedCard;


        [RelayCommand]
        async Task GetCards()
        {
            try
            {
                var cards = await _getCardsService.GetCards();
                                
                var mixed = cards.SelectMany(c => Enumerable.Range(0, 2).Select(i => c.Clone() as MemoryCard))
                    .ToList();
                Mix(mixed);

                GameCards = mixed;

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                await Shell.Current.DisplayAlert("Error,", "Unable to get cards", "OK");
            }
            finally
            {

            }
        }
        [RelayCommand]
        public async Task OnSelectCard(object card)
        {
            if (!(card is MemoryCard selectedCard)) return;
            await _gameService.OnChangeSelectionCard(GameCards, selectedCard);
            

        }

        private void Mix(List<MemoryCard> cards)
        {
            var random = new Random();
            for (int i = cards.Count-1; i > 0; i--)
            {
                int j = random.Next(i+1);
                var temp = cards[j];
                cards[j] = cards[i];
                cards[i] = temp;
            }
        }
    }
}
