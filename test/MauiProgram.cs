
using MauiIcons.Material;
using test.Main.Naigation;
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
                    services.RegisterForNavigation<MainPage, MainPageViewModel>("MainPageViewModel");
                    services.RegisterForNavigation<NoteDetailPage, NoteDetailPageViewModel>();
                    services.RegisterForNavigation<TabChild, TabChildViewModel>();
					services.AddSingleton<INoteService, NoteService>();
					services.AddSingleton<INavService, MyNavService>();
                })
				.RegisterTypes(container =>
				{
                    
                })
                //.OnAppStart(navigation => navigation.CreateBuilder().AddSegment<MainPageViewModel>().Navigate());
                .OnAppStart(navigation => navigation.CreateBuilder().AddTabbedSegment(b =>
                        b.CreateTab(t => t.AddSegment<MainPageViewModel>())
						 ).Navigate());


            })

			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			}).UseMaterialMauiIcons(); ;


		
        return builder.Build();
	}
}

