using ttcm_api.Interfaces;

namespace ttcm_api.Services
{
    public class ProgramsService : IProgramCRUD
    {
        public static List<ttcm_api.Models.Program> Programs = new List<ttcm_api.Models.Program>();

        public ttcm_api.Models.Program Update(int id, ttcm_api.Models.Program newProgram)
        {
            var oldProgam = Programs.FirstOrDefault(p => p.Id == id);
            if (oldProgam != null)
            {
                oldProgam.Title = newProgram.Title;
            }

            return oldProgam;
        }

        public bool Delete(int id)
        {
            var program = Programs.FirstOrDefault(p => p.Id == id);
            if (program != null)
            {
                Programs.Remove(program);
                return true;
            }
            return false;
        }

        IEnumerable<ttcm_api.Models.Program> IProgramCRUD.GetAll()
        {
            return Programs;
        }
        // task1 get program by id 
        public ttcm_api.Models.Program GetProgramById(int id)
        {
            return Programs.FirstOrDefault(p => p.Id == id);
        }
        // task1 get program by id 

        ttcm_api.Models.Program IProgramCRUD.Create(ttcm_api.Models.Program p)
        {
            Programs.Add(p);
            return p;
        }
    }
}
