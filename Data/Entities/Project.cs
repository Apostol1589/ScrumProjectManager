using System.ComponentModel.DataAnnotations;

namespace ScrumProjectManager.Data.Entities
{
    public class Project
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        public List<Sprint> Sprints { get; set; } = new();
    }
}
