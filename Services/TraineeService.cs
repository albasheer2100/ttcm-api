using ttcm_api.Interfaces;
using ttcm_api.Models;

namespace ttcm_api.Services
{
  
public class TraineesService : ITraineeService
    {
        private static List<Trainee> Trainees = new List<Trainee>();

        public IEnumerable<Trainee> GetAllTrainees()
        {
            return Trainees;
        }

        public Trainee GetTraineeById(int id)
        {
            return Trainees.FirstOrDefault(t => t.Id == id);
        }

        public Trainee CreateTrainee(Trainee trainee)
        {
            Trainees.Add(trainee);
            return trainee;
        }

        public Trainee UpdateTrainee(int id, Trainee updatedTrainee)
        {
            var trainee = Trainees.FirstOrDefault(t => t.Id == id);
            if (trainee != null)
            {
                trainee.Username = updatedTrainee.Username;
                trainee.Email = updatedTrainee.Email;
                trainee.Phone = updatedTrainee.Phone;
                trainee.Password = updatedTrainee.Password;
                trainee.Role = updatedTrainee.Role;
                trainee.IsGraduated = updatedTrainee.IsGraduated;
            }
            return trainee;
        }

        public bool DeleteTrainee(int id)
        {
            var trainee = Trainees.FirstOrDefault(t => t.Id == id);
            if (trainee != null)
            {
                Trainees.Remove(trainee);
                return true;
            }
            return false;
        }
    }
    }

