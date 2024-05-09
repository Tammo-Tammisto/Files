using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Data
{
    public class TodoItem : Entity
    {
        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        public string Description { get; set; }

        public bool IsDone { get; set; }

        public int TodoListId { get; set; }
        public TodoList TodoList { get; set; }
    }
}