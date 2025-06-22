using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Repositories;

namespace InternshipRegistrationSystem.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly RepositoryContext _context;

        public UserController(UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<Role> roleManager, RepositoryContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult CandidateSignUp()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CandidateSignUp([FromForm] User user)
        {
            if(user.Password != user.PasswordConfirm)
            {
                return View(user);
            }
            if (!ModelState.IsValid)
            {
                return View(user);
            }

            var createResult = await _userManager.CreateAsync(user, user.Password!);
            if (!createResult.Succeeded)
            {
                foreach (var error in createResult.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return View(user);
            }

            var roleResult = await _userManager.AddToRoleAsync(user, "Stajyer Adayı");
            if (!roleResult.Succeeded)
            {
                foreach (var error in roleResult.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return View(user);
            }

            return RedirectToAction("Login", "User");
        }
        [HttpGet]
        public IActionResult ProfessorSignUp()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ProfessorSignUp([FromForm] User user)
        {
            if (user.Password != user.PasswordConfirm)
            {
                return View(user);
            }
            if (!ModelState.IsValid)
            {
                return View(user);
            }

            var createResult = await _userManager.CreateAsync(user, user.Password!);
            if (!createResult.Succeeded)
            {
                foreach (var error in createResult.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return View(user);
            }

            var roleResult = await _userManager.AddToRoleAsync(user, "Profesör");
            if (!roleResult.Succeeded)
            {
                foreach (var error in roleResult.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return View(user);
            }

            return RedirectToAction("Login", "User");
        }
        [HttpGet]
        public async Task<IActionResult> ResearchAssistantSignUp()
        {

            var professorList = await _userManager.GetUsersInRoleAsync("Profesör");
            var professorSelectList = professorList.Select(p => new SelectListItem
            {
                Value = p.Id.ToString(),
                Text = p.Name + " " + p.Surname
            });
            ViewBag.Professor = professorSelectList;
            var categoryList = _context.Category.ToList();
            var categorySelectList = categoryList.Select(c => new SelectListItem
            {
                Value = c.CategoryId.ToString(),
                Text = c.Name
            }).ToList();
            ViewBag.Category = categorySelectList;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ResearchAssistantSignUp([FromForm] User user)
        {
            if (user.Password != user.PasswordConfirm)
            {
                return View(user);
            }
            var createResult = await _userManager.CreateAsync(user, user.Password!);

            if (createResult.Succeeded)
            {
                var roleName = "Araştırma Görevlisi";

                var roleExists = await _roleManager.RoleExistsAsync(roleName);
                if (!roleExists)
                {
                    var role = new Role
                    {
                        Name = roleName,
                        NormalizedName = roleName.ToUpperInvariant()
                    };
                    await _roleManager.CreateAsync(role);
                }

                var roleAssignResult = await _userManager.AddToRoleAsync(user, roleName);

                if (roleAssignResult.Succeeded)
                {
                    return RedirectToAction("Login", "User");
                }
                else
                {
                    foreach (var error in roleAssignResult.Errors)
                        ModelState.AddModelError("", error.Description);
                }
            }
            else
            {
                foreach (var error in createResult.Errors)
                    ModelState.AddModelError("", error.Description);
            }

            return View();
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login([FromForm] User user)
        {
            var response = await _signInManager.PasswordSignInAsync(user.UserName!, user.Password!, true, true);
            if (response.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "User");
        }

    }
}
