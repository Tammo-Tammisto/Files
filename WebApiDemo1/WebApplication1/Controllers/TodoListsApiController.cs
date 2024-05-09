using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoListsApiController : ControllerBase
    {
        private readonly ITodoListService _todoListService;

        public TodoListsApiController(ITodoListService todoListService)
        {
            _todoListService = todoListService;
        }

        [HttpGet("List")]
        public async Task<IActionResult> List(int page)
        {
            var lists = await _todoListService.List(page, 20);

            return Ok(lists);
        }

        [HttpGet("Get")]
        public async Task<IActionResult> Get(int id)
        {
            var model = await _todoListService.GetById(id);

            return Ok(model);
        }

        [HttpPost("Save")]
        public async Task<IActionResult> Save(TodoList model)
        {
            await _todoListService.Save(model);

            return Ok();
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            await _todoListService.Delete(id);

            return Ok();
        }
    }
}