using Android.App;
using Android.Content.PM;
using Android.OS;

namespace XamarinLocalStorage.Droid
{
    [Activity(Label = "XamarinLocalStorage", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
            var gnabber = Application.Context.CacheDir.AbsolutePath;
            var sdCardPath = Environment.ExternalStorageDirectory.AbsolutePath;
        }
    }
}