using ttcm_api.Interfaces;
using ttcm_api.Models;

namespace ttcm_api.Services
{
    
        public class CoursesService : ICourseCRUD
    {
            private static List<Course> Courses = new List<Course>();

            public IEnumerable<Course> GetAllCourses()
            {
                return Courses;
            }

            public Course GetCourseById(int id)
            {
                return Courses.FirstOrDefault(c => c.Id == id);
            }

            public Course CreateCourse(Course course)
            {
                Courses.Add(course);
                return course;
            }

            public Course UpdateCourse(int id, Course updatedCourse)
            {
                var course = Courses.FirstOrDefault(c => c.Id == id);
                if (course != null)
                {
                    course.ProgramId = updatedCourse.ProgramId;
                    course.StartDate = updatedCourse.StartDate;
                    course.EndDate = updatedCourse.EndDate;
                    course.TrainerId = updatedCourse.TrainerId;
                    course.IsActive = updatedCourse.IsActive;
                }
                return course;
            }

            public bool DeleteCourse(int id)
            {
                var course = Courses.FirstOrDefault(c => c.Id == id);
                if (course != null)
                {
                    Courses.Remove(course);
                    return true;
                }
                return false;
            }
        }
    }

