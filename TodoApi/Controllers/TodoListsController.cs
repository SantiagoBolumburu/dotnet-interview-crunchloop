using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Dtos;
using TodoApi.Mappers;
using TodoApi.Models;

namespace TodoApi.Controllers
{
    [Route("api/todolists")]
    [ApiController]
    public class TodoListsController : ControllerBase
    {
        private readonly TodoContext _context;

        public TodoListsController(TodoContext context)
        {
            _context = context;
        }

        // GET: api/todolists
        [HttpGet]
        public async Task<ActionResult<IList<OutTodoList>>> GetTodoLists()
        {
            List<TodoList> todoLists = await _context.TodoList.Include(x => x.TodoItems).ToListAsync();
            
            List<OutTodoList> outTodoLists = [];

            if (todoLists != null)
            {
                outTodoLists = todoLists.Select(x => TodoListMappper.ToOutDto(x)).ToList();
            }

            return Ok(outTodoLists);
        }

        // GET: api/todolists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OutTodoList>> GetTodoList(long id)
        {
            var todoList = await _context.TodoList
                .Include(x => x.TodoItems)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (todoList == null)
            {
                return NotFound();
            }

            return Ok(TodoListMappper.ToOutDto(todoList));
        }

        // PUT: api/todolists/5
        // To protect from over-posting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult> PutTodoList(long id, UpdateTodoList payload)
        {
            var todoList = await _context.TodoList.FindAsync(id);

            if (todoList == null)
            {
                return NotFound();
            }

            todoList.Name = payload.Name;
            await _context.SaveChangesAsync();

            return Ok(TodoListMappper.ToOutDto(todoList));
        }

        // POST: api/todolists
        // To protect from over-posting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TodoList>> PostTodoList(CreateTodoList payload)
        {
            var todoList = new TodoList
            {
                Name = payload.Name,
                TodoItems = []
            };

            _context.TodoList.Add(todoList);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTodoList", new { id = todoList.Id }, TodoListMappper.ToOutDto(todoList));
        }

        // DELETE: api/todolists/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTodoList(long id)
        {
            var todoList = await _context.TodoList.FindAsync(id);
            if (todoList == null)
            {
                return NotFound();
            }

            _context.TodoList.Remove(todoList);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TodoListExists(long id)
        {
            return (_context.TodoList?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
