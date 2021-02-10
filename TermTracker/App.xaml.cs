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

            MainPage = new NavigationPage(new TermsMainPage())
            {
                BarBackgroundColor = Color.FromHex("#002F51")
            };
        }

        private void InitializeData()
        {
            var db = new SqliteDataService();
            bool addData = db.Initialize();

            //TODO: Update initialized data to what is required in part C of requirements and B6 of rubric.
            if(addData)
            {
                var thisMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                db.AddTerm(new Term { Title = "Term 1", StartDate = thisMonth, EndDate = thisMonth.AddMonths(4).AddDays(-1) });
                db.AddTerm(new Term { Title = "Term 2", StartDate = thisMonth.AddMonths(4), EndDate = thisMonth.AddMonths(8).AddDays(-1) });
                db.AddTerm(new Term { Title = "Term 3", StartDate = thisMonth.AddMonths(8), EndDate = thisMonth.AddMonths(12).AddDays(-1) });
                db.AddCourse(new Course
                {
                    TermId = 1,
                    Title = "Sample Course",
                    StartDate = thisMonth,
                    EndDate = thisMonth.AddMonths(1).AddDays(-1),
                    Status = "Dropped",
                    InstructorName = "Bob Roberts",
                    InstructorPhone = "5557399999",
                    InstructorEmail = "bobby.bob@wgu.edu",
                    Notes = "This is only a Test",
                    EnableNotifications = true
                });
                db.AddAssessment(new Assessment 
                { 
                    CourseId = 1, 
                    Title = "Sample", 
                    StartDate = DateTime.Now, 
                    EndDate = DateTime.Now.AddDays(1), 
                    Type = "Performance" ,
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
