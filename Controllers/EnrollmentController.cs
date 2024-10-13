using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ttcm_api.Models;
using ttcm_api.Interfaces;
using ttcm_api.Models;

namespace ttcm_api.Controllers
{


    [Route("api/v1/enrollments")]
    [ApiController]
    public class EnrollmentController : ControllerBase
    {
        private readonly IEnrollmentCRUD _enrollmentService;

        public EnrollmentController(IEnrollmentCRUD enrollmentService)
        {
            _enrollmentService = enrollmentService;
        }

        [HttpGet]
        public IActionResult GetAllEnrollments()
        {
            return Ok(_enrollmentService.GetAllEnrollments());
        }

        [HttpGet("{id}")]
        public IActionResult GetEnrollmentById(int id)
        {
            var enrollment = _enrollmentService.GetEnrollmentById(id);
            if (enrollment == null)
            {
                return NotFound();
            }
            return Ok(enrollment);
        }

        [HttpPost]
        public IActionResult CreateEnrollment([FromBody] Enrollment enrollment)
        {
            var createdEnrollment = _enrollmentService.CreateEnrollment(enrollment);
            return CreatedAtAction(nameof(CreateEnrollment), new { id = createdEnrollment.Id }, createdEnrollment);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateEnrollment(int id, [FromBody] Enrollment updatedEnrollment)
        {
            var enrollment = _enrollmentService.UpdateEnrollment(id, updatedEnrollment);
            if (enrollment == null)
            {
                return NotFound();
            }
            return Ok(enrollment);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEnrollment(int id)
        {
            var isDeleted = _enrollmentService.DeleteEnrollment(id);
            if (!isDeleted)
            {
                return NotFound();
            }
            return NoContent();
        }
    }

}