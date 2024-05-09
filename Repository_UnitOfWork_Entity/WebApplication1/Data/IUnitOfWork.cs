using WebApplication1.Data.Repositories;

namespace WebApplication1.Data
{
    public interface IUnitOfWork
    {
        public ITodoListRepository TodoListRepository { get; }
        // Pluss kõik teised repositoryd

        Task BeginTransaction();
        Task Commit();
        Task Rollback();
    }
}
