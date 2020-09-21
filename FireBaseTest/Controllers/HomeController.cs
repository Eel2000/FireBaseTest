using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FireBaseTest.Models;
using FireBaseTest.Services.Interfaces;

namespace FireBaseTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMainService _mainService;

        public HomeController(IMainService mainService)
        {
            _mainService = mainService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Student student)
        {
            try
            {
                _mainService.AddNew(student);
                ModelState.AddModelError(String.Empty, "Student Added Successfuly");
            }
            catch (Exception)
            {

                ModelState.AddModelError(String.Empty, "Student Not Added 'Cause an Error Occure While Operating");
            }

            return View();
        }

        [HttpGet]
        public IActionResult List()
        {
            var students = _mainService.GetAllStudents();
            return View(students);
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
    }
}
