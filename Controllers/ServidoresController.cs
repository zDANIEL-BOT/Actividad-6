using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Actividad_6.Data;
using Actividad_6.Models;

namespace Actividad_6.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class ServidoresController : ControllerBase
{
    //manitos ded
    private readonly AppDbContext _context;
    public ServidoresController(AppDbContext context) => _context = context;

    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await _context.Servidores.ToListAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var item = await _context.Servidores.FindAsync(id);
        return item == null ? NotFound() : Ok(item);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Servidor servidor)
    {
        servidor.FechaCreacion = DateTime.UtcNow;
        _context.Servidores.Add(servidor);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { id = servidor.IdServidor }, servidor);
    }
}