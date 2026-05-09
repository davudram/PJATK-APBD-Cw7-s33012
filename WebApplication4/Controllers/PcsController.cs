using Microsoft.AspNetCore.Mvc;
using WebApplication4.DTOs;
using WebApplication4.Exceptions;
using WebApplication4.Services;

namespace WebApplication4.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PcsController(IPcsService service) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken ct)
    {
        try
        {
            return Ok(await service.GetPcs(ct));
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
    }
    
    [HttpGet]
    [Route("{id:int}/components")]
    public async Task<IActionResult> GetById([FromRoute]int id, CancellationToken ct)
    {
        try
        {
            return Ok(await service.GetPcComponents(id, ct));
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
    }
    
    [HttpPost]
    public async Task<IActionResult> Add([FromBody]CreatePcsRequest request, CancellationToken ct)
    {
        try
        {
            var createdPc = await service.CreatePcs(request, ct);
            return Created($"api/pcs/{createdPc.Id}", createdPc);
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
    }
    
    [HttpPut]
    [Route("{id:int}")]
    public async Task<IActionResult> Update([FromRoute]int id, [FromBody]UpdatePcsRequest request, CancellationToken ct)
    {
        try
        {
            await service.UpdatePcs(id, request, ct);
            return NoContent();
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
    }
    
    [HttpDelete]
    [Route("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute]int id, CancellationToken ct)
    {
        try
        {
            await service.DeletePcs(id, ct);
            return NoContent();
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
    }
}