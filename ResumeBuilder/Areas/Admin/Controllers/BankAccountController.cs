using FundRaiserWeb.Models.DataLayer;
using FundRaiserWeb.Models.DomainModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace FundRaiserWeb.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
	public class BankAccountController : Controller
    {


        private readonly FundRaiserWebContext _db;

        public BankAccountController(FundRaiserWebContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<BankAccount> objBankAccList = _db.BankAccounts;
            return View(objBankAccList);
        }

        [HttpGet]
        public IActionResult FindAcc(int? UserAccountId)
        {
            if (UserAccountId == null || UserAccountId == 0)
            {
                return NotFound();
            }

            var BankAccFromDB = _db.BankAccounts.Find(UserAccountId);
            if (BankAccFromDB == null)
            {
                return NotFound();
            }
            return View(BankAccFromDB);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(BankAccount obj)
        {
            if (ModelState.IsValid)
            {
                _db.BankAccounts.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Bank account added successfuly";
                return RedirectToAction("Index");
            }
            return View(obj);
        }
    }
}