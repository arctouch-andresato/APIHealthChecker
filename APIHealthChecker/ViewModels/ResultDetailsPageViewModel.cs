using System;
using APIHealthChecker.Models;
using Prism.Mvvm;
using Prism.Navigation;

namespace APIHealthChecker.ViewModels
{
    public class ResultDetailsPageViewModel : BindableBase, INavigationAware
    {
        private TestResult result;
        public TestResult Result
        {
            get => result;
            set
            {
                result = value;
                RaisePropertyChanged("Result");
            }
        }

        public ResultDetailsPageViewModel()
		{
		}

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {
            Result = parameters.GetValue<TestResult>("testResult");
        }
    }
}
