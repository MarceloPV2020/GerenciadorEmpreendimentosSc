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

    [HttpPost]
    [ProducesResponseType(typeof(EmpreendimentoReadDto), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<EmpreendimentoReadDto>> Inserir([FromServices] EmpreendimentoCreateDto.Validator validator, [FromBody] EmpreendimentoCreateDto dto, CancellationToken cancellationToken)
    {
        var resultadoValidacao = await validator.ValidateAsync(dto, cancellationToken);
        if (!resultadoValidacao.IsValid)
        {
            return Problem(detail: resultadoValidacao.ToString(), statusCode: StatusCodes.Status400BadRequest);
        }

        var empreendimento =
            new Empreendimento
            {
                NomeEmpreendimento = dto.NomeEmpreendimento.Trim(),
                NomeEmpreendedor = dto.NomeEmpreendedor.Trim(),
                Municipio = dto.Municipio.Trim(),
                Segmento = dto.Segmento,
                Telefone = dto.Telefone.Trim(),
                Status = dto.Status,
                Criado = DateTimeOffset.UtcNow,
                Atualizado = DateTimeOffset.UtcNow
            };
        _context.Empreendimentos.Add(empreendimento);
        await _context.SaveChangesAsync(cancellationToken);

        return CreatedAtAction(nameof(SelecionarPorId), new { id = empreendimento.Id }, CopiarParaDto(empreendimento));
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(typeof(EmpreendimentoReadDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<EmpreendimentoReadDto>> Editar(Guid id, [FromServices] EmpreendimentoUpdateDto.Validator validator, [FromBody] EmpreendimentoUpdateDto dto, CancellationToken cancellationToken)
    {
        var resultadoValidacao = await validator.ValidateAsync(dto, cancellationToken);
        if (!resultadoValidacao.IsValid)
        {
            return Problem(detail: resultadoValidacao.ToString(), statusCode: StatusCodes.Status400BadRequest);
        }

        var empreendimento = await _context.Empreendimentos.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        if (empreendimento is null)
        {
            return
                NotFound(new ProblemDetails
                {
                    Title = "Não encontrado",
                    Detail = $"Empreendimento '{id}' não existe.",
                    Status = StatusCodes.Status404NotFound
                });
        }

        empreendimento.NomeEmpreendimento = dto.NomeEmpreendimento.Trim();
        empreendimento.NomeEmpreendedor = dto.NomeEmpreendedor.Trim();
        empreendimento.Municipio = dto.Municipio.Trim();
        empreendimento.Segmento = dto.Segmento;
        empreendimento.Telefone = dto.Telefone.Trim();
        empreendimento.Status = dto.Status;
        await _context.SaveChangesAsync(cancellationToken);
        return Ok(CopiarParaDto(empreendimento));
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Excluir(Guid id, CancellationToken cancellationToken)
    {
        var empreendimento = await _context.Empreendimentos.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        if (empreendimento is null)
        {
            return
                NotFound(new ProblemDetails
                {
                    Title = "Não encontrado",
                    Detail = $"Empreendimento '{id}' não existe.",
                    Status = StatusCodes.Status404NotFound
                });
        }

        _context.Empreendimentos.Remove(empreendimento);
        await _context.SaveChangesAsync(cancellationToken);
        return NoContent();
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<EmpreendimentoReadDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<EmpreendimentoReadDto>>> SelecionarTodos([FromQuery] string? municipio, [FromQuery] Segmento? segmento, [FromQuery] StatusEmpreendimento? status, CancellationToken cancellationToken)
    {
        IQueryable<Empreendimento> query = _context.Empreendimentos.AsNoTracking();
        if (!string.IsNullOrWhiteSpace(municipio))
        {
            var m = municipio.Trim().ToLowerInvariant();
            query = query.Where(x => x.Municipio.ToLower() == m);
        }

        if (segmento.HasValue)
        {
            query = query.Where(x => x.Segmento == segmento.Value);
        }

        if (status.HasValue)
        {
            query = query.Where(x => x.Status == status.Value);
        }

        var list = await query
            .OrderBy(x => x.NomeEmpreendimento)
            .Select(e => CopiarParaDto(e))
            .ToListAsync(cancellationToken);
        return Ok(list);
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(EmpreendimentoReadDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<EmpreendimentoReadDto>> SelecionarPorId(Guid id, CancellationToken ct)
    {
        var empreendimento = await _context.Empreendimentos.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id, ct);
        if (empreendimento is null)
        {
            return
                NotFound(new ProblemDetails
                {
                    Title = "Não encontrado",
                    Detail = $"Empreendimento '{id}' não existe.",
                    Status = StatusCodes.Status404NotFound
                });
        }

        return Ok(CopiarParaDto(empreendimento));
    }

    private static EmpreendimentoReadDto CopiarParaDto(Empreendimento e) => new(
        e.Id,
        e.NomeEmpreendimento,
        e.NomeEmpreendedor,
        e.Municipio,
        e.Segmento,
        e.Telefone,
        e.Status,
        e.Criado,
        e.Atualizado
    );
}