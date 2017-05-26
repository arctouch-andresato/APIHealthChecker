using System;
using System.Collections.Generic;
using System.Diagnostics;
using APIHealthChecker.ViewModels;
using Xamarin.Forms;

namespace APIHealthChecker.Views
{
    public partial class AppsListPage : ContentPage
    {
        public AppsListPage()
        {
            try
            {
                InitializeComponent();
                //BindingContext = new AppsListViewModel();
            }
            catch(Exception ex)
            {
				Debug.WriteLine(ex.Message);
				throw;
            }
        }
    }
}
