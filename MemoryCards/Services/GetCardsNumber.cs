using MemoryCards.Models;

namespace MemoryCards.Services
{
    public static class GetCardsNumbers
    {
        public static List<CardsNumberInfo> GetNumbers()
        {
            return new List<CardsNumberInfo>
            {
                new CardsNumberInfo { Name="3x4", ColumnsNum  = 3, RowsNum = 4},
                new CardsNumberInfo { Name="4x4", ColumnsNum  = 4, RowsNum = 4},
                new CardsNumberInfo { Name="4x5", ColumnsNum  = 4, RowsNum = 5},
                new CardsNumberInfo { Name="4x6", ColumnsNum  = 4, RowsNum = 6}
            };
        }
    }
}
