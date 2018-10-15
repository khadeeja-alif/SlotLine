using Android.App;
using Android.Content.PM;
using Android.OS;
using Com.Syncfusion.Charts;
using Prism;
using Prism.Ioc;
using Syncfusion.ListView.XForms;

namespace SlotLineTest.Droid
{
    [Activity(Label = "SlotLineTest", Icon = "@mipmap/ic_launcher", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            FFImageLoading.Forms.Platform.CachedImageRenderer.Init(enableFastRenderer:true);
            //LoadApplication(new App(new AndroidInitializer()));
            LoadApplication(UXDivers.Gorilla.Droid.Player.CreateApplication(
    this,
    new UXDivers.Gorilla.Config("Good Gorilla")
                   .RegisterAssemblyFromType<CustomPicker>()
                .RegisterAssemblyFromType<MaterialEntry>()
                  .RegisterAssemblyFromType<SfListView>()
                 .RegisterAssemblyFromType<SfChart>()
                .RegisterAssembly(typeof(SlotLineTest.App).Assembly)
    ));
        }
    }

    public class AndroidInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // Register any platform specific implementations
        }
    }
}

