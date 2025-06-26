using ScrumProjectManager.Validators;
using System.ComponentModel.DataAnnotations;

namespace ScrumProjectManager.Data.Entities
{
    public class Project
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        [StartDateValidation]
        public DateTime StartDate { get; set; }
        public List<Sprint> Sprints { get; set; } = new();
    }
}
