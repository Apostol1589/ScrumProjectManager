using Microsoft.EntityFrameworkCore;
using ScrumProjectManager.Business.Interfaces;
using ScrumProjectManager.Data;
using ScrumProjectManager.Data.Entities;
using System;

namespace ScrumProjectManager.Business.Services
{
    public class ProjectService : IProjectService
    {
        private readonly AppDbContext _context;

        public ProjectService(AppDbContext context) => _context = context;

        public async Task<List<Project>> GetAllAsync() => await _context.Projects.ToListAsync();

        public async Task<Project?> GetByIdAsync(int id) => await _context.Projects.FindAsync(id);

        public async Task<Project> CreateAsync(Project project)
        {
            _context.Projects.Add(project);
            await _context.SaveChangesAsync();
            return project;
        }
    }

}
