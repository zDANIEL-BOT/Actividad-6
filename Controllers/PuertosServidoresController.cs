
using Actividad_6.Data;
using Actividad_6.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Actividad_6.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class PuertosServidoresController : ControllerBase
{
    private readonly AppDbContext _context;

    public PuertosServidoresController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> ObtenerTodos()
    {
        var puertos = await _context.PuertosServidores
            .AsNoTracking()
            .ToListAsync();

        return Ok(puertos);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> ObtenerPorId(int id)
    {
        var puerto = await _context.PuertosServidores
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.IdPuerto == id);

        if (puerto == null)
            return NotFound(new { mensaje = "Puerto no encontrado" });

        return Ok(puerto);
    }

    [HttpPost]
    public async Task<IActionResult> Crear(PuertoServidor puerto)
    {
        _context.PuertosServidores.Add(puerto);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(ObtenerPorId),
            new { id = puerto.IdPuerto },
            puerto);
    }

    //PUT
    [HttpPut("{id}")]
    public async Task<IActionResult> Actualizar(int id, PuertoServidor puerto)
    {
        if (id != puerto.IdPuerto)
            return BadRequest(new { mensaje = "Los identificadores no coinciden" });

        var puertoExistente = await _context.PuertosServidores.FindAsync(id);

        if (puertoExistente == null)
            return NotFound(new { mensaje = "Puerto no encontrado" });

        puertoExistente.IdServidor = puerto.IdServidor;
        puertoExistente.PuertoHost = puerto.PuertoHost;
        puertoExistente.PuertoContenedor = puerto.PuertoContenedor;
        puertoExistente.Activo = puerto.Activo;

        await _context.SaveChangesAsync();

        return NoContent();
    }

    //DELETE
    [HttpDelete("{id}")]
    public async Task<IActionResult> Eliminar(int id)
    {
        var puerto = await _context.PuertosServidores.FindAsync(id);

        if (puerto == null)
            return NotFound(new { mensaje = "Puerto no encontrado" });

        puerto.Activo = false;

        await _context.SaveChangesAsync();

        return Ok(new { mensaje = "Puerto desactivado correctamente" });
    }
}