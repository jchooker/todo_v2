using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
//using System.Data.Entity;
using ToDoApp.Data;
using ToDoList_ToDoAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ToDoApp.Controllers //**NEED TO FIX UP ALL OF THE ONES THAT ARE SWITCHING VALUES B/W TODO AND TODODTO!
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ToDoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<ToDo>>> GetToDos()
        {

            return Ok(await _context.ToDos.ToListAsync());
        }
        [HttpGet("{id:int}", Name = "GetToDo")] //must specify that this Get should be receiving an Id parameter
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ToDo>> GetToDo(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var toDo = await _context.ToDos.FirstOrDefaultAsync(u => u.Id == id);
            if (toDo == null)
            {
                return NotFound();
            }
            return Ok(toDo);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ToDo>> CreateToDo([FromBody] ToDo toDo)
        {
            if (toDo == null)
            {
                return BadRequest(toDo);
            }
            if (toDo.Id > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            //ToDo model = new() //removed all of the Id = toDoDTO.Id types from here
            //{
            //    Id = toDoDTO.Id,
            //    Title = toDoDTO.Title,
            //    Note = toDoDTO.Note,
            //    IsComplete = toDoDTO.IsComplete,
            //    DeadlineDateTime = toDoDTO.DeadlineDateTime,
            //    CreatedDate = toDoDTO.CreatedDate
            //};
            await _context.ToDos.AddAsync(toDo);
            await _context.SaveChangesAsync();
            return CreatedAtRoute("GetToDo", new { id = toDo.Id }, toDo);
        }
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id:int}", Name = "DeleteToDo")]
        public async Task<IActionResult> DeleteToDo(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var toDo = await _context.ToDos.FirstOrDefaultAsync(u => u.Id == id);
            if (toDo == null)
            {
                return NotFound();
            }
            _context.ToDos.Remove(toDo);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("{id:int}", Name = "UpdateToDo")]
        public async Task<IActionResult> UpdateToDo(int id, [FromBody] ToDo toDo) //to free up resources when we just want to
                                                                                        //replace one property, we use Http Patch
        {
            if (toDo == null || id != toDo.Id)
            {
                return BadRequest();
            }
            //var toDo = ToDoStore.toDoList.FirstOrDefault(u => u.Id == id);
            //toDo.Title = toDoDTO.Title;
            //toDo.Note = toDoDTO.Note;
            //toDo.IsComplete = toDoDTO.IsComplete;
            //toDo.DeadlineDateTime = toDoDTO.DeadlineDateTime;
            //ToDo model = new()
            //{
            //    Id = toDoDTO.Id,
            //    Title = toDoDTO.Title,
            //    Note = toDoDTO.Note,
            //    IsComplete = toDoDTO.IsComplete,
            //    DeadlineDateTime = toDoDTO.DeadlineDateTime,
            //    CreatedDate = toDoDTO.CreatedDate
            //};
            _context.ToDos.Update(toDo);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPatch("{id:int}", Name = "UpdatePartialToDo")]
        public async Task<IActionResult> UpdatePartialToDo(int id, JsonPatchDocument<ToDo> patch)
        {
            if (patch == null || id == 0)
            {
                return BadRequest();
            }
            var toDo = await _context.ToDos.AsNoTracking().FirstOrDefaultAsync(u => u.Id == id);

            //ToDoDTO toDoDTO = new()
            //{
            //    Id = toDo.Id, //***Worth investigating automapper to avoid doing this over and over
            //    Title = toDo.Title,
            //    Note = toDo.Note,
            //    IsComplete = toDo.IsComplete,
            //    DeadlineDateTime = toDo.DeadlineDateTime,
            //    CreatedDate = toDo.CreatedDate
            //};

            if (toDo == null)
            {
                return BadRequest();
            }
            patch.ApplyTo(toDo, ModelState);
            //ToDo model = new ToDo()
            //{
            //    Id = toDoDTO.Id,
            //    Title = toDoDTO.Title,
            //    Note = toDoDTO.Note,
            //    IsComplete = toDoDTO.IsComplete,
            //    DeadlineDateTime = toDoDTO.DeadlineDateTime,
            //    CreatedDate = toDoDTO.CreatedDate
            //};

            _context.ToDos.Update(toDo);
            await _context.SaveChangesAsync();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return NoContent();
        }
    }
}
