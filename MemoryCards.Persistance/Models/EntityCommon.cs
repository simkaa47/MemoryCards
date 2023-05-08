using CommunityToolkit.Mvvm.ComponentModel;

namespace MemoryCards.Persistance.Models
{
    public partial class EntityCommon : ObservableObject
    {
        public int Id { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime LastChangedTime { get; set; }
    }        
}

