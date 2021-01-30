using System;
using System.Collections.Generic;
using System.Text;

namespace TermTracker.Models
{
    public class Term
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        private static int count = 0;

        public Term(string title, DateTime startDate, DateTime endDate)
        {
            count++;
            Id = count;
            Title = title;
            StartDate = startDate;
            EndDate = endDate;
        }

        public Term(int id, string title, DateTime startDate, DateTime endDate)
        {
            Id = id;
            count = id;
            Title = title;
            StartDate = startDate;
            EndDate = endDate;
        }
    }
}
