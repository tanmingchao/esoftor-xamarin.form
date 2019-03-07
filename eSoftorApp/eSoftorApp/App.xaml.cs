using eSoftorApp.Services.Navigation;
using eSoftorApp.ViewModels.Infrastructure;
using eSoftorApp.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace eSoftorApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new MainPage();

        }

        protected override void OnStart()
        {
            // Handle when your app starts
            base.OnStart();
            if (Device.RuntimePlatform != Device.UWP)
                InitNavigation();

            // :TODO 其他操作，如初始化当前地理位置


            base.OnResume();
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        #region private
        void InitNavigation()
        {
            var navigationService = ViewModelLocator.Resolve<INavigationService>();
            navigationService.InitializeAsync();
        }
        #endregion
    }
}
