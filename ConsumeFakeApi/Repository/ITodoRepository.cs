using ConsumeFakeApi.Models;

namespace ConsumeFakeApi.Repository
{
    public interface ITodoRepository
    {
        List<Todos> GetAllTodos();
        Todos GetTodoById(int Id);

        // add todo into the list
        Todos AddTodo(Todos newTodo);

        // update todo in the list
        Todos UpdateTodo(int todoId, Todos newTodo);

        // delete 
        Todos DeleteTodo(int todoId);
    }
}
