using ttcm_api.Models;

namespace ttcm_api.Interfaces
{
    public interface ICourseCRUD
    {

            IEnumerable<Course> GetAllCourses();
            Course GetCourseById(int id);
            Course CreateCourse(Course course);
            Course UpdateCourse(int id, Course updatedCourse);
            bool DeleteCourse(int id);
        
    }
}