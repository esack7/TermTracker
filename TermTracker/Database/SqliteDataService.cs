using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using TermTracker.Models;

namespace TermTracker.Database
{
    public class SqliteDataService: ILocalDataService
    {
        private SQLiteConnection database;
        public bool Initialize()
        {
            if (database == null)
            {
                string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "TermTrackerDb.db3");
                database = new SQLiteConnection(dbPath);
            }

            return database.CreateTable<Term>() == CreateTableResult.Created || database.CreateTable<Course>() == CreateTableResult.Created || database.CreateTable<Assessment>() == CreateTableResult.Created;
        }

        public void AddTerm(Term term)
        {
            database.Insert(term);
        }

        public List<Term> GetAllTerms()
        {
            return database.Table<Term>().ToList();
        }

        public void AddCourse(Course course)
        {
            database.Insert(course);
        }

        public List<Course> GetCourseByTermId(int termId)
        {
            string query = $"SELECT * FROM course WHERE course.TermId = ${termId}";
            return database.Query<Course>(query);
        }
    }
}
