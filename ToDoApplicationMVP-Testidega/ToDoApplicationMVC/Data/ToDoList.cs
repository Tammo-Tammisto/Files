namespace ToDoApplicationMVC.Data
{
    public class ToDoList
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public IList<ToDoItem> Items { get; set; }

        public ToDoList() 
        { 
            Items = new List<ToDoItem>();
        }
    }
}