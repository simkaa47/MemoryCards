using MemoryCards.Models;

namespace MemoryCards.Services
{
    public class GameService
    {
        private bool isBusy;
        public GameService() { }

        public async Task OnChangeSelectionCard(GameInfo game)
        {
            if (isBusy)
                return;            

            if (game.SelectedCard is null)
                return;

            if (game.SelectedCard.State == CardState.Opened || game.SelectedCard.State == CardState.WaitForPair)
                return;

            var waitedCard = GetWaitedCard(game.GameCards);

            if(waitedCard is null)
            {
                game.SelectedCard.State = CardState.WaitForPair;
                return;
            }
            else if(waitedCard.Name == game.SelectedCard.Name)
            {
                waitedCard.State = CardState.Opened;
                game.SelectedCard.State = CardState.Opened;
                game.Serial++;
                var points = 60 - game.Time.TotalSeconds;
                points = points > 0 ? points : 1;
                game.Points += (int)(points * Math.Pow(2, game.Serial-1));
                return;
            }
            else
            {
                game.Serial = 0;
                isBusy = true;
                game.SelectedCard.State = CardState.Opened;
                await Task.Delay(500);
                game.SelectedCard.State = CardState.Closed;
                waitedCard.State = CardState.Closed;
            }

            isBusy = false;
        }



        private MemoryCard GetWaitedCard(IEnumerable<MemoryCard> cards)
        {
            return cards.Where(c=>c.State == CardState.WaitForPair).FirstOrDefault();
        }
        
    }
}
