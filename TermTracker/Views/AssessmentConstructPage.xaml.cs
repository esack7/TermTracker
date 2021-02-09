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
    public partial class AssessmentConstructPage : ContentPage
    {
        private int CourseID;
        private Assessment SelectedAssessment;
        private AssessmentPage AssessmentPageRef;
        public AssessmentConstructPage(int courseId)
        {
            InitializeComponent();
            CourseID = courseId;
            SaveEditButton.IsVisible = false;
        }

        public AssessmentConstructPage(AssessmentPage assessmentPage, Assessment assessment)
        {
            InitializeComponent();
            CourseID = assessment.CourseId;
            AssessmentPageRef = assessmentPage;
            SelectedAssessment = assessment;
            assessmentTitle.Text = assessment.Title;
            startDateSelected.Date = assessment.StartDate;
            endDateSelected.Date = assessment.EndDate;
            typePicker.SelectedItem = assessment.Type;
            SaveButton.IsVisible = false;
        }

        private async void SaveButton_Clicked(object sender, EventArgs e)
        {
            var newAssessment = new Assessment
            {
                CourseId = CourseID,
                Title = assessmentTitle.Text,
                StartDate = startDateSelected.Date,
                EndDate = endDateSelected.Date,
                Type = typePicker.SelectedItem.ToString()
            };
            Globals.addAssessmentToAssessmentCollection(newAssessment);
            await Navigation.PopModalAsync();
        }

        private async void SaveEditButton_Clicked(object sender, EventArgs e)
        {
            var newAssessment = new Assessment
            {
                Id = SelectedAssessment.Id,
                CourseId = CourseID,
                Title = assessmentTitle.Text,
                StartDate = startDateSelected.Date,
                EndDate = endDateSelected.Date,
                Type = typePicker.SelectedItem.ToString()
            };
            Globals.updateAssessmentInAssessmentCollection(SelectedAssessment, newAssessment);
            AssessmentPageRef.SetData(newAssessment);
            await Navigation.PopModalAsync();
        }

        private async void CancelButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}