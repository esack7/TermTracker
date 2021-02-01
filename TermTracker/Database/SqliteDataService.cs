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
            bool dbCreated = false;
            if (database == null)
            {
                string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "TermTrackerDb.db3");
                database = new SQLiteConnection(dbPath);
            }

            var createdResult = database.CreateTable<Term>();
            if (createdResult == CreateTableResult.Created)
            {
                dbCreated = true;
            }
            
            return dbCreated;
        }

        public void AddTerm(Term term)
        {
            database.Insert(term);
        }

        public List<Term> GetAllTerms()
        {
            return database.Table<Term>().ToList();
        }
    }
}
