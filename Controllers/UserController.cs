using Microsoft.AspNetCore.Mvc;
using ScrumProjectManager.Business.Interfaces;
using ScrumProjectManager.Data.Entities;

namespace ScrumProjectManager.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService) => _userService = userService;

        public async Task<IActionResult> Index()
        {
            var users = await _userService.GetAllAsync();
            return View(users);
        }

        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            if (!ModelState.IsValid) return View(user);

            await _userService.CreateAsync(user);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var user = await _userService.GetByIdAsync(id);
            if (user == null) return NotFound();
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(User user)
        {
            if (!ModelState.IsValid) return View(user);

            await _userService.UpdateAsync(user);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _userService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
