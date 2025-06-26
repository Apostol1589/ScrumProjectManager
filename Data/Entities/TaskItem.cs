using ScrumProjectManager.Validators.ScrumProjectManager.Validators;
using System.ComponentModel.DataAnnotations;

namespace ScrumProjectManager.Data.Entities
{
    public class TaskItem
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;

        [Required]
        [TaskStatusValidation]
        public string Status { get; set; } = "ToDo";

        public int SprintId { get; set; }
        public Sprint Sprint { get; set; } = null!;

        [Required]
        public int? AssignedUserId { get; set; } 
        public User? AssignedUser { get; set; }
    }

}
