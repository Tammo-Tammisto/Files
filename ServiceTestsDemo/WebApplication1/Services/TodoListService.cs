using WebApplication1.Data;
using WebApplication1.Data.Repositories;

namespace WebApplication1.Services
{
    public class TodoListService : ITodoListService
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly ITodoListRepository _todoListRepository;

        public TodoListService(IUnitOfWork unitOfWork) 
        { 
            _unitOfWork = unitOfWork;

            _todoListRepository = unitOfWork.TodoListRepository;
        }

        public async Task<PagedResult<TodoList>> List(int page, int pageSize)
        {
            var result = await _todoListRepository.ListAsync(page, pageSize);

            return result;
        }

        public async Task<TodoList> GetById(int id)
        {
            var result = await _todoListRepository.GetAsync(id);

            return result;
        }

        public async Task Save(TodoList list)
        {
            await _todoListRepository.SaveAsync(list);
        }

        public async Task Delete(int id)
        {
            await _todoListRepository.DeleteAsync(id);
        }

        public async Task<IList<LookupItem>> Lookup()
        {
            return await _todoListRepository.LookupAsync();
        }
    }
}