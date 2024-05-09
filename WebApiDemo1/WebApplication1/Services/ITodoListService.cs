using WebApplication1.Data;

namespace WebApplication1.Services
{
    public interface ITodoListService
    {
        Task<PagedResult<TodoList>> List(int page, int pageSize);
        Task<TodoList> GetById(int id);
        Task Save(TodoList list);
        Task Delete(int id);
        Task<IEnumerable<LookupItem>> Lookup();
    }
}
