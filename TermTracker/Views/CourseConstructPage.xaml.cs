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
        private CoursePage CoursePage;
        public CourseConstructPage(int termId)
        {
            InitializeComponent();
            TermID = termId;
            SaveEditButton.IsVisible = false;
        }

        public CourseConstructPage(CoursePage coursePage)
        {
            InitializeComponent();
            CoursePage = coursePage;
            Course course = coursePage.SelectedCourse;
            TermID = course.TermId;
            courseTitle.Text = course.Title;
            startDateSelected.Date = course.StartDate;
            endDateSelected.Date = course.EndDate;
            statusPicker.SelectedItem = course.Status;
            instructorName.Text = course.InstructorName;
            instructorPhone.Text = course.InstructorPhone;
            instructorEmail.Text = course.InstructorEmail;
            courseNotes.Text = course.Notes;
            notificationSwitch.IsToggled = course.EnableNotifications;
            SaveButton.IsVisible = false;
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
                EnableNotifications = notificationSwitch.IsToggled
            };
            Globals.addCourseToCourseCollection(newCourse);
            await Navigation.PopModalAsync();
        }

        private async void SaveEditButton_Clicked(object sender, EventArgs e)
        {
            var coursePage = CoursePage;
            var newCourse = new Course
            {
                Id = coursePage.SelectedCourse.Id,
                TermId = TermID,
                Title = courseTitle.Text,
                StartDate = startDateSelected.Date,
                EndDate = endDateSelected.Date,
                Status = statusPicker.SelectedItem.ToString(),
                InstructorName = instructorName.Text,
                InstructorPhone = instructorPhone.Text,
                InstructorEmail = instructorEmail.Text,
                Notes = courseNotes.Text,
                EnableNotifications = notificationSwitch.IsToggled
            };
            Globals.updateCourseInCourseCollection(coursePage.SelectedCourse, newCourse);
            coursePage.SetData(newCourse);
            await Navigation.PopModalAsync();
        }

        private async void CancelButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}