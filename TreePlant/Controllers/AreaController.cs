using Microsoft.AspNetCore.Mvc;
using TreePlant.Api.Helpers;
using TreePlant.Domain.ServiceInterfaces;
using TreePlant.Services.ServiceModels;

namespace TreePlant.Api.Controllers;

[ApiController]
[Route("[controller]")]
public sealed class AreaController : ControllerBase
{
    private readonly IAreaService _areaService;

    public AreaController(IAreaService areaService)
    {
        _areaService = areaService;
    }

    /// <summary>
    /// Http post method to create a new area entity in db.
    /// </summary>
    [HttpPost("add_area")]
    public async Task<IActionResult> AddAreaAsync(AreaCreate area)
    {
        return await _areaService.AddAreaAsync(area) ? Ok(ResponseMessages.AreaSuccess) : BadRequest(ResponseMessages.AreaFail);
    }

    /// <summary>
    /// Http get method to get an area from db by area id.
    /// </summary>
    [HttpGet("get_by_id/{id}")]
    public async Task<IActionResult> GetAreaByIdAsync(int id)
    {
        var response = await _areaService.GetAreaByIdAsync(id);
        if(response == null)
        {
            return NotFound();
        }
        return Ok(response);
    }

    [HttpGet("get_all")]
    public async Task<IActionResult> GetAllAreasAsync()
    {
        var response = await _areaService.GetAllAreasAsync();
        if(response == null)
        {
            return NotFound();
        }
        return Ok(response);
    }
}
