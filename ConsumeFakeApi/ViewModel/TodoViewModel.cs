using System.ComponentModel.DataAnnotations;

namespace ConsumeFakeApi.ViewModel
{
    public class TodoViewModel
    {
        [Required(ErrorMessage = "Todo Title is required")]
        [MinLength(2)] // where title should be minimum of 2 characters
        public string Title { get; set; }

        public bool Completed { get; set; }


        public TodoViewModel()
        {
        }
        public TodoViewModel(string title, bool completed_)
        {
            Title = title;
            Completed = completed_;
        }


    }
}
