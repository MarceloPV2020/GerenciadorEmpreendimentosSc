using GerenciadorEmpreendimentosSc.Api.Data;
using GerenciadorEmpreendimentosSc.Api.Dtos;
using GerenciadorEmpreendimentosSc.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorEmpreendimentosSc.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class EmpreendimentosController : ControllerBase
{
    private readonly AppDbContext _context;

    public EmpreendimentosController(AppDbContext context) => _context = context;

    // POST
    [HttpPost]
    [ProducesResponseType(typeof(EmpreendimentoReadDto), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<EmpreendimentoReadDto>> Create([FromBody] EmpreendimentoCreateDto dto, CancellationToken ct)
    {
        var entity = new Empreendimento
        {
            NomeEmpreendimento = dto.NomeEmpreendimento.Trim(),
            NomeEmpreendedor = dto.NomeEmpreendedor.Trim(),
            Municipio = dto.Municipio.Trim(),
            Segmento = dto.Segmento,
            Telefone = dto.Telefone.Trim(),
            Status = dto.Status,
            CreatedAt = DateTimeOffset.UtcNow,
            UpdatedAt = DateTimeOffset.UtcNow
        };

        _context.Empreendimentos.Add(entity);
        await _context.SaveChangesAsync(ct);

        return CreatedAtAction(nameof(GetById), new { id = entity.Id }, ToReadDto(entity));
    }

    // GET lista com filtros
    // Ex: /api/empreendimentos?municipio=Joinville&segmento=Tecnologia&status=Ativo
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<EmpreendimentoReadDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<EmpreendimentoReadDto>>> GetAll(
        [FromQuery] string? municipio,
        [FromQuery] Segmento? segmento,
        [FromQuery] StatusEmpreendimento? status,
        CancellationToken ct)
    {
        IQueryable<Empreendimento> q = _context.Empreendimentos.AsNoTracking();

        if (!string.IsNullOrWhiteSpace(municipio))
        {
            var m = municipio.Trim().ToLowerInvariant();
            q = q.Where(x => x.Municipio.ToLower() == m);
        }

        if (segmento.HasValue)
            q = q.Where(x => x.Segmento == segmento.Value);

        if (status.HasValue)
            q = q.Where(x => x.Status == status.Value);

        var list = await q
            .OrderBy(x => x.NomeEmpreendimento)
            .Select(e => ToReadDto(e))
            .ToListAsync(ct);

        return Ok(list);
    }

    // GET por id
    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(EmpreendimentoReadDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<EmpreendimentoReadDto>> GetById(Guid id, CancellationToken ct)
    {
        var entity = await _context.Empreendimentos.AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id, ct);

        if (entity is null)
        {
            return NotFound(new ProblemDetails
            {
                Title = "Não encontrado",
                Detail = $"Empreendimento '{id}' não existe.",
                Status = StatusCodes.Status404NotFound
            });
        }

        return Ok(ToReadDto(entity));
    }

    // PUT
    [HttpPut("{id:guid}")]
    [ProducesResponseType(typeof(EmpreendimentoReadDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<EmpreendimentoReadDto>> Update(Guid id, [FromBody] EmpreendimentoUpdateDto dto, CancellationToken ct)
    {
        var entity = await _context.Empreendimentos.FirstOrDefaultAsync(x => x.Id == id, ct);

        if (entity is null)
        {
            return NotFound(new ProblemDetails
            {
                Title = "Não encontrado",
                Detail = $"Empreendimento '{id}' não existe.",
                Status = StatusCodes.Status404NotFound
            });
        }

        entity.NomeEmpreendimento = dto.NomeEmpreendimento.Trim();
        entity.NomeEmpreendedor = dto.NomeEmpreendedor.Trim();
        entity.Municipio = dto.Municipio.Trim();
        entity.Segmento = dto.Segmento;
        entity.Telefone = dto.Telefone.Trim();
        entity.Status = dto.Status;

        await _context.SaveChangesAsync(ct);

        return Ok(ToReadDto(entity));
    }

    // DELETE
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(Guid id, CancellationToken ct)
    {
        var entity = await _context.Empreendimentos.FirstOrDefaultAsync(x => x.Id == id, ct);

        if (entity is null)
        {
            return NotFound(new ProblemDetails
            {
                Title = "Não encontrado",
                Detail = $"Empreendimento '{id}' não existe.",
                Status = StatusCodes.Status404NotFound
            });
        }

        _context.Empreendimentos.Remove(entity);
        await _context.SaveChangesAsync(ct);

        return NoContent();
    }

    private static EmpreendimentoReadDto ToReadDto(Empreendimento e) => new(
        e.Id,
        e.NomeEmpreendimento,
        e.NomeEmpreendedor,
        e.Municipio,
        e.Segmento,
        e.Telefone,
        e.Status,
        e.CreatedAt,
        e.UpdatedAt
    );
}