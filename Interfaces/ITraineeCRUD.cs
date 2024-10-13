using ttcm_api.Models;

namespace ttcm_api.Interfaces
{

    // Interface for Trainee CRUD operations
    public interface ITraineeService
        {
            IEnumerable<Trainee> GetAllTrainees();
            Trainee GetTraineeById(int id);
            Trainee CreateTrainee(Trainee trainee);
            Trainee UpdateTrainee(int id, Trainee updatedTrainee);
            bool DeleteTrainee(int id);
        }
    }

