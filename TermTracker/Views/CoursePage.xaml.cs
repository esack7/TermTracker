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
    public partial class CoursePage : ContentPage
    {
        public Course SelectedCourse;
        public CoursePage(Course course)
        {
            InitializeComponent();
            SelectedCourse = course;
            SetData(course);
        }

        public void SetData(Course course)
        {
            navTitle.Text = course.Title;
            CourseDateRange.Text = $"{course.StartDate.ToString("MM-dd-yyyy", DateTimeFormatInfo.InvariantInfo)} - {course.EndDate.ToString("MM-dd-yyyy", DateTimeFormatInfo.InvariantInfo)}";
            statusSelection.Text = course.Status;
            instructorsName.Text = course.InstructorName;
            instructorsPhone.Text = course.InstructorPhone;
            instructorsEmail.Text = course.InstructorEmail;
            notes.Text = course.Notes;
            notificationsEnabled.Text = course.EnableNotifications ? "ON" : "OFF";
        }

        private async void ShareNotes_Clicked(object sender, EventArgs e)
        {

        }

        private async void CourseAssessments_Clicked(object sender, EventArgs e)
        {
            
        }

        private async void EditCourse_Clicked(object sender, EventArgs e)
        {

        }

        private async void DeleteCourse_Clicked(object sender, EventArgs e)
        {
            Globals.deleteCourseFromCourseCollection(SelectedCourse);
            await Navigation.PopAsync();
        }
    }
}