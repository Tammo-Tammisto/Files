using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
    public class TodoListControllerTests
    {
        private readonly TodoListsController _controller;
        private readonly Mock<ITodoListService> _mockTodoListService;

        public TodoListControllerTests()
        {
            _mockTodoListService = new Mock<ITodoListService>();
            _controller = new TodoListsController(_mockTodoListService.Object);
        }

        [Fact]
        public async Task Details_should_return_notfound_when_id_is_missing()
        {
            // Arrange            
            var id = (int?)null;

            // Act
            var result = await _controller.Details(id) as NotFoundResult;

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task Details_should_return_notfound_when_todo_list_is_not_found()
        {
            // Arrange
            TodoList todoList = null;
            int id = 4;
            _mockTodoListService.Setup(srv => srv.GetById(id))
                                .ReturnsAsync(todoList)
                                .Verifiable();

            // Act
            var result = await _controller.Details(id) as NotFoundResult;

            // Assert
            Assert.NotNull(result);
            _mockTodoListService.VerifyAll();
        }

        [Fact]
        public async Task Details_should_return_details_view_when_todo_list_exists()
        {
            // Arrange
            int id = 4;
            TodoList todoList = new TodoList { Id = id, Title = "Todo list" };
            _mockTodoListService.Setup(srv => srv.GetById(id))
                                .ReturnsAsync(todoList)
                                .Verifiable();

            // Act
            var result = await _controller.Details(id) as ViewResult;

            // Assert
            Assert.NotNull(result);
            Assert.True(result.ViewName == "Details" ||
                        string.IsNullOrEmpty(result.ViewName));
            Assert.True(result.Model == todoList);
            _mockTodoListService.VerifyAll();
        }
    }
}