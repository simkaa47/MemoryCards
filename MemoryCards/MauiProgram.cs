namespace MemoryCards;

using MemoryCards.DataAccess;
using MemoryCards.Services;
using MemoryCards.ViewModels;
using MemoryCards.Views;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

#if DEBUG
		builder.Services.AddLogging(logging => 
		{
			logging.AddDebug();
		});
#endif
		builder.Services.AddSingleton<MainPage>();
		builder.Services.AddSingleton<GetCardsService>();
		builder.Services.AddSingleton<GameService>();
		builder.Services.AddSingleton<GameViewModel>();
		builder.Services.AddDbContext<ApplicationContext>();

        return builder.Build();
	}
}
