using GF5BAB_SOF_2023241_Webapp.Logic;
using GF5BAB_SOF_2023241_Webapp.Models;
using Microsoft.AspNetCore.Mvc;

namespace GF5BAB_SOF_2023241_Webapp.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class ApiController : ControllerBase
    {
        IPartLogic _partLogic;

        public ApiController(IPartLogic partLogic)
        {
            _partLogic = partLogic;
        }

        [HttpGet]
        public IEnumerable<Part> Get()
        {
            return this._partLogic.GetParts();
        }
    }
}
