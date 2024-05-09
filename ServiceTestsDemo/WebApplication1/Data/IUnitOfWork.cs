using WebApplication1.Data.Repositories;

namespace WebApplication1.Data
{
    public interface IUnitOfWork
    {
        ITodoListRepository TodoListRepository { get; }

        Task BeginTransaction();
        Task Commit();
        Task Rollback();
    }
}
