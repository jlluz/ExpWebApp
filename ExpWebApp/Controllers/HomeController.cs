using System;
using System.Diagnostics;

using ExpWebApp.Models;

using Microsoft.AspNetCore.Mvc;

namespace ExpWebApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ValidateForm(ValidateModel frm)
        {
            if (ModelState.IsValid)
            {
                var calcController = new CalculateController();

                ActionResult content = calcController.CalcDate(frm.myDate, frm.myDays);

                return content;

            }

            return View("Index");

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}

