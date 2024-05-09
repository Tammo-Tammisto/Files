using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using WebApplication1.Data;
using WebApplication1.Data.Repositories;
using WebApplication1.Services;
using Xunit;

namespace KooliProjekt.UnitTests.ServiceTests
{
    public class TodoListServiceTests
    {
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly Mock<ITodoListRepository> _todoListRepositoryMock;
        private readonly TodoListService _todoListService;

        public TodoListServiceTests()
        {
            _todoListRepositoryMock = new Mock<ITodoListRepository>();

            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _unitOfWorkMock.SetupGet(uow => uow.TodoListRepository)
                           .Returns(_todoListRepositoryMock.Object);

            _todoListService = new TodoListService( _unitOfWorkMock.Object);
        }

        [Fact]
        public async Task GetById_should_return_todo_list()
        {
            // Arrange
            var id = 1;
            var list = new TodoList { Id = id };
            _todoListRepositoryMock.Setup(r => r.GetAsync(id))
                                   .ReturnsAsync(list)
                                   .Verifiable();
            
            // Act
            var result =  await _todoListService.GetById(id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(id, result.Id);
            _todoListRepositoryMock.VerifyAll();
        }

        [Fact]
        public async Task GetById_should_return_null_if_todo_list_is_missing()
        {
            // Arrange
            var id = 1;
            var list = (TodoList)null;
            _todoListRepositoryMock.Setup(r => r.GetAsync(id))
                                   .ReturnsAsync(list)
                                   .Verifiable();

            // Act
            var result = await _todoListService.GetById(id);

            // Assert
            Assert.Null(result);
            _todoListRepositoryMock.VerifyAll();
        }

        [Fact]
        public async Task Save_should_call_repository_save_method()
        {
            // Arrange
            var id = 1;
            var list = new TodoList { Id = id };
            _todoListRepositoryMock.Setup(r => r.SaveAsync(list))
                                   .Verifiable();

            // Act
            await _todoListService.Save(list);

            // Assert
            _todoListRepositoryMock.VerifyAll();
        }
    }
}