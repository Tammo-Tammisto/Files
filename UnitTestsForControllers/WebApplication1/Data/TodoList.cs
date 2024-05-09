using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace WebApplication1.Data
{
    [ExcludeFromCodeCoverage]
    public class TodoList
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

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