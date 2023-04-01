using MemoryCards.Models;
using System.Text.Json;

namespace MemoryCards.Services
{
    public class GetCardsService
    {
        public GetCardsService()
        {

        }

        List<MemoryCard> _cards= new List<MemoryCard>();

        public async Task<List<MemoryCard>> GetCards()
        {
            
            using var stream = await FileSystem.OpenAppPackageFileAsync("cards.json");
            using var reader = new StreamReader(stream);
            var contents = await reader.ReadToEndAsync();
            _cards = JsonSerializer.Deserialize<List<MemoryCard>>(contents);

            return _cards;
        }
    }
}
