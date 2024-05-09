namespace WebApplication1.Data.Repositories
{
    public interface ITodoListRepository
    {
        Task<TodoList> GetAsync(int id);
        Task<PagedResult<TodoList>> ListAsync(int page, int pageSize);
        Task SaveAsync(TodoList item);
        Task DeleteAsync(int id);
        Task<IList<LookupItem>> LookupAsync();
    }
}