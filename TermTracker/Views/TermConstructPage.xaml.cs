using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TermTracker.Database;
using TermTracker.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TermTracker.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TermConstructPage : ContentPage
    {
        private TermsMainPage MainPage;
        public TermConstructPage(TermsMainPage mainPage)
        {
            InitializeComponent();
            MainPage = mainPage;
        }

        private async void SaveButton_Clicked(object sender, EventArgs e)
        {
            var db = new SqliteDataService();
            db.Initialize();
            var newTerm = new Term { Title = $"{termTitle.Text}", StartDate = startDateSelected.Date, EndDate = endDateSelected.Date };
            db.AddTerm(newTerm);
            MainPage.addToTermsList(newTerm);
            await Navigation.PopModalAsync();
        }

        private async void CancelButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}