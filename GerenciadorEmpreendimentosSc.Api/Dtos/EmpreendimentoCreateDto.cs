using System.ComponentModel.DataAnnotations;
using GerenciadorEmpreendimentosSc.Api.Models;

namespace GerenciadorEmpreendimentosSc.Api.Dtos;

public sealed class EmpreendimentoCreateDto
{
    [Required, MinLength(2), MaxLength(120)]
    public string NomeEmpreendimento { get; set; } = default!;

    [Required, MinLength(2), MaxLength(120)]
    public string NomeEmpreendedor { get; set; } = default!;

    [Required, MinLength(2), MaxLength(80)]
    public string Municipio { get; set; } = default!;

    [Required]
    public Segmento Segmento { get; set; }

    [Required, MinLength(8), MaxLength(20)]
    [RegularExpression(@"^[0-9\-\+\(\)\s]{8,20}$", ErrorMessage = "Telefone inválido. Use apenas números e separadores ((), -, +, espaço).")]
    public string Telefone { get; set; } = default!;

    public StatusEmpreendimento Status { get; set; } = StatusEmpreendimento.Ativo;
}