using ResumeBuilder.Models.DomainModels;
using ResumeBuilder.Models.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using ResumeBuilder.Models.ViewModel;
using ResumeBuilder.Models.CvModel;

namespace ResumeBuilder.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IWebHostEnvironment _hostEnvironment;

        private readonly IUnitOfWork _unitOfWork;


        public HomeController(
            UserManager<IdentityUser> userManager,
            ILogger<HomeController> logger,
            IWebHostEnvironment hostEnvironment,
            IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _hostEnvironment = hostEnvironment;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult MyResumes()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> GetAllUserResume()
        {
            var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var resumes = await _unitOfWork.ResumeRepository.GetAllUserResume(userId);
            return Json(new { data = resumes });
        }
        [HttpGet]
        public IActionResult CreateResume(Guid? id)
        {
            var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            ResumeViewModel viewModel = new ResumeViewModel()
            {
                Resume = new Resume(),
                ResumeTemplates = _unitOfWork.ResumeTemplateRepository.GetAll().Select(
                    u => new SelectListItem
                    {
                        Text = u.TemplateName,
                        Value = u.Id.ToString()
                    })
            };
            if (id == null)
            {
                // create new 
                viewModel.Resume.UserId = userId;
                return View(viewModel);
            }
            viewModel.Resume = _unitOfWork.ResumeRepository
                .GetFirstOrDefault(u => u.Id == id);
            return View(viewModel);
        }
        [HttpPost]
        public async Task<IActionResult> CreateResume(ResumeViewModel obj, IFormFile? imageFile)
        {
            var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            obj.Resume.UserId = userId;
            if (ModelState.IsValid)
            {
                string wwwRootPath = _hostEnvironment.WebRootPath;
                if (imageFile != null)
                {
                    string fileName = Guid.NewGuid().ToString();
                    string uploads = Path.Combine(wwwRootPath,
                        @"images\");
                    string extension = Path.GetExtension(imageFile.FileName);

                    if (obj.Resume.ImageURL != null)
                    {
                        string oldImagePath = Path.Combine(wwwRootPath,
                            obj.Resume.ImageURL.TrimStart('\\'));
                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    using (var fileStreams = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                    {
                        imageFile.CopyTo(fileStreams);
                    }
                    obj.Resume.ImageURL = @"\images\" + fileName + extension;
                }

                if (obj.Resume.Id == null || obj.Resume.Id == Guid.Empty)
                {
                    _unitOfWork.ResumeRepository.Add(obj.Resume);
                    TempData["success"] = "Resume created Successfully";
                }
                else
                {
                    _unitOfWork.ResumeRepository.Update(obj.Resume);
                    TempData["success"] = "Resume updated Successfully";
                }
                _unitOfWork.Save();
                return RedirectToAction("Index", "Home", new { area = "Customer" });

            }
            else
            {
                var errors = ModelState.Select(x => x.Value.Errors)
                    .Where(y => y.Count > 0)
                    .ToList();
            }
            return View(obj);

        }
        public IActionResult Privacy()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ResumeBuilder.Models.ErrorViewModel() { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult ContactUs()
        {
            var contact = new Models.CvModel.ContactUs();
            return View(contact);
        }
        [HttpPost]
        public IActionResult ContactUs(ContactUs contactUs)
        {
            _unitOfWork.ContactUsRepository.Add(contactUs);
            _unitOfWork.Save();
            TempData["success"] = "Submit Successfully";
            return RedirectToAction("Index", "Home");
        }
        public IActionResult AboutUs()
        {
            return View();
        }
        //POST   
        [HttpDelete]
        public IActionResult Delete(Guid? id)
        {
            var obj = _unitOfWork.ResumeRepository.GetFirstOrDefault(u => u.Id == id);
            if (obj == null)
                return Json(new { success = false, message = "Error while deleting" });

            obj.IsDelete = true;

            _unitOfWork.ResumeRepository.Update(obj);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Delete successful" });

        }
    }
}
