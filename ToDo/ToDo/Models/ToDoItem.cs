using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDo.Models
{
    public class ToDoItem
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "bit")]
        public bool IsActive { get; set; } = true;

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string Note { get; set; }

        [Required]
        [Column(TypeName = "bit")]
        public bool IsDone { get; set; }

        [Required]
        [Column(TypeName = "int")]
        public int Order { get; set; }
    }
}
