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

        public string Title { get; set; }

        public bool Done { get; set; }
    }
}
