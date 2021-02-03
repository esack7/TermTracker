using System.Collections.Generic;
using System.Text;
using TermTracker.Models;

namespace TermTracker.Database
{
    public interface ILocalDataService
    {
        bool Initialize();
        void AddTerm(Term term);
        List<Term> GetAllTerms();
        int DeleteTerm(Term term);
        void AddCourse(Course course);
        List<Course> GetCourseByTermId(int termId);
    }
}
