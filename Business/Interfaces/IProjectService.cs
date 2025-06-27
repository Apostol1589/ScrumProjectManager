using ScrumProjectManager.Data.Entities;

namespace ScrumProjectManager.Business.Interfaces
{
    public interface IProjectService
    {
        Task<List<Project>> GetAllAsync();
        Task<Project?> GetByIdAsync(int id);
        Task<Project> CreateAsync(Project project);
        Task<Project> UpdateAsync(Project project);
        Task DeleteAsync(int id);
    }
}
