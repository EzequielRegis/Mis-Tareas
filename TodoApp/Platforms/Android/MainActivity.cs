using Android.App;
using Android.Content.PM;
using Microsoft.Maui;
using Microsoft.Maui.Controls.PlatformApplication;

namespace TodoApp.Platforms.Android;

[Activity(Theme = "@android:style/Theme.SplashScreen", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.KeyboardHidden)]
public class MainActivity : PlatformApplication
{
	protected override IPlatformApplication CreateMauiApplication()
	{
		return Microsoft.Maui.Controls.PlatformApplication.PlatformApplication.CreateBuilder<App>()
			.Build();
	}
}
