using System;
using System.Collections.Generic;
using System.Text;

namespace TermTracker.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Status { get; set; }
        public string InstructorName { get; set; }
        public string InstructorPhone { get; set; }
        public string InstructorEmail { get; set; }
        public string Notes { get; set; }
        public bool EnableNotifications { get; set; }

        private static int count = 0;

        public Course(string title, DateTime startDate, DateTime endDate, string status, string instructorName, string instructorPhone, string instructorEmail, string notes, bool enableNotifications)
        {
            count++;
            Id = count;
            Title = title;
            StartDate = startDate;
            EndDate = endDate;
            Status = status;
            InstructorName = instructorName;
            InstructorPhone = instructorPhone;
            InstructorEmail = instructorEmail;
            Notes = notes;
            EnableNotifications = enableNotifications;
        }

        public Course(int id, string title, DateTime startDate, DateTime endDate, string status, string instructorName, string instructorPhone, string instructorEmail, string notes, bool enableNotifications)
        {
            Id = id;
            count = id;
            Title = title;
            StartDate = startDate;
            EndDate = endDate;
            Status = status;
            InstructorName = instructorName;
            InstructorPhone = instructorPhone;
            InstructorEmail = instructorEmail;
            Notes = notes;
            EnableNotifications = enableNotifications;
        }
    }
}
