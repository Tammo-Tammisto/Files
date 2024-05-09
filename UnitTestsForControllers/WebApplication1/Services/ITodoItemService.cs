using WebApplication1.Data;
using WebApplication1.Data.Queries;

namespace WebApplication1.Services
{
    public interface ITodoItemService
    {
        Task<PagedResult<TodoItem>> List(int page, int pageSize, TodoItemQuery query = null);
        Task<TodoItem> GetById(int id);
        Task Save(TodoItem item);
        Task Delete(int id);
    }
}
