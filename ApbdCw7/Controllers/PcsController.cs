using ApbdCw7.DTOs;
using ApbdCw7.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApbdCw7.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PcsController : ControllerBase
{
    private readonly IPcService _pcService;

    public PcsController(IPcService pcService)
    {
        _pcService = pcService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var pcs = await _pcService.GetAllPcsAsync();
        return Ok(pcs);
    }

    [HttpGet("{id}/components")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _pcService.GetPcWithComponentsAsync(id);
        if (result == null)
            return NotFound();

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] PcRequestDto request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var created = await _pcService.CreatePcAsync(request);
        return Created($"api/pcs/{created.Id}", created);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] PcRequestDto request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var success = await _pcService.UpdatePcAsync(id, request);
        if (!success)
            return NotFound();

        return Ok(request);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var success = await _pcService.DeletePcAsync(id);
        if (!success)
            return NotFound();

        return NoContent();
    }
}