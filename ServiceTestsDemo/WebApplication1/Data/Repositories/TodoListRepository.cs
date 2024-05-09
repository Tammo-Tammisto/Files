
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Data.Repositories
{
    public class TodoListRepository : ITodoListRepository
    {
        private readonly ApplicationDbContext _context;

        public TodoListRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task DeleteAsync(int id)
        {
            var todoList = await _context.TodoLists.FindAsync(id);
            if (todoList != null)
            {
                _context.TodoLists.Remove(todoList);
            }

            await _context.SaveChangesAsync();
        }

        public async Task<TodoList> GetAsync(int id)
        {
            return await _context.TodoLists.FindAsync(id);
        }

        public async Task<PagedResult<TodoList>> ListAsync(int page, int pageSize)
        {
            return await _context.TodoLists.GetPagedAsync(page, pageSize);
        }

        public async Task<IList<LookupItem>> LookupAsync()
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

        public async Task SaveAsync(TodoList list)
        {
            if (list.Id == 0)
            {
                await _context.AddAsync(list);
            }
            else
            {
                _context.Update(list);
            }

            await _context.SaveChangesAsync();
        }
    }
}
