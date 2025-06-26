using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ScrumProjectManager.Data;
using ScrumProjectManager.Data.Entities;

namespace ScrumProjectManager.Controllers
{
    public class SprintController : Controller
    {
        private readonly AppDbContext _context;

        public SprintController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var sprints = await _context.Sprints.Include(s => s.Project).ToListAsync();
            return View(sprints);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Sprint sprint)
        {
            if (!ModelState.IsValid) return View(sprint);

            _context.Sprints.Add(sprint);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
