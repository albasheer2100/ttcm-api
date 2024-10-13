using Microsoft.AspNetCore.Mvc;
using ttcm_api.Contexts;

namespace ttcm_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly MainAppContext _context;

        public TestController(MainAppContext context)
        {
            _context = context;
        }

        [HttpGet("test-connection")]
        public IActionResult TestConnection()
        {
            try
            {
                var programsCount = _context.Program.Count();
                return Ok(new { success = true, message = "Connection successful", programsCount });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, message = "Connection failed", error = ex.Message });
            }
        }
    }
}
