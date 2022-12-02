using Calculator.Data;
using Calculator.Views;

namespace Calculator;

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

        builder.Services.AddSingleton<HistoryPage>();
        builder.Services.AddTransient<MainPage>();
        builder.Services.AddTransient<AdvanceCalc>();

        builder.Services.AddSingleton<HistoryDatabase>();

        return builder.Build();
	}
}
