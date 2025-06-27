using ScrumProjectManager.Data.Entities;

namespace ScrumProjectManager.Business.Interfaces
{
    public interface ISprintService
    {
        Task<List<Sprint>> GetAllAsync();
        Task<Sprint?> GetByIdAsync(int id);
        Task<Sprint> CreateAsync(Sprint sprint);
        Task<Sprint> UpdateAsync(Sprint sprint);
        Task DeleteAsync(int id);
    }
}
