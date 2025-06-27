using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ScrumProjectManager.Business.Interfaces;
using ScrumProjectManager.Data.Entities;

namespace ScrumProjectManager.Controllers
{
    public class SprintController : Controller
    {
        private readonly ISprintService _sprintService;
        private readonly IProjectService _projectService;

        public SprintController(ISprintService sprintService, IProjectService projectService)
        {
            _sprintService = sprintService;
            _projectService = projectService;
        }

        public async Task<IActionResult> Index()
        {
            var sprints = await _sprintService.GetAllAsync();
            return View(sprints);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Projects = new SelectList(await _projectService.GetAllAsync(), "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Sprint sprint)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Projects = new SelectList(await _projectService.GetAllAsync(), "Id", "Name");
                return View(sprint);
            }

            await _sprintService.CreateAsync(sprint);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var sprint = await _sprintService.GetByIdAsync(id);
            if (sprint == null) return NotFound();

            ViewBag.Projects = new SelectList(await _projectService.GetAllAsync(), "Id", "Name", sprint.ProjectId);
            return View(sprint);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Sprint sprint)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Projects = new SelectList(await _projectService.GetAllAsync(), "Id", "Name", sprint.ProjectId);
                return View(sprint);
            }

            await _sprintService.UpdateAsync(sprint);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _sprintService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
