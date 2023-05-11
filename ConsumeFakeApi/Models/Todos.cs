using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ConsumeFakeApi.Models
{
    public class Todos
    {

        [DisplayName("Todo Id")]
        public int Id { get; set; }

        [MinLength(2)]
        public string Title { get; set; }

        public bool Completed { get; set; }

        public Todos()
        {

        }

        public Todos(int id, string title, bool complete)
        {
            Id = id;
            Title = title;
            Completed = complete;

        }

    }
}
