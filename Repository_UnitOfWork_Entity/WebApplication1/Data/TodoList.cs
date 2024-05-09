using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Data
{
    public class TodoList : Entity
    {
        [Required]
        [MaxLength(50, ErrorMessage = "Pealkirja maksimaalne pikkus on 50 tähemärki")]
        
        public string Title { get; set; }

        public IList<TodoItem> Items { get; set; }

        public TodoList()
        {
            Items = new List<TodoItem>();
        }
    }
}