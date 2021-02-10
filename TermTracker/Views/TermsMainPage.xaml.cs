using Plugin.LocalNotifications;
using System;
using TermTracker.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TermTracker.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TermsMainPage : ContentPage
    {
        public TermsMainPage()
        {
            Globals.initializeTermsCollection();
            InitializeComponent();
        }

        private async void AddTerm_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new TermConstructPage());
        }

        private async void Term_Clicked(object sender, EventArgs e)
        {
            var layout = (BindableObject)sender;
            var term = (Term)layout.BindingContext;
            await Navigation.PushAsync(new TermPage(term));
        }
    }
}