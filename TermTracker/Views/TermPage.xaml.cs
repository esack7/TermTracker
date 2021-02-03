using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TermTracker.Models;
using TermTracker.Database;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TermTracker.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TermPage : ContentPage
    {
        private ObservableCollection<Course> courses = new ObservableCollection<Course>();
        private TermsMainPage MainPage;
        public ObservableCollection<Course> Courses { get { return courses; } }
        public Term SelectedTerm { get; set; }
        public TermPage(Term term, TermsMainPage mainPage)
        {
            InitializeComponent();
            SelectedTerm = term;
            MainPage = mainPage;
            setData();
            BindingContext = this;
        }

        private void setData()
        {
            TermDateRange.Text = $"{SelectedTerm.StartDate.ToString("MM-dd-yyyy", DateTimeFormatInfo.InvariantInfo)} - {SelectedTerm.EndDate.ToString("MM-dd-yyyy", DateTimeFormatInfo.InvariantInfo)}";
            courses = getCoursesFromDb(SelectedTerm.Id);
        }

        private ObservableCollection<Course> getCoursesFromDb(int termId)
        {
            var database = new SqliteDataService();
            database.Initialize();
            var list = database.GetCourseByTermId(termId);
            return new ObservableCollection<Course>(list);
        }

        private void AddCourse_Clicked(object sender, EventArgs e)
        {

        }

        private void EditTerm_Clicked(object sender, EventArgs e)
        {

        }

        private async void DeleteTerm_Clicked(object sender, EventArgs e)
        {
            var database = new SqliteDataService();
            database.Initialize();
            database.DeleteTerm(SelectedTerm);
            MainPage.deleteFromTermsList(SelectedTerm);
            await Navigation.PopAsync();
        }
    }
}