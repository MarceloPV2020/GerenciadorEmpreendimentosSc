using System.ComponentModel.DataAnnotations;

namespace GerenciadorEmpreendimentosSc.Api.Models;

public sealed class Empreendimento
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    public string NomeEmpreendimento { get; set; } = default!;
    public string NomeEmpreendedor { get; set; } = default!;
    public string Municipio { get; set; } = default!;
    public Segmento Segmento { get; set; }
    public string Telefone { get; set; } = default!;
    public StatusEmpreendimento Status { get; set; } = StatusEmpreendimento.Ativo;
    public DateTimeOffset Criado { get; set; } = DateTimeOffset.UtcNow;
    public DateTimeOffset Atualizado { get; set; } = DateTimeOffset.UtcNow;
}