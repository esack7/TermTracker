using System;
using System.Linq;
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
            notificationSwitch.IsToggled = assessment.EnableNotifications;
            SaveButton.IsVisible = false;
        }

        private async void SaveButton_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (assessmentTitle.Text == null || assessmentTitle.Text == "")
                {
                    throw new Exception("You must have an Assessment Title");
                }

                if (new DateTime(startDateSelected.Date.Year, startDateSelected.Date.Month, startDateSelected.Date.Day) > new DateTime(endDateSelected.Date.Year, endDateSelected.Date.Month, endDateSelected.Date.Day))
                {
                    throw new Exception("The start date cannot be after the end date");
                }

                if (typePicker.SelectedItem == null)
                {
                    throw new Exception("You must pick an Assessment Type");
                }
                
                if(Globals.Assessments.Any())
                {
                    if (Globals.Assessments.First().Type == typePicker.SelectedItem.ToString())
                    {
                        throw new Exception("You cannot have two assessments of the same type");
                    }
                }

                var newAssessment = new Assessment
                {
                    CourseId = CourseID,
                    Title = assessmentTitle.Text,
                    StartDate = startDateSelected.Date,
                    EndDate = endDateSelected.Date,
                    Type = typePicker.SelectedItem.ToString(),
                    EnableNotifications = notificationSwitch.IsToggled
                };
                Globals.addAssessmentToAssessmentCollection(newAssessment);
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
                if (assessmentTitle.Text == "")
                {
                    throw new Exception("You must have an Assessment Title");
                }

                if (new DateTime(startDateSelected.Date.Year, startDateSelected.Date.Month, startDateSelected.Date.Day) > new DateTime(endDateSelected.Date.Year, endDateSelected.Date.Month, endDateSelected.Date.Day))
                {
                    throw new Exception("The start date cannot be after the end date");
                }

                if (Globals.Assessments.Where(test => test.Id != SelectedAssessment.Id).First().Type == typePicker.SelectedItem.ToString())
                {
                    throw new Exception("You cannot have two assessments of the same type");
                }

                var newAssessment = new Assessment
                {
                    Id = SelectedAssessment.Id,
                    CourseId = CourseID,
                    Title = assessmentTitle.Text,
                    StartDate = startDateSelected.Date,
                    EndDate = endDateSelected.Date,
                    Type = typePicker.SelectedItem.ToString(),
                    EnableNotifications = notificationSwitch.IsToggled
                };
                Globals.updateAssessmentInAssessmentCollection(SelectedAssessment, newAssessment);
                AssessmentPageRef.SetData(newAssessment);
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