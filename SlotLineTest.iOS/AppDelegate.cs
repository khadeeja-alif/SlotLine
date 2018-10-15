﻿using Foundation;
using PanCardView.iOS;
using Prism;
using Prism.Ioc;
using Syncfusion.ListView.XForms;
using Syncfusion.ListView.XForms.iOS;
using Syncfusion.SfChart.XForms;
using UIKit;


namespace SlotLineTest.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();
            CardsViewRenderer.Preserve();
            SfListViewRenderer.Init();
            FFImageLoading.Forms.Platform.CachedImageRenderer.Init();
            Syncfusion.SfChart.XForms.iOS.Renderers.SfChartRenderer.Init();
            //LoadApplication(new App(new iOSInitializer()));
            LoadApplication(UXDivers.Gorilla.iOS.Player.CreateApplication(
  new UXDivers.Gorilla.Config("Good Gorilla")
                .RegisterAssemblyFromType<CustomPicker>()
                .RegisterAssemblyFromType<MaterialEntry>()
                   .RegisterAssemblyFromType<SfListView>()
                .RegisterAssemblyFromType<SfChart>()
                .RegisterAssembly(typeof(SlotLineTest.App).Assembly)
    ));
            return base.FinishedLaunching(app, options);
        }
    }

    public class iOSInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // Register any platform specific implementations
        }
    }
}
