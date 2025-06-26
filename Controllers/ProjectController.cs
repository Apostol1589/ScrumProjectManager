using Microsoft.AspNetCore.Mvc;
using ScrumProjectManager.Business.Interfaces;
using ScrumProjectManager.Data.Entities;

namespace ScrumProjectManager.Controllers
{
    //[Route("management/[controller]/[action]")]
    public class ProjectController : Controller
    {
        private readonly IProjectService _projectService;

        
        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        public async Task<IActionResult> Index()
        {
            var projects = await _projectService.GetAllAsync();
            return View(projects);
        }

        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(Project project)
        {
            if (!ModelState.IsValid) return View(project);
            await _projectService.CreateAsync(project);
            return RedirectToAction(nameof(Index));
        }
    }
}
