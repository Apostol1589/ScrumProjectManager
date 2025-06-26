using Microsoft.AspNetCore.Mvc;
using ScrumProjectManager.Data.Entities;
using ScrumProjectManager.Data;
using Microsoft.EntityFrameworkCore;

namespace ScrumProjectManager.Controllers
{
    //[Route("task")]
    public class TaskController : Controller
    {
        private readonly AppDbContext _context;

        public TaskController(AppDbContext context) => _context = context;

        //[Route("edit/{id:int:min(1)}")]
        public async Task<IActionResult> Index()
        {
            var tasks = await _context.Tasks.Include(t => t.AssignedUser).Include(t => t.Sprint).ToListAsync();
            return View(tasks);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task == null) return NotFound();

            ViewBag.Users = await _context.Users.ToListAsync();
            return View(task);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(TaskItem task)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Users = await _context.Users.ToListAsync();
                return View(task);
            }

            _context.Tasks.Update(task);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
