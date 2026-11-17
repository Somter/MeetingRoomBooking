using backend.DTOs;
using backend.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ResourceController : ControllerBase
{
    private readonly IResourceService _resourceService;

    public ResourceController(IResourceService resourceService)
    {
        _resourceService = resourceService;
    }

    [HttpGet]
    public async Task<ActionResult<List<ResourceDto>>> GetAll()
    {
        var resources = await _resourceService.GetAllResourcesAsync();
        return Ok(resources);
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<ResourceDto>> Create([FromBody] CreateResourceDto dto)
    {
        var resource = await _resourceService.CreateResourceAsync(dto);
        return Ok(resource);
    }

    [HttpGet("{id}/slots")]
    public async Task<ActionResult<List<SlotDto>>> GetSlots(int id)
    {
        var slots = await _resourceService.GetResourceSlotsAsync(id);
        return Ok(slots);
    }

    [HttpPost("{id}/slots/generate")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GenerateSlots(int id, [FromQuery] DateTime date)
    {
        try
        {
            await _resourceService.GenerateSlotsForResourceAsync(id, date);
            return Ok(new { message = "Slots generated successfully." });
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }
}