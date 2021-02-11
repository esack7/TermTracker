using Plugin.LocalNotifications;
using System;
using System.Collections.Generic;
using TermTracker.Database;
using TermTracker.Models;
using TermTracker.Views;
using Xamarin.Forms;

namespace TermTracker
{
    public partial class App : Application
    {
        public App()
        {
            InitializeData();
            InitializeComponent();
            Globals.startupNotifications();

            MainPage = new NavigationPage(new TermsMainPage())
            {
                BarBackgroundColor = Color.FromHex("#002F51")
            };
        }

        private void InitializeData()
        {
            var db = new SqliteDataService();
            bool addData = db.Initialize();

            if(addData)
            {
                var thisMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                db.AddTerm(new Term { Title = "Term 1", StartDate = thisMonth, EndDate = thisMonth.AddMonths(4).AddDays(-1) });
                db.AddCourse(new Course
                {
                    TermId = 1,
                    Title = "Sample Course",
                    StartDate = thisMonth,
                    EndDate = thisMonth.AddMonths(1).AddDays(-1),
                    Status = "In Progress",
                    InstructorName = "Isaac Heist",
                    InstructorPhone = "555-444-3333", //change before submitting
                    InstructorEmail = "sample@wgu.edu", //change before submitting
                    Notes = "This is only a Test",
                    EnableNotifications = true
                });
                db.AddAssessment(new Assessment 
                { 
                    CourseId = 1, 
                    Title = "Sample", 
                    StartDate = thisMonth.AddMonths(1).AddDays(-1), 
                    EndDate = thisMonth.AddMonths(1), 
                    Type = "Performance" ,
                    EnableNotifications = true
                });
                db.AddAssessment(new Assessment
                {
                    CourseId = 1,
                    Title = "Sample 2",
                    StartDate = thisMonth.AddMonths(2).AddDays(-1),
                    EndDate = thisMonth.AddMonths(2),
                    Type = "Objective",
                    EnableNotifications = true
                });
            }
        }

        protected override void OnStart()
        {
            
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
