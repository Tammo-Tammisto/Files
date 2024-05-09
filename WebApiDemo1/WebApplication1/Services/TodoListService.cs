using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;

namespace WebApplication1.Services
{
    public class TodoListService : ITodoListService
    {
        private readonly ApplicationDbContext _context;

        public TodoListService(ApplicationDbContext context) 
        { 
            _context = context;
        }

        public async Task<PagedResult<TodoList>> List(int page, int pageSize)
        {
            var result = await _context.TodoLists.GetPagedAsync(page, pageSize);

            return result;
        }

        public async Task<TodoList> GetById(int id)
        {
            var result = await _context.TodoLists.FirstOrDefaultAsync(m => m.Id == id);

            return result;
        }

        public async Task Save(TodoList list)
        {
            if (list.Id == 0)
            {
                _context.Add(list);
            }
            else
            {
                _context.Update(list);
            }

            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var todoList = await _context.TodoLists.FindAsync(id);
            if (todoList != null)
            {
                _context.TodoLists.Remove(todoList);
            }

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<LookupItem>> Lookup()
        {
            var result = await _context.TodoLists
                                       .OrderBy(todoList => todoList.Title)
                                       .Select(todoList => new LookupItem 
                                       { 
                                           Id = todoList.Id,
                                           Title = todoList.Title
                                       })
                                       .ToListAsync();
            return result;
        }
    }
}