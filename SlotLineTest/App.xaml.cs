using Prism;
using Prism.Ioc;
using SlotLineTest.ViewModels;
using SlotLineTest.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Prism.DryIoc;
using Prism.Modularity;
using System;
using SlotLineTest.UserManagement;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace SlotLineTest
{
    public partial class App : PrismApplication
    {
        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("NavigationPage/AddGround");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage>();
            containerRegistry.RegisterForNavigation<BookingPage,BookingPageViewModel>();
            containerRegistry.RegisterForNavigation<AddGround>();
            containerRegistry.RegisterForNavigation<BookingList>();
            containerRegistry.RegisterForNavigation<GroundList>();
            containerRegistry.RegisterForNavigation<HomePage>();
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            Type userModule = typeof(UserModule);
            moduleCatalog.AddModule(new ModuleInfo(userModule)
            {
                ModuleName = userModule.Name,
                InitializationMode = InitializationMode.WhenAvailable
            });
        }
    }
}
