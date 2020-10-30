﻿using System.Threading.Tasks;
using CreditCards.Core.Interfaces;
using CreditCards.Core.Model;
using CreditCards.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CreditCards.Controllers
{
    public class ApplyController : Controller
    {
        private readonly ICreditCardApplicationRepository _applicationRepository;

        public ApplyController(ICreditCardApplicationRepository applicationRepository)
        {
            _applicationRepository = applicationRepository;
        }
        public IActionResult Index()
        {
            var model = new NewCreditCardApplicationDetails();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(NewCreditCardApplicationDetails applicationDetails)
        {
            if (!ModelState.IsValid)
            {
                return View(applicationDetails);
            }

            var creditCardApplication = new CreditCardApplication
            {
                FirstName = applicationDetails.FirstName,
                LastName = applicationDetails.LastName,
                Age = applicationDetails.Age.Value,
                FrequentFlyerNumber = applicationDetails.FrequentFlyerNumber,
                GrossAnnualIncome = applicationDetails.GrossAnnualIncome.Value
            };

            await _applicationRepository.AddAsync(creditCardApplication);

            return View("ApplicationComplete", creditCardApplication);
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
