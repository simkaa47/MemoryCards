using MemoryCards.ViewModels;

namespace MemoryCards.DataAccess
{
    public class EntityCommon:PropertyChangedBase
    {
        public int Id { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime LastChangedTime { get; set; }
    }
}
