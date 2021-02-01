using System.ComponentModel.DataAnnotations;

namespace ToDo.ViewModels
{
    public class ToDoItemUpdateModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public bool IsActive { get; set; } = true;

        [Required]
        public string Note { get; set; }

        [Required]
        public bool IsDone { get; set; }

        [Required]
        public int Order { get; set; }
    }
}
