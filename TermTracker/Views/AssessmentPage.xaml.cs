using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TermTracker.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TermTracker.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AssessmentPage : ContentPage
    {
        private Assessment SelectedAssessment;
        public AssessmentPage(Assessment assessment)
        {
            InitializeComponent();
            SelectedAssessment = assessment;
            SetData(assessment);
        }

        public void SetData(Assessment assessment)
        {
            navTitle.Text = assessment.Title;
            AssessmentDateRange.Text = $"{assessment.StartDate.ToString("MM-dd-yyyy", DateTimeFormatInfo.InvariantInfo)} - {assessment.EndDate.ToString("MM-dd-yyyy", DateTimeFormatInfo.InvariantInfo)}";
            TypeSelection.Text = assessment.Type;
            notificationsEnabled.Text = assessment.EnableNotifications ? "ON" : "OFF";
        }

        private async void EditAssessment_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new AssessmentConstructPage(this, SelectedAssessment));
        }

        private async void DeleteButton_Clicked(object sender, EventArgs e)
        {
            Globals.deleteAssessmentFromAssessmentCollection(SelectedAssessment);
            await Navigation.PopAsync();
        }
    }
}