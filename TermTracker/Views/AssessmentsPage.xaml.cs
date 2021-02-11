using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TermTracker.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TermTracker.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AssessmentsPage : ContentPage
    {
        public Course SelectedCourse { get; set; }
        public AssessmentsPage(Course course)
        {
            Globals.initializeAssessmentCollection(course.Id);
            InitializeComponent();
            SelectedCourse = course;
            navTitle.Text = $"{course.Title} Assessments";
        }

        private async void AddAssessment_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (Globals.Assessments.Count >= 2)
                {
                    throw new Exception("You cannot add more than 2 assessments to a course");
                }
                await Navigation.PushModalAsync(new AssessmentConstructPage(SelectedCourse.Id));
            }
            catch (Exception error)
            {
                await DisplayAlert("Alert", $"{error.Message}", "OK");
            }
        }

        private async void Assessment_Clicked(object sender, EventArgs e)
        {
            var layout = (BindableObject)sender;
            var assessment = (Assessment)layout.BindingContext;
            await Navigation.PushAsync(new AssessmentPage(assessment));
        }
    }
}