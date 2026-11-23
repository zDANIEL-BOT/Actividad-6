using Actividad_6.Data;
using Actividad_6.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Actividad_6.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class EventosServidoresController : ControllerBase
{
    private readonly AppDbContext _context;

    public EventosServidoresController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> ObtenerTodos()
    {
        var eventos = await _context.EventosServidores
            .AsNoTracking()
            .ToListAsync();

        return Ok(eventos);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> ObtenerPorId(int id)
    {
        var evento = await _context.EventosServidores
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.IdEvento == id);

        if (evento == null)
            return NotFound(new { mensaje = "Evento no encontrado" });

        return Ok(evento);
    }

    [HttpPost]
    public async Task<IActionResult> Crear(EventoServidor evento)
    {
        _context.EventosServidores.Add(evento);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(ObtenerPorId),
            new { id = evento.IdEvento },
            evento);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Actualizar(int id, EventoServidor evento)
    {
        if (id != evento.IdEvento)
            return BadRequest(new { mensaje = "Los identificadores no coinciden" });

        var eventoExistente = await _context.EventosServidores.FindAsync(id);

        if (eventoExistente == null)
            return NotFound(new { mensaje = "Evento no encontrado" });

        eventoExistente.IdServidor = evento.IdServidor;
        eventoExistente.IdUsuario = evento.IdUsuario;
        eventoExistente.TipoEvento = evento.TipoEvento;
        eventoExistente.Resultado = evento.Resultado;
        eventoExistente.Detalles = evento.Detalles;
        eventoExistente.Fecha = evento.Fecha;

        await _context.SaveChangesAsync();

        return NoContent();
    }
}