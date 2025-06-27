using Microsoft.EntityFrameworkCore;
using ScrumProjectManager.Business.Interfaces;
using ScrumProjectManager.Data;
using ScrumProjectManager.Data.Entities;

namespace ScrumProjectManager.Business.Services
{
    public class SprintService : ISprintService
    {
        private readonly AppDbContext _context;

        public SprintService(AppDbContext context) => _context = context;

        public async Task<List<Sprint>> GetAllAsync()
            => await _context.Sprints.Include(s => s.Project).ToListAsync();

        public async Task<Sprint?> GetByIdAsync(int id)
            => await _context.Sprints.FindAsync(id);

        public async Task<Sprint> CreateAsync(Sprint sprint)
        {
            _context.Sprints.Add(sprint);
            await _context.SaveChangesAsync();
            return sprint;
        }

        public async Task<Sprint> UpdateAsync(Sprint sprint)
        {
            _context.Sprints.Update(sprint);
            await _context.SaveChangesAsync();
            return sprint;
        }

        public async Task DeleteAsync(int id)
        {
            var sprint = await _context.Sprints.FindAsync(id);
            if (sprint != null)
            {
                _context.Sprints.Remove(sprint);
                await _context.SaveChangesAsync();
            }
        }
    }
}
