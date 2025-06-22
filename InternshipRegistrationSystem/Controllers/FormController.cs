using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Repositories.Contract;
using Services.Contract;

namespace InternshipRegistrationSystem.Controllers
{
    public class FormController : Controller
    {
        private readonly RepositoryContext _context;
        private readonly IServiceManager _serviceManager;
        private readonly UserManager<User> _userManager;

        public FormController(RepositoryContext context, IServiceManager serviceManager, UserManager<User> userManager)
        {
            _context = context;
            _serviceManager = serviceManager;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult RegistrationForm()
        {
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
        public async Task<IActionResult> Submit([FromForm] RegistrationForm registrationForm)
        {
            try
            {
                var user = await _userManager.GetUserAsync(User);
                registrationForm.CandidateId = user!.Id;
                _serviceManager.RegistrationFormService.CreateOne(registrationForm);
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home", ex.Message);
            }
        }
        [HttpGet]
        public async Task<IActionResult> RegistrationList()
        {
            try
            {
                var registrationList = _serviceManager.RegistrationFormService.GetAll(false);
                var registrationListQueryable = registrationList.AsQueryable().Include(r => r.Status);
                var currentUser = await _userManager.GetUserAsync(User);
                var userId = currentUser!.Id;
                var registrationListByCurrentCandidate = registrationListQueryable.Where(r => r.CandidateId.Equals(userId));
                var registrationListByCurrentCandidateList = registrationListByCurrentCandidate.ToList();
                return View(registrationListByCurrentCandidateList);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home", ex.Message);
            }
        }
        [HttpGet]
        public async Task<IActionResult> ApplicationsPendingAssistantApproval()
        {
            try
            {
                var registrationList = _serviceManager.RegistrationFormService.GetAll(false);
                var registrationListQueryable = registrationList.AsQueryable().Include(r => r.Status);
                var currentUser = await _userManager.GetUserAsync(User);
                
                var categoryId = currentUser!.CategoryId;
                var registrationListByCurrentCandidate = registrationListQueryable.Where(r => r.CategoryId.Equals(categoryId) && r.StatusId.Equals(1));
                var registrationListByCurrentCandidateList = registrationListByCurrentCandidate.ToList();
                return View(registrationListByCurrentCandidateList);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home", ex.Message);
            }
        }
        [HttpGet]
        public async Task<IActionResult> ApplicationsPendingAdministratorApproval()
        {
            try
            {
                var registrationList = _serviceManager.RegistrationFormService.GetAll(false);
                var registrationListQueryable = registrationList.AsQueryable().Include(r => r.Status);
                var currentUser = await _userManager.GetUserAsync(User);

                var professorId = currentUser!.Id;
                var registrationListByCurrentCandidate = registrationListQueryable.Where(r => r.ProfessorId.Equals(professorId) && r.StatusId.Equals(3));
                var registrationListByCurrentCandidateList = registrationListByCurrentCandidate.ToList();
                return View(registrationListByCurrentCandidateList);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home", ex.Message);
            }
        }
        [HttpGet]
        public async Task<IActionResult> ResearchApprove([FromRoute] int id)
        {
            try
            {
                var currentUser = await _userManager.GetUserAsync(User);
                var professorId = currentUser!.ProfessorId;
                var registrationModel = _serviceManager.RegistrationFormService.GetOne(id, true);
                registrationModel!.StatusId = 3;
                registrationModel!.ProfessorId = professorId;
                _serviceManager.RegistrationFormService.UpdateOne(registrationModel);
                return View("ApplicationsPendingAssistantApproval");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home", ex.Message);
            }
        }
        [HttpGet]
        public IActionResult ResearchReject([FromRoute] int id)
        {
            try
            {
                var registrationModel = _serviceManager.RegistrationFormService.GetOne(id, true);
                registrationModel!.StatusId = 2;
                _serviceManager.RegistrationFormService.UpdateOne(registrationModel);
                return View("ApplicationsPendingAssistantApproval");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home", ex.Message);
            }
        }
        [HttpGet]
        public async Task<IActionResult> AdministratorApprove([FromRoute] int id)
        {
            try
            {
                var currentUser = await _userManager.GetUserAsync(User);
                var professorId = currentUser!.ProfessorId;
                var registrationModel = _serviceManager.RegistrationFormService.GetOne(id, true);
                var applicantId = registrationModel!.CandidateId;
                var candidated = await _userManager.FindByIdAsync(applicantId.ToString()!);
                registrationModel!.StatusId = 4;
                await _userManager.AddToRoleAsync(candidated!, "Stajyer");
                _serviceManager.RegistrationFormService.UpdateOne(registrationModel);
                return View("ApplicationsPendingAdministratorApproval");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home", ex.Message);
            }
        
        }
        [HttpGet]
        public IActionResult AdministratorReject([FromRoute] int id)
        {
            try
            {
                var registrationModel = _serviceManager.RegistrationFormService.GetOne(id, true);
                registrationModel!.StatusId = 2;
                _serviceManager.RegistrationFormService.UpdateOne(registrationModel);
                return View("ApplicationsPendingAdministratorApproval");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home", ex.Message);
            }
        }
    }
}
