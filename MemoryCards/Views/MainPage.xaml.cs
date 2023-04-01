using MemoryCards.ViewModels;

namespace MemoryCards.Views;

public partial class MainPage : ContentPage
{
	public MainPage(GameViewModel gameViewModel)
	{
		InitializeComponent();
		this.BindingContext= gameViewModel;

	}
}