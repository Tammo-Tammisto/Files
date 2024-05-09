using System.Collections.Generic;
using WebApplication1.Data;
using WebApplication1.Data.Repositories;

namespace WebApplication1.Services
{
    public class TodoListService : ITodoListService
    {
        private readonly ITodoListRepository _todoListRepository;
        private readonly IUnitOfWork _unitOfWork;

        public TodoListService(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;

            _todoListRepository = unitOfWork.TodoListRepository;
        }

        public async Task<PagedResult<TodoList>> List(int page, int pageSize)
        {
            var result = await _todoListRepository.List(page, pageSize);

            return result;
        }

        public async Task<TodoList> GetById(int id)
        {
            var result = await _todoListRepository.GetById(id);

            return result;
        }

        public async Task Save(TodoList list)
        {
            await _unitOfWork.BeginTransaction();

            try
            {
                await _todoListRepository.Save(list);

                await _unitOfWork.Commit();
            }
            catch(Exception ex)
            {
                await _unitOfWork.Rollback();
            }
        }

        public async Task Delete(int id)
        {
            await _unitOfWork.BeginTransaction();

            try
            {
                await _todoListRepository.Delete(id);

                await _unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                await _unitOfWork.Rollback();
            }
        }
    }
}