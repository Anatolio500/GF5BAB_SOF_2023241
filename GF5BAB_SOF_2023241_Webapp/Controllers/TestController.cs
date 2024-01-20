using GF5BAB_SOF_2023241_Webapp.Data;
using GF5BAB_SOF_2023241_Webapp.Logic;
using GF5BAB_SOF_2023241_Webapp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GF5BAB_SOF_2023241_Webapp.Controllers
{
    public class TestController : Controller
    {
        private readonly TestLogic _testLogic;

        public TestController(TestLogic testLogic)
        {
            _testLogic = testLogic;
        }

        [Authorize]
        public IActionResult Index()
        {
            return View("../Test/ListTests", _testLogic.GetTests());
        }

        [Authorize(Roles = "Driver,Teamprincipal,Admin")]
        public IActionResult ListTests()
        {
            return View(_testLogic.GetTests());
        }

        [Authorize(Roles = "Driver,Admin")]
        public IActionResult AddTest()
        {
            return View();
        }

        
        [HttpPost]
        [Authorize(Roles = "Driver,Admin")]
        public async Task<IActionResult> AddTest(Test test)
        {
            
            if (!_testLogic.TestExists(test))
            {
                _testLogic.AddTest(test, this);
                TempData["SuccessMessage"] = "Item created successfully!";
                return RedirectToAction(nameof(ListTests));
            }
            else
            {
                TempData["WarningMessage"] = "Item already exist!";
                return RedirectToAction(nameof(AddTest));
            }
        }

        [Authorize(Roles = "Driver,Admin")]
        public IActionResult DeleteTest(string uid)
        {
            _testLogic.DeleteTest(uid, this);
            TempData["DeleteSuccessMessage"] = "Item deleted successfully!";
            return RedirectToAction(nameof(ListTests));
        }

        [HttpPost]
        public IActionResult ResetSuccessMessage()
        {
            TempData["SuccessMessage"] = null;
            return Ok();
        }

        [HttpPost]
        public IActionResult ResetDeleteSuccessMessage()
        {
            TempData["DeleteSuccessMessage"] = null;
            return Ok();
        }

        [HttpPost]
        public IActionResult ResetWarningMessage()
        {
            TempData["WarningMessage"] = null;
            return Ok();
        }
    }
}
