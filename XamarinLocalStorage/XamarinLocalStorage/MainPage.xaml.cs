using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace XamarinLocalStorage
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = ViewModel;
        }

        private MainViewModel ViewModel { get; } = new MainViewModel();

        private void NavigateToDirectoryListing(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ListDirectoriesPage());
        }
    }
}
