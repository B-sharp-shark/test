
using MauiIcons.Material;
using Microsoft.Extensions.Logging.Abstractions;
namespace test;

public class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UsePrism(prism => {
                prism.ConfigureServices(services => {
                })
				.RegisterTypes(container =>
				{
                    container.RegisterSingleton<INoteService, NoteService>();
                    container.RegisterForNavigation<MainPage, MainPageViewModel>();
					container.RegisterForNavigation<NoteDetailPage, NoteDetailPageViewModel>();
				})
                .OnAppStart(navigation => navigation.CreateBuilder().AddSegment<MainPageViewModel>().Navigate());
            })

			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			}).UseMaterialMauiIcons(); ;


		
        return builder.Build();
	}
}

