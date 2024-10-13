using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ttcm_api.Interfaces;
using ttcm_api.Models;
using ttcm_api.Services;

namespace ttcm_api.Controllers
{
    [Route("api/v1/programs")]
    [ApiController]
    public class ProgramController : ControllerBase
    {
        // For Dependency Injection
        // to be fetched from DI container, auto
        // SHOULD BE ADDED to the container of DI at program.cs file
        private IProgramCRUD _programsService;
        public ProgramController(IProgramCRUD programsService) {
            _programsService = programsService;
        }

        // Read:R
        [HttpGet]
        public IActionResult GetAll()
        {
            
            return Ok(_programsService.GetAll());
        }

        // task1 get program by id
        [HttpGet("{id}")]
        public IActionResult GetProgramById(int id)
        {
            var program = _programsService.GetProgramById(id);
            if (program == null)
            {
                return NotFound("Program not found");
            }
            return Ok(program);
        }
        // task1 get program by id

        [HttpPost]
        public IActionResult Create([FromBody] ttcm_api.Models.Program program)
        {
            _programsService.Create(program);
            //return Ok(program);// Http 200 => success
            return CreatedAtAction("Create", new { Id = program.Id }, program);

        }


        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] ttcm_api.Models.Program newProgram)
        {

           
            var newProg = _programsService.Update(id, newProgram);
            if (newProg != null)
            {
                return Ok(newProg);
            }
            // # if reach this line, this mean no resource found!
            return NotFound("The program resource not found!");
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            
            bool isDone =  _programsService.Delete(id);
            if (isDone)
            {
                return Ok();
            }

            return NotFound();
        }


    }
}
