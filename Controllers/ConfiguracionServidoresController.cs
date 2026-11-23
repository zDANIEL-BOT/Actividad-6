using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Actividad_6.Data;
using Actividad_6.Models;

namespace Actividad_6.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class ConfiguracionServidoresController : ControllerBase
{
    private readonly AppDbContext _context;
    public ConfiguracionServidoresController(AppDbContext context) => _context = context;

    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await _context.ConfiguracionServidores.ToListAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var item = await _context.ConfiguracionServidores.FindAsync(id);
        return item == null ? NotFound() : Ok(item);
    }

    [HttpPost]
    public async Task<IActionResult> Create(ConfiguracionServidor config)
    {
        _context.ConfiguracionServidores.Add(config);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { id = config.IdServidor }, config);
    }
}