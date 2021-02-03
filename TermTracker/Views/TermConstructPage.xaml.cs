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
        private TermPage TermPage;
        public TermConstructPage(TermsMainPage mainPage)
        {
            InitializeComponent();
            MainPage = mainPage;
            SaveEditButton.IsVisible = false;
        }

        public TermConstructPage(TermsMainPage mainPage, TermPage termPage)
        {
            InitializeComponent();
            MainPage = mainPage;
            this.TermPage = termPage;
            termTitle.Text = termPage.SelectedTerm.Title;
            startDateSelected.Date = termPage.SelectedTerm.StartDate;
            endDateSelected.Date = termPage.SelectedTerm.EndDate;
            SaveButton.IsVisible = false;
        }

        private async void SaveButton_Clicked(object sender, EventArgs e)
        {
            var db = new SqliteDataService();
            db.Initialize();
            var newTerm = new Term { Title = termTitle.Text, StartDate = startDateSelected.Date, EndDate = endDateSelected.Date };
            db.AddTerm(newTerm);
            MainPage.addToTermsList(newTerm);
            await Navigation.PopModalAsync();
        }

        private async void SaveEditButton_Clicked(object sender, EventArgs e)
        {
            var termPage = this.TermPage;
            termPage.UpdateData(termTitle.Text, startDateSelected.Date, endDateSelected.Date);
            var newTerm = new Term { Id = termPage.SelectedTerm.Id, Title = termTitle.Text, StartDate = startDateSelected.Date, EndDate = endDateSelected.Date };
            var db = new SqliteDataService();
            db.Initialize();
            db.UpdateTerm(newTerm);
            MainPage.updateTermInTermList(termPage.SelectedTerm, newTerm);
            await Navigation.PopModalAsync();
        }

        private async void CancelButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}