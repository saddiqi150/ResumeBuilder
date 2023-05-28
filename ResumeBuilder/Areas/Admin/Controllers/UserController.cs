using ResumeBuilder.Models.DomainModels;
using ResumeBuilder.Models.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using ResumeBuilder.Areas.Identity.Pages.Account;
using ResumeBuilder.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;

namespace ResumeBuilder.Controllers
{
	[Area("Admin")]
	[Authorize(Roles = "Admin")]
	public class UserController : Controller
	{

		private readonly IUnitOfWork _unitOfWork;

		private readonly SignInManager<IdentityUser> _signInManager;
		private readonly UserManager<IdentityUser> _userManager;
		private readonly ILogger<RegisterModel> _logger;
		private readonly IEmailSender _emailSender;
		private readonly RoleManager<IdentityRole> _roleManager;


		public UserController(
			UserManager<IdentityUser> userManager,
			SignInManager<IdentityUser> signInManager,
			ILogger<RegisterModel> logger,
			IEmailSender emailSender,
			IUnitOfWork unitOfWork,
			RoleManager<IdentityRole> roleManager)
		{
			_roleManager = roleManager;
			_userManager = userManager;
			_signInManager = signInManager;
			_logger = logger;
			_emailSender = emailSender;
			_unitOfWork = unitOfWork;
		}
		public IActionResult Index()
		{
			var objUsersList = _unitOfWork.User.GetAll();
			objUsersList = objUsersList.Where(x => x.IsAnnonymus == false);
			return View(objUsersList);
		}


		[HttpGet]
		public IActionResult Create()
		{
			var model = new Areas.Identity.Pages.Account.RegisterModel.InputModel();

			if (!_roleManager.RoleExistsAsync(SD.Role_User_Admin).GetAwaiter().GetResult())
			{
				_roleManager.CreateAsync(new IdentityRole(SD.Role_User_Admin)).GetAwaiter().GetResult();
				_roleManager.CreateAsync(new IdentityRole(SD.Role_User_User)).GetAwaiter().GetResult();
			}
			model.RoleList = _roleManager.Roles.Select(x => x.Name)
				.Select(i => new SelectListItem
				{
					Text = i,
					Value = i
				});

			return View(model);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(RegisterModel.InputModel model)
		{

			if (ModelState.IsValid)
			{
				var user = new ApplicationUser
				{
					UserName = model.Email,
					Email = model.Email,
					FirstName = model.FirstName,
					LastName = model.LastName,
					StreetAddress = model.StreetAddress,
					City = model.City,
					State = model.State,
					PostalCode = model.PostalCode,
					PhoneNumber = model.PhoneNumber,
					IsActive = true,
					IsAnnonymus = false,
					EmailConfirmed = true
				};

				var result = await _userManager.CreateAsync(user, model.Password);
				if (result.Succeeded)
				{
					if (model.Role == null)
					{
						await _userManager.AddToRoleAsync(user, SD.Role_User_User);
					}
					else
					{
						await _userManager.AddToRoleAsync(user, model.Role);
					}
					_logger.LogInformation("User created a new account with password.");
					return RedirectToAction("Index");
				}
				foreach (var error in result.Errors)
				{
					ModelState.AddModelError(string.Empty, error.Description);
				}
			}
			model.RoleList = _roleManager.Roles.Select(x => x.Name)
				.Select(i => new SelectListItem
				{
					Text = i,
					Value = i
				});
			
			return View(model);
		}

		[HttpGet]
		public IActionResult Edit(string userId)
		{
			var userObject = _unitOfWork.User.GetFirstOrDefault(u => u.Id == userId);
			if (userObject == null)
			{
				return NotFound();
			}
			return View(userObject);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Edit(ApplicationUser modelApplicationUser)
		{
			if (ModelState.IsValid)
			{
				var userObject = _unitOfWork.User.GetFirstOrDefault(u => u.Id == modelApplicationUser.Id);

				userObject.FirstName = modelApplicationUser.FirstName;
				userObject.LastName = modelApplicationUser.LastName;
				userObject.PhoneNumber = modelApplicationUser.PhoneNumber;
				userObject.State = modelApplicationUser.State;
				userObject.StreetAddress = modelApplicationUser.StreetAddress;
				userObject.City = modelApplicationUser.City;
				userObject.PostalCode = modelApplicationUser.PostalCode;
				userObject.IsActive = modelApplicationUser.IsActive;

				_unitOfWork.User.Update(userObject);
				_unitOfWork.Save();
				TempData["success"] = "User updated successfuly";
				return RedirectToAction("Index");
			}
			return View(modelApplicationUser);
		}

		[HttpGet]
		public IActionResult Delete(string userId)
		{
			var userObject = _unitOfWork.User.GetFirstOrDefault(u => u.Id == userId);
			if (userObject == null)
			{
				return NotFound();
			}
			return View(userObject);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Delete(ApplicationUser modelApplicationUser)
		{
			var userObject = _unitOfWork.User.GetFirstOrDefault(u => u.Id == modelApplicationUser.Id);
			if (userObject == null)
				return NotFound();

			_unitOfWork.User.Remove(userObject);
			_unitOfWork.Save();
			TempData["success"] = "User deleted successfuly";
			return RedirectToAction("Index");

		}

	}
}
