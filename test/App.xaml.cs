#if ANDROID
using Microsoft.Maui.Controls.Compatibility.Platform.Android;
#endif
namespace test;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();
        SetupHandlers();
        App.Current.UserAppTheme = AppTheme.Light;

        //MainPage = new MainPage();
    }
    private void SetupHandlers()
    {

        Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping("MyCustomization", (handler, view) =>
        {
            if (view is Entry)
            {

#if IOS || MACCATALYST
                handler.PlatformView.BorderStyle = UIKit.UITextBorderStyle.None;
#elif ANDROID
                handler.PlatformView.BackgroundTintList =
                Android.Content.Res.ColorStateList.ValueOf(Colors.Transparent.ToAndroid());
#endif

            }
        });
    }
}

