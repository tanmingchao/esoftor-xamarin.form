//  <copyright file="ViewModelLocator.cs" company="ESoftor">
//      Copyright (c) 2014-2015 ESoftor. All rights reserved.
//  </copyright>
//  <last-editor>谭明超</last-editor>
//  <last-date>2019/3/7 9:18:01</last-date>

namespace eSoftorApp.ViewModels.Infrastructure
{
    using eSoftorApp.Services.Navigation;
    using eSoftorApp.ViewModels.GaoXiao;
    using eSoftorApp.ViewModels.Home;
    using eSoftorApp.ViewModels.Mine;
    using eSoftorApp.ViewModels.Search;
    using System;
    using System.Globalization;
    using System.Reflection;
    using TinyIoC;
    using Xamarin.Forms;

    /// <summary>
    /// Defines the <see cref="ViewModelLocator" />
    /// </summary>
    public static class ViewModelLocator
    {
        /// <summary>
        /// Defines the _container
        /// </summary>
        private static TinyIoCContainer _container;

        /// <summary>
        /// 所有xaml的view页面xmns部分 加入 viewModelBase:ViewModelLocator.AutoWireViewModel="true" 即可，便可以自动将ViewModel绑定到xaml的view
        ///
        /// </summary>
        public static readonly BindableProperty AutoWireViewModelProperty =
            BindableProperty.CreateAttached("AutoWireViewModel", typeof(bool), typeof(ViewModelLocator), default(bool), propertyChanged: OnAutoWireViewModelChanged);

        /// <summary>
        /// The GetAutoWireViewModel
        /// </summary>
        /// <param name="bindable">The bindable<see cref="BindableObject"/></param>
        /// <returns>The <see cref="bool"/></returns>
        public static bool GetAutoWireViewModel(BindableObject bindable)
        {
            return (bool)bindable.GetValue(ViewModelLocator.AutoWireViewModelProperty);
        }

        /// <summary>
        /// The SetAutoWireViewModel
        /// </summary>
        /// <param name="bindable">The bindable<see cref="BindableObject"/></param>
        /// <param name="value">The value<see cref="bool"/></param>
        public static void SetAutoWireViewModel(BindableObject bindable, bool value)
        {
            bindable.SetValue(ViewModelLocator.AutoWireViewModelProperty, value);
        }

        /// <summary>
        /// Initializes static members of the <see cref="ViewModelLocator"/> class.
        /// </summary>
        static ViewModelLocator()
        {
            _container = new TinyIoCContainer();
            //在以下加入注入的 ViewModel对象 以及所有的 service对象
            //_container.Register<SampleViewModel>();
            //_container.Register<ISampleService, SampleService>();
            //viewModes
            _container.Register<MainPageViewModel>();
            _container.Register<HomePageViewModel>();
            _container.Register<GaoXiaoPageViewModel>();
            _container.Register<SearchPageViewModel>();
            _container.Register<MinePageViewModel>();

            //services
            _container.Register<INavigationService, NavigationService>();
        }

        /// <summary>
        /// The RegisterSingleton
        /// </summary>
        /// <typeparam name="TInterface"></typeparam>
        /// <typeparam name="T"></typeparam>
        public static void RegisterSingleton<TInterface, T>() where TInterface : class where T : class, TInterface
        {
            _container.Register<TInterface, T>().AsSingleton();
        }

        /// <summary>
        /// The Resolve
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>The <see cref="T"/></returns>
        public static T Resolve<T>() where T : class
        {
            return _container.Resolve<T>();
        }

        /// <summary>
        /// The OnAutoWireViewModelChanged
        /// </summary>
        /// <param name="bindable">The bindable<see cref="BindableObject"/></param>
        /// <param name="oldValue">The oldValue<see cref="object"/></param>
        /// <param name="newValue">The newValue<see cref="object"/></param>
        private static void OnAutoWireViewModelChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var view = bindable as Element;
            if (view == null)
            {
                return;
            }

            //TODO 这里需要注意的是 viewModels的创建命名一定要和Views中的View.xaml名称对应 
            // 比如：ViewModels.Home.HomePageViewModel 对应 Views.Home.HomePage.xaml(.cs) 其中HomePage部分的字符是一致的，否则下方的替换在 getType()是否无法正常运行
            var viewType = view.GetType();
            var viewName = viewType.FullName.Replace(".Views.", ".ViewModels.");
            var viewAssemblyName = viewType.GetTypeInfo().Assembly.FullName;
            var viewModelName = string.Format(CultureInfo.InvariantCulture, "{0}ViewModel, {1}", viewName, viewAssemblyName);

            var viewModelType = Type.GetType(viewModelName);
            if (viewModelType == null)
            {
                return;
            }
            var viewModel = _container.Resolve(viewModelType);
            view.BindingContext = viewModel;
        }
    }
}
