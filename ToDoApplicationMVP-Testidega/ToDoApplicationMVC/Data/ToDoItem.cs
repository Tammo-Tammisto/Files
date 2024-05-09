namespace ToDoApplicationMVC.Data
{
    public class ToDoItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsDone { get; set; }

        public ToDoList List { get; set; }
        public int ListId { get; set; }
    }
}