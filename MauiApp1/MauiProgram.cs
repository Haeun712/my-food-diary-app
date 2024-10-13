using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui.Maps;

namespace MauiApp1;

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
			})
            .ConfigureEssentials(essentials =>
            {
                essentials.UseMapServiceToken("Aq83c0GHHFQfuMmnLViPpXasGZV_3BM0heQwyov9aelj9R1uOtNwF6yBG3-p5gtK");
            })
            .UseMauiMaps();


#if DEBUG
        builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
