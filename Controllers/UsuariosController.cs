
using Actividad_6.Data;
using Actividad_6.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Actividad_6.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class UsuariosController : ControllerBase
{
    private readonly AppDbContext _context;

    public UsuariosController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> ObtenerTodos()
    {
        var usuarios = await _context.Usuarios
            .AsNoTracking()
            .Select(u => new
            {
                u.IdUsuario,
                u.IdRol,
                u.NombreUsuario,
                u.Correo,
                u.Estado,
                u.FechaCreacion
            })
            .ToListAsync();

        return Ok(usuarios);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> ObtenerPorId(int id)
    {
        var usuario = await _context.Usuarios
            .AsNoTracking()
            .Where(u => u.IdUsuario == id)
            .Select(u => new
            {
                u.IdUsuario,
                u.IdRol,
                u.NombreUsuario,
                u.Correo,
                u.Estado,
                u.FechaCreacion
            })
            .FirstOrDefaultAsync();

        if (usuario == null)
            return NotFound(new { mensaje = "Usuario no encontrado" });

        return Ok(usuario);
    }

    [HttpPost]
    public async Task<IActionResult> Crear(Usuario usuario)
    {
        _context.Usuarios.Add(usuario);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(ObtenerPorId),
            new { id = usuario.IdUsuario },
            new
            {
                usuario.IdUsuario,
                usuario.IdRol,
                usuario.NombreUsuario,
                usuario.Correo,
                usuario.Estado,
                usuario.FechaCreacion
            });
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Actualizar(int id, Usuario usuario)
    {
        if (id != usuario.IdUsuario)
            return BadRequest(new { mensaje = "Los identificadores no coinciden" });

        var usuarioExistente = await _context.Usuarios.FindAsync(id);

        if (usuarioExistente == null)
            return NotFound(new { mensaje = "Usuario no encontrado" });

        usuarioExistente.IdRol = usuario.IdRol;
        usuarioExistente.NombreUsuario = usuario.NombreUsuario;
        usuarioExistente.Correo = usuario.Correo;
        usuarioExistente.Estado = usuario.Estado;

        if (!string.IsNullOrWhiteSpace(usuario.ContrasenaHash))
            usuarioExistente.ContrasenaHash = usuario.ContrasenaHash;

        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Eliminar(int id)
    {
        var usuario = await _context.Usuarios.FindAsync(id);

        if (usuario == null)
            return NotFound(new { mensaje = "Usuario no encontrado" });

        usuario.Estado = "inactivo";

        await _context.SaveChangesAsync();

        return Ok(new { mensaje = "Usuario desactivado correctamente" });
    }
}
