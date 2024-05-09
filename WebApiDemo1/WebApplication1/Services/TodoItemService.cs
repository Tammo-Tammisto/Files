using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Data.Queries;

namespace WebApplication1.Services
{
    public class TodoItemService : ITodoItemService
    {
        private readonly ApplicationDbContext _context;

        public TodoItemService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<PagedResult<TodoItem>> List(int page, int pageSize, TodoItemQuery query = null)
        {
            IQueryable<TodoItem> dbQuery = _context.TodoItems.Include(t => t.TodoList);
            query = query ?? new TodoItemQuery();

            if(query.ListId != null)
            {
                dbQuery = dbQuery.Where(item => item.TodoListId == query.ListId);
            }

            if(!string.IsNullOrWhiteSpace(query.ItemSearch))
            {
                dbQuery = dbQuery.Where(item => item.Title.Contains(query.ItemSearch) ||
                                                item.Description.Contains(query.ItemSearch));
            }

            var result = await dbQuery.GetPagedAsync(page, pageSize);

            return result;
        }

        public async Task<TodoItem> GetById(int id)
        {
            return await _context.TodoItems.Include(t => t.TodoList).FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task Save(TodoItem item)
        {
            if(item.Id == 0)
            {
                await _context.AddAsync(item);
            }
            else
            {
                _context.Update(item);
            }

            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var item = await GetById(id);
            if(item == null)
            {
                return;
            }

            _context.Remove(item);

            await _context.SaveChangesAsync();
        }
    }
}
