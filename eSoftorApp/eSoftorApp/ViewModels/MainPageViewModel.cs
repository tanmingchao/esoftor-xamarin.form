using eSoftorApp.Services.Navigation;
using eSoftorApp.ViewModels.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace eSoftorApp.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        //public ICommand SettingsCommand => new Command(async () => await SettingsAsync());

        public override Task InitializeAsync(object navigationData)
        {
            //IsBusy = true;

            //if (navigationData is TabParameter)
            //{
            //    // Change selected application tab
            //    var tabIndex = ((TabParameter)navigationData).TabIndex;
            //    MessagingCenter.Send(this, MessageKeys.ChangeTab, tabIndex);
            //}

            //return base.InitializeAsync(navigationData);
            

            return base.InitializeAsync(navigationData);
        }

        //private async Task SettingsAsync()
        //{
        //    await NavigationService.NavigateToAsync<SettingsViewModel>();
        //}
    }
}
