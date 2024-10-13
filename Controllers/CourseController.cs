using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ttcm_api.Models;
using ttcm_api.Interfaces;
namespace ttcm_api.Controllers
{
    
    [Route("api/v1/courses")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet]
        public IActionResult GetAllCourses()
        {
            return Ok(_courseService.GetAllCourses());
        }

        [HttpGet("{id}")]
        public IActionResult GetCourseById(int id)
        {
            var course = _courseService.GetCourseById(id);
            if (course == null)
            {
                return NotFound();
            }
            return Ok(course);
        }

        [HttpPost]
        public IActionResult CreateCourse([FromBody] Course course)
        {
            var createdCourse = _courseService.CreateCourse(course);
            return CreatedAtAction(nameof(CreateCourse), new { id = createdCourse.Id }, createdCourse);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCourse(int id, [FromBody] Course updatedCourse)
        {
            var course = _courseService.UpdateCourse(id, updatedCourse);
            if (course == null)
            {
                return NotFound();
            }
            return Ok(course);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCourse(int id)
        {
            var isDeleted = _courseService.DeleteCourse(id);
            if (!isDeleted)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
