using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ttcm_api.Interfaces;
using ttcm_api.Models;

namespace ttcm_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    

    public class TraineeController : ControllerBase
    {
        private readonly ITraineeService _traineeService;

        // Constructor where DI happens
        public TraineeController(ITraineeService traineeService)
        {
            _traineeService = traineeService;
        }

        [HttpGet]
        public IActionResult GetAllTrainees()
        {
            return Ok(_traineeService.GetAllTrainees());
        }

        [HttpGet("{id}")]
        public IActionResult GetTraineeById(int id)
        {
            var trainee = _traineeService.GetTraineeById(id);
            if (trainee == null)
            {
                return NotFound();
            }
            return Ok(trainee);
        }

        [HttpPost]
        public IActionResult CreateTrainee([FromBody] Trainee trainee)
        {
            var createdTrainee = _traineeService.CreateTrainee(trainee);
            return CreatedAtAction(nameof(CreateTrainee), new { id = createdTrainee.Id }, createdTrainee);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTrainee(int id, [FromBody] Trainee updatedTrainee)
        {
            var trainee = _traineeService.UpdateTrainee(id, updatedTrainee);
            if (trainee == null)
            {
                return NotFound();
            }
            return Ok(trainee);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTrainee(int id)
        {
            var isDeleted = _traineeService.DeleteTrainee(id);
            if (!isDeleted)
            {
                return NotFound();
            }
            return NoContent();
        }
    }



}
