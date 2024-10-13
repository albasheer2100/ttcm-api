using ttcm_api.Interfaces;
using ttcm_api.Models;

namespace ttcm_api.Services
{
        public class EnrollmentService : IEnrollmentCRUD
    {
            private static List<Enrollment> Enrollments = new List<Enrollment>();

            public IEnumerable<Enrollment> GetAllEnrollments()
            {
                return Enrollments;
            }

            public Enrollment GetEnrollmentById(int id)
            {
                return Enrollments.FirstOrDefault(e => e.Id == id);
            }

            public Enrollment CreateEnrollment(Enrollment enrollment)
            {
                Enrollments.Add(enrollment);
                return enrollment;
            }

            public Enrollment UpdateEnrollment(int id, Enrollment updatedEnrollment)
            {
                var enrollment = Enrollments.FirstOrDefault(e => e.Id == id);
                if (enrollment != null)
                {
                    enrollment.CourseId = updatedEnrollment.CourseId;
                    enrollment.TraineeId = updatedEnrollment.TraineeId;
                    enrollment.EnrollmentDate = updatedEnrollment.EnrollmentDate;
                    enrollment.Price = updatedEnrollment.Price;
                    enrollment.Currency = updatedEnrollment.Currency;
                }
                return enrollment;
            }

            public bool DeleteEnrollment(int id)
            {
                var enrollment = Enrollments.FirstOrDefault(e => e.Id == id);
                if (enrollment != null)
                {
                    Enrollments.Remove(enrollment);
                    return true;
                }
                return false;
            }
        }
    }





