using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using ResumeBuilder.Models.DomainModels;
using Microsoft.AspNetCore.Authorization;
using ResumeBuilder.Models.Repository.IRepository;



namespace ResumeBuilder.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,User")]
    public class ResumeTemplatesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public ResumeTemplatesController(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            IUnitOfWork unitOfWork,
            RoleManager<IdentityRole> roleManager,
            IWebHostEnvironment hostEnvironment)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _signInManager = signInManager;
            _unitOfWork = unitOfWork;
            _hostEnvironment = hostEnvironment;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Upsert(Guid? id)
        {
            var resumeTemplate = new ResumeTemplate();
            if (id == null)
            {
                // create new project
                return View(resumeTemplate);
            }
            resumeTemplate = _unitOfWork.ResumeTemplateRepository
                .GetFirstOrDefault(u => u.Id == id);
            return View(resumeTemplate);

        }

        [HttpPost]
        public async Task<IActionResult> Upsert(ResumeTemplate obj)
        {
            if (ModelState.IsValid)
            {
                if (obj.Id == null || obj.Id == Guid.Empty)
                {
                    _unitOfWork.ResumeTemplateRepository.Add(obj);
                    TempData["success"] = "Template created Successfully";
                }
                else
                {
                    _unitOfWork.ResumeTemplateRepository.Update(obj);
                    TempData["success"] = "Template updated Successfully";
                }
                _unitOfWork.Save();

                var user = await _userManager.GetUserAsync(User);
                // get the user manager from the owin context
                // get user roles
                var roles = await _userManager.GetRolesAsync(user);
                if (roles.Contains("Admin"))
                    return RedirectToAction("Index");
                return RedirectToAction("Index", "Home", new { area = "Customer" });

            }
            return View(obj);

        }
        [HttpGet]
        public async Task<IActionResult> ViewResume()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> ViewContactUs()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> AdminManagement()
        {
            return View();
        }
        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            var projList = _unitOfWork.ResumeTemplateRepository
                .GetAll()
                .Where(x => x.IsDeleted == false);
            return Json(new { data = projList });
        }
        [HttpGet]
        public IActionResult GetAllContactFeedBack()
        {
            var contactList = _unitOfWork.ContactUsRepository
                .GetAll();
            return Json(new { data = contactList });
        }
        [HttpDelete]
        public IActionResult Delete(Guid? id)
        {
            var obj = _unitOfWork.ResumeTemplateRepository.GetFirstOrDefault(u => u.Id == id);
            if (obj == null)
                return Json(new { success = false, message = "Error while deleting" });

            obj.IsDeleted = true;

            _unitOfWork.ResumeTemplateRepository.Update(obj);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Delete successful" });

        }
        #endregion
    }

}

