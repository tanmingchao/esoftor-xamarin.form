//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

[assembly: global::Xamarin.Forms.Xaml.XamlResourceIdAttribute("eSoftorApp.Views.MainPage.xaml", "Views/MainPage.xaml", typeof(global::eSoftorApp.Views.MainPage))]

namespace eSoftorApp.Views {
    
    
    [global::Xamarin.Forms.Xaml.XamlFilePathAttribute("Views\\MainPage.xaml")]
    public partial class MainPage : global::Xamarin.Forms.TabbedPage {
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "0.0.0.0")]
        private global::eSoftorApp.Views.Home.HomePage HomePage;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "0.0.0.0")]
        private global::eSoftorApp.Views.GaoXiao.GaoXiaoPage GaoXiaoPage;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "0.0.0.0")]
        private global::eSoftorApp.Views.Search.SearchPage SearchPage;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "0.0.0.0")]
        private global::eSoftorApp.Views.Mine.MinePage MinePage;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "0.0.0.0")]
        private void InitializeComponent() {
            global::Xamarin.Forms.Xaml.Extensions.LoadFromXaml(this, typeof(MainPage));
            HomePage = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::eSoftorApp.Views.Home.HomePage>(this, "HomePage");
            GaoXiaoPage = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::eSoftorApp.Views.GaoXiao.GaoXiaoPage>(this, "GaoXiaoPage");
            SearchPage = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::eSoftorApp.Views.Search.SearchPage>(this, "SearchPage");
            MinePage = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::eSoftorApp.Views.Mine.MinePage>(this, "MinePage");
        }
    }
}