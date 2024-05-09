namespace WebApplication1.Data.Repositories
{
    public interface ITodoListRepository
    {
        Task<PagedResult<TodoList>> List(int page, int pageSize);
        Task<TodoList> GetById(int id);
        Task Save(TodoList list);
        Task Delete(int id);
    }
}
