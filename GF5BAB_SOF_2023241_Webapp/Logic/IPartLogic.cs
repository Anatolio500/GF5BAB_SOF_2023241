using GF5BAB_SOF_2023241_Webapp.Models;
using Microsoft.AspNetCore.Mvc;

namespace GF5BAB_SOF_2023241_Webapp.Logic
{
    public interface IPartLogic
    {
        Task<bool> AddPart(Part part, ControllerBase controller);
        Task<bool> DeletePart(string uid);
        IEnumerable<Part> GetParts();
    }
}