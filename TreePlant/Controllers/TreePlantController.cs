using Microsoft.AspNetCore.Mvc;
using TreePlant.Api.Helpers;
using TreePlant.Domain.ServiceInterfaces;
using TreePlant.Services.ServiceModels;
using TreePlant.Services.Services;

namespace TreePlant.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public sealed class TreePlantController : ControllerBase
    {
        private readonly IPlantTreeService _plantTreeService;

        public TreePlantController(IPlantTreeService plantTreeService)
        {
            _plantTreeService = plantTreeService;
        }

        /// <summary>
        /// Method to plant a tree in area
        /// It will be saved in planted tree table in db.
        /// </summary>
        [HttpPost("plant_tree")]
        public async Task<IActionResult> PlantTreeAsync(TreePlantModel tree)
        {
            return await _plantTreeService.PlantTreeAsync(tree) ? Ok(ResponseMessages.PlantSuccess) : BadRequest(ResponseMessages.PlantFail);
        }
    }
}
