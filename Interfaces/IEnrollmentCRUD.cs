using ttcm_api.Models;

namespace ttcm_api.Interfaces
{
    public interface IEnrollmentCRUD
    {

        IEnumerable<Enrollment> GetAllEnrollments();
        Enrollment GetEnrollmentById(int id);
        Enrollment CreateEnrollment(Enrollment enrollment);
        Enrollment UpdateEnrollment(int id, Enrollment updatedEnrollment);
        bool DeleteEnrollment(int id);

    }
}
