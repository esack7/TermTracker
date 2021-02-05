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
            bool dbTablesCreated = false;
            if (database == null)
            {
                string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "TermTrackerDb.db3");
                database = new SQLiteConnection(dbPath);
            }

            var create = database.CreateTables<Term, Course, Assessment>();

            foreach (var result in create.Results)
            {
                dbTablesCreated = dbTablesCreated || result.Value == CreateTableResult.Created;
            }

            return dbTablesCreated;
        }

        public void AddTerm(Term term)
        {
            database.Insert(term);
        }

        public List<Term> GetAllTerms()
        {
            return database.Table<Term>().ToList();
        }

        public int UpdateTerm(Term term)
        {
            return database.Update(term);
        }

        public int DeleteTerm(Term term)
        {
            return database.Delete(term);
        }

        public void AddCourse(Course course)
        {
            database.Insert(course);
        }

        public List<Course> GetCoursesByTermId(int termId)
        {
            string query = $"SELECT * FROM course WHERE course.TermId={termId}";
            return database.Query<Course>(query);
        }

        public void Close()
        {
            database.Close();
        }
    }
}
