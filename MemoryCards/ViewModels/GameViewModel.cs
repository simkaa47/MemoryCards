using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MemoryCards.Models;
using MemoryCards.Services;
using System.Diagnostics;


namespace MemoryCards.ViewModels;

public partial class GameViewModel : PropertyChangedBase
{
    GetCardsService _getCardsService;
    GameService _gameService;
    System.Timers.Timer _gameTimer;

    [ObservableProperty]
    private GameInfo _gameInfo;

    public GameViewModel(GetCardsService getCardsService, GameService gameService)
    {
        _getCardsService = getCardsService;
        _gameService = gameService;
    }


    [RelayCommand]
    async Task StartNewGame()
    {
        if (GameInfo != null && GameInfo.IsProcessing)
        {
            if (!await Shell.Current.DisplayAlert("New game request", "Do you want to start the new game?", "OK", "Cancel")) return;
        }
        try
        {
            GameInfo = new GameInfo();
            InitTimer();
            var cards = await _getCardsService.GetCards();
            var mixed = cards.SelectMany(c => Enumerable.Range(0, 2)
            .Select(i => c.Clone() as MemoryCard))
            .ToList();
            Mix(mixed);

            GameInfo.GameCards = mixed;

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
        if (!GameInfo.IsProcessing) return;
        if (!(card is MemoryCard selectedCard)) return;
        GameInfo.SelectedCard = selectedCard;
        await _gameService.OnChangeSelectionCard(GameInfo);
        if (IsGameOver())
        {
            GameInfo.IsProcessing = false;
            _gameTimer?.Stop();
        }
    }

    private void Mix(List<MemoryCard> cards)
    {
        var random = new Random();
        for (int i = cards.Count - 1; i > 0; i--)
        {
            int j = random.Next(i + 1);
            var temp = cards[j];
            cards[j] = cards[i];
            cards[i] = temp;
        }
    }

    private bool IsGameOver()
    {
        return GameInfo.GameCards.All(c => c.State == CardState.Opened);
    }

    private void InitTimer()
    {
        _gameTimer = new System.Timers.Timer();
        _gameTimer.AutoReset = true;
        _gameTimer.Enabled = true;
        _gameTimer.Elapsed += (o, e) => OnTimerExecuting();
        _gameTimer.Interval = 1000;
        _gameTimer.Start();

    }

    private void OnTimerExecuting()
    {
        GameInfo.Time = DateTime.Now - GameInfo.timeOfStart;
    }


}
