using System.Collections.Generic;
using System.Text;
using TermTracker.Models;

namespace TermTracker.Database
{
    public interface ILocalDataService
    {
        bool Initialize();
        void Close();
        void AddTerm(Term term);
        List<Term> GetAllTerms();
        int UpdateTerm(Term term);
        int DeleteTerm(Term term);
        void AddCourse(Course course);
        List<Course> GetCoursesByTermId(int termId);
        int UpdateCourse(Course course);
        int DeleteCourse(Course course);
        void AddAssessment(Assessment assessment);
        List<Assessment> GetAssessmentsByCourseId(int courseId);
        int DeleteAssessment(Assessment assessment);
    }
}
