namespace ToDo.ViewModels
{
    public class ToDoItemViewModel
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public string Note { get; set; }
        public bool IsDone { get; set; }
        public int Order { get; set; }
    }
}
