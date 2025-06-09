using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Dtos;
using TodoApi.Mappers;
using TodoApi.Models;

namespace TodoApi.Controllers
{
    [Route("api/todoitems")]
    [ApiController]
    public class TodoItemsController : ControllerBase
    {
        private readonly TodoContext _context;

        public TodoItemsController(TodoContext context)
        {
            _context = context;
        }

        // GET: api/todoitems
        [HttpGet]
        public async Task<ActionResult<IList<OutTodoItem>>> GetTodoItem()
        {
            List<TodoItem> todoItems = await _context.TodoItem.Include(x => x.TodoList).ToListAsync();

            List<OutTodoItem> todoItemListOut = [];

            if (todoItems != null)
            {
                todoItemListOut = todoItems.Select(x => TodoItemMappper.ToOutDto(x)).ToList();
            }

            return Ok(todoItemListOut);
        }

        // GET: api/todoitems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OutTodoItem>> GetTodoItem(long id)
        {
            var todoItem = await _context.TodoItem
                .Include(x => x.TodoList)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (todoItem == null)
            {
                return NotFound();
            }

            return Ok(TodoItemMappper.ToOutDto(todoItem));
        }

        // PUT: api/todoitems/5
        // To protect from over-posting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult> PutTodoItem(long id, UpdateTodoItem payload)
        {
            var todoItem = await _context.TodoItem
                .Include(x => x.TodoList)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (todoItem == null)
            {
                return NotFound();
            }

            todoItem.Name = payload.Name;
            todoItem.Description = payload.Description;
            todoItem.Completed = payload.Completed;

            await _context.SaveChangesAsync();

            return Ok(TodoItemMappper.ToOutDto(todoItem));
        }

        // POST: api/todoitems
        // To protect from over-posting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OutTodoItem>> PostTodoItem(CreateTodoItem payload)
        {
            var todoList = await _context.TodoList.FindAsync(payload.TodoListId);

            if (todoList == null)
            {
                return NotFound();
            }

            var todoItem = TodoItemMappper.FromCreateDto(payload, todoList);

            _context.TodoItem.Add(todoItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTodoItem",
                new { id = todoItem.Id },
                TodoItemMappper.ToOutDto(todoItem)
            );
        }

        // DELETE: api/todoitems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTodoItem(long id)
        {
            var todoItem = await _context.TodoItem.FindAsync(id);
            if (todoItem == null)
            {
                return NotFound();
            }

            _context.TodoItem.Remove(todoItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
