using System;
using System.Collections.Generic;
using System.Text;

namespace TermTracker.Models
{
    public class Assessment
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Type { get; set; }

        private static int count = 0;

        public Assessment(int courseId, string title, DateTime startDate, DateTime endDate, string type)
        {
            count++;
            Id = count;
            CourseId = courseId;
            Title = title;
            StartDate = startDate;
            EndDate = endDate;
            Type = type;
        }

        public Assessment(int id, int courseId, string title, DateTime startDate, DateTime endDate, string type)
        {
            Id = id;
            count = id;
            CourseId = courseId;
            Title = title;
            StartDate = startDate;
            EndDate = endDate;
            Type = type;
        }
    }
}
