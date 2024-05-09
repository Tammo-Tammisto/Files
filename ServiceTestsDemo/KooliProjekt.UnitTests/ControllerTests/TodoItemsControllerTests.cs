using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using WebApplication1.Controllers;
using WebApplication1.Data;
using WebApplication1.Services;
using Xunit;

namespace KooliProjekt.UnitTests.ControllerTests
{
    public class TodoItemsControllerTests
    {
        private readonly Mock<ITodoItemService> _todoItemServiceMock;
        private readonly Mock<ITodoListService> _todoListServiceMock;
        private readonly TodoItemsController _controller;
        
        public TodoItemsControllerTests() 
        { 
            _todoItemServiceMock = new Mock<ITodoItemService>();
            _todoListServiceMock = new Mock<ITodoListService>();

            _controller = new TodoItemsController(
                                    _todoItemServiceMock.Object,
                                    _todoListServiceMock.Object
                                );
        }

        [Fact]
        public async Task Details_should_return_notfound_if_id_is_missing()
        {
            // Arrange
            int? id = null;

            // Act
            var result = await _controller.Details(id) as NotFoundResult;

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task Details_should_return_notfound_if_item_was_not_found()
        {
            // Arrange
            var id = 4;
            TodoItem item = null;
            _todoItemServiceMock.Setup(srv => srv.GetById(id))
                                .ReturnsAsync(item);

            // Act
            var result = await _controller.Details(id) as NotFoundResult;

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task Details_should_return_view_and_model_if_todolist_was_found()
        {
            // Arrange
            int id = 4;
            var item = new TodoItem { Id = id };
            _todoItemServiceMock.Setup(srv =>srv.GetById(id))
                                .ReturnsAsync(item);    

            // Act
            var result = await _controller.Details(id) as ViewResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(item, result.Model);
        }

        [Fact]
        public async Task DeleteConfirmed_should_redirect_to_index()
        {
            // Arrange
            int id = 4;
            _todoItemServiceMock.Setup(srv => srv.Delete(id))
                                .Verifiable();

            // Act
            var result = await _controller.DeleteConfirmed(id) as RedirectToActionResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Index", result.ActionName);
            _todoItemServiceMock.VerifyAll();
        }
    }
}
