using System;
using System.Linq;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PuppeteerSharp.Media;
using ResumeBuilder.Controllers;
using ResumeBuilder.CvLogic;
using ResumeBuilder.Models.CvModel;
using ResumeBuilder.Models.Repository.IRepository;

namespace ResumeBuilder.Controllers
{
    [Area("Customer")]
    public class CvController : Controller
    {

        private readonly ILogger<HomeController> logger;
        private readonly IWebHostEnvironment env;
        private readonly IUnitOfWork _unitOfWork;
        private readonly Dictionary<string, Template> templates;
        private readonly HtmlToPdfConverter converter;


        public CvController(ILogger<HomeController> logger, IWebHostEnvironment env,
             HtmlToPdfConverter converter, Dictionary<string, Template> templates, IUnitOfWork unitOfWork)
        {
            this.logger = logger;
            this.env = env;
            this.converter = converter;
            this.templates = templates;
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> GetAllUserCv()
        {
            var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var resumes = await _unitOfWork.CvInformationRepository.GetAllUserResume(userId);
            return Json(new { data = resumes });
        }

        [HttpGet]
        public IActionResult GetAllUsersCvs()
        {
            var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var resumes =  _unitOfWork.CvInformationRepository.GetAll();
            return Json(new { data = resumes });
        }
        
        public IActionResult CreateCv()
        {
            var cv = new CvInformation();
            var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            cv.UserId = userId;
            return View(cv);
        }
        [HttpPost]
        public async Task<IActionResult> Preview(CvInformation cv)
        {
            byte[] pdfContent = await CreatePdf(cv);
            return Ok(Convert.ToBase64String(pdfContent));
        }

        [HttpPost]
        public async Task<IActionResult> GetHtml(CvInformation cv)
        {
            var html = await CreateHtml(cv);
            return File(Encoding.UTF8.GetBytes(html), "text/html", "cv.html");
        }
        [HttpPost]
        public async Task<IActionResult> GetPdf(CvInformation cv)
        {
            byte[] pdfContent = await CreatePdf(cv);
            return File(pdfContent, "application/pdf", "cv.pdf");
        }
        public async Task<IActionResult> DownloadPdf(Guid id)
        {
            var cv = _unitOfWork.CvInformationRepository.GetCv(id);

            byte[] pdfContent = await CreatePdf(cv);
            return File(pdfContent, "application/pdf", "cv.pdf");
        }
        [HttpPost]
        public async Task<IActionResult> CreateCv(CvInformation cv)
        {
            var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            cv.UserId = userId;
            if (!ModelState.IsValid)
            {
                return View(cv);
            }
            else
            {
                var errors = ModelState.Select(x => x.Value.Errors)
                    .Where(y => y.Count > 0)
                    .ToList();
            }
            if (cv.AgreeSave)
            {
                _unitOfWork.CvInformationRepository.Add(cv);
                _unitOfWork.Save();
            }
            TempData["success"] = "Resume Created Successfully";
            return RedirectToAction("Index", "Cv");
        }

        private async Task<string> CreateHtml(CvInformation cv)
        {
            CleanupEmptyListItems(cv);
            var selectedTemplate = templates[cv.TemplateName];
            return await Task.Run(() => selectedTemplate.Renderer.FillData(cv));
        }

        private async Task<byte[]> CreatePdf(CvInformation cv)
        {
            var html = await CreateHtml(cv);
            var paperFormat = cv.PaperSize == "A4" ? PaperFormat.A4 : PaperFormat.Letter;
            return await converter.ConvertToPdf(null, html, paperFormat, cv.Margin, cv.Scale / 100m);
        }
        //POST   
        [HttpDelete]
        public IActionResult Delete(Guid? id)
        {
            var obj = _unitOfWork.CvInformationRepository.GetFirstOrDefault(u => u.Id == id);
            if (obj == null)
                return Json(new { success = false, message = "Error while deleting" });

            obj.IsDelete = true;

            _unitOfWork.CvInformationRepository.Update(obj);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Delete successful" });

        }
        private void CleanupEmptyListItems(CvInformation cv)
        {
            foreach (var item in cv.Educations.Where(x => x.StartYear == 0 || x.Title == null).ToList())
                cv.Educations.Remove(item);
            foreach (var item in cv.Employments.Where(x => x.StartYear == 0 || x.JobTitle == null).ToList())
                cv.Employments.Remove(item);
            foreach (var item in cv.Languages.Where(x => x.Name == null).ToList())
                cv.Languages.Remove(item);
            foreach (var item in cv.Projects.Where(x => x.Year == 0 || x.Name == null).ToList())
                cv.Projects.Remove(item);
        }
        private IActionResult GetEditorTemplatePartialView(string name) => PartialView("EditorTemplates/" + name);

        public IActionResult AddSkillSet() => GetEditorTemplatePartialView(nameof(CvSkillSet));

        public IActionResult AddEducation() => GetEditorTemplatePartialView(nameof(CvEducation));

        public IActionResult AddEmployment() => GetEditorTemplatePartialView(nameof(CvEmployment));

        public IActionResult AddLanguageSkill() => GetEditorTemplatePartialView(nameof(CvLanguageSkill));

        public IActionResult AddProject() => GetEditorTemplatePartialView(nameof(CvProject));
    }
}
