using CommunityToolkit.Mvvm.ComponentModel;

namespace MemoryCards.Models
{
    public partial class CardsNumberInfo:ObservableObject
    {
        [ObservableProperty]
        private string _name;

        [ObservableProperty]
        private int _rowsNum;

        [ObservableProperty]
        private int _columnsNum;

    }
}
