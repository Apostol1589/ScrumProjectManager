namespace ScrumProjectManager.Data.Entities
{
    public class TaskItem
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Status { get; set; } = "ToDo";

        public int SprintId { get; set; }
        public Sprint Sprint { get; set; } = null!;
    }
}
