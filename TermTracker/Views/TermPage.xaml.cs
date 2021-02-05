using System;
using System.Globalization;
using TermTracker.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TermTracker.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TermPage : ContentPage
    {
        public Term SelectedTerm { get; set; }
        public TermPage(Term term)
        {
            Globals.initializeCoursesCollection(term.Id);
            InitializeComponent();
            SelectedTerm = term;
            setData();
        }

        public void UpdateData(string Title, DateTime start, DateTime end)
        {
            navTitle.Text = Title;
            TermDateRange.Text = $"{start.ToString("MM-dd-yyyy", DateTimeFormatInfo.InvariantInfo)} - {end.ToString("MM-dd-yyyy", DateTimeFormatInfo.InvariantInfo)}";
        }

        private void setData()
        {
            navTitle.Text = SelectedTerm.Title;
            TermDateRange.Text = $"{SelectedTerm.StartDate.ToString("MM-dd-yyyy", DateTimeFormatInfo.InvariantInfo)} - {SelectedTerm.EndDate.ToString("MM-dd-yyyy", DateTimeFormatInfo.InvariantInfo)}";
        }

        private void AddCourse_Clicked(object sender, EventArgs e)
        {

        }

        private async void EditTerm_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new TermConstructPage(this));
        }

        private async void DeleteTerm_Clicked(object sender, EventArgs e)
        {
            Globals.deleteTermFromTermCollection(SelectedTerm);
            await Navigation.PopAsync();
        }
    }
}