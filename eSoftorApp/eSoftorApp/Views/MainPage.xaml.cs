using eSoftorApp.ViewModels;
using eSoftorApp.ViewModels.GaoXiao;
using eSoftorApp.ViewModels.Home;
using eSoftorApp.ViewModels.Infrastructure;
using eSoftorApp.ViewModels.Mine;
using eSoftorApp.ViewModels.Search;
using eSoftorApp.Views.GaoXiao;
using eSoftorApp.Views.Home;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;

namespace eSoftorApp.Views
{
    public partial class MainPage : Xamarin.Forms.TabbedPage
    {
        public MainPage()
        {
            On<Android>().SetToolbarPlacement(ToolbarPlacement.Bottom);
            /*.SetBarItemColor(Color.DodgerBlue)*/
            ;
            //.SetBarItemColor(Color.Black)
            //.SetBarSelectedItemColor(Color.Red);

            InitializeComponent();

        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();


            MessagingCenter.Subscribe<MainPageViewModel, int>(this, MessageKeys.ChangeTab, (sender, arg) =>
            {
                switch (arg)
                {
                    case 0:
                        CurrentPage = HomePage;
                        break;
                    case 1:
                        CurrentPage = GaoXiaoPage;
                        break;
                    case 2:
                        CurrentPage = SearchPage;
                        break;
                    case 3:
                        CurrentPage = MinePage;
                        break;

                }
            });


            await ((HomePageViewModel)HomePage.BindingContext).InitializeAsync(null);
            await ((GaoXiaoPageViewModel)GaoXiaoPage.BindingContext).InitializeAsync(null);
            await ((SearchPageViewModel)SearchPage.BindingContext).InitializeAsync(null);
            await ((MinePageViewModel)MinePage.BindingContext).InitializeAsync(null);
        }

        protected override async void OnCurrentPageChanged()
        {
            base.OnCurrentPageChanged();
            Title = CurrentPage.Title;
            //if (CurrentPage is HomePage)
            //{
            //    await (HomePage.BindingContext as ViewModelBase).InitializeAsync(null);
            //}

            if (CurrentPage is GaoXiaoPage)
                await (GaoXiaoPage.BindingContext as ViewModelBase).InitializeAsync(null);

            if (CurrentPage is Search.SearchPage)
                await (SearchPage.BindingContext as ViewModelBase).InitializeAsync(null);

            if (CurrentPage is Mine.MinePage)
                await (MinePage.BindingContext as ViewModelBase).InitializeAsync(null);
        }
    }
}
