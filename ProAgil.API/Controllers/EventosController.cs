using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProAgil.API.Data;
using ProAgil.API.Model;

namespace ProAgil.API.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class EventosController : ControllerBase
  {
    public DataContext _context { get; }
    public EventosController(DataContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
      try
      {
          var results = await _context.Eventos.ToListAsync();
          return Ok(results); // Retorna status 200
      }
      catch (System.Exception ex)
      {
          return this.StatusCode(StatusCodes.Status500InternalServerError, $"Falha no banco de dados: {ex.Message}");
      }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
      try
      {
          var results = await _context.Eventos.FirstOrDefaultAsync(x => x.EventoId == id);
          return Ok(results); // Retorna status 200
      }
      catch (System.Exception ex)
      {
          return this.StatusCode(StatusCodes.Status500InternalServerError, $"Falha no banco de dados: {ex.Message}");
      }
    }
  }
}
