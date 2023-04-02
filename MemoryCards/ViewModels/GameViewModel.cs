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
        
        public ObservableCollection<MemoryCard> GameCards { get; } = new();


        public GameViewModel(GetCardsService getCardsService)
        {
            _getCardsService = getCardsService;
        }
        [ObservableProperty]
        MemoryCard _selectedCard;


        [RelayCommand]
        async Task GetCards()
        {
            try
            {
                var cards = await _getCardsService.GetCards();

                if(GameCards.Count!=0)
                    GameCards.Clear();

                var mixed = cards.SelectMany(c => Enumerable.Range(0, 2).Select(i => c.Clone() as MemoryCard))
                    .ToList();
                Mix(mixed);

                foreach (var card in mixed)
                {
                    GameCards.Add(card);
                }

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
        public async Task OnSelectCard()
        {
            if (SelectedCard is null) return;
            if (SelectedCard.State == CardState.Closed)
                SelectedCard.State = CardState.Opened;
            else
                SelectedCard.State = CardState.Closed;
            

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
