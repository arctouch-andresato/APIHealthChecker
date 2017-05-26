using System;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using APIHealthChecker.Views;
using Autofac;
using Prism.Autofac;
using Prism.Autofac.Forms;
using Prism.Mvvm;
using Xamarin.Forms;

namespace APIHealthChecker
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null) : base(initializer) { }

        protected override void OnInitialized()
        {
            InitializeComponent();

			try
			{
				NavigationService.NavigateAsync("NavigationPage/AppsListPage");
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.Message);
				throw;
			}
        }

        protected override void RegisterTypes()
        {
            Container.RegisterTypeForNavigation<NavigationPage>();
            Container.RegisterTypeForNavigation<AppsListPage>();
            Container.RegisterTypeForNavigation<TestAppPage>();
            Container.RegisterTypeForNavigation<ResultDetailsPage>();
        }

    }
}
