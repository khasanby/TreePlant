using Microsoft.AspNetCore.Mvc;
using TreePlant.Api.Helpers;
using TreePlant.Domain.ServiceInterfaces;
using TreePlant.Services.ServiceModels;

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

        /// <summary>
        /// Gets all planted trees from PlantedTrees table.
        /// </summary>
        [HttpGet("get_all")]
        public async Task<IActionResult> GetPlantedTreesAsync()
        {
            var plantedTrees = await _plantTreeService.GetPlantedTreesAsync();
            return plantedTrees != null ? Ok(plantedTrees) : NotFound(ResponseMessages.NoTreeFound);
        }

        /// <summary>
        /// Gets all planted trees from PlantedTrees table.
        /// </summary>
        [HttpGet("get_all_in_area/{id}")]
        public async Task<IActionResult> GetPlantedTreesInAreaAsync(int id)
        {
            var plantedTrees = await _plantTreeService.GetPlantedTreesInArea(id);
            return plantedTrees != null ? Ok(plantedTrees) : NotFound(ResponseMessages.NoTreeFound);
        }
    }
}
