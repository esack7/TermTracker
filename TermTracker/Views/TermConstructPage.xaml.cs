using System;
using TermTracker.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TermTracker.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TermConstructPage : ContentPage
    {
        private TermPage TermPage;
        public TermConstructPage()
        {
            InitializeComponent();
            SaveEditButton.IsVisible = false;
        }

        public TermConstructPage(TermPage termPage)
        {
            InitializeComponent();
            TermPage = termPage;
            termTitle.Text = termPage.SelectedTerm.Title;
            startDateSelected.Date = termPage.SelectedTerm.StartDate;
            endDateSelected.Date = termPage.SelectedTerm.EndDate;
            SaveButton.IsVisible = false;
        }

        private async void SaveButton_Clicked(object sender, EventArgs e)
        {
            try
            {
                if(termTitle.Text == null || termTitle.Text == "")
                {
                    throw new Exception("You must have Term Title");
                }

                //TODO: validate that start date is not after end date

                var newTerm = new Term { Title = termTitle.Text, StartDate = startDateSelected.Date, EndDate = endDateSelected.Date };
                Globals.addTermToTermCollection(newTerm);
                await Navigation.PopModalAsync();
            }
            catch (Exception error)
            {
                await DisplayAlert("Alert", $"{error.Message}", "OK");
            }
        }

        private async void SaveEditButton_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (termTitle.Text == "")
                {
                    throw new Exception("You must have Term Title");
                }
                var termPage = TermPage;
                var newTerm = new Term { Id = termPage.SelectedTerm.Id, Title = termTitle.Text, StartDate = startDateSelected.Date, EndDate = endDateSelected.Date };
                Globals.updateTermInTermCollection(termPage.SelectedTerm, newTerm);
                termPage.SetData(newTerm);
                await Navigation.PopModalAsync();
            }
            catch (Exception error)
            {
                await DisplayAlert("Alert", $"{error.Message}", "OK");
            }
        }

        private async void CancelButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}