
using Microsoft.Extensions.Logging.Abstractions;
namespace test;

public class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>();
		builder
			.UsePrism(prism => {
				prism.RegisterTypes(container =>
				{
					container.RegisterForNavigation<MainPage, MainPageViewModel>();
				});
                //.OnAppStart(navigation => navigation.CreateBuilder().AddSegment<MainPageViewModel>().Navigate());
            })

			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});


		
        return builder.Build();
	}
}

