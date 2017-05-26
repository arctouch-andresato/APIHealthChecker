using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using APIHealthChecker.Models;
using APIHealthChecker.Repositories;
using APIHealthChecker.Services;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;

namespace APIHealthChecker.ViewModels
{
    public class TestAppPageViewModel : BindableBase, INavigationAware
    {
        private ObservableCollection<TestResult> results;
        public ObservableCollection<TestResult> Results { get => results; set => SetProperty(ref results, value); }
        private string appName;
        public string AppName
        {
            get => appName;
            set
            {
                appName = value;
                RaisePropertyChanged("AppName");
            }
        }

		private bool showLoadingIcon;
        public bool ShowLoadingIcon
        {
            get => showLoadingIcon; 
            set 
            { 
                showLoadingIcon = value; 
                RaisePropertyChanged("ShowLoadingIcon");
            }
        }

        public DelegateCommand<TestResult> GoToResultDetailCommand { get; set; }

        public TestAppPageViewModel(INavigationService navigationService)
        {
            GoToResultDetailCommand = new DelegateCommand<TestResult>(async (testResult) =>
		   {
			   var p = new NavigationParameters();
			   p.Add("testResult", testResult);
			   await navigationService.NavigateAsync("ResultDetailsPage", p);
		   });
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
        }

        public async void OnNavigatingTo(NavigationParameters parameters)
        {
            try
            {
                ShowLoadingIcon = true;
                AppName = parameters.GetValue<string>("app");
                var app = await MobAppRepo.GetMobApp(AppName);
                if (app != null)
                {
                    Results = new ObservableCollection<TestResult>(await EndPointTestService.TestAllAppEndPoints(app));
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            finally
            {
                ShowLoadingIcon = false;
            }
        }
    }
}
