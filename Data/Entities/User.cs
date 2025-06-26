namespace ScrumProjectManager.Data.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Role { get; set; } = "Developer";
    }
}
