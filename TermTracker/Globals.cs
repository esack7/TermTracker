using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using TermTracker.Database;
using TermTracker.Models;

namespace TermTracker
{
    public static class Globals
    {
        public static ObservableCollection<Term> Terms = new ObservableCollection<Term>();
        public static ObservableCollection<Course> Courses = new ObservableCollection<Course>();
        public static ObservableCollection<Assessment> Assessments = new ObservableCollection<Assessment>();

        public static void initializeTermsCollection()
        {
            var database = new SqliteDataService();
            database.Initialize();
            var terms = database.GetAllTerms();
            terms.ForEach(term => Terms.Add(term));
            database.Close();
        }

        public static void addTermToTermCollection(Term term)
        {
            var database = new SqliteDataService();
            database.Initialize();
            database.AddTerm(term);
            Terms.Add(term);
            database.Close();
        }

        public static void updateTermInTermCollection(Term oldTerm, Term newTerm)
        {
            var termList = Terms.ToList();
            Terms.Clear();

            var database = new SqliteDataService();
            database.Initialize();
            database.UpdateTerm(newTerm);

            int indexFound = termList.IndexOf(oldTerm);
            termList.RemoveAt(indexFound);
            termList.Insert(indexFound, newTerm);
            termList.ForEach(term => Terms.Add(term));

            database.Close();
        }

        public static void deleteTermFromTermCollection(Term term)
        {
            var database = new SqliteDataService();
            database.Initialize();
            database.DeleteTerm(term);
            Terms.Remove(term);
            database.Close();
        }

        public static void initializeCoursesCollection(int termId)
        {
            Courses.Clear();
            var database = new SqliteDataService();
            database.Initialize();
            var courses = database.GetCoursesByTermId(termId);
            courses.ForEach(course => Courses.Add(course));
            database.Close();
        }

        public static void addCourseToCourseCollection(Course course)
        {
            var database = new SqliteDataService();
            database.Initialize();
            database.AddCourse(course);
            Courses.Add(course);
            database.Close();
        }

        public static void updateCourseInCourseCollection(Course oldCourse, Course newCourse)
        {
            var courseList = Courses.ToList();
            Courses.Clear();

            var database = new SqliteDataService();
            database.Initialize();
            database.UpdateCourse(newCourse);

            int indexFound = courseList.IndexOf(oldCourse);
            courseList.RemoveAt(indexFound);
            courseList.Insert(indexFound, newCourse);
            courseList.ForEach(course => Courses.Add(course));

            database.Close();
        }

        public static void deleteCourseFromCourseCollection(Course course)
        {
            var database = new SqliteDataService();
            database.Initialize();
            database.DeleteCourse(course);
            Courses.Remove(course);
            database.Close();
        }

        public static void initializeAssessmentCollection(int courseId)
        {
            Assessments.Clear();
            var database = new SqliteDataService();
            database.Initialize();
            var courses = database.GetAssessmentsByCourseId(courseId);
            courses.ForEach(assessment => Assessments.Add(assessment));
            database.Close();
        }

        public static void addAssessmentToAssessmentCollection(Assessment assessment)
        {
            var database = new SqliteDataService();
            database.Initialize();
            database.AddAssessment(assessment);
            Assessments.Add(assessment);
            database.Close();
        }

        public static void updateAssessmentInAssessmentCollection(Assessment oldAssessment, Assessment newAssessment)
        {
            var assessmentList = Assessments.ToList();
            Assessments.Clear();

            var database = new SqliteDataService();
            database.Initialize();
            database.UpdateAssessment(newAssessment);

            int indexFound = assessmentList.IndexOf(oldAssessment);
            assessmentList.RemoveAt(indexFound);
            assessmentList.Insert(indexFound, newAssessment);
            assessmentList.ForEach(assessment => Assessments.Add(assessment));

            database.Close();
        }

        public static void deleteAssessmentFromAssessmentCollection(Assessment assessment)
        {
            var database = new SqliteDataService();
            database.Initialize();
            database.DeleteAssessment(assessment);
            Assessments.Remove(assessment);
            database.Close();
        }
    }
}
