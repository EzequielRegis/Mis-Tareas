using Microsoft.Maui;

namespace TodoApp.Platforms.Android;

[Activity(Theme = "@android:style/Theme.SplashScreen", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.KeyboardHidden)]
public class MainActivity : Microsoft.Maui.Controls.PlatformApplication<Microsoft.Maui.Controls.PlatformApplication>
{
	protected override Microsoft.Maui.IPlatformApplication CreateMauiApplication() =>
		Microsoft.Maui.Controls.PlatformApplication.CreateBuilder<Microsoft.Maui.Controls.PlatformApplication>();
}
