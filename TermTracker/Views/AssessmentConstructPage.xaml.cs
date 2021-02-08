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
        public AssessmentConstructPage(int courseId)
        {
            InitializeComponent();
            CourseID = courseId;
            SaveEditButton.IsVisible = false;
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
            
        }

        private async void CancelButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}