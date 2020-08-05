using System.ComponentModel.DataAnnotations;

namespace TODO_WASM.Models
{
    public class TodoItem
    {
        public TodoItem()
        {
        }

        public TodoItem(string title, bool done = false)
            : this()
        {
            Title = title;
            Done = done;
        }

        [Required]
        [MinLength(1)]
        [MaxLength(128)]
        public string Title { get; set; }

        public bool Done { get; set; }
    }
}
