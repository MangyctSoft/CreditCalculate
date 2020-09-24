using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CreditApplication.Models;
using CreditApplication.Core.Domain;
using CreditApplication.Models.Home;
using CreditApplication.Core.Services;

namespace CreditApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ICalculateModelService _calculateModelService;
        public HomeController(ILogger<HomeController> logger, ICalculateModelService calculateModelService)
        {
            _logger = logger;
            _calculateModelService = calculateModelService;
        }

        public IActionResult Index()
        {
            var vm = new IndexViewModel
            {
                TermTypes = _calculateModelService.GetTermType(),
                StacksTypes = _calculateModelService.GetStacksType()
            };
            return View(vm);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult Сalculate(Credit credit)
        {


            return Content($"Sum = {credit.Sum} Term = {credit.Term} TermCredit = {credit.TermCredit} Stacks = {credit.Stacks} StacksCredit = {credit.StacksCredit}");
        }
    }
}
