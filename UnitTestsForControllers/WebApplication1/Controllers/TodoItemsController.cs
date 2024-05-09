using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication1.Data;
using WebApplication1.Data.Queries;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    public class TodoItemsController : Controller
    {
        private readonly ITodoItemService _todoItemService;
        private readonly ITodoListService _todoListService;

        public TodoItemsController(ITodoItemService todoItemService, ITodoListService todoListService)
        {
            _todoItemService = todoItemService;
            _todoListService = todoListService;
        }

        public async Task<IActionResult> Index(int page = 1, TodoItemQuery query = null)
        {
            var items = new PagedResult<TodoItem>();

            if (!query.IsEmpty())
            {
                items = await _todoItemService.List(page, pageSize: 5, query);
            }

            await FillTodoLists(query.ListId);

            return View(items);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var todoItem = await _todoItemService.GetById(id.Value);
            if (todoItem == null)
            {
                return NotFound();
            }

            return View(todoItem);
        }

        public async Task<IActionResult> Create()
        {
            await FillTodoLists(null);

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,IsDone,TodoListId")] TodoItem todoItem)
        {
            ModelState.Remove("TodoList");

            if (ModelState.IsValid)
            {
                await _todoItemService.Save(todoItem);
                return RedirectToAction(nameof(Index));
            }

            await FillTodoLists(null);

            return View(todoItem);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var todoItem = await _todoItemService.GetById(id.Value);
            if (todoItem == null)
            {
                return NotFound();
            }

            await FillTodoLists(todoItem.TodoListId);

            return View(todoItem);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, TodoItem todoItem)
        {
            if (id != todoItem.Id)
            {
                return NotFound();
            }

            var todoItemInDb = await _todoItemService.GetById(id);
            todoItemInDb.Description = todoItem.Description;
            todoItemInDb.IsDone = todoItem.IsDone;
            todoItemInDb.Title = todoItem.Title;
            todoItemInDb.TodoListId = todoItem.TodoListId;

            if (ModelState.IsValid)
            {
                await _todoItemService.Save(todoItem);
                return RedirectToAction(nameof(Index));
            }

            await FillTodoLists(todoItem.TodoListId);

            return View(todoItem);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var todoItem = await _todoItemService.GetById(id.Value);
            if (todoItem == null)
            {
                return NotFound();
            }

            return View(todoItem);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _todoItemService.Delete(id);

            return RedirectToAction(nameof(Index));
        }

        [NonAction]
        private async Task FillTodoLists(int? todoListId)
        {
            var items = await _todoListService.Lookup();
            var selectList = new SelectList(items, "Id", "Title", todoListId);           

            ViewData["TodoListId"] = selectList;
        }
    }
}