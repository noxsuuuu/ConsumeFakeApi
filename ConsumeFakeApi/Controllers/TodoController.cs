using ConsumeFakeApi.Models;
using ConsumeFakeApi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ConsumeFakeApi.Controllers
{
    public class TodoController : Controller
    {
        // inmemory
        // database
        // RDBMS
        // NoSQL
        // Files

        ITodoRepository _repo;

        // tightly coupled object 
        //ITodoRepository _repo = new InMemoryRepository();
        //ITodoRepository _repo1 = new DBRepository();

        // lossely coupled implementation
        public TodoController(ITodoRepository repo)
        {
            this._repo = repo;
        }
        // [AllowAnonymous]
        public IActionResult GetAllTodos(string searchString)
        {
            var todolists = from todoss in _repo.GetAllTodos()
                            select todoss;

            if (!String.IsNullOrEmpty(searchString))
            {
                todolists = todolists.Where(s => s.Title.ToLower().Contains(searchString.Trim().ToLower()));
                return View(todolists.ToList());
            }

            var todolist = _repo.GetAllTodos();
            return View(todolist);
        }
        public IActionResult Details(int todoId)
        {
            var todo = _repo.GetTodoById(todoId);
            return View(todo);
        }
        public IActionResult Delete(int todoId)
        {
            var todo = _repo.GetTodoById(todoId);
            var todolist = _repo.DeleteTodo(todoId);
            return RedirectToAction(controllerName: "Todo", actionName: "GetAllTodos"); // reload the getall page it self
        }

        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Create(Todos newTodo) // model binded this where the views data is accepted 
        {
            if (ModelState.IsValid)
            {
                var todo = _repo.AddTodo(newTodo);
                return RedirectToAction(controllerName: "Todo", actionName: "GetAllTodos");
            }
            ViewData["Message"] = "Data is not valid to create the Todo";
            return View();
        }

        [HttpGet]
        public IActionResult Update(int todoId)
        {
            var oldTodo = _repo.GetTodoById(todoId);
            return View(oldTodo);
        }
        [HttpPost]
        public IActionResult Update(Todos newTodo)
        {
            var todo = _repo.UpdateTodo(newTodo.Id, newTodo);
            return RedirectToAction(controllerName: "Todo", actionName: "GetAllTodos");
        }
    }
    }
