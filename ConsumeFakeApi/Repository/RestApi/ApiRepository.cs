using ConsumeFakeApi.Models;
using ConsumeFakeApi.ViewModel;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Text;



namespace ConsumeFakeApi.Repository.RestApi
{
    public class ApiRepository : ITodoRepository
    {
        string baseURL = "https://jsonplaceholder.typicode.com";

        HttpClient httpClient = new HttpClient();

        public ApiRepository()
        {
        }

        public Todos AddTodo(Todos newTodo)
        {

            TodoViewModel todoVM = new TodoViewModel();
            todoVM.Title = newTodo.Title;
            todoVM.Completed = newTodo.Completed;


            string data = JsonConvert.SerializeObject(todoVM);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");

            var response = httpClient.PostAsync(baseURL + "/todos", content).Result;
            if (response.IsSuccessStatusCode)
            {
                var responsecontent = response.Content.ReadAsStringAsync().Result;
                Todos todo = JsonConvert.DeserializeObject<Todos>(responsecontent);
                return todo;
            }
            return null;
        }

        public Todos DeleteTodo(int todoId)
        {
            var response = httpClient.DeleteAsync(baseURL + "/todos/" + todoId).Result;
            if (response.IsSuccessStatusCode)
            {
                var data = response.Content.ReadAsStringAsync().Result;// json standard
                Todos todo = JsonConvert.DeserializeObject<Todos>(data);
                return todo;
            }
            return null;
        }

        public List<Todos> GetAllTodos()
        {
            var response = httpClient.GetAsync(baseURL + "/todos").Result;
            if (response.IsSuccessStatusCode)
            {
                var data = response.Content.ReadAsStringAsync().Result;// json standard
                List<Todos> todos = JsonConvert.DeserializeObject<List<Todos>>(data);
                return todos;
            }
            return null;
        }

        public Todos GetTodoById(int Id)
        {
            var response = httpClient.GetAsync(baseURL + "/todos/" + Id).Result;
            if (response.IsSuccessStatusCode)
            {
                var data = response.Content.ReadAsStringAsync().Result;// json standard
                Todos todo = JsonConvert.DeserializeObject<Todos>(data);
                return todo;
            }
            return null;
        }

        public Todos UpdateTodo(int todoId, Todos newTodo)
        {
            string data = JsonConvert.SerializeObject(newTodo);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");

            var response = httpClient.PutAsync(baseURL + "/todos/" + todoId, content).Result;
            if (response.IsSuccessStatusCode)
            {
                var responsecontent = response.Content.ReadAsStringAsync().Result;
                Todos todo = JsonConvert.DeserializeObject<Todos>(responsecontent);
                return todo;
            }
            return null;
        }


    }
}
