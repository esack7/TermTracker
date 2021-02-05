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
        public static ObservableCollection<Course> Courses;
        public static ObservableCollection<Assessment> Assessments;

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
            Courses = new ObservableCollection<Course>();
            var database = new SqliteDataService();
            database.Initialize();
            var courses = database.GetCoursesByTermId(termId);
            courses.ForEach(course => Courses.Add(course));
            database.Close();
        }
    }
}
