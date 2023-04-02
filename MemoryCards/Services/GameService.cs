using MemoryCards.Models;

namespace MemoryCards.Services
{
    public class GameService
    {
        private bool isBusy;
        public GameService() { }

        public async Task OnChangeSelectionCard(IEnumerable<MemoryCard> cards, MemoryCard selectedCard)
        {
            if (isBusy)
                return;

            

            if (selectedCard is null)
                return;

            if (selectedCard.State == CardState.Opened || selectedCard.State == CardState.WaitForPair)
                return;

            var waitedCard = GetWaitedCard(cards);

            if(waitedCard is null)
            {
                selectedCard.State = CardState.WaitForPair;
                return;
            }
            else if(waitedCard.Name == selectedCard.Name)
            {
                waitedCard.State = CardState.Opened;
                selectedCard.State = CardState.Opened;
                return;
            }
            else
            {
                isBusy = true;
                selectedCard.State = CardState.Opened;
                await Task.Delay(500);
                selectedCard.State = CardState.Closed;
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
