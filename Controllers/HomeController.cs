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
using System.Text;

namespace CreditApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ICalculateModelService _calculateModelService;
        private ICalculateService _calculateService;        

        public HomeController(ILogger<HomeController> logger, ICalculateModelService calculateModelService, ICalculateService calculateService)
        {
            _logger = logger;
            _calculateModelService = calculateModelService;
            _calculateService = calculateService;

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
        public IActionResult Сalculate()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Сalculate(Credit credit)
        {
            var creditResults = _calculateService.GetCreditResult(credit);
            return View(creditResults);
        }

       

        public IActionResult Result(IEnumerable<CreditResult> creditResults)
        {
            if (creditResults == null)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();            
        }
    }
}
