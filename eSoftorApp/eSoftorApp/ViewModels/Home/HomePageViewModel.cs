using eSoftorApp.ViewModels.Infrastructure;
using System.Threading.Tasks;

namespace eSoftorApp.ViewModels.Home
{
    public class HomePageViewModel : ViewModelBase
    {
        public override async Task InitializeAsync(object navigationData)
        {
            await base.InitializeAsync(navigationData);
        }
    }
}