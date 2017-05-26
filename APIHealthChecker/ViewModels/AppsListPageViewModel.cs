using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using APIHealthChecker.Models;
using APIHealthChecker.Repositories;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;

namespace APIHealthChecker.ViewModels
{
    public class AppsListPageViewModel : BindableBase, INavigationAware
    {

        private ObservableCollection<MobApp> mobApps;
        public ObservableCollection<MobApp> MobApps { get => mobApps; set => SetProperty(ref mobApps, value); }

        public DelegateCommand<MobApp> TestAppCommand { get; set; }
        public MobApp AppSelected
        {
            get => appSelected;
            set 
            {
                appSelected = value;
                RaisePropertyChanged("AppSelected");
            }
        }

        private MobApp appSelected;

        public AppsListPageViewModel(INavigationService navigationService)
        {
            TestAppCommand = new DelegateCommand<MobApp>(async (app) =>
           {
               var p = new NavigationParameters();
               p.Add("app", app.FileName);
               await navigationService.NavigateAsync("TestAppPage", p);
           });
        }

        public AppsListPageViewModel()
        {
            Debug.WriteLine("Constructed");
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
        }

        public async void OnNavigatingTo(NavigationParameters parameters)
        {
            var apps = await MobAppRepo.GetAllAppNames();

            MobApps = new ObservableCollection<MobApp>(apps);
        }
    }
}
