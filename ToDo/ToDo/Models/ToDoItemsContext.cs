using Microsoft.EntityFrameworkCore;

namespace ToDo.Models
{
    public class ToDoItemsContext : DbContext
    {
        public ToDoItemsContext(DbContextOptions<ToDoItemsContext> options) : base(options)
        {

        }

        public DbSet<ToDoItem> ToDoItems { get; set; }
    }
}
