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
            return View("../Part/ListParts", _partLogic.GetParts());
        }

        [Authorize(Roles = "Engineer,Teamprincipal,Admin")]
        public IActionResult ListParts()
        {
            return View(_partLogic.GetParts());
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
            /*part.EngineerId = _userManager.GetUserId(this.User);
            var old = _db.Parts.FirstOrDefault(t => t.SerialNumber == part.SerialNumber && t.EngineerId == part.EngineerId);
            if (old == null)
            {
                _db.Parts.Add(part);
                _db.SaveChanges();
                TempData["SuccessMessage"] = "Item created successfully!";
                return RedirectToAction(nameof(ListParts));
            }
            else
            {
                TempData["WarningMessage"] = "Item already exist!";
                return RedirectToAction(nameof(AddPart));
            }*/
            if (part.Name.Length > 30 || part.Width > 99999 || part.Heigth > 99999 || part.SerialNumber.Length > 15)
            {
                TempData["WarningMessage"] = "Some fileds are not right.";
                return View(part);
            }

            var success = await _partLogic.AddPart(part, this);
            if (success)
            {
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
        public async Task<IActionResult> DeletePart(string uid)
        {
            /*var item = _db.Parts.FirstOrDefault(t => t.Uid == uid);
            if (item != null && item.EngineerId == _userManager.GetUserId(this.User))
            {
                _db.Parts.Remove(item);
                _db.SaveChanges();
            }
            TempData["DeleteSuccessMessage"] = "Item deleted successfully!";
            return RedirectToAction(nameof(ListParts));*/

            var success = await _partLogic.DeletePart(uid);
            if (success)
            {
                TempData["DeleteSuccessMessage"] = "Item deleted successfully!";
                return RedirectToAction(nameof(ListParts));
            }
            else
            {
                TempData["DeleteSuccessMessage"] = "Item deleted unsuccessfully!";
                return RedirectToAction(nameof(ListParts));
            }
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
