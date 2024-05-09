namespace WebApplication1.Data.Repositories
{
    public class TodoListRepository : BaseRepository<TodoList>, ITodoListRepository
    {
        public TodoListRepository(ApplicationDbContext context) : base(context)
        {
        }

        // Queriyes
    }
}
