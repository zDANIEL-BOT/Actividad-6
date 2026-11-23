using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Actividad_6.Data;
using Actividad_6.Models;

namespace Actividad_6.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class VersionJuegosController : ControllerBase
{
    private readonly AppDbContext _context;
    public VersionJuegosController(AppDbContext context) => _context = context;

    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await _context.VersionJuegos.ToListAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var item = await _context.VersionJuegos.FindAsync(id);
        return item == null ? NotFound() : Ok(item);
    }

    [HttpPost]
    public async Task<IActionResult> Create(VersionJuego version)
    {
        _context.VersionJuegos.Add(version);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { id = version.IdVersion }, version);
    }
}