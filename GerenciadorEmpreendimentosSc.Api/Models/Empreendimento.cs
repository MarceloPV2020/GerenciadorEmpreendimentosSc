using System.ComponentModel.DataAnnotations;

namespace GerenciadorEmpreendimentosSc.Api.Models;

public sealed class Empreendimento
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required, MinLength(2), MaxLength(120)]
    public string NomeEmpreendimento { get; set; } = default!;

    [Required, MinLength(2), MaxLength(120)]
    public string NomeEmpreendedor { get; set; } = default!;

    [Required, MinLength(2), MaxLength(80)]
    public string Municipio { get; set; } = default!;

    [Required]
    public Segmento Segmento { get; set; }

    // Somente telefone
    [Required, Phone, MinLength(8), MaxLength(20)]
    public string Telefone { get; set; } = default!;

    [Required]
    public StatusEmpreendimento Status { get; set; } = StatusEmpreendimento.Ativo;

    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
    public DateTimeOffset UpdatedAt { get; set; } = DateTimeOffset.UtcNow;
}