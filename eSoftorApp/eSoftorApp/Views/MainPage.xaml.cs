using eSoftorApp.ViewModels;
using eSoftorApp.ViewModels.GaoXiao;
using eSoftorApp.ViewModels.Home;
using eSoftorApp.ViewModels.Infrastructure;
using eSoftorApp.Views.GaoXiao;
using eSoftorApp.Views.Home;
using Xamarin.Forms;

namespace eSoftorApp.Views
{
    public partial class MainPage : TabbedPage
    {
        public MainPage()
        {
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
                        //case 2:
                        //    CurrentPage = BasketView;
                        //    break;
                        //case 3:
                        //    CurrentPage = CampaignView;
                        //    break;
                }
            });


            await ((HomePageViewModel)HomePage.BindingContext).InitializeAsync(null);
            await ((GaoXiaoPageViewModel)GaoXiaoPage.BindingContext).InitializeAsync(null);
        }

        protected override async void OnCurrentPageChanged()
        {
            base.OnCurrentPageChanged();

            if (CurrentPage is HomePage)
                await (HomePage.BindingContext as ViewModelBase).InitializeAsync(null);
            if (CurrentPage is GaoXiaoPage)
                await (GaoXiaoPage.BindingContext as ViewModelBase).InitializeAsync(null);
        }
    }
}
