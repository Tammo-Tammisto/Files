using WebApplication1.Data.Repositories;

namespace WebApplication1.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        public ITodoListRepository TodoListRepository { get; }
        // Pluss kõik teised repositoryd

        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context, ITodoListRepository todoListRepository)
        {
            _context = context;

            TodoListRepository = todoListRepository;
        }

        public async Task BeginTransaction()
        {
            await _context.Database.BeginTransactionAsync();
        }

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
            await _context.Database.CommitTransactionAsync();
        }

        public async Task Rollback()
        {
            await _context.Database.RollbackTransactionAsync();
        }
    }
}
