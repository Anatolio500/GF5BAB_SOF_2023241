using GF5BAB_SOF_2023241_Webapp.Data;
using GF5BAB_SOF_2023241_Webapp.Logic;
using GF5BAB_SOF_2023241_Webapp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GF5BAB_SOF_2023241_Webapp.Controllers
{
    public class PartController : Controller
    {
        private readonly PartLogic _partLogic;

        public PartController(PartLogic partLogic)
        {
            _partLogic = partLogic;
        }

        [Authorize]
        public IActionResult Index()
        {
            return View("../Part/ListParts", _partLogic.GetPartsList());
        }

        [Authorize(Roles = "Engineer,Teamprincipal,Admin")]
        public IActionResult ListParts()
        {
            return View(_partLogic.GetPartsList());
        }

        [Authorize(Roles = "Engineer,Admin")]
        public IActionResult AddPart()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Engineer,Admin")]
        public async Task<IActionResult> AddPart(Part part)
        {
            if (!_partLogic.PartExists(part))
            {
                _partLogic.AddPart(part, this);
                TempData["SuccessMessage"] = "Item created successfully!";
                return RedirectToAction(nameof(ListParts));
            }
            else
            {
                TempData["WarningMessage"] = "Item already exist!";
                return RedirectToAction(nameof(AddPart));
            }
        }

        [Authorize(Roles = "Engineer,Admin")]
        public IActionResult DeletePart(string uid)
        {
            _partLogic.DeletePart(uid, this);
            TempData["DeleteSuccessMessage"] = "Item deleted successfully!";
            return RedirectToAction(nameof(ListParts));
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
