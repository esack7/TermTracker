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
    public partial class CourseConstructPage : ContentPage
    {
        private int TermID;
        public CourseConstructPage(int termId)
        {
            InitializeComponent();
            TermID = termId;
            SaveEditButton.IsVisible = false;
        }

        private async void SaveButton_Clicked(object sender, EventArgs e)
        {
            var newCourse = new Course
            {
                TermId = TermID,
                Title = courseTitle.Text,
                StartDate = startDateSelected.Date,
                EndDate = endDateSelected.Date,
                Status = statusPicker.SelectedItem.ToString(),
                InstructorName = instructorName.Text,
                InstructorPhone = instructorPhone.Text,
                InstructorEmail = instructorEmail.Text,
                Notes = courseNotes.Text,
                EnableNotifications = notificationSwitch.IsEnabled
            };
            Globals.addCourseToCourseCollection(newCourse);
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